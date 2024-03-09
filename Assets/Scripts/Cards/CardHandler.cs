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

        public BaseCardSlot selectedCardSlot;
        public CardSlotHandler slotHandler;

        private BattleSceneManager m_battleSceneManager;
        #endregion

        #region Built-In Methods
        private void Awake()
        {
            //slotHandler.OnPointerClickEvent += SelectCard;

            slotHandler.OnBeginDragEvent += HandleBeginDrag;
            slotHandler.OnEndDragEvent += HandleEndDrag;
        }

        private void Start()
        {
            m_battleSceneManager = GetComponent<BattleSceneManager>();
        }
        #endregion

        #region Custom Methods
        private void SelectCard(BaseCardSlot t_cardSlot)
        {
            if (t_cardSlot.Card != null)
            {
                selectedCardSlot = t_cardSlot;
            }
        }

        private void UnselectCard(BaseCardSlot t_cardSlot)
        {
            
        }

        private void HandleBeginDrag(BaseCardSlot t_cardSlot)
        {
            if (t_cardSlot.Card != null)
            {
                SelectCard(t_cardSlot);
            }
        }

        private void HandleEndDrag(BaseCardSlot t_cardSlot)
        {
            switch (selectedCardSlot.Card.cardClass)
            {
                case CardBase.CardClass.Attack:
                    if (m_battleSceneManager.target != null)
                    {
                        SpendCard(t_cardSlot);
                    }
                    break;
                case CardBase.CardClass.Skill:
                case CardBase.CardClass.Power:
                    SpendCard(t_cardSlot);
                    break;
                default:
                    break;
            }
        }

        public void ShuffleCards()
        {
            discardPile.Shuffle();
            cardDrawPile = discardPile;
            discardPile = new List<Card>();
            discardCountText.text = discardPile.Count.ToString();
        }

        public void DrawFromDeck(int t_amountToDraw)
        {
            int t_cardsDrawn = 0;

            // If desired draw count is larger than remaining draw pile,
            // set the size to the remaining cards to avoid errors.
            //if (cardDrawPile.Count < t_amountToDraw)
            //    t_amountToDraw = cardDrawPile.Count;

            // When the function is called, keep drawing cards until either
            // hand is full, or draw pile runs out of cards.
            while (t_cardsDrawn < t_amountToDraw && cardsInHand.Count < 5)
            {
                if (cardDrawPile.Count < 1)
                {
                    ShuffleCards();
                }

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
            CardSlot t_slot = slotHandler.cardSlotObjects[cardsInHand.Count - 1];
            t_slot.Card = t_card;
            t_slot.gameObject.SetActive(true);
        }

        public void SpendCard(BaseCardSlot t_cardSlot)
        {
            // Call the actions for player-run cards here.
            t_cardSlot.Card.ExecuteActions(m_battleSceneManager.target, m_battleSceneManager.playerInstance);

            // Reset the selected card and turn off the gameObject.
            selectedCardSlot = null;
            t_cardSlot.gameObject.SetActive(false);

            cardsInHand.Remove(t_cardSlot.Card);
            DiscardCard(t_cardSlot.Card);
        }

        private void DiscardCard(Card t_card)
        {
            discardPile.Add(t_card);
            discardCountText.text = discardPile.Count.ToString();
        }
        #endregion
    }
}