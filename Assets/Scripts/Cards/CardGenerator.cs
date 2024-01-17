using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class CardGenerator : MonoBehaviour
    {
        [SerializeField] private List<CardBase> m_cardPool;

        public CardPool pool;

        public List<CardBase> card;

        private void Start()
        {
            SetupPool(pool);
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                card = GetRandom(3);
            }
        }

        public void SetupPool(CardPool t_profile)
        {
            m_cardPool = GetFullPool(t_profile.cards);

        }

        public List<CardBase> GetRandom(int t_amount)
        {
            return GetRandomFromPool(t_amount, m_cardPool);
        }

        public List<CardBase> GetRandomFromPool(int t_amount, List<CardBase> t_cardPool)
        {
            List<CardBase> t_cards = new();

            for (int i = 0; i < t_amount; i++)
            {
                CardBase t_card = t_cardPool[Random.Range(0, m_cardPool.Count)];
                t_cards.Add(t_card);
            }

            return t_cards;
        }

        public void AddToPool(List<CardBase> t_cardPool)
        {
            m_cardPool.AddRange(GetFullPool(t_cardPool));
        }

        public void RemoveFromPool(CardBase t_target)
        {
            CardBase t_card = m_cardPool.Find(t_instance => t_instance == t_target);
            if (t_card != null)
            {
                m_cardPool.Remove(t_card);
            }
        }

        private List<CardBase> GetFullPool(List<CardBase> t_cardPool)
        {
            List<CardBase> t_list = new();
            foreach (CardBase t_card in t_cardPool)
            {
                t_list.Add(t_card);
            }

            return t_list;
        }
    }
}