using UnityEngine;

namespace GBE
{
    [CreateAssetMenu(menuName = "Card System/Card", fileName = "New Card")]
    public class Card : CardBase
    {
        // For determining which Battlers will be valid targets.
        public enum CardClass
        {
            Attack,
            Heal,
            Buff,
            Debuff
        }

        public CardClass cardClass;

        // Actions separated by intended target. Self will be used only if the card
        // has additional effects i.e. attack cards that give out buffs to self.
        public CardAction[] m_actionsOnTarget;
        public CardAction[] m_actionsOnSelf;

        // Run the script for both action lists each time to make scripts shorter.
        public void ExecuteActions(Battler t_target, Battler t_self)
        {
            // If-statements just in case to avoid NullReferenceException.
            if (m_actionsOnTarget.Length > 0)
            {
                for (int i = 0; i < m_actionsOnTarget.Length; i++)
                {
                    CardAction t_action = m_actionsOnTarget[i];
                    t_action.PerformAction(t_target);
                }
            }

            if (m_actionsOnSelf.Length > 0)
            {
                for (int i = 0; i < m_actionsOnSelf.Length; i++)
                {
                    CardAction t_action = m_actionsOnSelf[i];
                    t_action.PerformAction(t_self);
                }
            }            
        }
    }
}