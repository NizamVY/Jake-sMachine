using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTextSetActive : MonoBehaviour
{
    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueManager.codeNumber == 1)
        {
            StartCoroutine("InfoSetClose");
        }
    }

    IEnumerator InfoSetClose()
    { 
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
