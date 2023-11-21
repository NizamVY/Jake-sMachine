using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBullet : MonoBehaviour
{

    public GameObject player;
    public PlayerLive pLive;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pLive = player.GetComponent<PlayerLive>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            pLive.canAzalt();
        }
    }
}
