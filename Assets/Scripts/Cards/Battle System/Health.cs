using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GBE
{
    public class Health : MonoBehaviour
    {
        public int maxHealth = 50;
        public int CurrentHealth { get; set; }

        public UnityAction<int, GameObject> OnDamaged;
        public UnityAction<int> OnHealed;
        public UnityAction OnDie;

        private bool m_isVulnerable;
        private bool m_isDead;

        private Battler m_battler;

        private void Start()
        {
            m_battler = GetComponent<Battler>();

            CurrentHealth = maxHealth;
        }

        public void Heal(int t_amount)
        {
            int t_previousHealth = CurrentHealth;
            CurrentHealth += t_amount;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);

            if (t_amount > 0)
            {
                OnHealed?.Invoke(t_amount);
            }
        }

        public void TakeDamage(int t_amount)
        {
            for (int i = 0; i < m_battler.buffs.Count; i++)
            {
                if (m_battler.buffs[i].buffClass == Buff.BuffClass.Resistance)
                {
                    m_isVulnerable = true;
                    break;
                }
            }

            CurrentHealth -= m_isVulnerable ? t_amount / 2 : t_amount;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);

            if (t_amount > 0)
            {
                OnDamaged?.Invoke(t_amount, null);
            }

            m_isVulnerable = false;

            HandleDeath();
        }

        public void Kill()
        {
            CurrentHealth = 0;

            OnDamaged?.Invoke(maxHealth, null);

            HandleDeath();
        }

        private void HandleDeath()
        {
            if (m_isDead) { return; }

            if (CurrentHealth <= 0)
            {
                m_isDead = true;
                OnDie?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}