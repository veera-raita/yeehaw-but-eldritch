using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GBE
{
    public class BattleWon : MonoBehaviour
    {
        private GameObject[] CardObjects;
        [SerializeField] private Button AcceptButton;
        [SerializeField] private GameObject CardScreen;
        [SerializeField] private GameObject RewardScreen;
        [SerializeField] private GameObject RewardCard;
        [SerializeField] private GameObject CardHolder;
        [SerializeField] private GameObject RewardItem;
        [SerializeField] private GameObject RewardHolder;
        [SerializeField] private CardGenerator cardGenerator;

        private _PlayerCardHolder CardMasterlist;
        private List<Card> CardRewardList;
        public List<GameObject> Options;

        private void Start()
        {
            //change this to work on gamemanager later
            CardMasterlist = GameObject.FindGameObjectWithTag("BattleMenu").GetComponent<_PlayerCardHolder>();
        }

        public void InitEndScreen()
        {

            int RewardCardsAmount = CardMasterlist.MasterList.Count;
            RewardCardsAmount = Math.Clamp(RewardCardsAmount, 0, 3);

            InstantiateCards(RewardCardsAmount);    //instantiates given amount of reward cards

            //adding listener to every instantiated ui card
            CardObjects = GameObject.FindGameObjectsWithTag("CardButton");

            for (int i = 0; i < CardObjects.Length; i++)
            {
                CardObjects[i].GetComponent<Button>().onClick.AddListener(() => MoveToRewards());
            }
            AcceptButton.onClick.AddListener(() => Accepted());
        }

        public void MoveToRewards()
        {
            //TODO add chosen card to _PlayerCardHolder MasterList
            
            CardScreen.SetActive(false);
            RewardScreen.SetActive(true);
            InstantiateRewards(4);    //instantiates given amount of reward items
            AcceptButton.onClick.AddListener(() => Accepted());
        }

        public void Accepted()
        {
            //TODO add rewards to player inventory here
            RewardScreen.SetActive(false);
        }

        private void InstantiateCards(int t_amount)
        {
            CardRewardList = cardGenerator.GetRandomFromPool(t_amount, CardMasterlist.MasterList);
            for (int i = 0; i < t_amount; ++i)
            {
                Options.Add(Instantiate(RewardCard, CardHolder.transform));
                Options[i].GetComponent<RewardCardDisplay>().InitDisplay(CardRewardList[i]);
            }
        }

        private void InstantiateRewards(int t_amount)
        {
            for (int i = 0; i < t_amount; ++i)
            {
                Instantiate(RewardItem, RewardHolder.transform);
            }
        }

    }
}
