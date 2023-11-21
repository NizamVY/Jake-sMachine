using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActiveted : MonoBehaviour
{

    public GameObject platform;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        platform.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, gameObject.transform.position);

        if (distance <= 1f)
        { 
            platform.SetActive(true);
        }
    }
}
