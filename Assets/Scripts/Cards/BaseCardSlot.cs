using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GBE
{
    public class BaseCardSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] protected TextMeshProUGUI nameText;

        public event Action<BaseCardSlot> OnPointerEnterEvent;
        public event Action<BaseCardSlot> OnPointerExitEvent;
        public event Action<BaseCardSlot> OnPointerClickEvent;

        protected bool isPointerOver;

        protected Card m_card;
        public Card Card
        {
            get => m_card;
            set
            {
                m_card = value;

                if (m_card != null)
                {
                    nameText.text = Card.cardName;
                }

                if (isPointerOver)
                {
                    OnPointerExit(null);
                    OnPointerEnter(null);
                }
            }
        }

        public void OnPointerClick(PointerEventData t_eventData)
        {
            if (t_eventData != null && t_eventData.button == PointerEventData.InputButton.Left)
            {
                OnPointerClickEvent?.Invoke(this);
            }
        }

        public void OnPointerEnter(PointerEventData t_eventData)
        {
            isPointerOver = true;
            OnPointerEnterEvent?.Invoke(this);
        }

        public void OnPointerExit(PointerEventData t_eventData)
        {
            isPointerOver = false;
            OnPointerExitEvent?.Invoke(this);
        }
    }
}