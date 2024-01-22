using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class CharacterDeck : MonoBehaviour
    {
        public CardPool pool;

        public CardGenerator m_generator;

        public List<CardBase> deck = new();
        public List<CardBase> hand = new();
        public List<CardBase> discard = new();

        public CardBase selectedCard;

        private void Start()
        {
            m_generator.SetupPool(pool);
            SetStartCards();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
                DrawFromDeck(3);

            if (hand.Count > 0)
                selectedCard = hand[0];

            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayCard(selectedCard);
            }
        }      

        public void SetStartCards()
        {
            List<CardBase> t_list = m_generator.GetRandom(10);
            foreach (CardBase t_instance in t_list)
            {
                deck.Add(t_instance.GetDuplicate());
            }
        }

        public void DrawFromDeck(int t_amountToDraw)
        {
            for (int i = 0; i < t_amountToDraw; i++)
            {
                hand.Add(deck[0]);
                deck.Remove(deck[0]);
            }
        }

        public void PlayCard(CardBase t_instance)
        {
            selectedCard = null;

            hand.Remove(t_instance);
            DiscardCard(t_instance);
        }

        public void DiscardCard(CardBase t_instance)
        {
            discard.Add(t_instance);
        }
    }
}