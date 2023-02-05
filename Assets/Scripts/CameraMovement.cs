using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform finalLoc;
    [SerializeField] Camera mainCamera;

    [SerializeField] Animator treeAnim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Boss.bossHealth <= 0)
        {
            transform.position = finalLoc.position;
            mainCamera.orthographicSize = 10;

            treeAnim.SetTrigger("FinalTree");
        }
    }



}
