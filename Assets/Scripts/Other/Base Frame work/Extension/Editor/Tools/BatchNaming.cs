using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using Unity.VisualScripting;

public class BatchRename : BaseEditorGUIExtension<LayoutForBatchRename>
{
    private string BaseName = "PortraitNone";
    private string StartIndex = "0";

    //[MenuItem("Tools/Batch Rename", false, priority:10)]
    private static void OpenWindow()
    {
        BatchRename window = GetWindow<BatchRename>();
        window.Show();
    }      

    private void OnGUI()
    {
        GUI.Label(layout.Rect_Label_Title, "Batch Rename Setting");

        GUI.Label(layout.Rect_Label_BaseName, layout.Label_BaseName);
        GUI.Label(layout.Rect_Label_StartIndex, layout.Label_StartIndex);
        BaseName = GUI.TextField(layout.Rect_TextField_BaseName, BaseName);
        StartIndex = GUI.TextField(layout.Rect_TextField_StartIndex, StartIndex);

        if (GUI.Button(new Rect(new Vector2(50, 100), new Vector2(200, 100)), "Rename"))
        {
            RenameObjects();
        }
    }

    private void RenameObjects()
    {
        GameObject[] selectedObjects = Selection.gameObjects;

        for (int i = 0; i < selectedObjects.Length; i++)
        {            
            GameObject obj = selectedObjects[i];
            Undo.RecordObject(obj, "Rename Object");

            obj.name = BaseName + (int.Parse(StartIndex) + i);
        }
    }
}