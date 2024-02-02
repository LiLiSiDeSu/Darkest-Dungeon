using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelExpeditionRoom : PanelBaseVector2<PanelCellExpeditionRoom, PanelGridExpeditionRoom>
{
    public int NowRoleMoveStep = 0;
    public KeyCode NowRoleMoveKey = KeyCode.None;
    public VectorInt2_4 NowRoleMoveSize = new();

    public Transform ImgRoomBk;

    protected override void Awake()
    {
        base.Awake();

        ImgRoomBk = transform.FindSonSonSon("ImgRoomBk");

        // Cancel chose - skill --> role
        Hot.TriggerEvent_.AddEventListener<KeyCode>
        (E_KeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (key == KeyCode.Mouse1 && Hot.PoolNowPanel_.ContainPanel(E_PanelName.PanelExpeditionRoom))
            {
                if (Hot.PanelExpeditionRoleDetails_.e_ChoseSkill != E_Skill.None)
                {
                    Hot.PanelExpeditionRoleDetails_.UpdateNowRoleSkill(E_Skill.None);
                    Hot.ChoseCellExpeditionRoom.GenerateMoveArea();
                    Hot.ChoseCellExpeditionRoom.ImgStatus.sprite = Hot.MgrRes_.LoadSprite(E_Res.ImgCoverTransparenctGreen);
                }
                else if (Hot.ChoseCellExpeditionRoom != null && Hot.PanelExpeditionRoleDetails_.UpdateOver)
                {
                    Hot.ChoseCellExpeditionRoom.UpdateImgStatus(true);
                    Hot.ChoseCellExpeditionRoom = null;
                    Hot.PanelBarRoleListExpedition_.ClickMapExpeditionRole(-1);

                    ClearMoveStaus();
                }
            }
        });

        //VFlip role that has been placed
        Hot.TriggerEvent_.AddEventListener<KeyCode>
        (E_KeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (key == KeyCode.F && Hot.ChoseCellExpeditionRoom != null && Hot.ChoseCellExpeditionRoom.RootGrid.Data.IndexListRole != -1)
            {
                NowRoleMoveKey = KeyCode.None;
                NowRoleMoveStep = 0;

                E_RoleName e_RoleName = Hot.ChoseCellExpeditionRoom.DataRole.e_RoleName;
                int X = Hot.ChoseCellExpeditionRoom.RootGrid.X;
                int Y = Hot.ChoseCellExpeditionRoom.RootGrid.Y;

                if (Hot.ChoseCellExpeditionRoom.DataRole.VFlip == 1)
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

                    Hot.ChoseCellExpeditionRoom.DataRole.VFlip = -1;
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

                    Hot.ChoseCellExpeditionRoom.DataRole.VFlip = 1;
                }

                ClearImgStatus();
                
                if (Hot.PanelExpeditionRoleDetails_.e_ChoseSkill != E_Skill.None)
                {
                    Hot.ChoseCellExpeditionRoom.GenerateSkillArea(Hot.PanelExpeditionRoleDetails_.e_ChoseSkill);
                }
                else
                {
                    Hot.ChoseCellExpeditionRoom.GenerateMoveArea();
                }

                Hot.Data_.Save();
            }
        });

        // Add now role premove distance
        Hot.TriggerEvent_.AddEventListener<KeyCode>
        (E_KeyEvent.KeyDown.ToString(),
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
                    return;
                }

                PreMove(true);

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

                PreMove(false);
            }
        });

        // Reduce now role premove distance
        Hot.TriggerEvent_.AddEventListener<KeyCode>
        (E_KeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (key == Hot.MgrInput_.Reduce && NowRoleMoveKey != KeyCode.None && NowRoleMoveStep > 1)
            {
                PreMove(true);

                NowRoleMoveStep -= 1;

                PreMove(false);
            }
        });

        // Confirm place a role
        Hot.TriggerEvent_.AddEventListener<KeyCode>
        (E_KeyEvent.KeyDown.ToString(),
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

        Hot.TriggerEvent_.AddEventListener<KeyCode>
        (E_KeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel(E_PanelName.PanelExpeditionRoom) && key == KeyCode.LeftControl)
            {
                ImgBkContent.gameObject.SetActive(false);
                ClearImgStatus();
            }
        });
        Hot.TriggerEvent_.AddEventListener<KeyCode>
        (E_KeyEvent.KeyUp.ToString(),
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel(E_PanelName.PanelExpeditionRoom) && key == KeyCode.LeftControl)
            {
                ImgBkContent.gameObject.SetActive(true);
            }
        });

        #endregion

        #region Pre place a grid

        Hot.TriggerEvent_.AddEventListener<KeyCode>
        (E_KeyEvent.KeyDown.ToString(),
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
                            Grids[Hot.NowEnterGridExpeditionRoom.Y + iY][Hot.NowEnterGridExpeditionRoom.X - iX].ImgStatus.sprite = 
                                Hot.LoadSprite(E_Res.ImgCoverTransparenctGreen);
                        }
                    }
                }

                Hot.VFlip = -1;
            }
        });
        Hot.TriggerEvent_.AddEventListener<KeyCode>
        (E_KeyEvent.KeyUp.ToString(),
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
                            Grids[Hot.NowEnterGridExpeditionRoom.Y + iY][Hot.NowEnterGridExpeditionRoom.X + iX].ImgStatus.sprite = 
                                Hot.LoadSprite(E_Res.ImgCoverTransparenctGreen);
                        }
                    }
                }
            }
        });

        #endregion

        Hot.MgrUI_.CreatePanel<PanelExpeditionRoleDetails>
        (true, E_PanelName.PanelExpeditionRoleDetails,
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
                item.CanChangeImgStatus = true;
            }
        }
    }
    public void ClearMoveStaus()
    {
        ClearImgStatus();
        
        NowRoleMoveStep = 0;
        NowRoleMoveKey = KeyCode.None;
        NowRoleMoveSize = new();
    }
    public void Clear()
    {
        ClearItem();
    }

    public void RoleOnClick(PanelCellExpeditionRoom p_clickCellExpeditionRoom)
    {
        if (!Hot.PanelExpeditionRoleDetails_.UpdateOver ||
            Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Count != 0)
        {
            return;
        }

        int IndexListRole = p_clickCellExpeditionRoom.RootGrid.Data.IndexListRole;
        Hot.PanelExpeditionRoom_.ClearMoveStaus();

        if (Hot.ChoseCellExpeditionRoom == null)
        {
            Hot.ChoseCellExpeditionRoom = p_clickCellExpeditionRoom;
            Hot.ChoseCellExpeditionRoom.UpdateImgStatus(false);            

            if (IndexListRole != -1)
            {
                Hot.ChoseCellExpeditionRoom.GenerateMoveArea();
                Hot.PanelBarRoleListExpedition_.ClickMapExpeditionRole(IndexListRole);
            }

            return;
        }

        if (IndexListRole != -1)
        {
            Hot.PanelExpeditionRoleDetails_.UpdateNowRoleSkill(E_Skill.None);
        }

        if (Hot.ChoseCellExpeditionRoom == p_clickCellExpeditionRoom)
        {
            Hot.ChoseCellExpeditionRoom.UpdateImgStatus(true);
            Hot.ChoseCellExpeditionRoom = null;

            if (IndexListRole != -1)
            {
                Hot.PanelBarRoleListExpedition_.ClickMapExpeditionRole(-1);
            }

            return;
        }

        if (Hot.ChoseCellExpeditionRoom != p_clickCellExpeditionRoom)
        {
            Hot.ChoseCellExpeditionRoom.UpdateImgStatus(true);
            Hot.ChoseCellExpeditionRoom = p_clickCellExpeditionRoom;
            Hot.ChoseCellExpeditionRoom.UpdateImgStatus(false);
            
            if (IndexListRole != -1)
            {
                Hot.ChoseCellExpeditionRoom.GenerateMoveArea();
                Hot.PanelBarRoleListExpedition_.ClickMapExpeditionRole(IndexListRole);
            }

            return;
        }
    }

    public void ChangeMapItemAlpha(float p_value, PanelCellExpeditionRoom p_CellExpeditionRoom)
    {
        foreach (List<PanelBaseGrid<PanelCellExpeditionRoom>> list in Grids)
        {
            foreach (PanelBaseGrid<PanelCellExpeditionRoom> item in list)
            {
                if (item.Item != null)
                {
                    if (item.Item != p_CellExpeditionRoom)
                    {
                        item.Item.ImgItem.color = new Color(item.Item.ImgItem.color.r, item.Item.ImgItem.color.g, item.Item.ImgItem.color.b, p_value);
                    }
                    else
                    {
                        item.Item.ImgItem.color = new Color(item.Item.ImgItem.color.r, item.Item.ImgItem.color.g, item.Item.ImgItem.color.b, 1f);
                    }
                }
            }
        }
    }
    public void RevertMapItemAlpha()
    {
        foreach (List<PanelBaseGrid<PanelCellExpeditionRoom>> list in Grids)
        {
            foreach (PanelBaseGrid<PanelCellExpeditionRoom> item in list)
            {
                if (item.Item != null)
                {
                    item.Item.ImgItem.color = new Color(item.Item.ImgItem.color.r, item.Item.ImgItem.color.g, item.Item.ImgItem.color.b, 1f);
                }
            }
        }
    }

    public void LoadDataMap(int p_x, int p_y, bool p_isCreateByChooseGameArchive)
    {
        Clear();

        List<List<DataContainer_GridExpeditionMap>> Map = Hot.DataNowCellGameArchive.DataNowEvent.ListCellMiniMap[p_y][p_x].Map;

        for (int Y = 0; Y < Map.Count; Y++)
        {
            int tempY = Y;

            for (int X = 0; X < Map[Y].Count; X++)
            {
                int tempX = X;

                if (Map[tempY][tempX].MapObj != null || Map[tempY][tempX].IndexListRole != -1 || Map[tempY][tempX].OtherRole != null)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellExpeditionRoom>(false, E_PanelName.PanelCellExpeditionRoom,
                    (PanelCellExpeditionRoom_) =>
                    {
                        PanelCellExpeditionRoom_.Init(Grids[tempY][tempX] as PanelGridExpeditionRoom, false);

                        if (Map[tempY][tempX].IndexListRole != -1)
                        {
                            if (Hot.DataNowCellGameArchive.ListExpeditionRoleIndex.Count == Hot.DataNowCellGameArchive.ListNowPutRole.Count)
                            {
                                Hot.MgrUI_.CreatePanel<PanelCellExpeditionTimeLine>(false, E_PanelName.PanelCellExpeditionTimeLine,
                                (panel) =>
                                {
                                    int Speed = -1;

                                    if (p_isCreateByChooseGameArchive)
                                    {
                                        Speed = Hot.ExpeditionTimeLineLength - Hot.DataNowCellGameArchive.ListRole[Map[tempY][tempX].IndexListRole].NowTimeLinePos;
                                    }
                                    else
                                    {
                                        Speed = Hot.DataNowCellGameArchive.ListRole[Map[tempY][tempX].IndexListRole].NowSpeed;
                                    }

                                    panel.Init(Speed, PanelCellExpeditionRoom_);
                                });
                            }

                            Hot.MgrUI_.CreatePanel<PanelCellExpeditionRole>(false, E_PanelName.PanelCellExpeditionRole,
                            (PanelCellRoleExpedition_) =>
                            {
                                PanelCellRoleExpedition_.CellExpeditionRoom = PanelCellExpeditionRoom_;
                                PanelCellRoleExpedition_.Init(Hot.PanelBarRoleListExpedition_.ListCellExpeditionRole.Count,
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

                                        Hot.MgrUI_.CreatePanel<PanelCellExpeditionRole>(false, E_PanelName.PanelCellExpeditionRole,
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
                        else if (Map[tempY][tempX].OtherRole != null)
                        {

                        }
                    });
                }

                if (tempY == Map.Count - 1 && tempX == Map[0].Count - 1 && p_isCreateByChooseGameArchive)
                {
                    if (Hot.DataNowCellGameArchive.ListNowPutRole.Count == 0)
                    {
                        Hot.PanelBarRoleListExpedition_.Init();
                    }
                }
            }
        }
    }

    public void PreMove(bool p_isClear)
    {
        E_Res e_Res = E_Res.ImgCoverTransparenctRed;
        E_RoleName p_e_RoleName = Hot.ChoseCellExpeditionRoom.DataRole.e_RoleName;
        int p_VFlip = Hot.ChoseCellExpeditionRoom.DataRole.VFlip;
        int p_RootX = Hot.ChoseCellExpeditionRoom.RootGrid.X;
        int p_RootY = Hot.ChoseCellExpeditionRoom.RootGrid.Y;

        if (p_isClear)
        {
            e_Res = E_Res.ImgCoverTransparenctRed;
        }
        else
        {
            e_Res = E_Res.ImgCoverTransparenctGreen;
        }

        for (int iY = 0; iY < Hot.DicRoleConfig[p_e_RoleName].SizeBody.Y; iY++)
        {
            for (int iX = 0; iX < Hot.DicRoleConfig[p_e_RoleName].SizeBody.X; iX++)
            {
                switch (NowRoleMoveKey)
                {
                    case KeyCode.W:
                        Grids[p_RootY + iY - NowRoleMoveStep][p_RootX + iX * p_VFlip].ImgStatus.sprite = Hot.LoadSprite(e_Res);
                        break;
                    case KeyCode.S:
                        Grids[p_RootY + iY + NowRoleMoveStep][p_RootX + iX * p_VFlip].ImgStatus.sprite = Hot.LoadSprite(e_Res);
                        break;
                    case KeyCode.A:
                        Grids[p_RootY + iY][p_RootX + iX * p_VFlip - NowRoleMoveStep].ImgStatus.sprite = Hot.LoadSprite(e_Res);
                        break;
                    case KeyCode.D:
                        Grids[p_RootY + iY][p_RootX + iX * p_VFlip + NowRoleMoveStep].ImgStatus.sprite = Hot.LoadSprite(e_Res);
                        break;
                }
            }
        }
    }

    public void MoveData(Vector2Int p_sourecPos, Vector2Int p_movePos)
    {
        (Grids[p_sourecPos.y][p_sourecPos.x] as PanelGridExpeditionRoom).Item.transform.SetParent(ItemRoot[p_movePos.y][p_movePos.x], false);
        (Grids[p_movePos.y][p_movePos.x] as PanelGridExpeditionRoom).Data = (Grids[p_sourecPos.y][p_sourecPos.x] as PanelGridExpeditionRoom).Data;
        (Grids[p_sourecPos.y][p_sourecPos.x] as PanelGridExpeditionRoom).InitGridByRole
            (Hot.ChoseCellExpeditionRoom.DataRole.e_RoleName, null, Hot.ChoseCellExpeditionRoom.DataRole.VFlip);
        (Grids[p_movePos.y][p_movePos.x] as PanelGridExpeditionRoom).InitGridByRole
            (Hot.ChoseCellExpeditionRoom.DataRole.e_RoleName,   
             ItemRoot[p_movePos.y][p_movePos.x].GetComponentInChildren<PanelCellExpeditionRoom>(),
             Hot.ChoseCellExpeditionRoom.DataRole.VFlip);
        ItemRoot[p_movePos.y][p_movePos.x].GetComponentInChildren<PanelCellExpeditionRoom>().RootGrid = Grids[p_movePos.y][p_movePos.x] as PanelGridExpeditionRoom;
        (Grids[p_sourecPos.y][p_sourecPos.x] as PanelGridExpeditionRoom).Data = new();

        Hot.PanelExpeditionRoom_.ClearImgStatus();
        Hot.ChoseCellExpeditionRoom.GenerateMoveArea();

        Hot.Data_.Save();
    }
}
