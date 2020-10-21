using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameGlobal : MonoBehaviour
{
    [HideInInspector]
    public static GameGlobal _instance;
    public static GameGlobal Ins
    {
        get
        {
            if (null == _instance)
            {
                _instance = FindObjectOfType(typeof(GameGlobal)) as GameGlobal;
                if (null == _instance)
                {
                    Debug.LogError("Fail to get GameGlobal Instance");
                }
            }
            return _instance;
        }
    }

    public AudioSource[] _bgmList;
    public int _selectedStage;
    public int _stageNum = 1;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        //_bgmList[(int)SCENE.TITTLE].Play();

        SceneManager.sceneLoaded += OnSceneLoaded;

        _stageNum = 1;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        foreach (AudioSource a in _bgmList)
            a.Stop();

        if(scene.name == "GameScene")
        {
           //_bgmList[(int)SCENE.GAME].Play();
           if(_selectedStage != 0)
            {
                GameManager.Instance._curStage = _stageNum;    
            }
        }
    }
}
