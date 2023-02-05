using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Diyalog : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(John());
    }

    void StartDialogueJenny()
    {
        index = 0;
        StartCoroutine(Jenny());
    }

    IEnumerator John()
    {

        //Tpye each character 1 by 1
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
            



        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(John());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator Jenny()
    {

        //Tpye each character 1 by 1
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);




        }
    }

    void NextLineJenny() 
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(Jenny());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
