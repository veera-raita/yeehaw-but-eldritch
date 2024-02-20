using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class Health : MonoBehaviour
    {
        public int maxHealth;
        public int currentHealth;

        public Battler battler;
        public HealthBar m_healthBar;

        private void Start()
        {
            currentHealth = maxHealth;

            m_healthBar.SetMaxHealth(maxHealth);

            battler = GetComponent<Battler>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                TakeDamage(Random.Range(5, 10));
        }

        public void TakeDamage(int t_amount)
        {
            currentHealth -= t_amount;

            m_healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                HandleDeath();
            }  
        }

        public void HandleDeath()
        {
            battler.m_battleSceneManager.enemyInstances.Remove(battler);
            Destroy(gameObject);
        }
    }
}