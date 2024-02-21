using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    [CreateAssetMenu(menuName = "Card System/Card", fileName = "New Card")]
    public class Card : CardBase
    {
        public CardAction[] m_actions;

        public void PerformActions(Battler t_target)
        {
            foreach (CardAction t_action in m_actions)
            {
                switch (t_action.cardType)
                {
                    case CardAction.CardType.Attack:
                        t_action.Attack(t_target);
                        break;
                    case CardAction.CardType.Heal:
                        break;
                    case CardAction.CardType.Buff:
                        break;
                    case CardAction.CardType.Debuff:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}