namespace GBE
{
    [System.Serializable]
    public class Buff
    {
        public enum BuffClass
        {
            Resistance,
            Vulnerable
        }

        public BuffClass buffClass;
        public int buffValue;
    }
}