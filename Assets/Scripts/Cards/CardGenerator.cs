using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class CardGenerator : MonoBehaviour
    {
        public CardPool m_CardPool;

        public List<CardBase> card;

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                GetRandom(3);
            }
        }


        public void GetRandom(int t_amount)
        {
            for (int i = 0; i < t_amount; i++)
            {
                CardBase t_cardBase = m_CardPool.cards[Random.Range(0, m_CardPool.cards.Count)];
                card.Add(t_cardBase);
            }
        }
    }
}