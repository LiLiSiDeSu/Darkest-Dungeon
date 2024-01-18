using UnityEngine;
using UnityEditor;
using System.IO;

[InitializeOnLoad]
public class ScriptCounter
{
    public static GUIStyle Style_fileCount = new();
    public static bool Enable = false;

    [MenuItem("Btn/ScriptCounter")]
    private static void Btn()
    {
        Enable = !Enable;
        EditorApplication.RepaintProjectWindow();
    }

    static ScriptCounter()
    {
        Style_fileCount.alignment = TextAnchor.MiddleRight;
        Style_fileCount.normal.textColor = new(255, 255, 255, 255);
        EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemGUI;
    }

    private static void OnProjectWindowItemGUI(string guid, Rect selectionRect)
    {
        if (Enable)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
        
            if (Directory.Exists(path))
            {
                string label = Directory.GetFiles(path, "*.cs", SearchOption.AllDirectories).Length.ToString();
                EditorGUI.LabelField(new(selectionRect.x + selectionRect.width - 20, selectionRect.y, 20, 20), label, Style_fileCount);
            }
        }
    }
}
