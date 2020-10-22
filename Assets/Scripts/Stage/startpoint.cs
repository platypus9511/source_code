using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class startpoint : MonoBehaviour
{
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.Label(transform.position, "startpoint");
    }
#endif
}
