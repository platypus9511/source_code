using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_Quit : MonoBehaviour
{
    public Canvas _canvas;

    public void Init(Canvas canvas)
    {
        _canvas = canvas;

        gameObject.transform.SetParent(_canvas.transform, false);
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
