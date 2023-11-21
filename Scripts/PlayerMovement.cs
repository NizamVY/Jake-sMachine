using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer rb_sprite;

    float horizontal;
    float vertical;

    public float runSpeed = 6.0f;
    GameObject IksirObj;
    private int ToplananIKsir;
    public GameObject AcikKapi;
    public GameObject KapaliKapi;
    public Animator anim;
    public GameObject machine;


    public GameObject kirmizi;
    public GameObject mavi;
    public GameObject yeþil;
    public GameObject sari;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb_sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        machine.SetActive(false);

        kirmizi.SetActive(false);
        mavi.SetActive(false);
        yeþil.SetActive(false);
        sari.SetActive(false);
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal == -1)
        {
            rb_sprite.flipX = true;
            anim.SetInteger("animValue", 1);
        }
        else if (horizontal == 1)
        {
            rb_sprite.flipX = false;
            anim.SetInteger("animValue", 1);
        }

        if (vertical == -1)
        {
            anim.SetInteger("animValue", 4);
        }
        else if (vertical == 1)
        {
            anim.SetInteger("animValue", 3);
        }
        
        if (vertical == 0 && horizontal == 0)
        {
            anim.SetInteger("animValue", 0);

        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
    public void StopMovement()
    {
        rb.velocity = Vector2.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Iksir"))
        {
            ToplananIKsir++;
            IksirObj = collision.gameObject;
            IksirObj.SetActive(false);

            if (collision.name == "kirmizi_iksir")
            {
                kirmizi.SetActive(true);
            }

            if (collision.name == "yesil_iksir")
            {
                yeþil.SetActive(true);
            }

            if (collision.name == "sari_iksir (1)")
            {
                sari.SetActive(true);
            }

            if (collision.name == "mavi_iksir (1)")
            {
                mavi.SetActive(true);
            }

        }
        if (collision.CompareTag("Masa"))
        {
            if (ToplananIKsir >= 4 )
            {
                KapaliKapi.SetActive(false);
                AcikKapi.SetActive(true);
                machine.SetActive(true);
            }
            if (IksirObj != null)
            {
                IksirObj.SetActive(true);
                IksirObj.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y + 2.1f);
            }
        }

        if (collision.CompareTag("exit"))
        {
            SceneManager.LoadScene("ThirdScene");
        }
    }

    void StopRun()
    { 
        
    }
}