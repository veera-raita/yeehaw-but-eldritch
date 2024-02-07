using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int sceneTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeMeme());         //on start, start timer
    }

    public IEnumerator TimeMeme()
    {
        while (true)                        //while timer is running, add to time and wait a second to do it again
        {
            sceneTime++;
            yield return new WaitForSeconds(1.0f);
        }
    }
}