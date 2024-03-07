using System.Collections.Generic;

namespace GBE
{
    [System.Serializable]
    public class CardAction
    {
        public enum ActionClass
        {
            Damage,
            Buff
        }

        public ActionClass actionClass;
        public int amount;
        public Buff.BuffClass buffClass;

        public void PerformAction(Battler t_target)
        {
            switch (actionClass)
            {
                case ActionClass.Damage:
                    Attack(t_target);
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
            t_target.m_health.TakeDamage(amount);
        }

        public void AddBuff(Battler t_target, Buff.BuffClass t_class)
        {
            t_target.AddBuff(t_class, amount);
        }
    }
}