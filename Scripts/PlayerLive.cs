using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLive : MonoBehaviour
{
    public float health;
    public float current;

    // Start is called before the first frame update
    void Start()
    {
        health = 150.0f;
        current = 150.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene("ThirdScene");
        }   
    }

    public  void canAzalt()
    { 
        health=health-5.0f;
    }
}
