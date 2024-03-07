using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class Battler : MonoBehaviour
    {
        public bool m_isValid = false;

        public List<Buff> buffs = null;

        private BattleSceneManager m_battleSceneManager;
        public Health m_health;

        private void Start()
        {
            m_battleSceneManager = FindObjectOfType<BattleSceneManager>();

            m_health = GetComponent<Health>();

            m_health.OnDie += OnDie;
            m_health.OnDamaged += OnDamaged;
            
        }

        public void AddBuff(Buff.BuffClass t_class, int t_amount)
        {
            Buff t_instance = new();

            t_instance.buffClass = t_class;
            t_instance.buffValue = t_amount;

            if (buffs.Count > 0)
            {
                for (int i = 0; i < buffs.Count; i++)
                {
                    if (buffs[i].buffClass == t_instance.buffClass)
                    {
                        buffs[i].buffValue += t_amount;
                        break;
                    }

                    if (buffs[i].buffClass != t_instance.buffClass)
                    {
                        buffs.Add(t_instance);
                        break;
                    }
                }
            }
            else
            {
                buffs.Add(t_instance);
            }
        }

        public void OnDamaged(int t_amount, GameObject t_source)
        {
            // If health component invokes OnDamaged.
            if (t_source)
            {
                // Do stuff like SFX or damage animation.
            }
        }

        public void OnDie()
        {
            // Do death effects.

            Destroy(gameObject);
        }

        public void BuffAtTurnEnd()
        {
            for (int i = 0; i < buffs.Count; i++)
            {
                buffs[i].buffValue -= 1;
            }
        }

        public void PointerEnterHandler()
        {
            if (m_battleSceneManager.m_cardHandler.selectedCard != null)
            {
                m_battleSceneManager.target = this;
            }
        }

        public void PointerExitHandler()
        {
            m_battleSceneManager.target = null;
        }

        public void SetValidTarget()
        {
            m_isValid = true;
        }
    }
}