using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public SpriteRenderer _renderer;
    public Sprite switch3;
    public Sprite switch1;
    public Platform[] _platforms;
    public pipe[] _pipes;
    public Door[] _doors;


    public void Test()
    {
        for (int i = 0; i < _platforms.Length; i++)
            _platforms[i].PlatformTurnOn();
     

        for (int i = 0; i < _pipes.Length; i++)
            _pipes[i].pipeTurnOn();

        for (int i = 0; i < _doors.Length; i++)
            _doors[i].DoorOpen();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _renderer.sprite = switch3;
            SoundManager.Ins.Play("buttonsound");

            for (int i = 0; i < _platforms.Length; i++)
            {
                if (_platforms[i]) _platforms[i].PlatformTurnOn();              
            }
                       
            for (int i = 0; i < _pipes.Length; i++)
            {
                if (_pipes[i]) _pipes[i].pipeTurnOn();
            }

            
            for (int i = 0; i < _doors.Length; i++)
            {
                if (_doors[i]) _doors[i].DoorOpen();
            }
            
            
            
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _renderer.sprite = switch3;

            for (int i = 0; i < _platforms.Length; i++)
            {
                if (_platforms[i]) _platforms[i].PlatformTurnOn();
            }
            
            /*
            for (int i = 0; i < _doors.Length; i++)
            {
                if (_doors[i]) _doors[i].DoorOpen();              
            }
            */
            
        }
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _renderer.sprite = switch1;

            for (int i = 0; i < _platforms.Length; i++)
            {
                if (_platforms[i]) _platforms[i].PlatformTurnOff();
            }
       
            for (int i = 0; i < _pipes.Length; i++)
            {
                if (_pipes[i]) _pipes[i].pipeTurnOff();
            }

            
           for (int i = 0; i < _doors.Length; i++)
           {
               if (_doors[i]) _doors[i].DoorClose();
           }
           
                     
        }
    }    
}
