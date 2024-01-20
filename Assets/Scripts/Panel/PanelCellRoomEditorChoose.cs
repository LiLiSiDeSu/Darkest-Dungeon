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
                Hot.PanelOtherEditorRoom_.ChangeCurrentChoose(e_MapObject);
                if (Hot.ChoseCellRoomEditor != null)
                {
                    Hot.ChoseCellRoomEditor.ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                    Hot.ChoseCellRoomEditor = null;
                }
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
