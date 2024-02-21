using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class CardGenerator : MonoBehaviour
    {
        public CardPool m_CardPool;
        [SerializeField] private List<Card> m_cardPool;

        public void SetupPool(CardPool t_profile)
        {
            m_cardPool = GetFullPool(t_profile.cards);
        }

        public List<Card> GetRandom(int t_amount)
        {
            return GetRandomFromPool(t_amount, m_cardPool);
        }

        public List<Card> GetRandomFromPool(int t_amount, List<Card> t_cardPool)
        {
            List<Card> t_cards = new();

            // Loop through specified amount of times and return said
            // amount of cards from the specified pool.
            for (int i = 0; i < t_amount; i++)
            {
                Card t_card = t_cardPool[Random.Range(0, m_cardPool.Count)];
                t_cards.Add(t_card);
            }

            return t_cards;
        }

        public void AddToPool(List<Card> t_cardPool)
        {
            m_cardPool.AddRange(GetFullPool(t_cardPool));
        }

        public void RemoveFromPool(Card t_target)
        {
            // Find a specific given card inside the specified card pool,
            // then remove said card from the pool.
            Card t_card = m_cardPool.Find(t_instance => t_instance == t_target);
            if (t_card != null)
            {
                m_cardPool.Remove(t_card);
            }
        }

        private List<Card> GetFullPool(List<Card> t_cardPool)
        {
            // Take all the instances inside a card pool and return them as a list.
            List<Card> t_list = new();
            foreach (Card t_card in t_cardPool)
            {
                t_list.Add(t_card);
            }

            return t_list;
        }
    }
}