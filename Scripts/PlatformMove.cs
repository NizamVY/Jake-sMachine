using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Transform noktaB;
    public float hareketHizi = 3.0f;

    private Transform hedefNokta;

    public GameObject Player;

    void Start()
    {
        hedefNokta = noktaB;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector2.Distance(Player.transform.position, gameObject.transform.position);

        if(distance < 1.35f) 
        {
            transform.position = Vector2.MoveTowards(transform.position, hedefNokta.position, hareketHizi * Time.deltaTime);
        }
    }
}
