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
        public GameObject player;
        public Transform playerStation;
        public int actions = 6;

        [Space, Header("Enemies")]
        public GameObject enemy;
        public List<Battler> enemies = new();
        public GameObject[] possibleEnemies;
        public Transform enemyStation;

        public BattleState m_state;

        private void Start()
        {
            m_state = BattleState.Start;
            //BeginBattle(possibleEnemies);
        }

        public void BeginBattle(GameObject[] t_prefabs)
        {
            roundMsg.text = "Your Turn";

            m_state = BattleState.PlayerTurn;
            ChangeTurn();
        }

        public void ChangeTurn()
        {

        }
    }
}