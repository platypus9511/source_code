using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour
{
    public Rigidbody2D _rigid;
   [SerializeField] private float _moveForce = 10.0f;
    public float MoveForce { get; set; }

    [SerializeField ]private float _moveMax = 5.0f;
    public float MoveMax { get; set; }
        

    public Char2D _Char2D;
    public TestRotation _testR;
    public FixedJoystick _joystick;
    TrapManager _trapMgr;
    public Animator _anim;
    [SerializeField]private bool _isGrab = false;
    [SerializeField] private GameObject _grabObj = null;


    Vector2 _len = Vector2.zero;

    private void OnDrawGizmos()
    {
        /*
        if( _len != Vector2.zero)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + new Vector3(_len.x, _len.y, 0.0f));
        }
        */
        
        
        
        
    }


    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        float h = _joystick.Horizontal;
        float v = _joystick.Vertical;
        //Debug.Log("h " + h);
        //Debug.Log("v" + v);

        if (h != 0)
        {
            _rigid.AddForce(new Vector2(h * _moveForce, 0.0f));

            if (h > 0)
                _Char2D.Flip(true);
            if (h < 0)
                _Char2D.Flip(false);
        }
        else
        {
            _anim.speed = 1.0f;
        }

        if (v > 0.5f)
        {
            _Char2D.Jump();
        }



        if (Input.GetMouseButtonUp(0))
        {
            if (_isGrab == true)
            {
                UnGrab();
            }
            else if (_isGrab == false)
            {
                TrapManager.Instance.CheckNearPlayer();
            }        
        }
       
        
        if(Input.GetKeyDown(KeyCode.J))
        {          
           //_len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            Char2D.Ins.FireProjectile(_len);
            _testR.MouseRotation();
        }
        else
        {
            _len = Vector2.zero;
        }
        



        if (Input.GetKeyDown(KeyCode.W))
        {

            _Char2D.Jump();
        }

        if (Input.GetKey(KeyCode.A))

        {
            _rigid.AddForce(new Vector2(-1 * _moveForce, 0.0f));
            _Char2D.Flip(false);

        }
        if (Input.GetKey(KeyCode.D))
        {
            _rigid.AddForce(new Vector2(_moveForce, 0.0f));
            _Char2D.Flip(true);
        }

        Vector2 vel = _rigid.velocity;

        //x축으로의 속도가 3(_moveMAx)를 넘지 않게 한다.
        float newVelX = Mathf.Min(_moveMax, vel.x);

        //x축으로의 속도가 -1* _moveMAx보다 작아지지 않게 한다.
        newVelX = Mathf.Max(-1 * _moveMax, newVelX);

        _rigid.velocity = new Vector2(newVelX, vel.y);
    }

    

    public void Grab(GameObject grabObj)

    {
        if (_isGrab) return;

        _isGrab = true;
        _grabObj = grabObj;

        Rigidbody2D r = grabObj.GetComponent<Rigidbody2D>();
        r.bodyType = RigidbodyType2D.Kinematic;
        r.simulated = false;


        float dir = _Char2D.Right? 1.0f : 1.0f;
   
     
        grabObj.transform.parent = transform;
        grabObj.transform.localPosition = new Vector3(dir * 8.0f, 2.0f, -0.13f); // 0.16f
            
    }


    public void UnGrab()
    {
        if (_isGrab == false) return;

        if (_grabObj == null) return;

        _isGrab = false;


        _grabObj.transform.parent = null;

   
        Rigidbody2D r = _grabObj.GetComponent<Rigidbody2D>();
        _grabObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        r.simulated = true;
        _grabObj.GetComponent<Animator>().enabled = false;
        cube cube = _grabObj.GetComponent<cube>();
        if(cube != null)
        {
            cube._grab = false;
        }

        _grabObj = null;
    }

}
