using UnityEngine;

namespace GBE
{
    public class CardTarget : MonoBehaviour
    {
        private BattleSceneManager m_battleSceneManager;
        private Battler m_battler;

        private void Start()
        {
            m_battleSceneManager = FindObjectOfType<BattleSceneManager>();
            m_battler = GetComponent<Battler>();
        }

        private void OnMouseEnter()
        {
            if (m_battleSceneManager.m_cardHandler.selectedCardSlot != null &&
                m_battleSceneManager.m_cardHandler.selectedCardSlot.Card.cardClass == CardBase.CardClass.Attack)
            {
                m_battleSceneManager.target = m_battler;
            }
        }

        private void OnMouseExit()
        {
            m_battleSceneManager.target = null;
        }
    }
}