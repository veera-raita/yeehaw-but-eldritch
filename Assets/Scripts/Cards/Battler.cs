using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class Battler : MonoBehaviour
    {
        public Health m_Health;

        private BattleSceneManager m_battleSceneManager;


        private void Start()
        {
            m_battleSceneManager = FindObjectOfType<BattleSceneManager>();
        }

        public void SetTarget()
        {
            FindObjectOfType<CardController>().target = this;
        }

        public void None()
        {
            FindObjectOfType<CardController>().target = null;
        }
    }
}