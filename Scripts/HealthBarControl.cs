using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarControl : MonoBehaviour
{
    public Image healthBarImage;
    public GameObject player;
    public PlayerLive pLive;
    public float healthValue;
    public float currentValue;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pLive=player.GetComponent<PlayerLive>();
    }

    // Update is called once per frame
    void Update()
    {

        currentValue = pLive.current;
        healthValue = pLive.health;
        healthBarImage.fillAmount = healthValue / currentValue;

    }
}
