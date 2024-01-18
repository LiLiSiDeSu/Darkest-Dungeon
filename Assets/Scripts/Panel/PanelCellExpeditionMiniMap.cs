using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PanelCellExpeditionMiniMap : PanelBaseCellVector2
{
    public PanelGridExpeditionMiniMap RootGrid = new();
    public DataContainer_CellExpeditionMiniMap Data => Hot.DataNowCellGameArchive.GetDataNowCellMiniMap(RootGrid.Y, RootGrid.X);

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellExpeditionMiniMap":
                if (JudgeRoleCanEnter() && JudgeIsSide())
                {
                    Hot.PanelExpeditionRoom_.LoadDataMap(RootGrid.X, RootGrid.Y, false);
                    Hot.NowInCellExpeditionMiniMap = this;
                    Hot.DataNowCellGameArchive.UpdataNowCellMiniMapPos();

                    Hot.Data_.Save();
                }
                break;
        }
    }

    public void Init(PanelGridExpeditionMiniMap p_RootGrid)
    {
        RootGrid = p_RootGrid;

        transform.SetParent(Hot.PanelExpeditionMiniMap_.ItemRoot[RootGrid.Y][RootGrid.X].transform, false);
        transform.localPosition = Vector3.zero;

        ImgItem.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + Data.e_CellMiniMap);

        ImgItem.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicCellMiniMap[Data.e_CellMiniMap].X * Hot.BodyGrid.X, Hot.BodyDicCellMiniMap[Data.e_CellMiniMap].Y * Hot.BodyGrid.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicCellMiniMap[Data.e_CellMiniMap].X * Hot.BodyGrid.X, Hot.BodyDicCellMiniMap[Data.e_CellMiniMap].Y * Hot.BodyGrid.Y);
    }

    public bool JudgeRoleCanEnter()
    {
        return true;
    }

    public bool JudgeIsSide()
    {
        int roomX = Hot.BodyDicCellMiniMap[Hot.DataNowCellGameArchive.GetDataNowCellMiniMap(RootGrid.X, RootGrid.Y).e_CellMiniMap].X;
        int roomY = Hot.BodyDicCellMiniMap[Hot.DataNowCellGameArchive.GetDataNowCellMiniMap(RootGrid.X, RootGrid.Y).e_CellMiniMap].Y;

        for (int iX = 0; iX < roomX; iX++)
        {
            if (RootGrid.Y - 1 >= 0)
            {
                if (Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(RootGrid.X + iX, RootGrid.Y - 1) != null &&
                    Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(RootGrid.X + iX, RootGrid.Y - 1) ==
                    Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(Hot.DataNowCellGameArchive.NowCellMiniMapPos.X, Hot.DataNowCellGameArchive.NowCellMiniMapPos.Y))
                {
                    return true;
                }
            }
            if (RootGrid.Y + roomY <= Hot.PanelExpeditionMiniMap_.MiniMapY - 1)
            {
                if (Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(RootGrid.X + iX, RootGrid.Y + roomY) != null &&
                    Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(RootGrid.X + iX, RootGrid.Y + roomY) ==
                    Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(Hot.DataNowCellGameArchive.NowCellMiniMapPos.X, Hot.DataNowCellGameArchive.NowCellMiniMapPos.Y))
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
                    Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(RootGrid.X - 1, RootGrid.Y + iY) ==
                    Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(Hot.DataNowCellGameArchive.NowCellMiniMapPos.X, Hot.DataNowCellGameArchive.NowCellMiniMapPos.Y))
                {
                    return true;
                }
            }
            if (RootGrid.X + roomX <= Hot.PanelExpeditionMiniMap_.MiniMapX - 1)
            {
                if (Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(RootGrid.X + roomX, RootGrid.Y + iY) != null &&
                    Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(RootGrid.X + roomX, RootGrid.Y + iY) ==
                    Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(Hot.DataNowCellGameArchive.NowCellMiniMapPos.X, Hot.DataNowCellGameArchive.NowCellMiniMapPos.Y))
                {
                    return true;
                }
            }
        }

        return false;
    }
}
