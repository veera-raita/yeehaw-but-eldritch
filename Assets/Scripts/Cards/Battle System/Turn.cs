using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    private bool TurnHandler;
    private GameObject BattleHandler;
    [SerializeField] private int Speed;

    void Start()                                //getting some values set
    {
        TurnHandler = false;
        BattleHandler = GameObject.FindWithTag("BattleManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (TurnHandler && BattleHandler.GetComponent<Timer>().sceneTime % Speed == 0)      //if turnhandler is true & timer is divisible by speed, run a turn
        {                                                                                   //e.g.,  timer == 14  speed == 7  will allow a turn to run.
            TurnMeme();
        }
    }

    private void TurnMeme()                                                                 //runs a turn.
    {
        TurnHandler = false;
        StopCoroutine(BattleHandler.GetComponent<Timer>().TimeMeme());                      //stop timer, turn off helper

        //what it do chat           |
        //tähän joku tälläne check  |
        //                          V

        if (gameObject.CompareTag("Player"))
        {
            PlayerTurn();
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            EnemyTurn();
        }

        StartCoroutine(BattleHandler.GetComponent<Timer>().TimeMeme());                     //restart timer, turn on helper
        TurnHandler = true;
    }

    /*
    *********************************
          PLAYER TURN GOES HERE
    *********************************
    */

    private void PlayerTurn()
    {

    }

    /*
    *********************************
          ENEMY TURN GOES HERE
    *********************************
    */

    private void EnemyTurn()
    {

    }
}
