using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    public Animator _anim;
    public SpriteRenderer _renderer;
    public Sprite _cube1;
    public Sprite _cube2;
    public bool _grab = false;

    
    
    void Start()
    {
        _grab = false;
        
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "switch1")
        {
            _renderer.sprite = _cube2;
            
        
        }
       
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "switch1")
        {
            _renderer.sprite = _cube1;
        }
       
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "laser")
        {
            gameObject.GetComponent<Animator>().enabled = true;

            _anim.SetTrigger("destroy");


            Destroy(gameObject,0.7f);
            TrapManager.Instance.OnErase(this);            
        }
    }
}
