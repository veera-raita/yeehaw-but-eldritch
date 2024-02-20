using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class Battler : MonoBehaviour
    {
        public Health m_Health;
        public BattleSceneManager m_battleSceneManager;

        private void Start()
        {
            m_battleSceneManager = FindObjectOfType<BattleSceneManager>();
            m_Health = GetComponent<Health>();
        }

        public void PointerEnterHandler()
        {
            if (m_battleSceneManager.m_cardHandler.selectedCard != null)
            {
                m_battleSceneManager.target = this;
            }
        }

        public void PointerExitHandler() => m_battleSceneManager.target = null;
    }
}