using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlActive : MonoBehaviour
{
    public DialogueManager manager;
    public PlayerControl pControl;

    void Start()
    {
        pControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.codeNumber == 1)
        {
            pControl.enabled = true;
        }
    }
}
