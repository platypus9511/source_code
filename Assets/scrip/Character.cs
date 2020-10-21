using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CharacterData
{
    //
    public int _hp = 0;
    public int _maxHp = 100;
}

public class Character : MonoBehaviour
{
    public virtual CharacterData Data
    {
        get { return null; }
    }
}
