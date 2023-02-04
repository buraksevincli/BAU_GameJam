using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBubleSpawner : MonoBehaviour
{
    public GameObject bubble;
    GameObject currentBubble;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBubble());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnBubble()
    {
        currentBubble = Instantiate(bubble, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.7f);
        Destroy(currentBubble, 3f);
        StartCoroutine(SpawnBubble());
        
    }

}
