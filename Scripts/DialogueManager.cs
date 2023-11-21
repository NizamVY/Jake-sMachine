using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text sencenceText;

    private Queue<string> sentences;
    private Queue<string> names;
    public GameAction action;
    public Animator anim;
    public bool isDialogue;

    public PlayerControl pMovement;

    public int codeNumber;
    

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        pMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogue = true;
        codeNumber = 0;

        sentences.Clear();
        names.Clear();

        if (pMovement != null)
        {
            pMovement.enabled = false;
        }

        anim.SetBool("isOpen",true);

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (string name in dialogue.names) 
        { 
            names.Enqueue(name);
        }

        DisplayNextDialogue();
    }


    public void DisplayNextDialogue()
    { 
        if(sentences.Count == 0) 
        {
            FinishDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();

        nameText.text = name;
        StopAllCoroutines();
        StartCoroutine(CharbyChar(sentence));

    }

    IEnumerator CharbyChar(string sentence)
    {
        sencenceText.text = "";

        foreach (char c in sentence.ToCharArray())
        { 
            sencenceText.text += c;
            yield return new WaitForSeconds(0.015f);
        }
    }

    public void FinishDialogue() 
    {
        anim.SetBool("isOpen", false);
        codeNumber = 1;
        isDialogue = false;
    }
}
