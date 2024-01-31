using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GBE
{
    public class HealthBar : MonoBehaviour
    {
        public TextMeshProUGUI healthText;
        public Slider healthFill;

        public void SetMaxHealth(int t_amount)
        {
            healthFill.maxValue = t_amount;
            healthFill.value = t_amount;

            healthText.text = t_amount.ToString("D2") + " / " + t_amount.ToString("D2");
        }

        public void SetHealth(int t_amount)
        {
            healthFill.value = t_amount;
            healthText.text = t_amount.ToString("D2") + " / " + healthFill.maxValue;
        }
    }
}