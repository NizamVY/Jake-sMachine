using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurRunner : MonoBehaviour
{
    public GameObject finishPoint;
    public float speed;
    public PlayerControl playerControl;
    public GameObject player;
    public GameObject playerSkyPoint;
    public bool isSky=false;
    public float distance = 0f;
    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
       playerControl = player.GetComponent<PlayerControl>();
       speed = playerControl.runSpeed-1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSky&&distance<=7f && !dialogueManager.isDialogue)
        {
            transform.position = Vector2.MoveTowards(transform.position, finishPoint.transform.position, speed * Time.deltaTime);
        }
        else if(!isSky && !dialogueManager.isDialogue)
        { 
            transform.position = Vector2.MoveTowards(transform.position, finishPoint.transform.position, speed * Time.deltaTime);
        }

        if (isSky && !dialogueManager.isDialogue)
        {
            distance = Vector2.Distance(transform.position, playerSkyPoint.transform.position);
        }
        else if(!isSky && !dialogueManager.isDialogue)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
        }

        if (distance > 6f) 
        {
            speed = playerControl.runSpeed + 1.5f;
        }

        if (distance < 4f)
        {
            speed = playerControl.runSpeed - 1f;
        }
    }
}
