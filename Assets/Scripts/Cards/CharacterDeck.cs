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

            //if (Input.GetKeyDown(KeyCode.P))
                //DrawFromDeck(5);

        }

        public void SetStartCards()
        {
            List<CardBase> t_list = m_generator.GetRandom(10);
            foreach (CardBase t_instance in t_list)
            {
                deck.Add(t_instance.GetDuplicate());
            }
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