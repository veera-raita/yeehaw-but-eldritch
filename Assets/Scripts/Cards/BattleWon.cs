using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace GBE
{
    public class BattleWon : MonoBehaviour
    {
        private GameObject[] CardObjects;
        [SerializeField] private Button AcceptButton;
        [SerializeField] private GameObject CardScreen;
        [SerializeField] private GameObject RewardScreen;

        public void InitEndScreen()
        {
            CardObjects = GameObject.FindGameObjectsWithTag("CardButton");

            for (int i = 0; i < CardObjects.Length; i++)
            {
                CardObjects[i].GetComponent<Button>().onClick.AddListener(() => HideMenu());
            }
            AcceptButton.onClick.AddListener(() => Accepted());
        }

        public void HideMenu()
        {
            //TODO add chosen card to _PlayerCardHolder MasterList
            CardScreen.SetActive(false);
            RewardScreen.SetActive(true);
            AcceptButton.onClick.AddListener(() => Accepted());
        }

        public void Accepted()
        {
            //TODO add rewards to player inventory here
            RewardScreen.SetActive(false);
        }
    }
}
