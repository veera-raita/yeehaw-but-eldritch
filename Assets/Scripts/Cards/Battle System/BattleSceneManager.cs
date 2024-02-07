using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GBE
{
    public enum BattleState
    {
        Start,
        PlayerTurn,
        EnemyTurn,
        Won,
        Lost
    }

    public class BattleSceneManager : MonoBehaviour
    {
        public TextMeshProUGUI roundCount;
        public TextMeshProUGUI roundMsg;

        [Space, Header("Player")]
        public Battler player;
        public Transform playerStation;
        public int actions = 6;

        [Space, Header("Enemies")]
        public Battler enemy;
        public List<Battler> enemies = new();
        public GameObject[] possibleEnemies;
        public Transform enemyStation;



        public TextMeshProUGUI deckText;
        public TextMeshProUGUI discardText;

        public List<Card> deck = new();
        public List<Card> hand = new();
        public List<Card> discard = new();

        public CardSlot selectedCard;

        public List<CardSlot> slots;
        [SerializeField] protected Transform m_cardHolder;



        public Battler target;

        public BattleState m_state;

        protected void OnValidate()
        {
            if (m_cardHolder != null)
                m_cardHolder.GetComponentsInChildren(includeInactive: true, result: slots);
        }

        private void Start()
        {
            m_state = BattleState.Start;
            //BeginBattle(possibleEnemies);
        }

        private void Update()
        {
            deckText.text = deck.Count.ToString();
            discardText.text = discard.Count.ToString();

            if (Input.GetKeyDown(KeyCode.P))
                DrawFromDeck(5);

        }

        public void BeginBattle(GameObject[] t_prefabs)
        {
            m_state = BattleState.PlayerTurn;
            ChangeTurn(player);
        }

        public void ChangeTurn(Battler t_battler)
        {
            if (m_state == BattleState.PlayerTurn)
                roundMsg.text = "Your Turn";

            if (m_state == BattleState.EnemyTurn)
                roundMsg.text = "Enemy Turn";
        }




        /*

        **********************************************************************
                         DECK INVESTIGATION DO NOT CROSS
        **********************************************************************

        */

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

            t_cardSlot.m_card.action.PerformAction(target);

            hand.Remove(t_cardSlot.m_card);
            Discard(t_cardSlot.m_card);
        }

        private void Discard(Card t_card)
        {
            discard.Add(t_card);
        }
    }
}