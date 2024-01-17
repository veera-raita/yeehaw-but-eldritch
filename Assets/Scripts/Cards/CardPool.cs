using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    [CreateAssetMenu(menuName = "Cards/Card Pool", fileName = "New Card Pool")]
    public class CardPool : ScriptableObject
    {
        public List<CardBase> cards;
    }
}