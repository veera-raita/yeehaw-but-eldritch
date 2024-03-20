using UnityEngine;

namespace GBE
{
    [System.Serializable]
    public class EnemyAction
    {
        public enum IntentClass
        {
            Attack,
            Dodge,
            Buff
        }

        [Space, Header("Action Settings")]
        public IntentClass intentClass;
        public int amount;

        [Space, Header("Status Effect Settings")]
        public Buff.BuffClass buffClass;
        public int buffAmount;
    }
}