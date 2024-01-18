using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PanelExpeditionMiniMap : PanelBaseVector2<PanelCellExpeditionMiniMap, PanelGridExpeditionMiniMap>
{
    public int MiniMapY => Grids.Count;
    public int MiniMapX => Grids[0].Count;

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(), (key) =>
        {
            if (Hot.e_NowPlayerLocation == E_PlayerLocation.OnExpedition && key == Hot.MgrInput_.Map)
            {
                if (Hot.PoolNowPanel_.ListNowPanel.Contains("PanelExpeditionMiniMap"))
                {
                    Hot.MgrUI_.HidePanel(false, Hot.PanelExpeditionMiniMap_.gameObject, "PanelExpeditionMiniMap");
                }
                else
                {
                    Hot.MgrUI_.ShowPanel<PanelExpeditionMiniMap>(true, "PanelExpeditionMiniMap");
                }
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyHold.ToString(),
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelExpeditionMiniMap"))
            {
                if (key == Hot.MgrInput_.Add)
                {
                    AllContent.localScale += new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
                }

                if (key == Hot.MgrInput_.Reduce && AllContent.localScale.x > 0.5f)
                {
                    AllContent.localScale -= new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
                }
            }
        });
    }

    public void Init(bool isCreateByChooseGameArchive)
    {
        ClearAll();
        InitGrids(Hot.DataNowCellGameArchive.DataNowEvent.ListCellMiniMap.Count,
                  Hot.DataNowCellGameArchive.DataNowEvent.ListCellMiniMap[0].Count);
        LoadItem(isCreateByChooseGameArchive);
    }

    public override void End()
    {
        base.End();

        DisableImgBkRaycast();
    }

    public void LoadItem(bool isCreateByChooseGameArchive)
    {
        DataContainer_ExpeditionMiniMap DataNowExpeditionEvent = Hot.DataNowCellGameArchive.DataNowEvent;

        for (int iY = 0; iY < DataNowExpeditionEvent.ListCellMiniMap.Count; iY++)
        {
            int tempY = iY;

            for (int iX = 0; iX < DataNowExpeditionEvent.ListCellMiniMap[0].Count; iX++)
            {
                int tempX = iX;

                if (DataNowExpeditionEvent.ListCellMiniMap[tempY][tempX].e_CellMiniMap != E_CellMiniMap.None)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellExpeditionMiniMap>(false, "/PanelCellExpeditionMiniMap",
                    (panel) =>
                    {
                        E_CellMiniMap e_CellMiniMap = DataNowExpeditionEvent.ListCellMiniMap[tempY][tempX].e_CellMiniMap;
                        panel.Init(Grids[tempY][tempX] as PanelGridExpeditionMiniMap);

                        for (int jY = 0; jY < Hot.BodyDicCellMiniMap[e_CellMiniMap].Y; jY++)
                        {
                            for (int jX = 0; jX < Hot.BodyDicCellMiniMap[e_CellMiniMap].X; jX++)
                            {
                                Grids[tempY + jY][tempX + jX].Item = panel;
                            }
                        }

                        if (e_CellMiniMap == E_CellMiniMap.CellMiniMapRoomEntrance)
                        {
                            my_VectorInt2 pos = new();
                            if (Hot.e_NowPlayerLocation != E_PlayerLocation.ChooseGameArchive)
                            {
                                pos = DataNowExpeditionEvent.EntrancePos;
                                Hot.NowInCellExpeditionMiniMap = GetCellExpeditionMiniMap(pos.X, pos.Y);
                                Hot.DataNowCellGameArchive.UpdataNowCellMiniMapPos();
                            }
                            else
                            {
                                pos = Hot.DataNowCellGameArchive.NowCellMiniMapPos;
                            }
                            Hot.PanelExpeditionRoom_.LoadDataMap(pos.X, pos.Y, isCreateByChooseGameArchive);
                            Hot.e_NowPlayerLocation = E_PlayerLocation.OnExpedition;
                        }
                    });
                }
            }
        }
    }

    public PanelCellExpeditionMiniMap GetCellExpeditionMiniMap(int p_x, int p_y)
    {
        return Grids[p_y][p_x].Item;
    }
}
