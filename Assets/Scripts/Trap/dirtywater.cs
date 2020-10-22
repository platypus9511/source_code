using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirtywater : MonoBehaviour
{
    public int _attack = 5;
    private BoxCollider2D _boxCol;



    void Start()
    {
        _boxCol = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        
    }
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            Char2D myChar2D = FindObjectOfType<Char2D>();
            myChar2D.OnDamage(_attack);
            //피격 이펙트

        }
    }
}
