using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAction : MonoBehaviour
{
    public GameObject meteor;
    public DialogueManager dialogueManager;

    public MeteorFalling mFalling;
    public PlayerControl pControl;
    public SpriteRenderer playerSpriteRenderer;
    public GameObject stoppedPlace;
    public GameObject player;
    public GameObject stoppedDialogue;
    public GameObject nounPlace;
    public LastDialgue lastDg;

    public int codeNumber;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pControl = player.GetComponent<PlayerControl>();
        pControl.enabled = false;
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueManager.codeNumber == 0)
        {
            pControl.enabled = false;
        }

        if (dialogueManager.codeNumber==1) 
        {
            if(meteor!=null) 
            {
                meteor.SetActive(true);
            }
        }
        

        if (mFalling.codeNumber == 11)
        { 
            pControl.enabled = false;
        }

        if (mFalling.codeNumber == 12)
        { 
            pControl.enabled = true;
            playerSpriteRenderer.sortingOrder = 3;
        }

        if (lastDg.codeNumber == 1111)
        {
            pControl.horizontal = 0;
            pControl.enabled = false;
        }

        if (lastDg.codeNumber == 1112)
        {
            pControl.enabled = true;
        }
    }
}
