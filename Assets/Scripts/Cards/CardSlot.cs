using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GBE
{
    public class CardSlot : MonoBehaviour
    {
        public CardController controller;

        public Card m_card;

        private void Awake()
        {
            
        }

        public void LoadCard(Card t_card)
        {
            m_card = t_card;
        }

        public void SelectCard()
        {
            controller.selectedCard = this;
        }

        public void DeselectCard()
        {
            controller.selectedCard = null;
        }

        public void HandleEndDrag()
        {
            controller.PlayCard(this);
        }
    }
}