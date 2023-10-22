using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutForNowNews : MonoBehaviour
{
    public string String_NowItemContent = "NowPanelItem: ";
    public Rect Rect_NowItemContent = new Rect(0, 0, 0, 0);
    public GUIStyle Style_NowItemContent = new GUIStyle();

    public string String_PanelTownItemStatus = "---PanelTownItemStatus---";
    public Rect Rect_PanelTownItemStatus = new Rect(0, 20, 0, 0);
    public GUIStyle Style_PanelTownItemStatus = new GUIStyle();

    public void Refresh()
    {
        if (Application.isPlaying)
        {
            if (Hot.NowPanelItem == null) String_NowItemContent = "NowPanelItem: null";
            else
            {
                String_NowItemContent = "NowPanelItem: " + Hot.NowPanelItem.gameObject.name;
            }

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
}
