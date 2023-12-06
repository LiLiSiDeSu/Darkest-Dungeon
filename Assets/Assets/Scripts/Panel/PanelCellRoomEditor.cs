using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellRoomEditor : PanelBase,
             IPointerEnterHandler, IPointerExitHandler
{
    public Image ImgCellRoomEditor;
    public Image ImgStatus;

    public PanelGridRoomEditor RootGrid = new();

    public E_MapObject e_Obj = E_MapObject.None;

    protected override void Awake()
    {
        base.Awake();

        ImgCellRoomEditor = transform.FindSonSonSon("ImgCellRoomEditor").GetComponent<Image>();
        ImgStatus = transform.FindSonSonSon("ImgStatus").GetComponent<Image>();
    }

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

    public void Init(E_MapObject p_e_Obj, PanelGridRoomEditor p_rootGrid)
    {
        e_Obj = p_e_Obj;
        RootGrid = p_rootGrid;

        ImgCellRoomEditor.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + p_e_Obj);

        ImgCellRoomEditor.GetComponent<RectTransform>().sizeDelta = 
            new(Hot.BodyDicMapObject[p_e_Obj].X * Hot.BodySizeGridExpeditionMap.X, Hot.BodyDicMapObject[p_e_Obj].Y * Hot.BodySizeGridExpeditionMap.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicMapObject[p_e_Obj].X * Hot.BodySizeGridExpeditionMap.X, Hot.BodyDicMapObject[p_e_Obj].Y * Hot.BodySizeGridExpeditionMap.Y);
    }
}
