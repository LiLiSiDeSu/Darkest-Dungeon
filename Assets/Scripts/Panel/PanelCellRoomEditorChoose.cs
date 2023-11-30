using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCellRoomEditorChoose : PanelBase
{
    public Image ImgChooseGrid;

    public E_MapObject e_MapObject = E_MapObject.None;

    protected override void Awake()
    {
        base.Awake();

        ImgChooseGrid = transform.FindSonSonSon("ImgChoose").GetComponent<Image>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnChoose":
                Hot.e_ChoseObj = e_MapObject;
                Hot.PanelOtherRoomEditor_.ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + e_MapObject);
                Hot.PanelOtherRoomEditor_.ImgCurrentChoose.GetComponent<RectTransform>().sizeDelta = 
                    new(Hot.BodyDicMapObject[e_MapObject].X * Hot.BodyCellGridExpeditionMap.X, Hot.BodyDicMapObject[e_MapObject].Y * Hot.BodyCellGridExpeditionMap.Y);
                break;
        }
    }

    public void Init(E_MapObject P_e_MapObject)
    {
        e_MapObject = P_e_MapObject;
        ImgChooseGrid.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + e_MapObject);

        if (!e_MapObject.ToString().Contains("Grid"))
        {
            int Step = 80 / Mathf.Max(Hot.BodyDicMapObject[e_MapObject].X, Hot.BodyDicMapObject[e_MapObject].Y);

            ImgChooseGrid.GetComponent<RectTransform>().sizeDelta =
                new(Step * Hot.BodyDicMapObject[e_MapObject].X, Step * Hot.BodyDicMapObject[e_MapObject].Y);
        }
    }
}
