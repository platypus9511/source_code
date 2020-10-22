using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_state_idle : AI_state
{
    public float _attackRange = 1.0f;



    public override void Update()
    {
        CheckInAttackRange();
    }

    void CheckInAttackRange()
    {
        if(_player != null)
        {
            //플레이어의 위치 확인
            float playerPosX = _player.transform.position.x;

            //적의 위치 확인
            float enemyPosX = _owner.transform.position.x;

            //거리계산
            float distance = Mathf.Abs(playerPosX - enemyPosX);

            if(distance <= _attackRange)
            {
                _con.ChangeState(AIStateID.ATTACK);

                Debug.Log("attack!!");
            }
        }
        
    }
}
