using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finals : MonoBehaviour
{

    public GameObject player;
    public GameObject target;
    public GameObject FinalDialogue;
    public GameObject weapon;
    public PlayerControl playerControl;
    public Animator playerAnim;
    public bool isTp;
    public float speed;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        FinalDialogue.SetActive(false);
        playerControl=player.GetComponent<PlayerControl>();
        playerAnim=player.GetComponent<Animator>();
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > 68 && player.transform.position.x<78)
        { 
            playerAnim.SetInteger("animValue", 1);
            weapon.SetActive(false);
            playerControl.enabled = false;
            player.transform.position = Vector2.MoveTowards(player.transform.position, target.transform.position, speed * Time.deltaTime);

            float distance = Vector2.Distance(player.transform.position, target.transform.position);
            if (distance<=4.5f)
            {
                playerAnim.SetInteger("animValue", 0);
                FinalDialogue.SetActive(true);
            }
        }


            
        
    }
}
