using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldiersControll : MonoBehaviour
{
    public GameObject soldier1;
    public GameObject soldier2;
    public GameObject soldier3;

    public Animator soldierAnim1;
    public Animator soldierAnim2;
    public Animator soldierAnim3;

    public SpriteRenderer soldierSprit1;
    public SpriteRenderer soldierSprit2;
    public SpriteRenderer soldierSprit3;

    public MeteorFalling mFalling;

    public PlayerControl pController;
    public GameObject soldierFollowPoint;
    void Start()
    {
        pController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

        soldierAnim1=soldier1.GetComponent<Animator>();
        soldierAnim2=soldier2.GetComponent<Animator>();
        soldierAnim3=soldier3.GetComponent<Animator>();

        soldierSprit1=soldier1.GetComponent<SpriteRenderer>();
        soldierSprit2=soldier2.GetComponent<SpriteRenderer>();
        soldierSprit3=soldier3.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position,soldierFollowPoint.transform.position,pController.runSpeed);

        if (gameObject.transform.position.x>=1f)
        {
            soldier1.GetComponent<SpriteRenderer>().sortingOrder = 2;
            soldier2.GetComponent<SpriteRenderer>().sortingOrder = 2;
            soldier3.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }

        if (pController.horizontal != 0f)
        {
            soldierAnim1.SetBool("isRun", true);
            soldierAnim2.SetBool("isRun", true);
            soldierAnim3.SetBool("isRun", true);
            
        }
        else 
        {
            soldierAnim1.SetBool("isRun", false);
            soldierAnim2.SetBool("isRun", false);
            soldierAnim3.SetBool("isRun", false);
        }

        if (pController.horizontal < 0)
        {
            soldierSprit1.flipX = true;
            soldierSprit2.flipX = true;
            soldierSprit3.flipX = true;
        }
        else
        {
            soldierSprit1.flipX = false;
            soldierSprit2.flipX = false;
            soldierSprit3.flipX = false;
        }
    }
}
