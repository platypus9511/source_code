using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleport : MonoBehaviour {

    public GameObject _Portal;
    public GameObject _player;
    public bool _invertY = false;
    public bool _inbertX = false;
    public float _yspeed = -100.0f;
    public float _xspeed = 1f;
    public Transform _teleportpoint;
    public Teleport _pair;



    public void Init (GameObject player)
    {
        _player = player;
        
	}

	void Update ()
    {
		
	}

    bool _nowWarp = false;
    IEnumerator Warp()
    {
        if (_nowWarp == false)
        {
            _nowWarp = true;

            _player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

            //_cube.GetComponent<SpriteRenderer>().enabled = false;

            yield return new WaitForSeconds(0.2f);
            //yield return null;

            _player.transform.position = new Vector3(_teleportpoint.position.x, _teleportpoint.position.y, -3);

            _player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

           // _cube.GetComponent<SpriteRenderer>().enabled = true;

            //Debug.Log("TELEPORT");
            if (_invertY)
            {
                InvertY();         
            }
            if (_inbertX)
            {
                InvertX();
            }

            yield return new WaitForSeconds(0.1f);

            _nowWarp = false;
            //player.layer = LayerMask.NameToLayer("Player");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CircleCollider2D) return;
        if (_nowWarp) return;
        // _pair의 boxCollider2D를 enabled , false로
        _pair.GetComponent<BoxCollider2D>().enabled = false;

        if (Vector2.Distance(transform.position, collision.transform.position) > 0.2f)
        {
            StartCoroutine( Warp() );

           // StartCoroutine(ObjectWarp());
        }
    }

    void InvertY()
    {
        Rigidbody2D rigid = _player.GetComponent<Rigidbody2D>();

        rigid.AddForce(new Vector2(0,_yspeed),ForceMode2D.Force);
        Debug.Log("AddForce Y: " + _yspeed + ", GameObject: " + gameObject.name);
        //Vector3 vel = rigid.velocity;
        //vel.y *= -1;
        //rigid.velocity = vel;
    }


    void InvertX()
    {
        Rigidbody2D rigid = _player.GetComponent<Rigidbody2D>();

        rigid.AddForce(new Vector2(-1, 0));
        //Vector3 vel = rigid.velocity;
        //vel.x *= -1;
        //rigid.velocity = vel;
    }
}
