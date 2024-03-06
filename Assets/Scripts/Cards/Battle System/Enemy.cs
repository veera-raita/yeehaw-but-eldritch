using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class Enemy : MonoBehaviour
    {
        public Battler player;

        public BattleSceneManager manager;

        public Card action;

        private Battler m_battler;

        private void Start()
        {
            manager = FindObjectOfType<BattleSceneManager>();
            player = manager.playerInstance;

            m_battler = GetComponent<Battler>();
        }

        private void OnDestroy()
        {
            manager.FoeInstances.Remove(m_battler);
        }

        public void TakeTurn()
        {
            action.Execute(player);
        }
    }
}