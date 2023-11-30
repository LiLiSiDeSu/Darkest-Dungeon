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

    protected override void Awake()
    {
        base.Awake();

        ImgCellRoomEditor = transform.FindSonSonSon("ImgCellRoomEditor").GetComponent<Image>();
        ImgStatus = transform.FindSonSonSon("ImgStatus").GetComponent<Image>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellRoomEditor":
                Debug.Log(e_Obj);
                break;
        }
    }

    public void Init(E_MapObject e_Obj, PanelCellGridRoomEditor RootGrid)
    {
        this.e_Obj = e_Obj;
        this.RootGrid = RootGrid;

        ImgCellRoomEditor.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + e_Obj);

        ImgCellRoomEditor.GetComponent<RectTransform>().sizeDelta = 
            new(Hot.BodyDicMapObject[e_Obj].X * Hot.BodyCellGridExpeditionMap.X, Hot.BodyDicMapObject[e_Obj].Y * Hot.BodyCellGridExpeditionMap.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicMapObject[e_Obj].X * Hot.BodyCellGridExpeditionMap.X, Hot.BodyDicMapObject[e_Obj].Y * Hot.BodyCellGridExpeditionMap.Y);
    }
}
