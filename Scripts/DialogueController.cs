using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public Dialogue dialogue;
    public bool isDialogue;

    void Start()
    {
        isDialogue = true;
    }

    void Update()
    {
        if (isDialogue)
        { 
            isDialogue=false;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

}
