using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class Battler : MonoBehaviour
    {
        public Health m_Health;
        public BattleSceneManager m_battleSceneManager;

        public bool m_isValid = false;

        public List<Buff> buffs = null;

        private void Start()
        {
            m_battleSceneManager = FindObjectOfType<BattleSceneManager>();
            m_Health = GetComponent<Health>();
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