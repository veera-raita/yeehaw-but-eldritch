using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongeroSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Longero;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));
            Instantiate(Longero, new Vector3(13f, 0.5f, Random.Range(13.0f, -13.0f)), Quaternion.identity);
        }
    }
}
