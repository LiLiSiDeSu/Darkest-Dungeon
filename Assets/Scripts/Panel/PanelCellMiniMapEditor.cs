using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelCellMiniMapEditor : PanelBaseCellVector2,
             IPointerEnterHandler, IPointerExitHandler
{
    public PanelBaseGrid<PanelCellMiniMapEditor> RootGrid = new();

    public List<List<PanelGridRoomEditorConfig>> Map = new();

    public E_CellMiniMap e_CellMiniMap = E_CellMiniMap.None;

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
                    Hot.e_ChoseRoom = Hot.ChoseCellMiniMapEditor.e_CellMiniMap;
                    Hot.PanelOtherEditorMiniMap_.ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + Hot.ChoseCellMiniMapEditor.e_CellMiniMap);
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

    public void Init(E_CellMiniMap p_e_room, PanelBaseGrid<PanelCellMiniMapEditor> p_RootGrid)
    {
        e_CellMiniMap = p_e_room;
        RootGrid = p_RootGrid;

        transform.SetParent(Hot.PanelOtherEditorMiniMap_.ItemRoot[RootGrid.Y][RootGrid.X].transform, false);
        transform.localPosition = new(-20, 20);

        ImgItem.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + e_CellMiniMap);
        ChangeRoomSize();

        InitRoomMap();
    }

    public void InitRoomMap()
    {
        for (int i5 = 0; i5 < Hot.BodyMap.Y; i5++)
        {
            Map.Add(new());

            for (int i6 = 0; i6 < Hot.BodyMap.X; i6++)
            {
                Map[i5].Add(new());
                Map[i5][i6].Init(i5, i6);
            }
        }
    }

    public void ChangeRoomSize()
    {
        ImgItem.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicCellMiniMap[e_CellMiniMap].X * Hot.BodySizeCellMinimap.X, Hot.BodyDicCellMiniMap[e_CellMiniMap].Y * Hot.BodySizeCellMinimap.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicCellMiniMap[e_CellMiniMap].X * Hot.BodySizeCellMinimap.X, Hot.BodyDicCellMiniMap[e_CellMiniMap].Y * Hot.BodySizeCellMinimap.Y);
    }
}
