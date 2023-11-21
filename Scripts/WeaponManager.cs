using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerHandRight;
    public GameObject playerHandLeft;
    public GameObject player;
    public SpriteRenderer playerSpR;
    public bool isFire;

    public GameObject GunPivot;
    public GameObject blasterPrefab;

    public Bullet bulletScript;
    public float fireTimer;
    public float fireRepeat;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpR = player.GetComponent<SpriteRenderer>();
        isFire = false;
        fireTimer = 0;
        fireRepeat = 1;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer -= Time.deltaTime;

        float distance = Vector2.Distance(gameObject.transform.position,player.transform.position);

        if (distance <= 1.5f && !playerSpR.flipX)
        { 
            gameObject.transform.position=playerHandRight.transform.position;
            gameObject.GetComponent<SpriteRenderer>().flipX=false;
            isFire = true;
        }

        if(distance <= 1.5f && playerSpR.flipX)
        {
            gameObject.transform.position = playerHandLeft.transform.position;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            isFire = true;
        }

        if (fireTimer <= 0f)
        {
            if (isFire && Input.GetMouseButtonDown(0))
            {
                GameObject bullet = Instantiate(blasterPrefab, GunPivot.transform.position, GunPivot.transform.rotation);
                fireTimer = fireRepeat;
            }
        }
        


    }
}
