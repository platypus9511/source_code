using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour
{
    public FixedJoystick _rjoystick;
    float _angel;
    Vector2 _targer, _mouse;
    //bool _right = true;
    void Start()
    {
        _targer = transform.position;
    }

    
    void Update()
    {
        MouseRotation();

    }

    public void MouseRotation()
    {
        float h = _rjoystick.Horizontal;
        float v = _rjoystick.Vertical;
        //Debug.Log("h " + h);
        //Debug.Log("v" + v);

        
        _angel = Mathf.Atan2(v, h) * Mathf.Rad2Deg;

        //_mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //_angel = Mathf.Atan2(_mouse.y - _targer.y, _mouse.x - _targer.x) * Mathf.Rad2Deg;
        // Debug.Log("angle: " + _angel);

        //float mousePosX = _mouse.x;
        //float playerPosX = transform.position.x;
        //if( mousePosX < playerPosX )
        if( h < 0 )
        {
            if (Char2D.Ins.Right == true)
                Char2D.Ins.Flip(false);
        }
        //if( playerPosX < mousePosX )
        if( h > 0 )
        {
            if (Char2D.Ins.Right == false)
                Char2D.Ins.Flip(true);
        }
            
        float _limitAngle = 45.0f;

        
        if(_limitAngle < _angel && _angel < 180 - _limitAngle ||
            -1 * (180-_limitAngle) < _angel && _angel < -1 * _limitAngle )
        {

        }
        else
        {
            

            if( Char2D.Ins.Right == false && 
                (( (180 - _limitAngle) <= _angel && _angel <= 180) ||
                  (-1 * (180 - _limitAngle) >= _angel && _angel >= -180))
            )
            {
                transform.rotation = Quaternion.AngleAxis(_angel + 90, Vector3.forward);
            }


            if( Char2D.Ins.Right && _limitAngle > _angel && _angel > -1 * _limitAngle
            )
            {
                transform.rotation = Quaternion.AngleAxis(_angel + 90, Vector3.forward);
            }


        }

        
    }
}
