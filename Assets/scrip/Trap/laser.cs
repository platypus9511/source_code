using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    SpriteRenderer _renderer;
    BoxCollider2D _boxcoll;
    
    
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();   
        _boxcoll = GetComponent<BoxCollider2D>();

        
        StartCoroutine(_LaserTurnOff());
    }


    void Update()
    {

        
       
    }

    IEnumerator _LaserTurnOff()
    {
        while (true)
        {
            _renderer.enabled = true;
            _boxcoll.enabled = true;
            yield return new WaitForSeconds(2.0f);
            _renderer.enabled = false;
            _boxcoll.enabled = false;
            yield return new WaitForSeconds(1.0f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            if (collision is CircleCollider2D) return;
            {
                Char2D player = collision.gameObject.GetComponent<Char2D>();
                player.OnDamage(1);
            }
        }
    }

}
