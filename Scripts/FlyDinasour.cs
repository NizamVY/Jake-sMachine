using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyDinasour : MonoBehaviour
{
    public GameObject finishPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, finishPoint.transform.position, 6 * Time.deltaTime);
    }
}
