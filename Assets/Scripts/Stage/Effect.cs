using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    ParticleSystem _particle;
    float _delta = 0.0f;
    protected float _span = 0.0f;
    protected virtual void Start()
    {
        _particle = GetComponent<ParticleSystem>();
        _span = _particle.duration;
    }


    // Update is called once per frame
    void Update()
    {
        _delta += Time.deltaTime;
        if( _delta > _span)
        {
            Destroy(gameObject);
        }
    }
}
