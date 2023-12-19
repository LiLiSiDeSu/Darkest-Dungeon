using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                ClearImgStatus();
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
        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (key == KeyCode.F && Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Count != 0)
            {
                E_RoleName e_RoleName =
                    Hot.DataNowCellGameArchive.ListRole[Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex[Hot.PanelBarRoleListExpedition_.NowPutIndex]].e_RoleName;

                Hot.VFlip = 1;
                if (Hot.NowEnterGridExpeditionRoom.JudgeRoleCanPut(e_RoleName))
                {
                    for (int iY = 0; iY < Hot.DicRoleConfig[e_RoleName].BodySize.Y; iY++)
                    {
                        for (int iX = 0; iX < Hot.DicRoleConfig[e_RoleName].BodySize.X; iX++)
                        {
                            Grids[Hot.NowEnterGridExpeditionRoom.Y + iY][Hot.NowEnterGridExpeditionRoom.X + iX].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                        }
                    }
                }
                Hot.NowEnterGridExpeditionRoom.ImgStatus.sprite = Hot.LoadSprite(E_Res.BorderChoosedGreen);
                Hot.VFlip = -1;
                if (Hot.NowEnterGridExpeditionRoom.JudgeRoleCanPut(e_RoleName))
                {
                    for (int iY = 0; iY < Hot.DicRoleConfig[e_RoleName].BodySize.Y; iY++)
                    {
                        for (int iX = 0; iX < Hot.DicRoleConfig[e_RoleName].BodySize.X; iX++)
                        {
                            Grids[Hot.NowEnterGridExpeditionRoom.Y + iY][Hot.NowEnterGridExpeditionRoom.X - iX].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgCoverTransparenctGreen);
                        }
                    }
                }

                Hot.VFlip = -1;
            }
        });
        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyUp.ToString(),
        (key) =>
        {
            if (key == KeyCode.F && Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Count != 0)
            {
                E_RoleName e_RoleName =
                    Hot.DataNowCellGameArchive.ListRole[Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex[Hot.PanelBarRoleListExpedition_.NowPutIndex]].e_RoleName;

                Hot.VFlip = -1;
                if (Hot.NowEnterGridExpeditionRoom.JudgeRoleCanPut(e_RoleName))
                {
                    for (int iY = 0; iY < Hot.DicRoleConfig[e_RoleName].BodySize.Y; iY++)
                    {
                        for (int iX = 0; iX < Hot.DicRoleConfig[e_RoleName].BodySize.X; iX++)
                        {
                            Grids[Hot.NowEnterGridExpeditionRoom.Y + iY][Hot.NowEnterGridExpeditionRoom.X - iX].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                        }
                    }
                }
                Hot.NowEnterGridExpeditionRoom.ImgStatus.sprite = Hot.LoadSprite(E_Res.BorderChoosedGreen);
                Hot.VFlip = 1;
                if (Hot.NowEnterGridExpeditionRoom.JudgeRoleCanPut(e_RoleName))
                {
                    for (int iY = 0; iY < Hot.DicRoleConfig[e_RoleName].BodySize.Y; iY++)
                    {
                        for (int iX = 0; iX < Hot.DicRoleConfig[e_RoleName].BodySize.X; iX++)
                        {
                            Grids[Hot.NowEnterGridExpeditionRoom.Y + iY][Hot.NowEnterGridExpeditionRoom.X + iX].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgCoverTransparenctGreen);
                        }
                    }
                }
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

    public void LoadDataMap(int p_x, int p_y, bool isCreateByChooseGameArchive)
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
                       PanelCellExpeditionRoom_.Init(Grids[tempY][tempX], false);

                        if (Map[tempY][tempX].IndexListRole != -1)
                        {
                            Hot.MgrUI_.CreatePanel<PanelCellExpeditionRole>(false, "/PanelCellExpeditionRole",
                            (PanelCellRoleExpedition_) =>
                            {
                                PanelCellRoleExpedition_.CellExpeditionMiniMap = PanelCellExpeditionRoom_;
                                PanelCellRoleExpedition_.Init(
                                    Hot.PanelBarRoleListExpedition_.ListCellRoleExpedition.Count,
                                   (PanelCellRoleExpedition_.CellExpeditionMiniMap.RootGrid as PanelGridExpeditionRoom).Data.IndexListRole,
                                    Hot.PanelBarRoleListExpedition_.RoleListExpeditionContent);
                                Hot.PanelBarRoleListExpedition_.ListCellRoleExpedition.Add(PanelCellRoleExpedition_);

                                if (Hot.DataNowCellGameArchive.ListNowPutRole.Count < Hot.DataNowCellGameArchive.ListExpeditionRoleIndex.Count &&
                                    Hot.PanelBarRoleListExpedition_.ListCellRoleExpedition.Count == Hot.DataNowCellGameArchive.ListNowPutRole.Count)
                                {
                                    for (int i = 0; i < Hot.DataNowCellGameArchive.ListNowPutRole.Count; i++)
                                    {
                                        Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Add(-1);
                                    }

                                    Hot.PanelBarRoleListExpedition_.NowPutIndex = Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Count;

                                    for (int i = 0; i < Hot.DataNowCellGameArchive.ListExpeditionRoleIndex.Count; i++)
                                    {
                                        if (!Hot.DataNowCellGameArchive.ListNowPutRole.Contains(Hot.DataNowCellGameArchive.ListExpeditionRoleIndex[i]))
                                        {
                                            Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Add(Hot.DataNowCellGameArchive.ListExpeditionRoleIndex[i]);
                                        }
                                    }

                                    for (int i = 0; i < Hot.DataNowCellGameArchive.ListExpeditionRoleIndex.Count - Hot.DataNowCellGameArchive.ListNowPutRole.Count; i++)
                                    {
                                        int tempi = i + Hot.DataNowCellGameArchive.ListNowPutRole.Count;

                                        Hot.MgrUI_.CreatePanel<PanelCellExpeditionRole>(false, "/PanelCellExpeditionRole",
                                        (panel) =>
                                        {
                                            panel.Init(tempi, Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex[tempi], Hot.PanelBarRoleListExpedition_.RoleListExpeditionContent);
                                            Hot.PanelBarRoleListExpedition_.ListCellRoleExpedition.Add(panel);
                                        });
                                    }
                                }
                            });
                        }
                    });
                }

                if (tempY == Map.Count - 1 && tempX == Map[0].Count - 1 && isCreateByChooseGameArchive)
                {
                    if (Hot.DataNowCellGameArchive.ListNowPutRole.Count == 0)
                    {
                        Hot.PanelBarRoleListExpedition_.Init();
                    }
                }
            }
        }
    }

    public void Clear()
    {
        ClearItem();
    }
}
