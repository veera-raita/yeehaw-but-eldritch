using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GBE
{
    public class HealthBar : MonoBehaviour
    {
        public TextMeshProUGUI healthText;
        public Slider healthFill;

        private Health m_health;

        private void Start()
        {
            m_health = GetComponentInParent<Health>();
            healthFill.maxValue = m_health.maxHealth;
        }

        private void Update()
        {
            healthFill.value = m_health.CurrentHealth;
            healthText.text = m_health.CurrentHealth.ToString("D2") + " / " + healthFill.maxValue;
        }
    }
}