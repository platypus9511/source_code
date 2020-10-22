using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public uiManager _uiMgr;


    public override void Init()
    {
        base.Init();

        GameManager.Instance.Init(_player);




        _uiMgr.Init(_player);

    }
}
