using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class Enemy : MonoBehaviour
    {
        public Battler player;

        public BattleSceneManager manager;

        public CardAction action;

        private void Start()
        {
            manager = FindObjectOfType<BattleSceneManager>();
            player = manager.playerInstance;
        }

        public void TakeTurn()
        {
            action.PerformAction(player);
        }
    }
}