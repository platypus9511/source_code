using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    [HideInInspector]
    public static SaveData _instance;
    public static SaveData Ins
    {
        get
        {
            if (null == _instance)
            {
                _instance = FindObjectOfType(typeof(SaveData)) as SaveData;
                if (null == _instance)
                {
                    Debug.LogError("Fail to get SaveData Instance");
                }
            }
            return _instance;
        }
    }

    public const string STAGE_PROGRESS = "userdata_stage_progress_";
    public const string USER_RESOURCE = "userdata_resource_";

    public int[] _stageList;

    /*
    public void Init()
    {
        _stageList = new int[(int)StageType.STAGE_10];

        for (int i = 0; i < (int)StageType.STAGE_10; i++)
        {
            int progress = PlayerPrefs.GetInt(STAGE_PROGRESS + i); //저장된 정보 가져오기

            _stageList[i] = progress;
        }
    }
    */

    /*
    public void UpdateStage(StageType type, int stageNum)
    {
        _stageList[(int)type] += stageNum; //정보 저장

        int questNum = (int)type;
        int progress = _stageList[(int)type];
        PlayerPrefs.SetInt(STAGE_PROGRESS + questNum, progress);
    }
    */



}
