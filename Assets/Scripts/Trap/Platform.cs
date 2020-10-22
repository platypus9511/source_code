using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Platform : MonoBehaviour
{
     
    public Switch _switch;
    public Animator _anim;
   // bool _turnedOn = false;
   
 
    void Update()
    {
       
    }

    public void PlatformTurnOn()
    {
        _anim.SetBool("up", true);
        
        /*
        if (_turnedOn) return;
        {
           _platformhead.transform.Translate(new Vector2(0, 1.15f));
           //_turnedOn = true;
        }
        */
    }
   
    public void PlatformTurnOff()
    {
        _anim.SetBool("up", false);  
        
    }
   
  
    

    

}
