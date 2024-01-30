using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class CardSlot : BaseCardSlot
    {
        public void LoadCard(Card t_card)
        {
            Card = t_card;
        }
    }
}