using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_gameOver : Ui_base
{
    public override void OnButtonClick(GameObject buttonObj)
    {
        base.OnButtonClick(buttonObj);


        if (buttonObj.name == "restart")
        {
           
            if (_gameMgr != null)
            {
                _gameMgr.ResPawn();

            }
           
        }

    }
}
