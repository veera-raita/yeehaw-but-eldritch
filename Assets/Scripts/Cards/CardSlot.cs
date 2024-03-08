using TMPro;
using UnityEngine;

namespace GBE
{
    public class CardSlot : MonoBehaviour
    {
        public Card card;

        public TextMeshProUGUI nameText;

        public BattleSceneManager m_battleSceneManager;

        public void LoadCard(Card t_card)
        {
            // Assign all variables from the incoming card.
            card = t_card;
            nameText.text = card.cardName;
        }

        public void SelectCard()
        {
            m_battleSceneManager.m_cardHandler.selectedCardSlot = this;
        }

        public void DeselectCard()
        {
            m_battleSceneManager.m_cardHandler.selectedCardSlot = null;
        }

        public void HandleEndDrag()
        {
            if (m_battleSceneManager.target != null)
                m_battleSceneManager.m_cardHandler.SpendCard(this);
        }
    }
}