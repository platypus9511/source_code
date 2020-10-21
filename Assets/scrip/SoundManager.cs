using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource[] _audioList;

    [HideInInspector]
    public static SoundManager _instance;
    public static SoundManager Ins
    {
        get
        {
            if (null == _instance)
            {
                _instance = FindObjectOfType(typeof(SoundManager)) as SoundManager;
                if (null == _instance)
                {
                    Debug.LogError("Fail to get SoundManager Instance");
                }
            }
            return _instance;
        }
    }

    void Start()
    {
        _audioList = GetComponentsInChildren<AudioSource>();
    }
  
    public void Play(string sndName)
    {
        //배열을 탐색해서 , sndName과 일치하는 사운드를 찾아서 플레이시켜줌
        foreach (AudioSource audio in _audioList)
        {
            if (audio.name == sndName)
            {
                audio.Play();
            }
        }
    }

}
