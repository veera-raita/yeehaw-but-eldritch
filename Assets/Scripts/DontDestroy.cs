using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script will keep any game object loaded when changing scenes, e.g.
//if this is attached to GameManager (as it's meant to be),
//it should stay loaded when going from menu to map and map to battle

//can be used to move data between scenes

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
