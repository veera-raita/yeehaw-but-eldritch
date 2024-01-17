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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SetStartCards();
        }

        public void SetStartCards()
        {
            List<CardBase> t_list = m_generator.GetRandom(20);
            foreach (CardBase t_instance in t_list)
            {
                deck.Add(t_instance.GetDuplicate());
            }
        }
    }
}