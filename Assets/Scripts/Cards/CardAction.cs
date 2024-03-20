using UnityEngine;

namespace GBE
{
    [System.Serializable]
    public class CardAction
    {
        public enum ActionTarget
        {
            Target,
            Self
        }

        public enum ActionClass
        {
            Damage,
            Heal,
            Buff
        }

        public ActionTarget target;
        public bool targetAllEnemies;

        [Space]
        [SerializeField] private ActionClass actionClass;
        [SerializeField] private int amount;

        [Space]
        public Buff.BuffClass buffClass;

        #region Custom Methods
        public void PerformAction(Battler t_target)
        {
            // All the different actions should be under here. If there's more
            // complex functionality, it might be smort to make a new case.
            switch (actionClass)
            {
                case ActionClass.Damage:
                    Attack(t_target);
                    break;
                case ActionClass.Heal:
                    AddHealth(t_target);
                    break;
                case ActionClass.Buff:
                    AddBuff(t_target, buffClass);
                    break;
                default:
                    break;
            }
        }

        public void Attack(Battler t_target)
        {
            t_target.m_health.Damage(amount);
        }

        public void AddHealth(Battler t_target)
        {
            t_target.m_health.Heal(amount);
        }

        public void AddBuff(Battler t_target, Buff.BuffClass t_class)
        {
            t_target.AddBuff(t_class, amount);
        }
        #endregion
    }
}