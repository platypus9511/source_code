using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    public float _speed;
    public float _desPoint;
    public float _origPoint;
    private bool _right = true;
   


   

    
    void Update()
    {
        MovingEnergyball();


    }

    public void MovingEnergyball()
    {
        Vector3 pos = transform.localPosition;

        float move = Time.deltaTime * _speed;

        if (_right)
            move = move * 1;
        else
            move = move * -1;

        transform.Translate(new Vector3(move, 0, 0));

        pos = transform.localPosition;

        if (pos.x > _desPoint)
        {
            _right = false;
        }
        if (pos.x <= _origPoint)
        {
            _right = true;

        }
    }

   
}
