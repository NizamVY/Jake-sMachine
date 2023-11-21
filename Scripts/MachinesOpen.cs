using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinesOpen : MonoBehaviour
{
    public GameObject machinesLeft;
    public GameObject machinesRight;
    public DialogueManager dialogueManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueManager.codeNumber==1)
        {
            machinesLeft.SetActive(true);
            StartCoroutine("NewMachines");

        }
    }

    IEnumerator NewMachines()
    {
        yield return new WaitForSeconds(0.5f);
        machinesRight.SetActive(true);
    }
}
