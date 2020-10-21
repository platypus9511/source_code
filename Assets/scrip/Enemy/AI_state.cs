using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIStateID
{
    NONE = -1,
    IDLE = 0,
    ATTACK,
}



public class AI_state : MonoBehaviour
{
    protected Enemy _owner;
    protected Animator _anim;
    protected Char2D _player;
    protected Sentry_controller _con;

    public virtual void Init(Enemy owner)
    {
        _owner = owner;
        _con = _owner.GetComponent<Sentry_controller>();
        _anim = owner.GetComponent<Animator>(); //owner의 Animator를 가져옴
        GameObject playerObj = GameManager.Instance._player;
        _player = playerObj.GetComponent<Char2D>();

        Debug.Log("스테이트 초기화 :" + GetType().ToString());
    }

    protected virtual void OnEnable()
    {

    }

    protected virtual void OnDisable()
    {

    }



    public virtual void Update()
    {

    }
}
