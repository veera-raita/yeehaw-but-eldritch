using UnityEngine;

namespace GBE
{
    public class Hand : CardContainer
    {
        [SerializeField] protected Transform m_cardHolder;

        protected override void OnValidate()
        {
            if (m_cardHolder != null)
                m_cardHolder.GetComponentsInChildren(includeInactive: true, result: slots);
        }

        protected override void Awake()
        {
            base.Awake();
        }
    }
}