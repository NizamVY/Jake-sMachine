using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartStop : MonoBehaviour
{
    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueManager.codeNumber==1) 
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
            gameObject.SetActive(false);
        }
    }
}
