using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellMapEditor : PanelBase,
       IPointerEnterHandler, IPointerExitHandler
{
    public PanelCellMapEditorGrid RootGrid = new();    

    public Image ImgCellMapEditor;
    public Image ImgStatus;    

    public E_CellExpeditionMiniMapHall e_Hall = E_CellExpeditionMiniMapHall.None;
    public E_CellExpeditionMiniMapRoom e_Room = E_CellExpeditionMiniMapRoom.None;

    protected override void Awake()
    {
        base.Awake();

        ImgCellMapEditor = transform.FindSonSonSon("ImgCellMapEditor").GetComponent<Image>();
        ImgStatus = transform.FindSonSonSon("ImgStatus").GetComponent<Image>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellMapEditor":
                break;
        }
    }

    #region EventSystem

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.NowCellMapEditor = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.NowCellMapEditor = null;
    }

    #endregion

    public void Init(E_CellExpeditionMiniMapRoom e_Room, E_CellExpeditionMiniMapHall e_Hall)
    {
        if (e_Room != E_CellExpeditionMiniMapRoom.None)
        {
            this.e_Room = e_Room;
            e_Hall = E_CellExpeditionMiniMapHall.None;
            ImgCellMapEditor.sprite = Hot.MgrRes_.Load<Sprite>("Art/CellMapRoom" + e_Room);
            ChangeRoomSize();
        }

        if (e_Hall != E_CellExpeditionMiniMapHall.None)
        {
            this.e_Hall = e_Hall;
            e_Room = E_CellExpeditionMiniMapRoom.None;
            ImgCellMapEditor.sprite = Hot.MgrRes_.Load<Sprite>("Art/CellMapHall" + e_Hall);
            ChangeHallSize();
        }
    }

    public void ChangeHallSize()
    {
        ImgCellMapEditor.GetComponent<RectTransform>().sizeDelta =
            new(Hot.DicHallBody[e_Hall].x * Hot.SizeCellItemBody.x, Hot.DicHallBody[e_Hall].y * Hot.SizeCellItemBody.y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta =
            new(Hot.DicHallBody[e_Hall].x * Hot.SizeCellItemBody.x, Hot.DicHallBody[e_Hall].y * Hot.SizeCellItemBody.y);
    }

    public void ChangeRoomSize()
    {
        ImgCellMapEditor.GetComponent<RectTransform>().sizeDelta =
            new(Hot.DicRoomBody[e_Room].x * Hot.SizeCellItemBody.x, Hot.DicRoomBody[e_Room].y * Hot.SizeCellItemBody.y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta =
            new(Hot.DicRoomBody[e_Room].x * Hot.SizeCellItemBody.x, Hot.DicRoomBody[e_Room].y * Hot.SizeCellItemBody.y);
    }    
}
