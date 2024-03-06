using System.Collections;
using System.Collections.Generic;
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

        public void Execute(Battler t_target)
        {
            foreach (CardAction t_action in m_actionsOnTarget)
            {
                t_action.PerformAction(t_target);
            }
        }

        public void Execute(Battler t_target, Battler t_self)
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