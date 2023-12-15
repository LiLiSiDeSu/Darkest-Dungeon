using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelExpeditionDetails : PanelBase
{
    public Text TxtHeightAndWidth;
    public Text TxtEntrancePos;

    protected override void Awake()
    {
        base.Awake();

        TxtHeightAndWidth = transform.FindSonSonSon("TxtHeightAndWidth").GetComponent<Text>();
        TxtEntrancePos = transform.FindSonSonSon("TxtEntrancePos").GetComponent<Text>();
    }

    public void UpdateInfo(DataContainer_ExpeditionMiniMap data)
    {
        TxtHeightAndWidth.text = "H:" + data.ListCellMiniMap.Count + " / " + "W:" + data.ListCellMiniMap[0].Count;
        TxtEntrancePos.text = "H:" + data.EntrancePos.Y + " / " + "W:" + data.EntrancePos.X;
    }

    public void Clear()
    {
        TxtHeightAndWidth.text = "";
        TxtEntrancePos.text = "";
    }
}
