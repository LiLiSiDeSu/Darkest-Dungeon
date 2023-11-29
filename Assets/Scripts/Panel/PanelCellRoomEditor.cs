using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCellRoomEditor : PanelBase
{
    public PanelCellGridRoomEditor RootGrid = new();

    public Image ImgCellRoomEditor;
    public Image ImgStatus;

    public E_MapObject e_Obj = E_MapObject.None;
    public int IndexRoleListRole = -1;
    public bool HaveOtherRole = false;

    protected override void Awake()
    {
        base.Awake();

        ImgCellRoomEditor = transform.FindSonSonSon("ImgCellRoomEditor").GetComponent<Image>();
        ImgStatus = transform.FindSonSonSon("ImgStatus").GetComponent<Image>();
    }

    public void Init(E_MapObject e_Obj, PanelCellGridRoomEditor RootGrid)
    {
        this.e_Obj = e_Obj;
        this.RootGrid = RootGrid;

        ImgCellRoomEditor.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + e_Obj);
    }
}
