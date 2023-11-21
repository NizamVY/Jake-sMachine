using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robots : MonoBehaviour
{
    public Animator anim1;
    public Animator anim2;
    public GameObject player;

    public float fireTimer;
    public float fireRepeat;

    public GameObject GunPivot;
    public GameObject blasterPrefab;

    public bool isActive;

    public float speed;
    public SpriteRenderer spRenderer;
    public bool isWalk;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fireTimer = 0;
        fireRepeat = 1.5f;
        isActive = true;
        spRenderer=gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            float distance = Vector2.Distance(gameObject.transform.position, player.transform.position);

            if (distance > 10f && distance < 25f)
            {
                if (!isWalk)
                {
                    gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, speed);
                }

                anim1.SetBool("Walk", true);
                anim1.SetBool("Fire", false);
            }
            else if (distance < 10f)
            {
                gameObject.transform.position = gameObject.transform.position;
                anim1.SetBool("Walk", false);
                anim1.SetBool("Fire", true);
            }

            fireTimer -= Time.deltaTime;
        }
        else
        {
            anim1.SetBool("Walk", false);
            anim1.SetBool("Fire", false);
            anim1.SetBool("Disable", true);
            anim2.SetBool("Disable", true);
            StartCoroutine(Wait());
        }

        if (gameObject.transform.position.x < player.transform.position.x)
        {
            spRenderer.flipX = false;
        }
        else 
        {
            spRenderer.flipX = true;
        }


    }

    public void Fire() 
    {
        if (fireTimer <= 0f)
        {
            GameObject bullet = Instantiate(blasterPrefab, GunPivot.transform.position, GunPivot.transform.rotation);

            if (spRenderer.flipX)
            {
                bullet.gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * -12;
            }
            else 
            {
                bullet.gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * 12;
            }
            
            fireTimer = fireRepeat;
        }
    }

    IEnumerator Wait() 
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
