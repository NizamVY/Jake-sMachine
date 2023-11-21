using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    public SpriteRenderer playerSpR;
    public int direction;
    public bool isFlip;
    public Robots rbts;


    // Start is called before the first frame update
    void Start()
    {
        rb=gameObject.GetComponent<Rigidbody2D>();  
        playerSpR = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        isFlip = playerSpR.flipX;
    }

    // Update is called once per frame
    void Update()
    {

        if (isFlip)
        {
            direction = -1;
        }
        else 
        {
            direction = 1;
        }
        

        rb.velocity=(transform.right*speed)*direction;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag=="Enemy")
        {
            collision.gameObject.GetComponent<Robots>().isActive = false;
            Destroy(gameObject);
        }
    }
}
