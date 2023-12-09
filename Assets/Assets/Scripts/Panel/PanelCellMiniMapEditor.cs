using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellMiniMapEditor : PanelBaseCellVector2,
             IPointerEnterHandler, IPointerExitHandler
{    
    public PanelBaseGrid<PanelCellMiniMapEditor> RootGrid = new();

    public List<List<PanelCellGridRoomEditorConfig>> Map = new();

    public E_CellMiniMapRoom e_Room = E_CellMiniMapRoom.None;

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellMiniMapEditor":
                if (Hot.ChoseCellMiniMapEditor == null)
                {
                    Hot.ChoseCellMiniMapEditor = this;
                }

                if (Hot.ChoseCellMiniMapEditor != this)
                {
                    Hot.ChoseCellMiniMapEditor.ImgItem.raycastTarget = true;
                    Hot.ChoseCellMiniMapEditor.ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                    Hot.ChoseCellMiniMapEditor = this;
                }

                if (Hot.ChoseCellMiniMapEditor != null)
                {
                    Hot.e_ChoseRoom = Hot.ChoseCellMiniMapEditor.e_Room;
                    Hot.PanelOtherMiniMapEditor_.ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + Hot.ChoseCellMiniMapEditor.e_Room);
                }

                Hot.ChoseCellMiniMapEditor.ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctGreen");
                Hot.ChoseCellMiniMapEditor.ImgItem.raycastTarget = false;
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

    public void Init(E_CellMiniMapRoom p_e_room)
    {
        e_Room = p_e_room;
        ImgItem.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + e_Room);
        ChangeRoomSize();

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

    public void ChangeRoomSize()
    {
        ImgItem.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicRoom[e_Room].X * Hot.BodySizeCellMinimap.X, Hot.BodyDicRoom[e_Room].Y * Hot.BodySizeCellMinimap.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicRoom[e_Room].X * Hot.BodySizeCellMinimap.X, Hot.BodyDicRoom[e_Room].Y * Hot.BodySizeCellMinimap.Y);
    }    
}
