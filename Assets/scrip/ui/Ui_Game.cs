using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui_Game : MonoBehaviour
{
    public Canvas _canvas;

    public void Init(Canvas canvas)
    {
        _canvas = canvas;
    }
    

    public void OnButtonGame(GameObject buttonObj)
    {
        if (buttonObj.name == Common.BTN_NEWG)
        {
            SceneManager.LoadScene((int)SCENE.GAME);
            Time.timeScale = 1.0f;
        }

        if(buttonObj.name == Common.BTN_LOAD)
        {


        }
        if(buttonObj.name == Common.BTN_STAGE)
        {
            // 팝업 메시지 프리팹 로드
            GameObject stagePrefab = Resources.Load("UI/StagePopup") as GameObject;

            // 프리팹으로 부터 복사된 인스턴스 씬에 배치
            GameObject stagepopup = Instantiate(stagePrefab);

            // 캔버스의 자식 객체로 만들기
            stagepopup.transform.parent = _canvas.transform;
            RectTransform rect = stagepopup.GetComponent<RectTransform>();
            rect.anchoredPosition = Vector3.zero;
        }
        if(buttonObj.name == "back")
        {
            Destroy(gameObject);
        }
    }
}
