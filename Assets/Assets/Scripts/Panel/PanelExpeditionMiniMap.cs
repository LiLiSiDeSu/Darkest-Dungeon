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

    public void InitItem()
    {
        for (int iY = 0; iY < Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap.Count; iY++)
        {
            for (int iX = 0; iX < Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap[0].Count; iX++)
            {

            }
        }

        //¸øHot.NowEnterCellExpeditionMiniMap¸³EntranceµÄÖµ
        //Hot.DataNowCellGameArchive.InitDataNowEnterCellExpeditionMiniMap();
    }

    public PanelCellExpeditionMiniMap GetCellExpeditionMiniMap(int p_x, int p_y)
    {
        return Grids[p_y][p_x].Item;
    }
}
