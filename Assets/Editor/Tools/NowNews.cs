using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NowNews : BaseEditorGUIExtension<LayoutForNowNews>
{
    [MenuItem("-Tools-/News/NowNew_ #&%_2", false, 1)]
    public static void ShowWindow()
    {
        NowNews NowNew_ = GetWindow<NowNews>();
        NowNew_.Show();

        layout.Style_NowItemContent.fontSize = 15;
        layout.Style_NowPointerLocation.fontSize = 15;
        layout.Style_NowPlayerLocation.fontSize = 15;
        layout.Style_NowTranslateRate.fontSize = 15;
        layout.Style_NowIndexGameArchive.fontSize = 15;
        layout.Style_NowRootExpeditionRole.fontSize = 15;        
        layout.Style_DragingRolePortrait.fontSize = 15;
        layout.Style_PanelTownItemStatus.fontSize = 15;
    }

    private void OnGUI()
    {
        if (!Application.isPlaying)
            Close();

        GUI.Label(layout.Rect_NowItemContent, layout.String_NowItemContent, layout.Style_NowItemContent);
        GUI.Label(layout.Rect_NowPointerLocation, layout.String_NowPointerLocation, layout.Style_NowPointerLocation);
        GUI.Label(layout.Rect_NowPlayerLocation, layout.String_NowPlayerLocation, layout.Style_NowPlayerLocation);
        GUI.Label(layout.Rect_NowTranslateRate, layout.String_NowTranslateRate, layout.Style_NowTranslateRate);
        GUI.Label(layout.Rect_NowIndexGameArchive, layout.String_NowIndexGameArchive, layout.Style_NowIndexGameArchive);
        GUI.Label(layout.Rect_NowRootExpeditionRole, layout.String_NowRootExpeditionRole, layout.Style_NowRootExpeditionRole);        
        GUI.Label(layout.Rect_DragingRolePortrait, layout.String_DragingRolePortrait, layout.Style_DragingRolePortrait);
        GUI.Label(layout.Rect_PanelTownItemStatus, layout.String_PanelTownItemStatus, layout.Style_PanelTownItemStatus);
        layout.Refresh();

        Repaint();        
    }
}
