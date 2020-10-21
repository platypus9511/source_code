using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemyData : CharacterData
{
    public string _name;

    // 적의 공격력
    public int _attack = 10;

    // 적의 스피드
    public float _speed = 0.3f;
}



public class Enemy : Character
{
    public EnemyData _data;

    public override CharacterData Data
    {
        get { return _data; }
    }


    public float _destPoint;    // 목적지(오른쪽)
    public float _origPoint;    // 시작점(현재 박쥐가 있는 위치)
    protected bool _right = true;

    public GameObject _effectPrefab;
    protected Animator _anim;
    protected BoxCollider2D _boxCol;




    // Start is called before the first frame update
    public virtual void Init()
    {
        _data._hp = _data._maxHp;

        _anim = gameObject.GetComponent<Animator>();

        _boxCol = GetComponent<BoxCollider2D>();
    }

    public virtual void OnDamage(int damage)
    {
        _data._hp = _data._hp - damage;
        _data._hp = Math.Max(0, _data._hp);

        if (_data._hp == 0)
        {
            _anim.SetBool("die", true);

            // 죽는 타이밍
            StartCoroutine(OnDie());

            if (_boxCol != null)
            {
                _boxCol.enabled = false;
            }
            else
            {
                Debug.LogError("[Error] BoxCollider2D를 안붙였군요!!");
            }

        }
    }

    IEnumerator OnDie()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
        GameManager.Instance.OnDie(this); //this의 의미는 self 자기자신 객체(인스턴스)를 가리킴
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {    
        if (collision.gameObject.name == "playe")
        {
            Char2D playerChar = FindObjectOfType<Char2D>();
            playerChar.OnDamage(_data._attack);
            GameObject effectGo = Instantiate(_effectPrefab);
            Vector3 charPos = playerChar.transform.position;
            effectGo.transform.position = new Vector3(charPos.x, charPos.y, charPos.z);
        }      
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
    }

    public void Move()
    {
        bool die = _anim.GetBool("die");
        if (die == true)
            return;

        Vector3 pos = transform.localPosition;

        float move = Time.deltaTime * _data._speed;

        if (_right)
            move = move * 1;
        else
            move = move * -1;

        transform.Translate(new Vector3(move, 0, 0));

        pos = transform.localPosition;

        // 목표점에 도달하면 왼쪽으로 가도록 _right를 false로 해줌
        if (pos.x > _destPoint)
        {
            _right = false;
            Flip(_right);
        }
        // 왼쪽으로 가다가 다시 시작점보다 더 왼쪽으로 가려고 하면
        // 다시 오른쪽으로 가도록 _right를 true로 해줌
        if (pos.x < _origPoint)
        {
            _right = true;
            Flip(_right);
        }
    }

    public void Flip(bool right)
    {
        if (right) // 오른쪽을 바라봄, right가 true이면,
        {
            Vector3 scale = transform.localScale;
            float newScaleX = Mathf.Abs(scale.x); //Absolute
            transform.localScale = new Vector3(newScaleX, scale.y, scale.z);
        }
        else        // 왼쪽을 바라봄, right가 false이면,
        {
            Vector3 scale = transform.localScale;
            float newScaleX = Mathf.Abs(scale.x); //Absolute
            transform.localScale = new Vector3(-1 * newScaleX, scale.y, scale.z);
        }
    }
}
