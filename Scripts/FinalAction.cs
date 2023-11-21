using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalAction : MonoBehaviour
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
            StartCoroutine(WaitGameOver());
        }
    }

    IEnumerator WaitGameOver()
    { 
        yield return new WaitForSeconds(5.5f);
        SceneManager.LoadScene("GAMEOVER");

    }
}
