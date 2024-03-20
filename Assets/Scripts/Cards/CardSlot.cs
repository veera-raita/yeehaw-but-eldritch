using System;
using UnityEngine.EventSystems;

namespace GBE
{
    public class CardSlot : BaseCardSlot, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
    {
        public event Action<BaseCardSlot> OnBeginDragEvent;
        public event Action<BaseCardSlot> OnEndDragEvent;
        public event Action<BaseCardSlot> OnDragEvent;
        public event Action<BaseCardSlot> OnDropEvent;

        private bool isDragging;

        public void OnBeginDrag(PointerEventData t_eventData)
        {
            isDragging = true;
            OnBeginDragEvent?.Invoke(this);
        }

        public void OnEndDrag(PointerEventData t_eventData)
        {
            isDragging = false;
            OnEndDragEvent?.Invoke(this);
        }

        public void OnDrag(PointerEventData t_eventData)
        {
            OnDragEvent?.Invoke(this);
        }

        public void OnDrop(PointerEventData t_eventData)
        {
            OnDropEvent?.Invoke(this);
        }
    }
}