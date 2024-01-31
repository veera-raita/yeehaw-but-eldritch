using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    [CreateAssetMenu(menuName = "Cards/Card Action", fileName = "New Action")]
    public class CardAction : ScriptableObject
    {
        public void PerformAction(Battler t_target)
        {
            t_target.m_Health.TakeDamage(50);
        }
    }
}