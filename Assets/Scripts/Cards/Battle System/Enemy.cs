using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class Enemy : MonoBehaviour
    {
        public Card enemyAction;

        public Battler player;

        private BattleSceneManager m_battleSceneManager;
        private Battler m_battler;

        #region Built-In Methods
        private void Start()
        {
            m_battleSceneManager = FindObjectOfType<BattleSceneManager>();
            player = m_battleSceneManager.playerInstance;

            m_battler = GetComponent<Battler>();
        }

        private void OnDestroy()
        {
            m_battleSceneManager.FoeInstances.Remove(m_battler);
        }
        #endregion

        public void TakeTurn()
        {
            enemyAction.ExecuteActions(player, m_battler);
        }
    }
}