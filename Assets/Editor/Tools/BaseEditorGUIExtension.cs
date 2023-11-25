using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BaseEditorGUIExtension<T> : EditorWindow where T : Component                                                          
{
    protected EditorGUILayout EditorGUILayoutObj;
    protected static T layout;

    private void Awake()
    {
        EditorGUILayoutObj = FindAnyObjectByType<EditorGUILayout>();
        if (EditorGUILayoutObj == null)
        {
            GameObject cao = new GameObject("EditorGUILayout");
            EditorGUILayoutObj = cao.AddComponent<EditorGUILayout>();
        }

        layout = FindAnyObjectByType<T>();
        if (layout != null)
            DestroyImmediate(layout.gameObject);

        GameObject obj = new GameObject(typeof(T).ToString());
        obj.transform.parent = EditorGUILayoutObj.transform;
        layout = obj.AddComponent<T>();
    }    
}
