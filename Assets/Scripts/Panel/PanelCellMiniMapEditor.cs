using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellMiniMapEditor : PanelBase,
             IPointerEnterHandler, IPointerExitHandler
{    
    public Image ImgCellMiniMapEditor;
    public Image ImgStatus;

    public PanelCellGridMiniMapEditor RootGrid = new();

    public List<List<PanelCellGridRoomEditorConfig>> Map = new();

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
                if (Hot.ChoseCellMapEditor == null)
                {
                    Hot.ChoseCellMapEditor = this;
                    ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctGreen");
                }
                else if (Hot.ChoseCellMapEditor != this)
                {
                    Hot.ChoseCellMapEditor.ImgCellMiniMapEditor.raycastTarget = true;
                    Hot.ChoseCellMapEditor.ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                    ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctGreen");
                    Hot.ChoseCellMapEditor = this;
                }

                if (Hot.ChoseCellMapEditor.e_Hall != E_CellExpeditionMiniMapHall.None)
                {
                    Hot.e_ChoseHall = Hot.ChoseCellMapEditor.e_Hall;
                    Hot.PanelOtherMapEditor_.ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + e_Hall);
                }
                if (Hot.ChoseCellMapEditor.e_Room != E_CellExpeditionMiniMapRoom.None)
                {
                    Hot.e_ChoseRoom = Hot.ChoseCellMapEditor.e_Room;
                    Hot.PanelOtherMapEditor_.ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + e_Room);
                }

                Hot.ChoseCellMapEditor.ImgCellMiniMapEditor.raycastTarget = false;
                break;
        }
    }

    #region EventSystem

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.NowEnterCellMiniMapEditor = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.NowEnterCellMiniMapEditor = null;
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

        InitRoomMap();
    }    

    public void InitRoomMap()
    {
        for (int i5 = 0; i5 < Hot.BodyExpeditionRoom.Y; i5++)
        {
            Map.Add(new());

            for (int i6 = 0; i6 < Hot.BodyExpeditionRoom.X; i6++)
            {
                Map[i5].Add(new());
                Map[i5][i6].Init(i5, i6);
            }
        }
    }

    public void ChangeHallSize()
    {
        ImgCellMiniMapEditor.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicHall[e_Hall].X * Hot.BodySizeCellItem.X, Hot.BodyDicHall[e_Hall].Y * Hot.BodySizeCellItem.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicHall[e_Hall].X * Hot.BodySizeCellItem.X, Hot.BodyDicHall[e_Hall].Y * Hot.BodySizeCellItem.Y);
    }

    public void ChangeRoomSize()
    {
        ImgCellMiniMapEditor.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicRoom[e_Room].X * Hot.BodySizeCellItem.X, Hot.BodyDicRoom[e_Room].Y * Hot.BodySizeCellItem.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicRoom[e_Room].X * Hot.BodySizeCellItem.X, Hot.BodyDicRoom[e_Room].Y * Hot.BodySizeCellItem.Y);
    }    
}
