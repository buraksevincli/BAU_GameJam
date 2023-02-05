using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform finalLoc;
    [SerializeField] Camera mainCamera;

    [SerializeField] Animator treeAnim;

    [SerializeField] GameObject finalScreen;
    [SerializeField] GameObject bossHealthBar;


    bool once;
    // Start is called before the first frame update
    void Start()
    {
        once = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Boss.bossHealth <= 0 && !once)
        {
            once = true;
            transform.position = finalLoc.position;
            mainCamera.orthographicSize = 10;

            treeAnim.SetTrigger("FinalTree");

            StartCoroutine(DelayFinalScreen());
        }
    }

    IEnumerator DelayFinalScreen()
    {
        
        yield return new WaitForSeconds(2f);
        bossHealthBar.SetActive(false);
        finalScreen.SetActive(true);
    }

}
