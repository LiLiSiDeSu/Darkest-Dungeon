using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEditor;
using UnityEngine;

public class PanelNews : BaseEditorGUIExtension<LayoutForPanelNews>
{    
    [MenuItem("-Tools-/News/PanelNews #&%_3", false, 2)]
    public static void ShowWindow()
    {
        PanelNews PanelNews_ = GetWindow<PanelNews>();
        PanelNews_.Show();

        layout.Style_PoolEsc.fontSize = 15;
        layout.Style_PoolNowPanel.fontSize = 15;
        layout.Style_PoolBuffer.fontSize = 15;
        layout.Style_MgrUI.fontSize = 15;        
    }

    private void OnGUI()
    {
        if (!Application.isPlaying)
            Close();

        GUI.Label(layout.Rect_PoolEsc, layout.String_PoolEsc, layout.Style_PoolEsc);
        GUI.Label(layout.Rect_PoolNowPanel, layout.String_PoolNowPanel, layout.Style_PoolNowPanel);
        GUI.Label(layout.Rect_PoolBuffer, layout.String_PoolBuffer, layout.Style_PoolBuffer);
        GUI.Label(layout.Rect_MgrUI, layout.String_MgrUI, layout.Style_MgrUI);

        layout.Refresh();

        Repaint();
    }
}