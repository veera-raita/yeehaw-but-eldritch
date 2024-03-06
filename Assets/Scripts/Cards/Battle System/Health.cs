using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class Health : MonoBehaviour
    {
        public int maxHealth;
        public int currentHealth;

        public HealthBar m_healthBar;
        public Battler m_battler;


        private bool m_isVulnerable;

        private void Start()
        {
            m_battler = GetComponent<Battler>();

            currentHealth = maxHealth;
            m_healthBar.SetMaxHealth(maxHealth);
        }

        public void TakeDamage(int t_amount)
        {
            for (int i = 0; i < m_battler.buffs.Count; i++)
            {
                if (m_battler.buffs[i].buffClass == Buff.BuffClass.Resistance)
                {
                    m_isVulnerable = true;
                }
            }

            currentHealth -= m_isVulnerable ? t_amount / 2 : t_amount;
            m_isVulnerable = false;

            m_healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                HandleDeath();
            }  
        }

        public void HandleDeath()
        {
            Destroy(gameObject);
        }
    }
}