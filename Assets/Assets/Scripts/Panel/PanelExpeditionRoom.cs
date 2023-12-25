using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelExpeditionRoom : PanelBaseVector2<PanelCellExpeditionRoom, PanelGridExpeditionRoom>
{
    public int NowRoleMoveStep = 0;
    public KeyCode NowRoleMoveKey = KeyCode.None;
    public VectorInt2_4 NowRoleMoveSize = new();


    public Transform ImgRoomBk;

    public DataContainer_CellRole ChoseRoleData
    {
        get
        {
            return Hot.DataNowCellGameArchive.ListRole[Hot.ChoseCellExpeditionRoom.RootGrid.Data.IndexListRole];
        }
    }

    protected override void Awake()
    {
        base.Awake();

        ImgRoomBk = transform.FindSonSonSon("ImgRoomBk");

        //取消现在选择的角色
        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelExpeditionRoom") && key == KeyCode.Mouse1)
            {
                if (Hot.ChoseCellExpeditionRoom != null && Hot.UpdateOver)
                {
                    Hot.ChoseCellExpeditionRoom.ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                    Hot.ChoseCellExpeditionRoom = null;
                    Hot.PanelExpeditionRoom_.ClearImgStatus();
                    Hot.PanelBarRoleListExpedition_.ClickMapRole(-1);
                    NowRoleMoveStep = 0;
                    NowRoleMoveKey = KeyCode.None;
                }
            }
        });

        //VFlip已经放置的角色
        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (key == KeyCode.F && Hot.ChoseCellExpeditionRoom != null && Hot.ChoseCellExpeditionRoom.RootGrid.Data.IndexListRole != -1)
            {
                NowRoleMoveKey = KeyCode.None;
                NowRoleMoveStep = 0;

                E_RoleName e_RoleName = ChoseRoleData.e_RoleName;
                int X = Hot.ChoseCellExpeditionRoom.RootGrid.X;
                int Y = Hot.ChoseCellExpeditionRoom.RootGrid.Y;

                if (ChoseRoleData.VFlip == 1)
                {
                    Hot.ChoseCellExpeditionRoom.transform.SetParent(ItemRoot[Y][X + Hot.DicRoleConfig[e_RoleName].SizeBody.X - 1], false);
                    (Grids[Y][X + Hot.DicRoleConfig[e_RoleName].SizeBody.X - 1] as PanelGridExpeditionRoom).Data = (Grids[Y][X] as PanelGridExpeditionRoom).Data;
                    (Grids[Y][X] as PanelGridExpeditionRoom).Data = new();
                    Hot.ChoseCellExpeditionRoom.RootGrid = Grids[Y][X + Hot.DicRoleConfig[e_RoleName].SizeBody.X - 1] as PanelGridExpeditionRoom;
                    Hot.ChoseCellExpeditionRoom.transform.localRotation = new(0, 180, 0, 0);
                    Hot.ChoseCellExpeditionRoom.transform.localPosition = new Vector3(20, 20);
                    Hot.ChoseCellExpeditionRoom.ImgItem.raycastTarget = false;

                    Image img = Instantiate(Hot.ChoseCellExpeditionRoom.ImgItem, Hot.ChoseCellExpeditionRoom.ImgItem.transform.parent);
                    Hot.ChoseCellExpeditionRoom.ImgVFlipCast = img;
                    Hot.ChoseCellExpeditionRoom.ImgVFlipCast.transform.localRotation = new(0, 180, 0, 0);
                    Hot.ChoseCellExpeditionRoom.ImgVFlipCast.transform.localPosition = new Vector3(Hot.BodyGrid.X * Hot.DicRoleConfig[e_RoleName].SizeBody.X, 0);
                    Hot.ChoseCellExpeditionRoom.ImgVFlipCast.raycastTarget = true;
                    Hot.ChoseCellExpeditionRoom.ImgVFlipCast.sprite = Hot.LoadSprite(E_Res.ImgEmpty);

                    ChoseRoleData.VFlip = -1;
                }
                else
                {
                    Hot.ChoseCellExpeditionRoom.transform.SetParent(ItemRoot[Y][X - (Hot.DicRoleConfig[e_RoleName].SizeBody.X - 1)], false);
                    (Grids[Y][X - (Hot.DicRoleConfig[e_RoleName].SizeBody.X - 1)] as PanelGridExpeditionRoom).Data = (Grids[Y][X] as PanelGridExpeditionRoom).Data;
                    (Grids[Y][X] as PanelGridExpeditionRoom).Data = new();
                    Hot.ChoseCellExpeditionRoom.RootGrid = Grids[Y][X - (Hot.DicRoleConfig[e_RoleName].SizeBody.X - 1)] as PanelGridExpeditionRoom;
                    Hot.ChoseCellExpeditionRoom.transform.localRotation = Quaternion.identity;
                    Hot.ChoseCellExpeditionRoom.transform.localPosition = new(-20, 20);
                    Hot.ChoseCellExpeditionRoom.ImgItem.raycastTarget = true;
                    Destroy(Hot.ChoseCellExpeditionRoom.ImgVFlipCast.gameObject);

                    ChoseRoleData.VFlip = 1;
                }

                Hot.PanelExpeditionRoom_.ClearImgStatus();
                Hot.ChoseCellExpeditionRoom.GenerateMoveArea();

                Hot.Data_.Save();
            }
        });

        //移动角色预放置位置
        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (Hot.ChoseCellExpeditionRoom == null)
            {
                return;
            }
            if (Hot.ChoseCellExpeditionRoom.RootGrid.Data.IndexListRole == -1)
            {
                return;
            }

            if (key == KeyCode.W || key == KeyCode.S || key == KeyCode.A || key == KeyCode.D)
            {
                if (NowRoleMoveSize[key] == 0)
                {
                    NowRoleMoveStep = 0;

                    return;
                }

                PreMove(ChoseRoleData.e_RoleName,
                        Hot.ChoseCellExpeditionRoom.RootGrid.X,
                        Hot.ChoseCellExpeditionRoom.RootGrid.Y,
                        Hot.DataNowCellGameArchive.ListRole[Hot.ChoseCellExpeditionRoom.RootGrid.Data.IndexListRole].VFlip,
                        true);

                if (NowRoleMoveKey != key)
                {
                    NowRoleMoveStep = 0;
                }

                NowRoleMoveKey = key;
                NowRoleMoveStep++;

                if (NowRoleMoveStep > NowRoleMoveSize[NowRoleMoveKey])
                {
                    NowRoleMoveStep = NowRoleMoveSize[NowRoleMoveKey];
                }

                PreMove(ChoseRoleData.e_RoleName, Hot.ChoseCellExpeditionRoom.RootGrid.X, Hot.ChoseCellExpeditionRoom.RootGrid.Y, ChoseRoleData.VFlip, false);
            }
        });

        //减少现在角色移动的距离
        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (key == Hot.MgrInput_.Reduce && NowRoleMoveKey != KeyCode.None && NowRoleMoveStep > 1)
            {
                PreMove(Hot.PanelExpeditionRoom_.ChoseRoleData.e_RoleName, 
                        Hot.ChoseCellExpeditionRoom.RootGrid.X, 
                        Hot.ChoseCellExpeditionRoom.RootGrid.Y, 
                        Hot.PanelExpeditionRoom_.ChoseRoleData.VFlip,
                        true);

                NowRoleMoveStep -= 1;

                PreMove(Hot.PanelExpeditionRoom_.ChoseRoleData.e_RoleName,
                        Hot.ChoseCellExpeditionRoom.RootGrid.X,
                        Hot.ChoseCellExpeditionRoom.RootGrid.Y,
                        Hot.PanelExpeditionRoom_.ChoseRoleData.VFlip,
                        false);
            }
        });

        //放置角色
        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (key == KeyCode.Return && Hot.ChoseCellExpeditionRoom != null)
            {
                int x = Hot.ChoseCellExpeditionRoom.RootGrid.X;
                int y = Hot.ChoseCellExpeditionRoom.RootGrid.Y;

                switch (NowRoleMoveKey)
                {
                    case KeyCode.W:
                        MoveData(new(x, y), new(x, y - NowRoleMoveStep));
                        break;
                    case KeyCode.S:
                        MoveData(new(x, y), new(x, y + NowRoleMoveStep));
                        break;
                    case KeyCode.A:
                        MoveData(new(x, y), new(x - NowRoleMoveStep, y));
                        break;
                    case KeyCode.D:
                        MoveData(new(x, y), new(x + NowRoleMoveStep, y));
                        break;
                }

                NowRoleMoveStep = 0;
                NowRoleMoveKey = KeyCode.None;
            }
        });

        #region 开启关闭PanelExpeditionRoom移动

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

        #endregion

        #region Grid预放置逻辑

        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (key == KeyCode.F && Hot.NowEnterGridExpeditionRoom != null && Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Count != 0)
            {
                E_RoleName e_RoleName =
                    Hot.DataNowCellGameArchive.ListRole[Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex[Hot.PanelBarRoleListExpedition_.IndexNowPut]].e_RoleName;

                Hot.VFlip = 1;
                if (Hot.NowEnterGridExpeditionRoom.JudgeRoleCanPut(e_RoleName))
                {
                    for (int iY = 0; iY < Hot.DicRoleConfig[e_RoleName].SizeBody.Y; iY++)
                    {
                        for (int iX = 0; iX < Hot.DicRoleConfig[e_RoleName].SizeBody.X; iX++)
                        {
                            Grids[Hot.NowEnterGridExpeditionRoom.Y + iY][Hot.NowEnterGridExpeditionRoom.X + iX].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                        }
                    }
                }
                Hot.NowEnterGridExpeditionRoom.ImgStatus.sprite = Hot.LoadSprite(E_Res.BorderChoosedGreen);
                Hot.VFlip = -1;
                if (Hot.NowEnterGridExpeditionRoom.JudgeRoleCanPut(e_RoleName))
                {
                    for (int iY = 0; iY < Hot.DicRoleConfig[e_RoleName].SizeBody.Y; iY++)
                    {
                        for (int iX = 0; iX < Hot.DicRoleConfig[e_RoleName].SizeBody.X; iX++)
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
            if (key == KeyCode.F && Hot.NowEnterGridExpeditionRoom != null && Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Count != 0)
            {
                E_RoleName e_RoleName =
                    Hot.DataNowCellGameArchive.ListRole[Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex[Hot.PanelBarRoleListExpedition_.IndexNowPut]].e_RoleName;

                Hot.VFlip = -1;
                if (Hot.NowEnterGridExpeditionRoom.JudgeRoleCanPut(e_RoleName))
                {
                    for (int iY = 0; iY < Hot.DicRoleConfig[e_RoleName].SizeBody.Y; iY++)
                    {
                        for (int iX = 0; iX < Hot.DicRoleConfig[e_RoleName].SizeBody.X; iX++)
                        {
                            Grids[Hot.NowEnterGridExpeditionRoom.Y + iY][Hot.NowEnterGridExpeditionRoom.X - iX].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                        }
                    }
                }
                Hot.NowEnterGridExpeditionRoom.ImgStatus.sprite = Hot.LoadSprite(E_Res.BorderChoosedGreen);
                Hot.VFlip = 1;
                if (Hot.NowEnterGridExpeditionRoom.JudgeRoleCanPut(e_RoleName))
                {
                    for (int iY = 0; iY < Hot.DicRoleConfig[e_RoleName].SizeBody.Y; iY++)
                    {
                        for (int iX = 0; iX < Hot.DicRoleConfig[e_RoleName].SizeBody.X; iX++)
                        {
                            Grids[Hot.NowEnterGridExpeditionRoom.Y + iY][Hot.NowEnterGridExpeditionRoom.X + iX].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgCoverTransparenctGreen);
                        }
                    }
                }
            }
        });

        #endregion

        Hot.MgrUI_.CreatePanel<PanelExpeditionRoleDetails>(true, "/PanelExpeditionRoleDetails",
        (panel) =>
        {
            panel.transform.SetParent(transform, false);
        });

        LimitAdd = 5f;
        LimitReduce = 1f;

        InitGrids(Hot.BodyMap.Y, Hot.BodyMap.X);
    }

    public override void ClearImgStatus()
    {
        foreach (var list in Grids)
        {
            foreach (PanelGridExpeditionRoom item in list)
            {
                item.ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                item.CanMove = false;
            }
        }
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
                       PanelCellExpeditionRoom_.Init(Grids[tempY][tempX] as PanelGridExpeditionRoom, false);

                        if (Map[tempY][tempX].IndexListRole != -1)
                        {
                            Hot.MgrUI_.CreatePanel<PanelCellExpeditionRole>(false, "/PanelCellExpeditionRole",
                            (PanelCellRoleExpedition_) =>
                            {
                                PanelCellRoleExpedition_.CellExpeditionRoom = PanelCellExpeditionRoom_;
                                PanelCellRoleExpedition_.Init(
                                    Hot.PanelBarRoleListExpedition_.ListCellExpeditionRole.Count,
                                    PanelCellRoleExpedition_.CellExpeditionRoom.RootGrid.Data.IndexListRole,
                                    Hot.PanelBarRoleListExpedition_.RoleListExpeditionContent);
                                Hot.PanelBarRoleListExpedition_.ListCellExpeditionRole.Add(PanelCellRoleExpedition_);

                                if (Hot.DataNowCellGameArchive.ListNowPutRole.Count < Hot.DataNowCellGameArchive.ListExpeditionRoleIndex.Count &&
                                    Hot.PanelBarRoleListExpedition_.ListCellExpeditionRole.Count == Hot.DataNowCellGameArchive.ListNowPutRole.Count)
                                {
                                    for (int i = 0; i < Hot.DataNowCellGameArchive.ListNowPutRole.Count; i++)
                                    {
                                        Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Add(-1);
                                    }

                                    Hot.PanelBarRoleListExpedition_.IndexNowPut = Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Count;

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
                                            panel.Init(tempi, 
                                                       Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex[tempi], 
                                                       Hot.PanelBarRoleListExpedition_.RoleListExpeditionContent);
                                            Hot.PanelBarRoleListExpedition_.ListCellExpeditionRole.Add(panel);
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

    public void PreMove(E_RoleName e_RoleName, int RootX, int RootY, int VFlip, bool isClear)
    {
        E_Res e_Res = E_Res.ImgCoverTransparenctRed;

        if (isClear)
        {
            e_Res = E_Res.ImgCoverTransparenctRed;
        }
        else
        {
            e_Res= E_Res.ImgCoverTransparenctGreen;
        }

        for (int iY = 0; iY < Hot.DicRoleConfig[e_RoleName].SizeBody.Y; iY++)
        {
            for (int iX = 0; iX < Hot.DicRoleConfig[e_RoleName].SizeBody.X; iX++)
            {
                switch (NowRoleMoveKey)
                {
                    case KeyCode.W:
                        Grids[RootY + iY - NowRoleMoveStep][RootX + iX * VFlip].ImgStatus.sprite = Hot.LoadSprite(e_Res);
                        break;
                    case KeyCode.S:
                        Grids[RootY + iY + NowRoleMoveStep][RootX + iX * VFlip].ImgStatus.sprite = Hot.LoadSprite(e_Res);
                        break;
                    case KeyCode.A:
                        Grids[RootY + iY][RootX + iX * VFlip - NowRoleMoveStep].ImgStatus.sprite = Hot.LoadSprite(e_Res);
                        break;
                    case KeyCode.D:
                        Grids[RootY + iY][RootX + iX * VFlip + NowRoleMoveStep].ImgStatus.sprite = Hot.LoadSprite(e_Res);
                        break;
                }
            }
        }
    }
    public void MoveData(Vector2Int sourecPos, Vector2Int movePos)
    {
        (Grids[sourecPos.y][sourecPos.x] as PanelGridExpeditionRoom).Item.transform.SetParent(ItemRoot[movePos.y][movePos.x], false);
        (Grids[movePos.y][movePos.x] as PanelGridExpeditionRoom).Data = (Grids[sourecPos.y][sourecPos.x] as PanelGridExpeditionRoom).Data;
        (Grids[sourecPos.y][sourecPos.x] as PanelGridExpeditionRoom).InitGridByRole(ChoseRoleData.e_RoleName, null, ChoseRoleData.VFlip);
        (Grids[movePos.y][movePos.x] as PanelGridExpeditionRoom).
            InitGridByRole(ChoseRoleData.e_RoleName, ItemRoot[movePos.y][movePos.x].GetComponentInChildren<PanelCellExpeditionRoom>(), ChoseRoleData.VFlip);
        ItemRoot[movePos.y][movePos.x].GetComponentInChildren<PanelCellExpeditionRoom>().RootGrid = (Grids[movePos.y][movePos.x] as PanelGridExpeditionRoom);
        (Grids[sourecPos.y][sourecPos.x] as PanelGridExpeditionRoom).Data = new();

        Hot.PanelExpeditionRoom_.ClearImgStatus();
        Hot.ChoseCellExpeditionRoom.GenerateMoveArea();

        Hot.Data_.Save();
    }

    public void Clear()
    {
        ClearItem();
    }
}
