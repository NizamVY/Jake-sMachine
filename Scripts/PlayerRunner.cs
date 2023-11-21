using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunner : MonoBehaviour
{
    public PlayerControl pControl;
    public GameObject finishPoint;
    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        pControl = GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!dialogueManager.isDialogue)
        {

            if (dialogueManager.codeNumber == 1)
            {
                pControl.isRunner = true;
            }
            transform.position = Vector2.MoveTowards(gameObject.transform.position, finishPoint.transform.position, pControl.runSpeed * Time.deltaTime);
        }
        else 
        {
            pControl.isRunner = false;
        }
    }
}
