using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
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
