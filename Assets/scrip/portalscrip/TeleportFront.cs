using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
public class TeleportFront : MonoBehaviour
{
    public Vector2 _direction = Vector2.zero;

    public Tilemap _tilemap;
    public bool PlayerInPortal
    {
        get { return _playerInPortal; }
        set { _playerInPortal = value; }
    }
    private bool _playerInPortal = false;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CircleCollider2D)
        {         
            if (_playerInPortal == false && collision.gameObject.name == "player")
            {
                _tilemap.gameObject.layer = LayerMask.NameToLayer("NonCollision");               
                Teleport tele = transform.parent.GetComponent<Teleport>();
                TeleportFront pairFront = tele._pair.GetComponentInChildren<TeleportFront>();
                pairFront.PlayerInPortal = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision is CircleCollider2D)
        {           
            if (_playerInPortal == true && collision.gameObject.name == "player")
            {
                _tilemap.gameObject.layer = LayerMask.NameToLayer("tile");
                _playerInPortal = false;
                // 부모객체에 있는 Teleport의 boxCollider2D enabled 다시 true
                transform.parent.GetComponent<BoxCollider2D>().enabled = true;              
            }
            
            if( _playerInPortal == false && transform.parent.GetComponent<BoxCollider2D>().enabled )
            {
                Collider2D thisCol = GetComponent<BoxCollider2D>();
                Vector2 dir = collision.Distance(thisCol).normal;
                Debug.Log(dir);
                if( (dir == Vector2.left && _direction == Vector2.right) ||
                    (dir == Vector2.right && _direction == Vector2.left) ||
                    (dir == Vector2.down && _direction == Vector2.up) ||
                    (dir == Vector2.up && _direction == Vector2.down) 
                )
                {
                    _tilemap.gameObject.layer = LayerMask.NameToLayer("tile");
                }
            }
        }
    }
}
