using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ui_play : Ui_base
{
    public GameObject _mebuObj;
    public Text _hpText;



    public void InitHp(int hp)
    {
        _hpText.text = hp.ToString();
    }




    public override void OnButtonClick(GameObject buttonObj)
    {
       // base.OnButtonClick(buttonObj);

        if(buttonObj.name == Common.BTN_SETTING)
        {
            _mebuObj.SetActive(true);
            Time.timeScale = 0.0f;

        }

        if (buttonObj.name == Common.BTN_BACK)
        {
            _mebuObj.SetActive(false);
            Time.timeScale = 1.0f;
        }


        if (buttonObj.name == Common.BTN_TITTLE)
        {
            //타이틀로 이동
            SceneManager.LoadScene((int)SCENE.TITTLE);
        }

        if(buttonObj.name == Common.BTN_RESTART)
        {
            //리스폰
            GameManager.Instance.ResPawn();

            _mebuObj.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

   


}
