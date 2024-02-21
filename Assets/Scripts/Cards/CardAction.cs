namespace GBE
{
    [System.Serializable]
    public class CardAction
    {
        public enum CardType
        {
            Attack,
            Heal,
            Buff,
            Debuff
        }

        public CardType cardType;
        public int amount;

        public void Attack(Battler t_target)
        {
            t_target.m_Health.TakeDamage(amount);
        }
    }
}