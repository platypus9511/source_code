using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_OptionPopUp : MonoBehaviour
{
    public Canvas _canvas;

    public void Init(Canvas canvas)
    {
        _canvas = canvas;

        gameObject.transform.SetParent(_canvas.transform, false);
    }


    public void OnButtonOption()
    {
        Destroy(gameObject);
    }
}
