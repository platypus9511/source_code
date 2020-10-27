using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class uiManager : MonoBehaviour
{
    [HideInInspector]
    public static uiManager _instance;
    public static uiManager Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = FindObjectOfType(typeof(uiManager)) as uiManager;
                if (null == _instance)
                {
                    Debug.LogError("Fail to get GameManager Instance");
                }
            }
            return _instance;
        }
    }

    public GameObject[] _uiList;
    public FixedJoystick _joystick;
    public FixedJoystick _rjoystick;


    GraphicRaycaster _raycaster;
    Char2D _Char;
    

    public void Init(GameObject player)
    {
        Hideall();

        Show("Ui_play", true);

        GameObject ui = null;
        Ui_base uiBase = null;
        for (int i = 0; i < _uiList.Length; i++)
        {
            ui = _uiList[i];
            uiBase = ui.GetComponent<Ui_base>();
            uiBase.Init();
        }

        _joystick.Init();
        _rjoystick.Init();
        _rjoystick.gameObject.SetActive(true);
        _joystick.gameObject.SetActive(false);

        _raycaster = GetComponent<GraphicRaycaster>();

        _Char = player.GetComponent<Char2D>();

        
    }

    public void Hideall()
    {
        GameObject ui = null;
        for(int i = 0; i < _uiList.Length; i++)
        {
            ui = _uiList[i];
            ui.SetActive(false);

        }

    }
 void Update()
    {
        
    }

    public void Show(string name, bool show)
    {
        Hideall();

        GameObject ui = null;

        for(int i = 0; i < _uiList.Length; i++)
        {
            ui = _uiList[i];

            if(ui.name == name)
            {
                Debug.Log("ui Show:" + ui.name + " on? " + show);
                ui.SetActive(show);
            }

        }

    }

    public void OnGameStar()
    {
        Show("Ui_play", true);      
    }

    public GameObject GetUI(string name)
    {
        GameObject ui = null;
        for (int i = 0; i < _uiList.Length; i++)
        {
            ui = _uiList[i];
            if (ui.name == name)
            {
                return ui;
            }
        }

        return null;
    }

    public void InitHp(int hp)
    {
        // play ui에 있는 hp text를 초기화
        GameObject ui = GetUI("Ui_play");
        if (ui != null)
        {
            Ui_play uiPlay = ui.GetComponent<Ui_play>();
            uiPlay.InitHp(hp);
        }

    }

    public void OnDamage(int hp)
    {
        // play ui에 있는 hp text 갱신
        GameObject ui = GetUI("Ui_play");
        if (ui != null)
        {
            Ui_play uiPlay = ui.GetComponent<Ui_play>();
            uiPlay.InitHp(hp);
        }
    }

    /*
    public void OnPortalButton()
    {
        _Char.FireProjectile();
    }
    */






    public void OnPointerDown()
    {
        _joystick.gameObject.SetActive(true);
        _joystick.transform.position = Input.mousePosition;


        PointerEventData data = new PointerEventData(EventSystem.current);
        data.position = Input.mousePosition;

        _joystick.OnPointerDown(data);
    }

    public void OnDrag()
    {
        PointerEventData data = new PointerEventData(EventSystem.current);
        data.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        bool uiTouched = false;
        _raycaster.Raycast(data, results);
        foreach (RaycastResult r in results)
        {
            if (r.gameObject.name == "Lefttoucharea" ||
                r.gameObject.name == "Handle" ||
                r.gameObject.name == "Fixed Joystick")
            {

            }
            else
            {
                uiTouched = true;
                Debug.Log("UI 요소가 드래그 되었습니다: " + r.gameObject.name);
            }
        }


        if (uiTouched == false) // 다른 ui가 터치되지 않았을 때만 캐릭터 이동하게 하기
            _joystick.OnDrag(data);
    }

    public void OnPointerUp()
    {
        _joystick.gameObject.SetActive(false);
        _joystick.OnPointerUp(null);
    }
}

