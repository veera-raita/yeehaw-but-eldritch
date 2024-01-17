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

        private void Start()
        {
            m_generator.SetupPool(pool);
            SetStartCards();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DeckToHand(4);
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

        public void DeckToHand(int t_amount)
        {
            if (t_amount >= deck.Count)
            {
                t_amount = deck.Count;
            }

            for (int i = 0; i < t_amount; i++)
            {
                CardBase t_instance = deck[Random.Range(0, deck.Count)];
                hand.Add(t_instance);
                deck.Remove(t_instance);
            }
        }
    }
}