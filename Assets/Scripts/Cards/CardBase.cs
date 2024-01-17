using UnityEngine;

namespace GBE
{
    public class CardBase : ScriptableObject
    {
        public enum CardType
        {
            Attack,
            Defense,
            Disruption,
            Support
        }

        public string cardName;
        public CardType cardType;
        [TextArea(3, 6)] public string cardDescription;
    }
}