using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(Switch))]
[CanEditMultipleObjects]
public class SwitchInspector : Editor
{
    Switch _target;

    void OnEnable()
    {
        
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        _target = target as Switch;

        if ( GUILayout.Button("Test"))
        {
            Debug.Log("test");

            _target.Test();
        }
    }
}