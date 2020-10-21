using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class test : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(testCo());
    }
  
    void Update()
    {
        
    }

    IEnumerator testCo()
    {
        Debug.Log("TestCo" + Time.time);
        yield return null;

        Debug.Log("TestCo" + Time.time);

        yield return new WaitForSeconds(1.0f);

        Debug.Log("TestCo" + Time.time);

        yield return new WaitForSeconds(5.0f);

        Debug.Log("TestCo" + Time.time);

    }
}
