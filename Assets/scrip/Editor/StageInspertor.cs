using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
[CanEditMultipleObjects]
public class StageInspertor : Editor
{

	GameManager _target;
	

    public override void OnInspectorGUI()
    {
		if (_target == null)
			_target = target as GameManager;

		for (int i = 1; i <= 8; i++)
		{
			if (GUILayout.Button("스테이지 " + i))
			{
				_target.MoveStartPoint(i);
			}
		}
		base.OnInspectorGUI();
	}
}
