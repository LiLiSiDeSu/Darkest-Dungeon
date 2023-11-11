using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using Unity.VisualScripting;

public class BatchRename : BaseEditorGUIExtension<LayoutForBatchRename>
{    
    [MenuItem("-Tools-/GameTools/Batch Rename", false, 2)]
    private static void OpenWindow()
    {
        BatchRename window = GetWindow<BatchRename>();
        window.Show();

        layout.Style_BtnRename.normal.textColor = Color.white;
        layout.Style_InputBaseNameTitle.fontSize = 20;
        layout.Style_InputBaseName.fontSize = 20;
        layout.Style_StartIndexTitle.fontSize = 20;
        layout.Style_InputStartIndex.fontSize = 20;
        layout.Style_BtnRename.fontSize = 20;
    }      

    private void OnGUI()
    {
        GUI.Label(layout.Rect_InputBaseNameTitle, layout.String_InputBaseNameTitle, layout.Style_InputBaseName);
        layout.String_InputBaseName = 
            GUI.TextField(layout.Rect_InputBaseName, layout.String_InputBaseName, layout.Style_InputBaseName);

        GUI.Label(layout.Rect_StartIndexTitle, layout.String_StartIndexTitle, layout.Style_StartIndexTitle);
        layout.String_InputStartIndex =
            GUI.TextField(layout.Rect_InputStartIndex, layout.String_InputStartIndex, layout.Style_InputStartIndex);

        if (GUI.Button(layout.Rect_BtnRename, layout.String_BtnRenameTitle, layout.Style_BtnRename))
        {
            Rename();
        }

        Repaint();
    }

    private void Rename()
    {
        GameObject[] selectedObjects = Selection.gameObjects;

        for (int i = 0; i < selectedObjects.Length; i++)
        {            
            GameObject obj = selectedObjects[i];            

            obj.name = layout.String_InputBaseName + (int.Parse(layout.String_InputStartIndex) + i);
        }
    }
}