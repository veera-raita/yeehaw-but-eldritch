using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    [CreateAssetMenu(menuName = "Card System/Card Pool", fileName = "New Card Pool")]
    public class CardPool : ScriptableObject
    {
        public List<Card> cards;
    }
}