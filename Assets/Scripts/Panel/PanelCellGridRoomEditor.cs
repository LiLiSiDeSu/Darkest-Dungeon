using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCellGridRoomEditor : PanelBase
{
    public int X;
    public int Y;

    public Image ImgBk;
    public Image ImgStatus;

    public PanelCellRoomEditor CellRoomEditor;

    protected override void Awake()
    {
        base.Awake();

        ImgBk = transform.FindSonSonSon("ImgBk").GetComponent<Image>();
        ImgStatus = transform.FindSonSonSon("ImgStatus").GetComponent<Image>();

        ImgBk.alphaHitTestMinimumThreshold = 0.2f;
    }
}
