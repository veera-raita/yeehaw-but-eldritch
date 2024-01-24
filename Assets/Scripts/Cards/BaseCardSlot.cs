using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GBE
{
    public class BaseCardSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
		public event Action<BaseCardSlot> OnPointerEnterEvent;
		public event Action<BaseCardSlot> OnPointerExitEvent;
		public event Action<BaseCardSlot> OnRightClickEvent;

        protected bool isPointerOver;

		public CardBase Card;

		public void OnPointerClick(PointerEventData t_eventData)
		{
			if (t_eventData != null && t_eventData.button == PointerEventData.InputButton.Left)
			{
                OnRightClickEvent?.Invoke(this);
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