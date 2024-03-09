using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    [CreateAssetMenu(menuName = "Card System/Card", fileName = "New Card")]
    public class Card : CardBase
    {
        public List<CardAction> listOfActions = new();

        // Run the script for both action lists each time to make scripts shorter.
        public void ExecuteActions(Battler t_target, Battler t_self)
        {
            if (listOfActions.Count > 0)
            {
                for (int i = 0; i < listOfActions.Count; i++)
                {
                    CardAction t_action = listOfActions[i];

                    if (t_action.target == CardAction.ActionTarget.Target)
                    {
                        t_action.PerformAction(t_target);
                    }
                    
                    if (t_action.target == CardAction.ActionTarget.Self)
                    {
                        t_action.PerformAction(t_self);
                    }
                }
            }           
        }
    }
}