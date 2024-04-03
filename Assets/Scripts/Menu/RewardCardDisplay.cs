using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GBE
{
    public class RewardCardDisplay : MonoBehaviour
    {
        [SerializeField] TMP_Text Title;
        [SerializeField] TMP_Text Description;
        [SerializeField] TMP_Text Cost;
        [SerializeField] Sprite Image;

        public void InitDisplay(Card t_card)
        {
            Title.text = t_card.cardName;
            Description.text = t_card.cardDescription;
            Cost.text = "Cost: " + t_card.cardCost.ToString();
            Image = t_card.cardIcon;
        }
    }
}
