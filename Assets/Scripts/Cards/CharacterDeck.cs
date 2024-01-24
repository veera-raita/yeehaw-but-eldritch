using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GBE
{
    public class CharacterDeck : MonoBehaviour
    {
        [SerializeField] private Hand cardsHand;

        public CardPool pool;

        public CardGenerator m_generator;

        public TextMeshProUGUI deckText;
        public TextMeshProUGUI discardText;

        public List<CardBase> deck = new();
        public List<CardBase> hand = new();
        public List<CardBase> discard = new();

        public BaseCardSlot selectedCard;

        private void Awake()
        {
            cardsHand.OnRightClickEvent += PlayCard;
            cardsHand.OnPointerEnterEvent += SelectCard;
            cardsHand.OnPointerExitEvent += DeselectCard;
        }

        private void Start()
        {
            m_generator.SetupPool(pool);
            SetStartCards();
        }

        private void Update()
        {
            deckText.text = deck.Count.ToString();
            discardText.text = discard.Count.ToString();

            if (Input.GetKeyDown(KeyCode.P))
                DrawFromDeck(5);

        }

        public void SetStartCards()
        {
            List<CardBase> t_list = m_generator.GetRandom(10);
            foreach (CardBase t_instance in t_list)
            {
                deck.Add(t_instance.GetDuplicate());
            }
        }

        private void DrawFromDeck(int t_amountToDraw)
        {
            int t_cardsDrawn = 0;

            while (t_cardsDrawn < t_amountToDraw && hand.Count <= 5)
            {
                hand.Add(deck[0]);
                DisplayCard(deck[0]);
                deck.RemoveAt(0);
                t_cardsDrawn++;
            }
        }

        public void DisplayCard(CardBase t_card)
        {
            CardSlot t_slot = cardsHand.slots[hand.Count - 1];
            t_slot.Card = t_card;
            t_slot.gameObject.SetActive(true);
        }


        private void PlayCard(BaseCardSlot t_cardSlot)
        {
            selectedCard = null;
            t_cardSlot.gameObject.SetActive(false);
            hand.Remove(t_cardSlot.Card);
            Discard(t_cardSlot.Card);
        }

        private void Discard(CardBase t_card)
        {
            discard.Add(t_card);
        }

        private void SelectCard(BaseCardSlot t_cardSlot)
        {
            selectedCard = t_cardSlot;
        }

        private void DeselectCard(BaseCardSlot t_cardSlot)
        {
            selectedCard = null;
        }
    }
}