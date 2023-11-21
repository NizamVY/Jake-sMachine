using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Image healtBar;
    public PlayerLive pLive;
    public float currentHealt;
    public float maxHealth=150f;

    // Start is called before the first frame update
    void Start()
    {
        pLive=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLive>();
        healtBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealt = pLive.health;
        healtBar.fillAmount = currentHealt / maxHealth;
    }
}
