using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScene : MonoBehaviour
{
    public GameObject _playerPrefab;
    public GameObject _startPoint;
    public FixedJoystick _joystick;
    public FixedJoystick _rjoystick;

    protected GameObject _player;


     void Start()
    {
        Init();    
    }
    
    public virtual void Init()
    {
        InitGameGlobal();

        if( this is TittleScene)
        {
           
        }
        else
        {
            InitPlayer();
        }

        Time.timeScale = 1.0f;
    }

    void InitGameGlobal()
    {
        GameObject gameGlobalObj = GameObject.Find("GameGlobal");
        if(gameGlobalObj == null)
        {
            GameObject gameGlobalPrefab = Resources.Load("GameGlobal") as GameObject;
            gameGlobalObj = Instantiate(gameGlobalPrefab);
            gameGlobalObj.name = "GameGlobal";
        }
    }


    void InitPlayer()
    {
        GameObject player = GameObject.Find("player");
        if(player == null)
        {
            GameObject p = Instantiate(_playerPrefab);
            p.name = "player";

            player = p;

            _player = player;
        }

        if(player == null)
        {
            Debug.LogError("player == null");
        }

        Vector3 startPos = _startPoint.transform.position;
        player.transform.position = new Vector3(startPos.x, startPos.y, startPos.z);

        control userControl = player.GetComponent<control>();
        userControl._joystick = _joystick;       

        Debug.Log("moveForce :" + userControl.MoveForce);
        userControl.MoveForce = 10.0f;



        TestRotation rotationControl = player.GetComponentInChildren<TestRotation>();
        rotationControl._rjoystick = _rjoystick;
        
    }
}
