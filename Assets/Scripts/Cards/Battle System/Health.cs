using UnityEngine;
using UnityEngine.Events;

namespace GBE
{
    public class Health : MonoBehaviour
    {
        #region Variables
        [Space, Header("Health Settings")]
        public int maxHealth = 50;

        // Events for convenient invoking of effects in other scripts.
        public UnityAction<int, GameObject> OnDamaged;
        public UnityAction<int> OnHealed;
        public UnityAction OnDie;

        public int CurrentHealth { get; set; }

        private bool m_isVulnerable;
        private bool m_isDead;

        private Battler m_battler;
        #endregion

        #region Built-In Methods
        private void Start()
        {
            m_battler = GetComponent<Battler>();
            CurrentHealth = maxHealth;
        }
        #endregion

        #region Custom Methods
        public void Heal(int t_amount)
        {
            int t_previousHealth = CurrentHealth;
            CurrentHealth += t_amount;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);

            // When receiving health, invoke OnHealed for related scripts.
            if (t_amount > 0)
            {
                OnHealed?.Invoke(t_amount);
            }
        }

        public void Damage(int t_amount)
        {
            // When taking damage, sort through the Battlers list of buffs and
            // look for the vulnerability status effect.
            for (int i = 0; i < m_battler.buffs.Count; i++)
            {
                if (m_battler.buffs[i].buffClass == Buff.BuffClass.Resistance)
                {
                    m_isVulnerable = true;
                    break;
                }
            }

            // If vulnerable, double the damage, otherwise deal normal damage.
            int t_previousHealth = CurrentHealth;
            CurrentHealth -= m_isVulnerable ? t_amount / 2 : t_amount;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);

            // Invoke OnDamaged for other scripts. This makes playing things like
            // damage SFX or animations easier.
            if (t_amount > 0)
            {
                OnDamaged?.Invoke(t_amount, null);
            }

            m_isVulnerable = false;
            HandleDeath();
        }

        // Method to instant kill the Battler if needed, only used through other 
        // scripts, because death state automatically happens at zero health.
        public void Kill()
        {
            CurrentHealth = 0;

            OnDamaged?.Invoke(maxHealth, null);

            HandleDeath();
        }

        private void HandleDeath()
        {
            // If death state is already achieved, prevent possible bugs.
            if (m_isDead) { return; }

            // Run each time damage is dealt, only giving the kill order once
            // health is at zero.
            if (CurrentHealth <= 0)
            {
                // Same event thing as above with healing and damage.
                m_isDead = true;
                OnDie?.Invoke();
            }
        }
        #endregion
    }
}