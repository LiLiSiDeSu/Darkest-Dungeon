using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PanelCellExpeditionMiniMap : PanelBaseCellVector2
{
    public PanelBaseGrid<PanelCellExpeditionMiniMap> RootGrid = new();
    public E_CellMap e_CellMap = E_CellMap.None;

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellExpeditionMiniMap":
                if (JudgeCanEnter())
                {
                    Hot.PanelExpeditionRoom_.LoadDataMap(RootGrid.X, RootGrid.Y);
                    Hot.NowEnterCellExpeditionMiniMap = this;
                    Hot.DataNowCellGameArchive.UpdataNowRoomPos();
                }
                break;
        }
    }

    public void Init(PanelBaseGrid<PanelCellExpeditionMiniMap> p_RootGrid, E_CellMap p_e_CellMap)
    {
        e_CellMap = p_e_CellMap;
        RootGrid = p_RootGrid;
        transform.SetParent(RootGrid.transform, false);

        ImgItem.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + e_CellMap);

        ImgItem.GetComponent<RectTransform>().sizeDelta = new(Hot.BodyDicRoom[e_CellMap].X * Hot.BodySizeGrid.X, Hot.BodyDicRoom[e_CellMap].Y * Hot.BodySizeGrid.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta = new(Hot.BodyDicRoom[e_CellMap].X * Hot.BodySizeGrid.X, Hot.BodyDicRoom[e_CellMap].Y * Hot.BodySizeGrid.Y);
    }

    public bool JudgeCanEnter()
    {
        int roomX = Hot.BodyDicRoom[Hot.NowExpeditionEvent.GetDataCellExpeditionMiniMap(RootGrid.X, RootGrid.Y).e_Room].X;
        int roomY = Hot.BodyDicRoom[Hot.NowExpeditionEvent.GetDataCellExpeditionMiniMap(RootGrid.X, RootGrid.Y).e_Room].Y;

        for (int iX = 0; iX < roomX; iX++)
        {
            if (RootGrid.Y - 1 >= 0)
            {
                if (Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(RootGrid.X + iX, RootGrid.Y - 1) != null &&
                    Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(RootGrid.X + iX, RootGrid.Y - 1) == Hot.NowEnterCellExpeditionMiniMap)
                {
                    return true;
                }
            }
            if (RootGrid.Y + roomY <= Hot.PanelExpeditionMiniMap_.MiniMapY - 1)
            {
                if (Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(RootGrid.X + iX, RootGrid.Y + roomY) != null &&
                    Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(RootGrid.X + iX, RootGrid.Y + roomY) == Hot.NowEnterCellExpeditionMiniMap)
                {
                    return true;
                }
            }
        }

        for (int iY = 0; iY < roomY; iY++)
        {
            if (RootGrid.X - 1 >= 0)
            {
                if (Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(RootGrid.X - 1, RootGrid.Y + iY) != null &&
                    Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(RootGrid.X - 1, RootGrid.Y + iY) == Hot.NowEnterCellExpeditionMiniMap)
                {
                    return true;
                }
            }
            if (RootGrid.X + roomX <= Hot.PanelExpeditionMiniMap_.MiniMapX - 1)
            {
                if (Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(RootGrid.X + roomX, RootGrid.Y + iY) != null &&
                    Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(RootGrid.X + roomX, RootGrid.Y + iY) == Hot.NowEnterCellExpeditionMiniMap)
                {
                    return true;
                }
            }
        }

        Debug.Log(false);
        return false;
    }
}
