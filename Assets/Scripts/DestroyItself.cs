using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItself : MonoBehaviour
{
    [SerializeField] float delay;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delay);
    }


}
