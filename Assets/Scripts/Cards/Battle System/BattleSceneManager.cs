using System;
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
        #region Variables
        //
        public TextMeshProUGUI roundCountText;
        public TextMeshProUGUI roundMessageText;

        [Space, Header("Round Settings")]
        public int roundCounter = 1;
        public BattleState m_state;
        public bool endTurn = false;

        [Space, Header("Player")]
        public Battler player;
        public Transform playerStation;
        public Battler playerInstance;
        [Space]
        public int maximumActions = 3;
        public int CurrentActions { get; set; }

        [Space, Header("Enemies")]
        public List<Battler> possibleEnemies;
        public Transform[] FoeStations;

        public Battler target;
        [HideInInspector] public CardHandler m_cardHandler;

        private EnemyManager m_enemyManager;

        [Space, Header("Menu Management")]
        [SerializeField] private GameObject CardScreen;
        #endregion

        #region Built-In Methods
        private void Start()
        {
            m_cardHandler = GetComponent<CardHandler>();
            m_enemyManager = GetComponent<EnemyManager>();

            m_state = BattleState.Start;
            BeginBattle();
        }

        private void Update()
        {
            roundCountText.text = roundCounter.ToString();
        }
        #endregion

        #region Custom Methods
        public void BeginBattle()
        {
            playerInstance = Instantiate(player, playerStation.position, playerStation.rotation);

            // When beginning the battle, instantiate all the enemies into the scene.
            for (int i = 0; i < possibleEnemies.Count; i++)
            {
                Instantiate(possibleEnemies[i], FoeStations[i].position, FoeStations[i].rotation);
            }

            CurrentActions = maximumActions;
            m_cardHandler.actionCountText.text = CurrentActions.ToString() + "/" + maximumActions.ToString();

            m_state = BattleState.PlayerTurn;
            StartCoroutine(PlayerTurn());
        }

        private IEnumerator PlayerTurn()
        {
            endTurn = false;
            roundMessageText.text = "Player Turn";

            yield return new WaitForSeconds(1f);

            if (CurrentActions < maximumActions)
            {
                RestoreAction(maximumActions);
            }

            m_cardHandler.DrawFromDeck(5);

            yield return new WaitUntil(() => endTurn || m_enemyManager.EnemiesInScene.Count <= 0);
            yield return new WaitForSeconds(1f);

            playerInstance.BuffAtTurnEnd();

            if (m_enemyManager.EnemiesInScene.Count <= 0)
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

        public void EndTurn()
        {
            endTurn = true;
        }

        private IEnumerator FoeTurn()
        {
            endTurn = false;
            roundMessageText.text = "Foe Turn";

            yield return new WaitForSeconds(1f);

            // Loop through all enemy instances active in the scene and run their turn unless
            // the player is missing, in which case skip straight to the battle end.
            for (int i = 0; i < m_enemyManager.EnemiesInScene.Count; i++)
            {
                if (playerInstance == null)
                {
                    m_state = BattleState.Lost;
                    EndBattle();

                    break;
                }
                else
                {
                    m_enemyManager.EnemiesInScene[i].GetComponent<Enemy>().TakeTurn();
                    yield return new WaitForSeconds(2f);
                }
            }

            roundCounter++;

            m_state = BattleState.PlayerTurn;
            StartCoroutine(PlayerTurn());
        }

        public void RestoreAction(int t_restore)    //increase current actions by t_restore, up to maximum actions
        {
            if (CurrentActions < maximumActions)
            {
                CurrentActions += t_restore;
                CurrentActions = Math.Clamp(CurrentActions, 0, maximumActions);
            }
            m_cardHandler.actionCountText.text = CurrentActions.ToString() + "/" + maximumActions.ToString();
        }

        private void EndBattle()
        {
            if (m_state == BattleState.Won)
            {
                roundMessageText.text = "Yippee!!";
                HandleEndScreen();
            }

            if (m_state == BattleState.Lost)
            {
                roundMessageText.text = "Fuck you";
            }
        }

        private void HandleEndScreen()
        {
            // When the battle results in victory, this function will be run.
            CardScreen.SetActive(true);
            GameObject.FindGameObjectWithTag("BattleMenu").GetComponent<BattleWon>().InitEndScreen();
            Debug.Log("end");
        }
        #endregion
    }
}