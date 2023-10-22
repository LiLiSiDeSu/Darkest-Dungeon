using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NowNews : BaseEditorGUIExtension<LayoutForNowNews>
{
    [MenuItem("Tools/News/NowNews #&%_1", false, 2)]
    public static void ShowWindow()
    {
        NowNews CenterNews = GetWindow<NowNews>();
        CenterNews.Show();

        layout.Style_NowItemContent.fontSize = 15;
        layout.Style_PanelTownItemStatus.fontSize = 15;
    }

    private void OnGUI()
    {
        if (!Application.isPlaying)
            Close();

        GUI.Label(layout.Rect_NowItemContent, layout.String_NowItemContent, layout.Style_NowItemContent);
        GUI.Label(layout.Rect_PanelTownItemStatus, layout.String_PanelTownItemStatus, layout.Style_PanelTownItemStatus);
        layout.Refresh();

        Repaint();        
    }
}
