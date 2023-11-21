using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerManager : MonoBehaviour
{
    public PlayerControl playerControl;
    public PlayerRunner runner;
    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        playerControl= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        playerControl.isRunner = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueManager.codeNumber == 1)
        { 
            playerControl.isRunner= true;
        }

        if(dialogueManager.isDialogue)
        {
            playerControl.isRunner = false;
        }
    }
}
