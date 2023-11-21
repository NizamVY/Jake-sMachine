using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdGameInfoSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ThirdGameInfoClose");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ThirdGameInfoClose()
    {
        yield return new WaitForSeconds(8f);
        gameObject.SetActive(false);
    }
}
