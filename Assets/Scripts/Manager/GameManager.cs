using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
                if (null == _instance)
                {
                    Debug.LogError("Fail to get GameManager Instance");
                }
            }
            return _instance;
        }
    }

    public GameObject[] _startPointList;
    public GameObject _player;
    public GameObject _camera;
    public Vector2[] _camposlist;
    public int _curStage = 1;
    public List<Enemy> _enemies;

    public GameObject _teleports;
    public TrapManager _trapMgr;
    public cube _cube;
    

    public void Init(GameObject player)
    {
        _curStage = 1;
        _player = player;
        foreach (Enemy e in _enemies)
            e.Init();

        Portal[] teleportList = _teleports.GetComponentsInChildren<Portal>();
        foreach (Portal p in teleportList)
            p.Init(_player);


        _trapMgr.Init(_player);



       int stageNum = GameGlobal.Ins._selectedStage;
        Gonext(stageNum);
    }

    public void OnDie(Enemy enemy)
    {
        _enemies.Remove(enemy);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Gonext(int stageNum)
    {
        GameObject startPoint = _startPointList[stageNum -1];

        Vector3 pos = startPoint.transform.position;
        Vector3 camPos = _camera.transform.position;

        _player.transform.position = new Vector3(pos.x, pos.y, pos.z);

        Vector2 newCamPos = _camposlist[stageNum -1];

        _camera.transform.position = new Vector3(pos.x+ newCamPos.x, pos.y+ newCamPos.y, camPos.z);

        _curStage++;
    }
    public void ResPawn()
    {
       
        GameObject spawnPoint = _startPointList[_curStage -1] ;
        Vector3 newpos = spawnPoint.transform.position;
        Vector3 charpos = _player.transform.position;  
       _player.transform.position = new Vector3(newpos.x, newpos.y, charpos.z);


        Char2D playerCher = _player.GetComponent<Char2D>();
        playerCher.InitHP();

        // playerChar.

        uiManager.Instance.Show("Ui_play", true);
           
        Rigidbody2D rigid = _player.GetComponent<Rigidbody2D>();
        rigid.bodyType = RigidbodyType2D.Dynamic;    
        

    }

    public void MoveStartPoint(int stageNum)
    {
        GameObject startPoint = _startPointList[stageNum - 1];
        Vector3 pos = startPoint.transform.position;
        Vector3 camPos = _camera.transform.position;
        Vector2 newCamPos = _camposlist[stageNum - 1];
        _camera.transform.position = new Vector3(pos.x + newCamPos.x, pos.y + newCamPos.y, camPos.z);
        _player.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

    
}
