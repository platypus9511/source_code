using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class StageUi : MonoBehaviour
{
   


    public void Init()
    {
      
    }

   
    void Update()
    {
        
    }

    public void OnclickStage(GameObject buttonObj)
    {
        string str = Regex.Replace(buttonObj.name, @"\D", "");
        int stageNum = Convert.ToInt32(str);

        GameGlobal.Ins._selectedStage = stageNum;

        SceneManager.LoadScene((int)SCENE.GAME);
        //GameManager.Instance.Gonext(stageNum);

        if (buttonObj.name == "stg1")
        {
            
        }
        if(buttonObj.name == "stg2")
        {

        }
        if (buttonObj.name == "stg3")
        {
        }
        if (buttonObj.name == "stg4")
        {
        }
        if (buttonObj.name == "stg5")
        {
           
        }
        if (buttonObj.name == "stg6")
        {
           
        }
        if (buttonObj.name == "stg7")
        {
           
        }
        if (buttonObj.name == "stg8")
        {
           
        }
        if (buttonObj.name == "stg9")
        {
            
        }
        if (buttonObj.name == "stg10")
        {
           
        }


    }


    public void OnCancel()
    {
        Destroy(gameObject);
    }
}
