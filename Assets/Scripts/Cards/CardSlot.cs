using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class CardSlot : BaseCardSlot
    {
        public void LoadCard(CardBase t_card)
        {
            Card = t_card;
        }
    }
}