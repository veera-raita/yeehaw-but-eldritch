using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class Enemy : MonoBehaviour
    {
        // List of possible actions and new list for their final order.
        public List<EnemyAction> enemyActions;
        public List<EnemyAction> turnActions = new();

        // Shuffle actions casts moves in a random order, turn number
        // tells which action from the order will be taken.
        public bool shuffleActions = false;
        public int turnNumber;

        public Battler player;

        private EnemyManager m_enemyManager;

        private BattleSceneManager m_battleSceneManager;
        private Battler m_battler;

        private Health m_health;

        #region Built-In Methods
        private void Start()
        {
            m_battleSceneManager = FindObjectOfType<BattleSceneManager>();
            player = m_battleSceneManager.playerInstance;

            m_enemyManager = FindObjectOfType<EnemyManager>();
            m_enemyManager.RegisterEnemy(this);

            m_battler = GetComponent<Battler>();

            m_health = GetComponent<Health>();

            m_health.OnDie += OnDie;

            if (shuffleActions)
            {
                ShuffleActions();
            }
        }
        #endregion

        public void ShuffleActions()
        {
            for (int i = 0; i < enemyActions.Count; i++)
            {
                EnemyAction t_action = enemyActions[i];
                turnActions.Add(t_action);
            }

            turnActions.Shuffle();
        }

        public void TakeTurn()
        {
            switch (turnActions[turnNumber].intentClass)
            {
                case EnemyAction.IntentClass.Attack:
                    Attack();
                    break;
                case EnemyAction.IntentClass.Dodge:
                    
                    break;
                case EnemyAction.IntentClass.Buff:
                    AddBuffToSelf(turnActions[turnNumber].buffClass);
                    break;
                default:
                    Debug.Log("Pluh.");
                    break;
            }

            FinishTurn();
        }

        private void OnDie()
        {
            m_enemyManager.UnregisterEnemy(this);
        }

        private void Attack()
        {
            int t_damage = turnActions[turnNumber].amount;
            player.m_health.Damage(t_damage);
        }

        private void AddBuffToSelf(Buff.BuffClass t_class)
        {
            m_battler.AddBuff(t_class, turnActions[turnNumber].amount);
        }

        private void FinishTurn()
        {
            turnNumber++;

            if (turnNumber == turnActions.Count)
            {
                turnNumber = 0;
            }

            m_battler.BuffAtTurnEnd();
        }
    }
}