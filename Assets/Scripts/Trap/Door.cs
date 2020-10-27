using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    public Switch[] _switch;
    public Animator _anim;
    BoxCollider2D _boxcoll;
    public int _switchCount = 0;
    public int _switchCountMax = 1;
    public AudioSource _dooropen;
    public AudioSource _doorclosed;
   

    
    public void Start()
    {
      _anim = GetComponent<Animator>();
      _boxcoll= GetComponent<BoxCollider2D>();
    }
   

    public void DoorOpen(Switch turnedOnSwitch)
    {
                
        foreach (Switch s in _switch) //  s 는 객체이므로 bool값가 비교할 수 없음
                                      //  하지만 객체가 존재할때는 true로 인식되어 작동은 할 수 있지만 
                                      // 좋은 방법은 아님 bool값을 비교할때는 bool값끼리
        {
            if (s.Equals(turnedOnSwitch)) 
            {
                ++_switchCount;            
                //_switchCount++;

                if (_switchCount >= _switchCountMax) 
                {
                    
                    _anim.SetBool("open", true);
                    _boxcoll.enabled = false;
                }
              
            }

        }         
    }
     
   
    public void DoorClose(Switch turnedOffSwitch)
    {
                  
        foreach (Switch s in _switch)
        {
            if ( s.Equals( turnedOffSwitch) )
            {
                --_switchCount;

                if (_switchCount < _switchCountMax)
                {
                    _anim.SetBool("open", false);
                    _boxcoll.enabled = true;
                }

                
            }
        }   
    }    

    public void OnDoorOpen()
    {
        _dooropen.Play();
    }

    public void OnDoorClosed()
    {
        _doorclosed.Play();
    }
}
