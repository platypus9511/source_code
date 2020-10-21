using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_base : MonoBehaviour
{
    protected GameManager _gameMgr;
    public virtual void Init()
    {
        _gameMgr = FindObjectOfType<GameManager>();
    }

    
    void Update()
    {
        
    }
    public virtual void OnButtonClick(GameObject buttonObj)
    {
       


    }


}
