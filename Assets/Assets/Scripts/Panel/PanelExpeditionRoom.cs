using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PanelExpeditionRoom : PanelBaseVector2<PanelCellExpeditionRoom, PanelGridExpeditionRoom>
{
    public Transform ImgRoomBk;

    protected override void Awake()
    {
        base.Awake();

        ImgRoomBk = transform.FindSonSonSon("ImgRoomBk");

        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelExpeditionRoom") && key == KeyCode.LeftControl)
            {
                ImgBkContent.gameObject.SetActive(false);
                Hot.NowEnterGridExpeditionRoom.ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
            }
        });
        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyUp.ToString(),
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelExpeditionRoom") && key == KeyCode.LeftControl)
            {
                ImgBkContent.gameObject.SetActive(true);
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyHold.ToString(),
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelExpeditionRoom") && !Hot.PoolNowPanel_.ContainPanel("PanelExpeditionMiniMap"))
            {
                if (AllContent.localScale.x < 5f && key == Hot.MgrInput_.Add)
                {
                    AllContent.localScale += new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime);
                }

                if (AllContent.localScale.x > 1f && key == Hot.MgrInput_.Reduce)
                {
                    AllContent.localScale -= new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime);
                }
            }
        });

        Hot.MgrUI_.CreatePanel<PanelExpeditionRoleDetails>(true, "/PanelExpeditionRoleDetails",
        (panel) =>
        {
            panel.transform.SetParent(transform, false);
        });

        InitGrids(Hot.BodyMap.Y, Hot.BodyMap.X);
    }    

    public void LoadDataMap(int p_x, int p_y)
    {
        ClearItem();

        List<List<DataContainer_GridExpeditionMap>> Map = Hot.DataNowCellGameArchive.DataNowEvent.ListCellMiniMap[p_y][p_x].Map;

        for (int Y = 0; Y < Map.Count; Y++)
        {
            int tempY = Y;

            for (int X = 0; X < Map[Y].Count; X++)
            {
                int tempX = X;

                if (Map[tempY][tempX].MapObj != null || Map[tempY][tempX].IndexListRole != -1 || Map[tempY][tempX].OtherRole != null)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellExpeditionRoom>(false, "/PanelCellExpeditionRoom",
                    (panel) =>
                    {
                        panel.Init(Grids[tempY][tempX]);
                    });
                }
            }
        }
    }
}
