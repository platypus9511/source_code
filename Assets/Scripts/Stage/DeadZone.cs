using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            Char2D character = collision.gameObject.GetComponent<Char2D>();
            character.Ondie();

            Rigidbody2D rigid = collision.gameObject.GetComponent<Rigidbody2D>();
            rigid.bodyType = RigidbodyType2D.Static;

        }
    }
}
