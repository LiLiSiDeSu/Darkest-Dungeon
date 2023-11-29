using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellMiniMapEditor : PanelBase,
             IPointerEnterHandler, IPointerExitHandler
{
    public PanelCellGridMiniMapEditor RootGrid = new();    

    public Image ImgCellMiniMapEditor;
    public Image ImgStatus;    

    public E_CellExpeditionMiniMapHall e_Hall = E_CellExpeditionMiniMapHall.None;
    public E_CellExpeditionMiniMapRoom e_Room = E_CellExpeditionMiniMapRoom.None;

    protected override void Awake()
    {
        base.Awake();

        ImgCellMiniMapEditor = transform.FindSonSonSon("ImgCellRoomEditor").GetComponent<Image>();
        ImgStatus = transform.FindSonSonSon("ImgStatus").GetComponent<Image>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellMapEditor":                                
                if (Hot.ChoseMapEditor == null)
                {
                    Hot.ChoseMapEditor = this;
                    ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctGreen");
                }
                else if (Hot.ChoseMapEditor != this)
                {
                    Hot.ChoseMapEditor.ImgCellMiniMapEditor.raycastTarget = true;
                    Hot.ChoseMapEditor.ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                    ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctGreen");
                    Hot.ChoseMapEditor = this;
                }

                if (Hot.ChoseMapEditor.e_Hall != E_CellExpeditionMiniMapHall.None)
                {
                    Hot.e_ChoseHall = Hot.ChoseMapEditor.e_Hall;
                    Hot.PanelOtherMapEditor_.ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + e_Hall);
                }
                if (Hot.ChoseMapEditor.e_Room != E_CellExpeditionMiniMapRoom.None)
                {
                    Hot.e_ChoseRoom = Hot.ChoseMapEditor.e_Room;
                    Hot.PanelOtherMapEditor_.ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + e_Room);
                }

                Hot.ChoseMapEditor.ImgCellMiniMapEditor.raycastTarget = false;
                break;
        }
    }

    #region EventSystem

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.NowEnterCellMapEditor = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.NowEnterCellMapEditor = null;
    }

    #endregion

    public void Init(E_CellExpeditionMiniMapRoom e_Room, E_CellExpeditionMiniMapHall e_Hall)
    {
        if (e_Room != E_CellExpeditionMiniMapRoom.None)
        {
            this.e_Room = e_Room;
            e_Hall = E_CellExpeditionMiniMapHall.None;
            ImgCellMiniMapEditor.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + e_Room);
            ChangeRoomSize();
        }

        if (e_Hall != E_CellExpeditionMiniMapHall.None)
        {
            this.e_Hall = e_Hall;
            e_Room = E_CellExpeditionMiniMapRoom.None;
            ImgCellMiniMapEditor.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + e_Hall);
            ChangeHallSize();
        }
    }

    public void ChangeHallSize()
    {
        ImgCellMiniMapEditor.GetComponent<RectTransform>().sizeDelta =
            new(Hot.DicHallBody[e_Hall].X * Hot.SizeCellItemBody.X, Hot.DicHallBody[e_Hall].Y * Hot.SizeCellItemBody.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta =
            new(Hot.DicHallBody[e_Hall].X * Hot.SizeCellItemBody.X, Hot.DicHallBody[e_Hall].Y * Hot.SizeCellItemBody.Y);
    }

    public void ChangeRoomSize()
    {
        ImgCellMiniMapEditor.GetComponent<RectTransform>().sizeDelta =
            new(Hot.DicRoomBody[e_Room].X * Hot.SizeCellItemBody.X, Hot.DicRoomBody[e_Room].Y * Hot.SizeCellItemBody.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta =
            new(Hot.DicRoomBody[e_Room].X * Hot.SizeCellItemBody.X, Hot.DicRoomBody[e_Room].Y * Hot.SizeCellItemBody.Y);
    }    
}
