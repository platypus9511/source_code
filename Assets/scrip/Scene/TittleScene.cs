using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum StageType
{
   STAGE_1 = 0,
   STAGE_2 = 1,
   STAGE_3 = 2,
   STAGE_4 = 3,
   STAGE_5 = 4,
   STAGE_6 = 5,
   STAGE_7 = 6,
   STAGE_8 = 7,
   STAGE_9 = 8,
   STAGE_10 = 9,
}
public class TittleScene : BaseScene
{
    public Canvas _canvas;

    public override void Init()
    {
        base.Init();
    }

    public void OnclickGame(GameObject buttonObj)
    {
        if (buttonObj.name == Common.BTN_GAME)
        {
            // 팝업 메시지 프리팹 로드
            GameObject gamePrefab = Resources.Load("UI/GamePopup") as GameObject;

            // 프리팹으로 부터 복사된 인스턴스 씬에 배치
            GameObject gamepopup = Instantiate(gamePrefab);

            Ui_Game uiGame = gamepopup.GetComponent<Ui_Game>();
            uiGame.Init(_canvas);
            // 캔버스의 자식 객체로 만들기
            gamepopup.transform.parent = _canvas.transform;



            RectTransform rect = gamepopup.GetComponent<RectTransform>();
            rect.anchoredPosition = Vector3.zero;

            
        }
        if (buttonObj.name == Common.BTN_OPTION)
        {
            // 팝업 메시지 프리팹 로드
            GameObject optionPrefab = Resources.Load("UI/OptionPopup") as GameObject;

            // 프리팹으로 부터 복사된 인스턴스 씬에 배치
            GameObject optionpopup = Instantiate(optionPrefab);

            // 캔버스의 자식 객체로 만들기
            optionpopup.transform.parent = _canvas.transform;
            RectTransform rect = optionpopup.GetComponent<RectTransform>();
            rect.anchoredPosition = Vector3.zero;
        }
        /*
        if(buttonObj.name == Common.BTN_LOAD)
        {
           // Char2D.Ins.OnApplicationQuit();
        }
        */
        if(buttonObj.name == Common.BTN_QUIT)
        {
            // 팝업 메시지 프리팹 로드
            GameObject stagePrefab = Resources.Load("UI/QuitPopup") as GameObject;

            // 프리팹으로 부터 복사된 인스턴스 씬에 배치
            GameObject stagepopup = Instantiate(stagePrefab);

            // 캔버스의 자식 객체로 만들기
            stagepopup.transform.parent = _canvas.transform;
            RectTransform rect = stagepopup.GetComponent<RectTransform>();
            rect.anchoredPosition = Vector3.zero;
        }

    }

   
}

