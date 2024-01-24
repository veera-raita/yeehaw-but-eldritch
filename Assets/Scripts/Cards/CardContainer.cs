using System;
using System.Collections.Generic;
using UnityEngine;

namespace GBE
{
    public class CardContainer : MonoBehaviour, ICard
    {
        public List<CardSlot> slots;

        public event Action<BaseCardSlot> OnPointerEnterEvent;
        public event Action<BaseCardSlot> OnPointerExitEvent;
        public event Action<BaseCardSlot> OnRightClickEvent;

        protected virtual void OnValidate()
        {
            GetComponentsInChildren(includeInactive: true, result: slots);
        }

        protected virtual void Awake()
        {
            for (int i = 0; i < slots.Count; i++)
            {
                slots[i].OnPointerEnterEvent += t_slot => EventHelper(t_slot, OnPointerEnterEvent);
                slots[i].OnPointerExitEvent += t_slot => EventHelper(t_slot, OnPointerExitEvent);
                slots[i].OnRightClickEvent += t_slot => EventHelper(t_slot, OnRightClickEvent);
            }
        }

        private void EventHelper(BaseCardSlot t_cardSlot, Action<BaseCardSlot> t_action)
        {
            t_action?.Invoke(t_cardSlot);
        }
    }
}