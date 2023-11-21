using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsFinish : MonoBehaviour
{

    public GameObject finishPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(gameObject.transform.position, finishPoint.transform.position);

        if (distance<=2.0f)
        { 
            SceneManager.LoadScene("SecondGame");
        }
    }
}
