using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry_controller : MonoBehaviour
{
    public AI_state[] _states;

    public void Init(Enemy enemy)
    {
        foreach(AI_state st in _states)
        {
            st.Init(enemy);  //초기화
            st.enabled = false; // 초기화 동시에 _states들 전부 false로
        }

        ChangeState(AIStateID.IDLE);
    }

    public void ChangeState(AIStateID stateID)
    {

       foreach(AI_state st in _states)
        {
            st.enabled = false;
        }

        _states[(int)stateID].enabled = true; // 스크립트에서 true로 변경
    }
}
