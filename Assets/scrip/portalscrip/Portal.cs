using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal _pair;
    public GameObject _Portal;
    public Transform _SpawnPoint;
    public GameObject _player;
   // public GameObject _object;
    public bool _invertY = false;
    public bool _inbertX = false;
    public float _yspeed = 300.0f;
    public float _xspeed = 1f;
    private bool _right = true;


    public void Init(GameObject player)
    {
        _player = player;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CircleCollider2D)
        {
            if (_pair != null && _pair._nowWarp) return;

            if (_nowWarp) return;

            Debug.Log("트리거 엔터: " + gameObject.name);
            

               StartCoroutine(Warp());         
        }
    }


    [SerializeField]bool _nowWarp = false;
    IEnumerator Warp()
    {
        if (_nowWarp == false)
        {
            Debug.Log("워프 시작");

            _nowWarp = true;

            _player.transform.position = new Vector3(_SpawnPoint.position.x, _SpawnPoint.position.y, -3.0f);
          
            Debug.Log("위치 이동");

            yield return new WaitForSeconds(0.05f);
            Debug.Log("0.05초 대기");
            //yield return null;

            if (_invertY)
            {
                InvertY();
            }
            if (_inbertX)
            {
                InvertX();
            }
            Debug.Log("0.5초 대기");
            yield return new WaitForSeconds(0.5f);
            Debug.Log("워프 종료");

            _nowWarp = false;

        }
    }

    void InvertY()
    {
        Rigidbody2D rigid = _player.GetComponent<Rigidbody2D>();

        rigid.AddForce(new Vector2(0, _yspeed), ForceMode2D.Force);
        Debug.Log("AddForce Y: " + _yspeed + ", GameObject: " + gameObject.name);    
    }


    void InvertX()
    {
        Rigidbody2D rigid = _player.GetComponent<Rigidbody2D>();

        rigid.AddForce(new Vector2(_xspeed, 0), ForceMode2D.Force);
        Debug.Log("AddForce Y: " + _xspeed + ", GameObject: " + gameObject.name);
    }

}
