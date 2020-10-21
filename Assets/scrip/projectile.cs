using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : Effect
{
    protected Rigidbody2D _rigid;
    public float _flyForce = 100.0f;
    Vector2 _dirNormal = Vector2.zero;
    

    protected override void Start()
    {
        base.Start();

        _rigid = GetComponent<Rigidbody2D>();
        Fire();
        _span = 1.0f;
    }

    public void Init(Vector2 dirNoraml)
    {
        _dirNormal = dirNoraml;
    }

    public void Fire()
    {

        //Vector2 flyForce = new Vector2(_flyForce, 0);
        Vector2 flyForce = _dirNormal * _flyForce;

        _rigid.AddForce(flyForce);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {        
            Destroy(gameObject);

            /*
            GameObject PortalPrefab = Resources.Load("Blue") as GameObject;
            GameObject portal = Instantiate(PortalPrefab);
            */
            
        }
    }

}
