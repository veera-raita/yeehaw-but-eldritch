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
        FoeTurn,
        Won,
        Lost
    }

    public class BattleSceneManager : MonoBehaviour
    {
        //

        public TextMeshProUGUI roundCount;
        public TextMeshProUGUI roundMsg;

        public int roundCounter = 1;

        [Space, Header("Player")]
        public Battler player;
        public Transform playerStation;

        public Battler playerInstance;
        public int actions = 6;

        [Space, Header("Enemies")]
        public List<Battler> enemies;
        public Transform[] FoeStations;
        public List<Battler> FoeInstances;

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

            //
            for (int i = 0; i < enemies.Count; i++)
            {
                Battler t_instance = Instantiate(enemies[i], FoeStations[i].position, FoeStations[i].rotation);
                FoeInstances.Add(t_instance);
            }

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

            m_cardHandler.DrawFromDeck(5);

            yield return new WaitUntil(() => m_cardHandler.hand.Count == 0 || endTurn || FoeInstances.Count <= 0);
            yield return new WaitForSeconds(1f);

            if (FoeInstances.Count <= 0)
            {
                m_state = BattleState.Won;
                EndBattle();
            }
            else
            {
                m_state = BattleState.FoeTurn;
                StartCoroutine(FoeTurn());
            }
        }

        private IEnumerator FoeTurn()
        {
            endTurn = false;
            roundMsg.text = "Foe Turn";

            yield return new WaitForSeconds(1f);

            //
            for (int i = 0; i < FoeInstances.Count; i++)
            {
                if (playerInstance == null) { break; }
                else
                {
                    FoeInstances[i].GetComponent<Enemy>().TakeTurn();
                    yield return new WaitForSeconds(2f);
                }
            }

            if (playerInstance == null)
            {
                m_state = BattleState.Lost;
                EndBattle();
            }
            else
            {
                roundCounter++;

                m_state = BattleState.PlayerTurn;
                StartCoroutine(PlayerTurn());
            }
        }

        private void EndBattle()
        {
            if (m_state == BattleState.Won)
            {
                roundMsg.text = "Yippee!!";
                HandleEndScreen();
            }

            if (m_state == BattleState.Lost)
            {
                roundMsg.text = "Fuck you";
            }
        }

        private void HandleEndScreen()
        {
            Debug.Log("end");
        }
    }
}