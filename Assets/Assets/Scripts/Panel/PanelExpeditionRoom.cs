using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

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

        Hot.MgrUI_.CreatePanel<PanelExpeditionRoleDetails>(true, "/PanelExpeditionRoleDetails",
        (panel) =>
        {
            panel.transform.SetParent(transform, false);
        });

        LimitAdd = 5f;
        LimitReduce = 1f;

        InitGrids(Hot.BodyMap.Y, Hot.BodyMap.X);
    }    

    public void LoadDataMap(int p_x, int p_y)
    {
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
                    (PanelCellExpeditionRoom_) =>
                    {
                        PanelCellExpeditionRoom_.Init(Grids[tempY][tempX]);

                        if (Map[tempY][tempX].IndexListRole != -1)
                        {
                            Hot.MgrUI_.CreatePanel<PanelCellRoleExpedition>(false, "/PanelCellRoleExpedition",
                            (PanelCellRoleExpedition_) =>
                            {
                                PanelCellRoleExpedition_.CellExpeditionMiniMap = PanelCellExpeditionRoom_;
                                PanelCellRoleExpedition_.Init(
                                           Hot.PanelBarRoleListExpedition_.ListCellRoleExpedition.Count, 
                                          (PanelCellRoleExpedition_.CellExpeditionMiniMap.RootGrid as PanelGridExpeditionRoom).Data.IndexListRole,
                                           Hot.PanelBarRoleListExpedition_.RoleListExpeditionContent);
                                Hot.PanelBarRoleListExpedition_.ListCellRoleExpedition.Add(PanelCellRoleExpedition_);
                                if (Hot.PanelBarRoleListExpedition_.ListCellRoleExpedition.Count == Hot.DataNowCellGameArchive.ListExpeditionRoleIndex.Count)
                                {
                                    Hot.PanelBarRoleListExpedition_.Sort();
                                }
                            });
                        }
                    });
                }
            }
        }
    }

    public void Clear()
    {
        ClearItem();
    }
}
