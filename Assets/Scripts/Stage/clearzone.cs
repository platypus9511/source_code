using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class clearzone : MonoBehaviour
{
    public int _stageNum;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.Label(transform.position, "clearzone");
    }
#endif


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            if( collision is BoxCollider2D)
            {
                Debug.Log("stage clear");
                uiManager uiMgr = FindObjectOfType<uiManager>();
                uiMgr.Show("Ui_loading", true);

                Ui_loading uiLoding = FindObjectOfType<Ui_loading>();
                uiLoding.Gonext(_stageNum + 1);
            }
            //if(_stageNum == 10)
           // {
            //    SceneManager.LoadScene((int)SCENE.GAME2);
           // }
        }
        

    }

}
