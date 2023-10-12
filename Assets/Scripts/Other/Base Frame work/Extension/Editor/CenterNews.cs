using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEditor;
using UnityEngine;

public class CenterNews : BaseEditorGUIExtension<LayoutForCreaterNews>
{    
    [MenuItem("Tools/CenterNews %_q", false, 2)]
    public static void ShowWindow()
    {
        CenterNews CenterNews = GetWindow<CenterNews>();
        CenterNews.Show();

        layout.Style_PoolEsc.fontSize = 15;
        layout.Style_PoolNowPanel.fontSize = 15;
        layout.Style_PoolBuffer.fontSize = 15;
        layout.Style_MgrUI.fontSize = 15;
        layout.Style_IsAlwaysRefresh.fontSize = 15;
    }

    private void OnGUI()
    {
        GUI.Label(layout.Rect_PoolEsc, layout.String_PoolEsc, layout.Style_PoolEsc);
        GUI.Label(layout.Rect_PoolNowPanel, layout.String_PoolNowPanel, layout.Style_PoolNowPanel);
        GUI.Label(layout.Rect_PoolBuffer, layout.String_PoolBuffer, layout.Style_PoolBuffer);
        GUI.Label(layout.Rect_MgrUI, layout.String_MgrUI, layout.Style_MgrUI);

        if (layout.Bool_IsAlwaysRefresh = GUI.Toggle
           (layout.Rect_IsAlwaysRefresh, layout.Bool_IsAlwaysRefresh, layout.String_IsAlwaysRefresh))
            layout.Refresh();
    }
}