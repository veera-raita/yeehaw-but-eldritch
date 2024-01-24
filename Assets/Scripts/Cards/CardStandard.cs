using UnityEngine;

namespace GBE
{
    [CreateAssetMenu(menuName = "Cards/Card", fileName = "New Card")]
    public class CardStandard : CardBase
    {
        public override CardBase GetDuplicate()
        {
            return Instantiate(this);
        }

        public override void Destroy()
        {
            Destroy(this);
        }
    }
}