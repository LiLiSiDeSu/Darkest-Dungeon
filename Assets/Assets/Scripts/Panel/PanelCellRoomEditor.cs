using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellRoomEditor : PanelBaseCellVector2,
             IPointerEnterHandler, IPointerExitHandler
{
    public PanelBaseGrid<PanelCellRoomEditor> RootGrid = new();

    public E_MapObject e_Obj = E_MapObject.None;

    #region EventSystem

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.NowEnterCellRoomEditor = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.NowEnterCellRoomEditor = null;
    }

    #endregion

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellRoomEditor":
                if (Hot.ChoseCellRoomEditor == null)
                {
                    Hot.ChoseCellRoomEditor = this;
                    ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctGreen");

                    Hot.PanelOtherRoomEditor_.ChangeCurrentChoose(e_Obj);

                    return;
                }

                if (Hot.ChoseCellRoomEditor == this)
                {
                    Hot.ChoseCellRoomEditor = null;
                    ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");

                    return;
                }

                if (Hot.ChoseCellRoomEditor != this)
                {
                    Hot.ChoseCellRoomEditor.ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                    Hot.ChoseCellRoomEditor = this;
                    ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctGreen");

                    Hot.PanelOtherRoomEditor_.ChangeCurrentChoose(e_Obj);
                }
                break;
        }
    }

    public void Init(E_MapObject p_e_Obj, PanelBaseGrid<PanelCellRoomEditor> p_rootGrid)
    {
        e_Obj = p_e_Obj;
        RootGrid = p_rootGrid;

        transform.SetParent(Hot.PanelOtherRoomEditor_.ItemRoot[RootGrid.Y][RootGrid.X], false);
        transform.localPosition = new(-20, 20);

        ImgItem.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + p_e_Obj);

        ImgItem.GetComponent<RectTransform>().sizeDelta = 
            new(Hot.BodyDicMapObject[p_e_Obj].X * Hot.BodyGrid.X, Hot.BodyDicMapObject[p_e_Obj].Y * Hot.BodyGrid.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicMapObject[p_e_Obj].X * Hot.BodyGrid.X, Hot.BodyDicMapObject[p_e_Obj].Y * Hot.BodyGrid.Y);
    }

    public override void ChangeCellSize()
    {
        base.ChangeCellSize();

        ImgItem.GetComponent<RectTransform>().sizeDelta = new(Hot.BodyDicMapObject[e_Obj].X * Hot.BodyGrid.X, Hot.BodyDicMapObject[e_Obj].Y * Hot.BodyGrid.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta = new(Hot.BodyDicMapObject[e_Obj].X * Hot.BodyGrid.X, Hot.BodyDicMapObject[e_Obj].Y * Hot.BodyGrid.Y);
    }
}
