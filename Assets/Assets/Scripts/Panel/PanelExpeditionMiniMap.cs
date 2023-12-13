using System.Collections.Generic;
using UnityEngine;

public class PanelExpeditionMiniMap : PanelBaseVector2<PanelCellExpeditionMiniMap, PanelGridExpeditionMiniMap>
{    
    public int MiniMapY
    {
        get
        {
            return Grids.Count;
        }
    }
    public int MiniMapX
    {
        get
        {
            return Grids[0].Count;
        }
    }

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyDown", (key) =>
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

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
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

    public void Init()
    {
        InitGrids(Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap.Count, Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap[0].Count);
        InitItem();
    }

    public override void End()
    {
        base.End();

        DisableImgBkRaycast();
    }

    public void InitItem()
    {
        for (int iY = 0; iY < Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap.Count; iY++)
        {
            int tempY = iY;

            for (int iX = 0; iX < Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap[0].Count; iX++)
            {
                int tempX = iX;

                if (Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap[tempY][tempX].e_CellMiniMap != E_CellMiniMap.None)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellExpeditionMiniMap>(false, "/PanelCellExpeditionMiniMap",
                    (panel) =>
                    {
                        E_CellMiniMap e_CellMiniMap = Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap[tempY][tempX].e_CellMiniMap;
                        panel.Init(Grids[tempY][tempX], e_CellMiniMap);

                        for (int jY = 0; jY < Hot.BodyDicCellMiniMap[e_CellMiniMap].Y; jY++)
                        {
                            for (int jX = 0; jX < Hot.BodyDicCellMiniMap[e_CellMiniMap].X; jX++)
                            {
                                Grids[tempY + jY][tempX + jX].Item = panel;
                            }
                        }

                        if (e_CellMiniMap == E_CellMiniMap.CellMiniMapRoomEntrance)
                        {
                            my_Vector2 pos = Hot.NowExpeditionEvent.DataExpedition.EntrancePos;
                            Hot.NowEnterCellExpeditionMiniMap = Hot.PanelExpeditionMiniMap_.GetCellExpeditionMiniMap(pos.X, pos.Y);
                            Hot.DataNowCellGameArchive.InitDataNowEnterCellMiniMap();
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
