using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_loading : Ui_base
{
    public Animator _animator;
    private int _nextStage = 0;
    private float _waitTime = 0.0f; //현재 총 대기시간
    public float _loadingTime = 0.0f;//로딩시간

    void Start()
    {
        
    }
    public void Gonext(int stageNum)
    {
        _nextStage = stageNum;

        GameManager gameMgr = FindObjectOfType<GameManager>();
        gameMgr.Gonext(_nextStage);
       
    }
    void Update()
    {
        if (_nextStage > 0)
        {
            _waitTime += Time.deltaTime;

            // if(_waitTime > _loadingTime - 0.5f)
            {
                //  _animator.SetBool("loading.end", true);
                //로딩시간 다 차기전 조금 일찍 (0.5초정도)미리 fadeout이 일어나도록
            }

            //몇초간 기다렸다가 로딩시간이 차면
            if (_waitTime > _loadingTime)
            {




                uiManager uiMgr = FindObjectOfType<uiManager>();
                uiMgr.Show("UI_loading", false); // 로딩이 끝아면 ui loading을 false로 
                uiMgr.Show("Ui_play", true); // 스테이지 이동시 ui play를 다시 true로


                //다음에 로딩화면을 또 사용할테니, 값들을 다시리셋
                _waitTime = 0.0f;
                _nextStage = 0;
                

            }
        }

    }
}
