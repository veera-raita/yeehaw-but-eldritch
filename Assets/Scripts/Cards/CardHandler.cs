using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GBE
{
    public class CardHandler : MonoBehaviour
    {

        public TextMeshProUGUI deckText;
        public TextMeshProUGUI discardText;

        public List<Card> deck = new();
        public List<Card> hand = new();
        public List<Card> discard = new();

        public CardSlot selectedCard;

        public List<CardSlot> slots;
        [SerializeField] protected Transform m_cardHolder;

        private BattleSceneManager m_battleSceneManager;

        protected void OnValidate()
        {
            if (m_cardHolder != null)
                m_cardHolder.GetComponentsInChildren(includeInactive: true, result: slots);
        }

        private void Start()
        {
            m_battleSceneManager = GetComponent<BattleSceneManager>();
        }

        private void Update()
        {
            deckText.text = deck.Count.ToString();
            discardText.text = discard.Count.ToString();

            if (Input.GetKeyDown(KeyCode.P))
                DrawFromDeck(1);
        }

        public void DrawFromDeck(int t_amountToDraw)
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

        public void DisplayCard(Card t_card)
        {
            CardSlot t_slot = slots[hand.Count - 1];
            t_slot.m_card = t_card;
            t_slot.gameObject.SetActive(true);
        }

        public void PlayCard(CardSlot t_cardSlot)
        {
            selectedCard = null;
            t_cardSlot.gameObject.SetActive(false);

            t_cardSlot.m_card.action.PerformAction(m_battleSceneManager.target);

            hand.Remove(t_cardSlot.m_card);
            Discard(t_cardSlot.m_card);
        }

        private void Discard(Card t_card)
        {
            discard.Add(t_card);
        }
    }
}