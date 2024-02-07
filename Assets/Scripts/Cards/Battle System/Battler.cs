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

        public void PointerEnterHandler()
        {
            if (m_battleSceneManager.selectedCard != null)
            {
                m_battleSceneManager.target = this;
            }
        }

        public void PointerExitHandler()
        {
            m_battleSceneManager.target = null;
        }
    }
}