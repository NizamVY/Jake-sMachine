using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDialgue : MonoBehaviour
{

    public GameObject stoppedPlace;
    public GameObject nounPlace;
    public GameObject player;
    public GameObject lastDialgue;
    public DialogueManager dialogueManager;
    public DialogueController dialogueController;
    public PlayerControl playerControl;
    public bool isDial;
    public bool isTouch;

    public int codeNumber;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl=player.GetComponent<PlayerControl>();
        dialogueController = lastDialgue.GetComponent<DialogueController>();
        isDial = false;
        isTouch = false;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position,stoppedPlace.transform.position);


        if (distance <= 0.2f && !isDial)
        {
            codeNumber = 1111;
            lastDialgue.SetActive(true);
            dialogueController.enabled = true;
        }

        if (lastDialgue.activeSelf && dialogueManager.codeNumber==1)
        {
            codeNumber = 1112;
        }
    }
}
