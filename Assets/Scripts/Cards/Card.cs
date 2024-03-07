using UnityEngine;

namespace GBE
{
    [CreateAssetMenu(menuName = "Card System/Card", fileName = "New Card")]

    public class Card : CardBase
    {
        public enum CardClass
        {
            Attack,
            Heal,
            Buff,
            Debuff
        }

        public CardClass cardClass;

        public CardAction[] m_actionsOnTarget;
        public CardAction[] m_actionsOnSelf;

        // Run the actions on a specified target.
        public void ExecuteActions(Battler t_target)
        {
            foreach (CardAction t_action in m_actionsOnTarget)
            {
                t_action.PerformAction(t_target);
            }
        }

        // Perform actions two sets of actions if two targets are given.
        public void ExecuteActions(Battler t_target, Battler t_self)
        {
            foreach (CardAction t_action in m_actionsOnTarget)
            {
                t_action.PerformAction(t_target);
            }

            foreach (CardAction t_action in m_actionsOnSelf)
            {
                t_action.PerformAction(t_self);
            }
        }
    }
}