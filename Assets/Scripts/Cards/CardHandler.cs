using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GBE
{
    public class CardHandler : MonoBehaviour
    {
        #region Variables
        [Space, Header("Label References")]
        public TextMeshProUGUI drawCountText;
        public TextMeshProUGUI discardCountText;

        // Cards are cycled between these three lists.
        [Space, Header("Card Lists")]
        public List<Card> cardDrawPile = new();
        public List<Card> cardsInHand = new();
        public List<Card> discardPile = new();

        // References to the card slots.
        public List<CardSlot> cardSlotObjects;
        public CardSlot selectedCardSlot;

        [SerializeField] protected Transform m_cardHolder;
        private BattleSceneManager m_battleSceneManager;
        #endregion

        #region Built-In Methods
        protected void OnValidate()
        {
            // Editor-related function, which refreshes the list of
            // CardSlots under their holder object.
            if (m_cardHolder != null)
            {
                m_cardHolder.GetComponentsInChildren(includeInactive: true, result: cardSlotObjects);
            }
        }

        private void Start()
        {
            m_battleSceneManager = GetComponent<BattleSceneManager>();
        }
        #endregion

        #region Custom Methods
        public void DrawFromDeck(int t_amountToDraw)
        {
            int t_cardsDrawn = 0;

            // If desired draw count is larger than remaining draw pile,
            // set the size to the remaining cards to avoid errors.
            if (cardDrawPile.Count < t_amountToDraw)
                t_amountToDraw = cardDrawPile.Count;

            // When the function is called, keep drawing cards until either
            // hand is full, or draw pile runs out of cards.
            while (t_cardsDrawn < t_amountToDraw && cardsInHand.Count < 5)
            {
                // When drawing, use the first card in the pile each time.
                cardsInHand.Add(cardDrawPile[0]);
                ShowCardInHand(cardDrawPile[0]);
                cardDrawPile.RemoveAt(0);
                drawCountText.text = cardDrawPile.Count.ToString();
                t_cardsDrawn++;
            }
        }

        public void ShowCardInHand(Card t_card)
        {
            // Update the visuals of a card slot.
            CardSlot t_slot = cardSlotObjects[cardsInHand.Count - 1];
            t_slot.LoadCard(t_card);
            t_slot.gameObject.SetActive(true);
        }

        public void SpendCard(CardSlot t_cardSlot)
        {
            // Reset the selected card and turn off the gameObject.
            selectedCardSlot = null;
            t_cardSlot.gameObject.SetActive(false);

            // Call the actions for player-run cards here.
            t_cardSlot.card.ExecuteActions(m_battleSceneManager.target, m_battleSceneManager.playerInstance);

            cardsInHand.Remove(t_cardSlot.card);
            DiscardCard(t_cardSlot.card);
        }

        private void DiscardCard(Card t_card)
        {
            discardPile.Add(t_card);
            discardCountText.text = discardPile.Count.ToString();
        }
        #endregion
    }
}