using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject _bullet;
    public Transform _pos;
    public float _cooltime;
    private float _curtime; 


    void Update()
    {
        ///Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, z);

        if(_curtime <= 0)
        {
            if(Input.GetKey(KeyCode.Z))
            {
                Instantiate(_bullet, _pos.position, transform.rotation);
            }
            _curtime = _cooltime;
        }
      
        _curtime -= Time.deltaTime;
    }
}
