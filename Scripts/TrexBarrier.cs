using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrexBarrier : MonoBehaviour
{
    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barrier")) 
        {
            collision.gameObject.GetComponent<Animator>().enabled=true;
        }
    }
}
