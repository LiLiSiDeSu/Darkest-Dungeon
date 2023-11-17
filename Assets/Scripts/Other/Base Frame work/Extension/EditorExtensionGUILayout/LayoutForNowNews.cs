using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutForNowNews : MonoBehaviour
{
    public string String_NowItemContent = "NowPanelItem: ";
    public Rect Rect_NowItemContent = new Rect(0, 0, 0, 0);
    public GUIStyle Style_NowItemContent = new GUIStyle();

    public string String_NowPointerLocation = "NowPointerLocation: ";
    public Rect Rect_NowPointerLocation = new Rect(0, 20, 0, 0);
    public GUIStyle Style_NowPointerLocation = new GUIStyle();

    public string String_NowPlayerLocation = "NowPlayerLocation: ";
    public Rect Rect_NowPlayerLocation = new Rect(0, 40, 0, 0);
    public GUIStyle Style_NowPlayerLocation = new GUIStyle();

    public string String_NowTranslateRate = "NowTranslateRate: ";
    public Rect Rect_NowTranslateRate = new Rect(0, 60, 0, 0);
    public GUIStyle Style_NowTranslateRate = new GUIStyle();

    public string String_NowIndexGameArchive = "NowIndexGameArchive: ";
    public Rect Rect_NowIndexGameArchive = new Rect(0, 80, 0, 0);
    public GUIStyle Style_NowIndexGameArchive = new GUIStyle();

    public string String_NowRootExpeditionRole = "NowRootExpeditionRole: ";
    public Rect Rect_NowRootExpeditionRole = new Rect(0, 100, 0, 0);
    public GUIStyle Style_NowRootExpeditionRole = new GUIStyle();

    public string String_DragingRolePortrait = "DragingRolePortrait: ";
    public Rect Rect_DragingRolePortrait = new Rect(0, 120, 0, 0);
    public GUIStyle Style_DragingRolePortrait = new GUIStyle();

    public string String_PanelTownItemStatus = "---PanelTownItemStatus---";
    public Rect Rect_PanelTownItemStatus = new Rect(0, 140, 0, 0);
    public GUIStyle Style_PanelTownItemStatus = new GUIStyle();

    public void Refresh()
    {        
        if (Hot.NowPanelItem == null) String_NowItemContent = "NowPanelItem: null";
        else
        {
            String_NowItemContent = "NowPanelItem: " + Hot.NowPanelItem.gameObject.name;
        }

        String_NowPointerLocation = "NowPointerLocation: " + Hot.e_NowPointerLocation;
        String_NowPlayerLocation = "NowPlayerLocation: " + Hot.e_NowPlayerLocation;
        String_NowTranslateRate = "NowTranslateRate: " + Hot.NowTranslateRate;
        String_NowIndexGameArchive = "NowIndexGameArchive: " + Hot.NowIndexCellGameArchive;

        if (Hot.NowRootExpeditionRole != null)
            String_NowRootExpeditionRole = "NowRootExpeditionRole: " + Hot.NowRootExpeditionRole.name;
        else
            String_NowRootExpeditionRole = "NowRootExpeditionRole: null";

        if (Hot.DragingRolePortrait != null)
            String_DragingRolePortrait =
                "DragingRolePortrait: " +
                Hot.DataNowCellGameArchive.ListCellRole
                [Hot.DragingRolePortrait.GetComponent<PanelCellRolePortraitCanDrag>().PanelCellRole_.Index].Name;
        else
            String_DragingRolePortrait = "DragingRolePortrait: null";


        if (Hot.NowIndexCellGameArchive != -1)
        {
            String_PanelTownItemStatus = "---PanelTownItemStatus---\n";
            for (int i = 0; i < Hot.DataNowCellGameArchive.ListCellStore.Count; i++)
            {
                String_PanelTownItemStatus += Hot.MgrUI_.GetPanel<PanelTownItem>("PanelTownItem" + i).gameObject.name + "-NowIndex: "
                    + Hot.MgrUI_.GetPanel<PanelTownItem>("PanelTownItem" + i).NowIndex + "\n";
            }
        }
    }
}
