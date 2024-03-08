namespace GBE
{
    [System.Serializable]
    public class Buff
    {
        // List of all status effects, later sorted based on the buff type
        // inside other scripts as needed.
        public enum BuffClass
        {
            Resistance,
            Vulnerable
        }

        public BuffClass buffClass;
        public int buffValue;
    }
}