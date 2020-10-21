using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    [HideInInspector]
    public static TrapManager _instance;
    public static TrapManager Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = FindObjectOfType(typeof(TrapManager)) as TrapManager;
                if (null == _instance)
                {
                    Debug.LogError("Fail to get TrapManager Instance");
                }
            }
            return _instance;
        }
    }
    

    [SerializeField]private float _sight = 1.5f;
    public Char2D _player;
    public control _con;
    public List<cube> _cubes = new List<cube>();
   

    public void Init(GameObject player)
    {
        _player = player.GetComponent<Char2D>();
        _con = player.GetComponent<control>();
        
        
    }
    void Update()
    {
       
    }

    public void CheckNearPlayer()
    {
        if(_player != null)
        {
            //float playerPosX = _player.transform.position.x;

            foreach (cube c in _cubes)
            {
                if( c._grab == false )
                {
                    //float cubePosX = c.transform.position.x;
                    //float distance = Mathf.Abs(playerPosX - cubePosX);

                    Vector2 cubePos = c.transform.position;
                    Vector2 playerPos = _player.transform.position;
                    float distance = (cubePos - playerPos).magnitude;

                    if (distance <= _sight)
                    {
                        c._grab = true;
                        Debug.Log("닿았습니다: " + c.gameObject.name);
                        _con.Grab(c.gameObject);
                        break;
                    }
                   
                   
                    
                  
                }
                
            }            
        }
    } 
    

    public void OnErase(cube cubes)
    {
        _cubes.Remove(cubes);
    }
}
