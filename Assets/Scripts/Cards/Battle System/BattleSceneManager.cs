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

        public int roundCounter = 1;

        [Space, Header("Player")]
        public Battler player;
        public Transform playerStation;
        public int actions = 6;

        [Space, Header("Enemies")]
        public Enemy enemy;
        public GameObject[] possibleEnemies;
        public Transform enemyStation;

        public Battler playerInstance;
        public Enemy enemyInstance;

        public bool endTurn = false;

        public Battler target;
        public BattleState m_state;

        public CardHandler m_cardHandler;

        private void Start()
        {
            m_cardHandler = GetComponent<CardHandler>();

            m_state = BattleState.Start;
            BeginBattle();
        }

        private void Update()
        {
            roundCount.text = roundCounter.ToString();
        }

        public void BeginBattle()
        {
            playerInstance = Instantiate(player, playerStation.position, playerStation.rotation);

            enemyInstance = Instantiate(enemy, enemyStation.position, enemyStation.rotation);

            m_state = BattleState.PlayerTurn;
            StartCoroutine(PlayerTurn());
        }

        public void EndTurn()
        {
            endTurn = true;
        }

        private IEnumerator PlayerTurn()
        {
            endTurn = false;
            roundMsg.text = "Player Turn";

            yield return new WaitForSeconds(1f);

            m_cardHandler.DrawFromDeck(1);

            yield return new WaitUntil(() => m_cardHandler.hand.Count == 0 || endTurn || enemyInstance == null);
            yield return new WaitForSeconds(1f);

            if (enemyInstance == null)
            {
                m_state = BattleState.Won;
                EndBattle();
            }
            else
            {
                m_state = BattleState.EnemyTurn;
                StartCoroutine(EnemyTurn());
            }
        }

        private IEnumerator EnemyTurn()
        {
            endTurn = false;
            roundMsg.text = "Enemy Turn";

            yield return new WaitForSeconds(1f);

            enemyInstance.TakeTurn();

            yield return new WaitForSeconds(2f);

            roundCounter++;

            if (playerInstance == null)
            {
                m_state = BattleState.Lost;
                EndBattle();
            }
            else
            {
                m_state = BattleState.PlayerTurn;
                StartCoroutine(PlayerTurn());
            }
        }

        private void EndBattle()
        {
            if (m_state == BattleState.Won)
            {
                roundMsg.text = "Yippee!!";
            }

            if (m_state == BattleState.Lost)
            {
                roundMsg.text = "Fuck you";
            }
        }
    }
}