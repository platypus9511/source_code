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
   // public AudioSource _doorclosed;

    
    public void Start()
    {
      _anim = GetComponent<Animator>();
      _boxcoll= GetComponent<BoxCollider2D>();
    }
   

    public void DoorOpen()
    {
    
         //   _anim.SetBool("open", false);
         //   _boxcoll.enabled = false;

        
        foreach (Switch s in _switch)
        {
            if (s == true)
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
     
   
    public void DoorClose()
    {
       
        // _anim.SetBool("open", true);
        // _boxcoll.enabled = true;

        
        foreach (Switch s in _switch)
        {
            if (s == false)
            {
                --_switchCount;

                if (_switchCount < _switchCountMax)
                {
                    _anim.SetBool("open", false);
                    _boxcoll.enabled = true;
                }

                
            }

            //_switchCount--;
        }   
    }    

    public void OnDoorOpen()
    {
        _dooropen.Play();
    }

    public void OnDoorClosed()
    {

    }
}
