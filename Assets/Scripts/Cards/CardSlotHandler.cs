using System;
using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class CardSlotHandler : MonoBehaviour
    {
        #region Variables
        // References to the card slots.
        [SerializeField] protected Transform m_cardHolder;
        public List<CardSlot> cardSlotObjects;

        public event Action<BaseCardSlot> OnPointerEnterEvent;
        public event Action<BaseCardSlot> OnPointerExitEvent;
        public event Action<BaseCardSlot> OnPointerClickEvent;
        public event Action<BaseCardSlot> OnBeginDragEvent;
        public event Action<BaseCardSlot> OnEndDragEvent;
        public event Action<BaseCardSlot> OnDragEvent;
        public event Action<BaseCardSlot> OnDropEvent;
        #endregion

        #region Built-In Methods
        protected void OnValidate()
        {
            // Editor-related function, which refreshes the list of
            // CardSlots under their holder object.
            if (m_cardHolder != null)
            {
                m_cardHolder.GetComponentsInChildren(includeInactive: true, result: cardSlotObjects);
            }
        }

        protected void Awake()
        {
            for (int i = 0; i < cardSlotObjects.Count; i++)
            {
                cardSlotObjects[i].OnPointerEnterEvent += t_slot => EventHelper(t_slot, OnPointerEnterEvent);
                cardSlotObjects[i].OnPointerExitEvent += t_slot => EventHelper(t_slot, OnPointerExitEvent);
                cardSlotObjects[i].OnPointerClickEvent += t_slot => EventHelper(t_slot, OnPointerClickEvent);
                cardSlotObjects[i].OnBeginDragEvent += t_slot => EventHelper(t_slot, OnBeginDragEvent);
                cardSlotObjects[i].OnEndDragEvent += t_slot => EventHelper(t_slot, OnEndDragEvent);
                cardSlotObjects[i].OnDragEvent += t_slot => EventHelper(t_slot, OnDragEvent);
                cardSlotObjects[i].OnDropEvent += t_slot => EventHelper(t_slot, OnDropEvent);
            }
        }
        #endregion

        #region Custom Methods
        private void EventHelper(BaseCardSlot t_itemSlot, Action<BaseCardSlot> t_action)
        {
            t_action?.Invoke(t_itemSlot);
        }
        #endregion
    }
}