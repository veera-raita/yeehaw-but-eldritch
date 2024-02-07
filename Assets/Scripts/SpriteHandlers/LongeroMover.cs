using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongeroMover : MonoBehaviour
{
    private bool FloorCheck;
    private Rigidbody RB;
    // Start is called before the first frame update
    void Start()
    {
        FloorCheck = false;
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FloorCheck)
        {
            //RB.AddForce(transform.up * Random.Range(1.0f, 15.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            FloorCheck = true;
        }
    }
}
