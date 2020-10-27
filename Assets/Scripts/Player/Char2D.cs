using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


[Serializable]
public class MyCharData : CharacterData
{

}

public class Char2D : Character
{
    [HideInInspector]
    public static Char2D _instance;
    public static Char2D Ins
    {
        get
        {
            if (null == _instance)
            {
                _instance = FindObjectOfType(typeof(Char2D)) as Char2D;
                if (null == _instance)
                {
                    Debug.LogError("Fail to get Char2D Instance");
                }
            }
            return _instance;
        }
    }




    public MyCharData _data;

    public override CharacterData Data
    {
        get { return _data; }
    }


    public Rigidbody2D _rigid;
    public Animator _anim;
    public float _jumpForce = 20.0f;
    public float _jumpMax = 10.0f;
    public uiManager _uiMgr;

    
    public bool Right { get { return _right; } }
    private bool _right = true;
    

    public int _hp = 5;
    public int _maxhp = 5;
    public Text _hpText;


    private const string KEY_PLAYER_POS_X = "save_player_pos_x";
    private const string KEY_PLAYER_POS_Y = "save_player_pos_y";


    public AudioSource _sndFootLeft;
    public AudioSource _sndFootRight;
    public AudioSource _sndJump;
    public AudioSource _sndLanding;

    public GameObject _fireposition;

    void Start()
    {
        _uiMgr = FindObjectOfType<uiManager>();

        /*
            if(PlayerPrefs.HasKey(KEY_PLAYER_POS_X) == true &&
            PlayerPrefs.HasKey(KEY_PLAYER_POS_Y)== true)
            {
             float posX = PlayerPrefs.GetFloat(KEY_PLAYER_POS_X);
             float posY = PlayerPrefs.GetFloat(KEY_PLAYER_POS_Y);

             float posZ = transform.position.z;
             transform.position = new Vector3(posX, posY, posZ);
            }
        */

        InitHP();


       
    }


    public void InitHP()
    {
        //hp 초기화
        _data._hp = _data._maxHp;

        if (_uiMgr != null)
            _uiMgr.InitHp(_data._hp);

        _anim.SetInteger("HP", _data._hp);
    }

    public void OnDamage(int damage)
    {
        if (_data._hp == 0) return;

        _data._hp = _data._hp - damage;
        _data._hp = Math.Max(0, _data._hp);
        //_hpText.text = _data._hp.ToString();
        _uiMgr.OnDamage(_data._hp);


        _anim.SetTrigger("hit 0");
        _anim.SetInteger("HP", _data._hp);



        if (_data._hp == 0)
        {
            Ondie();
        }

    }

    public void Ondie()
    {
        //게임오버 처리
        _uiMgr.Show("Ui_gameOver", true); // 게임오버 On
        // if (_snd_Death) _snd_Death.Play();
    }

    public void OnHeal(int heal)
    {
        _data._hp = _data._hp + heal;
        _data._hp = Math.Min(_data._maxHp, _data._hp);
        _hpText.text = _data._hp.ToString();
    }


    void Update()
    {
        float currentVel = Mathf.Abs(_rigid.velocity.x);
        //Debug.Log("현재 속도:" + currentVel);
        _anim.SetFloat("run", Mathf.Abs(_rigid.velocity.x));
    }
    public void Jump()
    {
        bool isJumpingNow = _anim.GetBool("jump");
        if (isJumpingNow) return;

        if (_sndJump) _sndJump.Play();

        _anim.SetBool("jump", true);


        _rigid.AddForce(new Vector2(0, _jumpForce));

        Vector2 vel = _rigid.velocity;
        float limit = Mathf.Min(_jumpMax, vel.y);
        _rigid.velocity = new Vector2(vel.x, limit);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" )
        {
            if (_sndLanding) _sndLanding.Play();

            _anim.SetBool("jump", false);
        }

    }
    public void Flip(bool right)
    {
        if (right)// 오른쪽을 바라보면 , (right 가 true일때)
        {
            Vector3 scale = transform.localScale;
            float newscaleX = Mathf.Abs(scale.x);  //Abs = Absolute
            transform.localScale = new Vector3(newscaleX, scale.y, scale.z);
        }
        else //왼쪽을 바라볼때 , (right가 false일때)
        {
            Vector3 scale = transform.localScale;
            float newscaleX = Mathf.Abs(scale.x);  //Abs = Absolute
            transform.localScale = new Vector3(-1 * newscaleX, scale.y, scale.z);

        }
        _right = right;
    }

    /*
    public void OnApplicationQuit()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;

        PlayerPrefs.SetFloat(KEY_PLAYER_POS_X, posX);
        PlayerPrefs.SetFloat(KEY_PLAYER_POS_Y, posY);
    }
    */

    
    public void OnFootRight()
    {
        _sndFootRight.Play();
    }
    public void OnFootLeft()
    {
        _sndFootLeft.Play();
    }


    public void FireProjectile(Vector2 dirNormal)
    {
        GameObject portaleffectPrefab = Resources.Load("Portaleffect") as GameObject;
        GameObject Portaleffect = Instantiate(portaleffectPrefab);
        Vector3 playerPos = _fireposition.transform.position;
        projectile proj = Portaleffect.GetComponent<projectile>();
        proj.Init(dirNormal);
        ParticleSystem ps = Portaleffect.GetComponent<ParticleSystem>();

        //float offset_x = 0.0f;
        //float offset_y = 0.0f;
        float offset_z = 0.0f;

        if (_right)
        {
            //offset_x = 1.0f;
            // offset_y = 0.3f;
            offset_z = -1.0f;
            proj._flyForce += -1.0f;
            ps.startRotation = Mathf.Deg2Rad * -90.0f;
        }
        else
        {
             //offset_x = -1.0f;
            // offset_y = -0.3f;
            offset_z = 1.0f;
            proj._flyForce *= 1.0f;
            ps.startRotation = Mathf.Deg2Rad * 90.0f;
        }
        Portaleffect.transform.position = new Vector3(playerPos.x, playerPos.y, playerPos.z * offset_z);
    }
}