using System;
using UnityEngine;

public class cameraFollow : MonoBehaviour  
{
    public Transform _target;

   
    void Start()
    {
        
    }

   
    void Update()
    {
        Vector3 charpos = _target.position;

        float camZ = transform.position.z;
       transform.position = new Vector3(charpos.x, charpos.y, camZ);
    }  
}
