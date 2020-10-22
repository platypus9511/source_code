using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_Quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonQuit()
    {
        Application.Quit();
    }

    public void OnButtonBack()
    {
        Destroy(gameObject);
    }
}
