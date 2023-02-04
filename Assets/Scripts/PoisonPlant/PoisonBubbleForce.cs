using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBubbleForce : MonoBehaviour
{
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        float randNumber = Random.Range(100, 150);
        //float randNumber2 = Random.Range(50, 200);

        rb2d.AddForce(-transform.up * randNumber);
        rb2d.AddForce(-transform.right * 250);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
