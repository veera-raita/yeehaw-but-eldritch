using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongeroMover : MonoBehaviour
{
    private Rigidbody RB;
    private SpriteRenderer Spr;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Spr.transform.Rotate(0, 0, 135f * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            Debug.Log("meow");
            RB.AddForce(Random.Range(-0.5f, -1.5f), Random.Range(1.5f, 3.0f), 0, ForceMode.Impulse);
        }
    }
}
