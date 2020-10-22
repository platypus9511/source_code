using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry : Enemy
{
    Sentry_controller _con;

    public override void Init()
    {
        base.Init();

        _con = GetComponent<Sentry_controller>();
        _con.Init(this);

    }

    protected override void Update()
    {
        //base.Update();


    }
}
