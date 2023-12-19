using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGridExpeditionRoom : PanelBaseGrid<PanelCellExpeditionRoom>
{
    public DataContainer_GridExpeditionMap Data
    {
        get { return Hot.DataNowCellGameArchive.DataNowCellMiniMap.Map[Y][X]; }
        set { Hot.DataNowCellGameArchive.DataNowCellMiniMap.Map[Y][X] = value; }
    }

    protected override void Awake()
    {
        base.Awake();

        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, UnityEngine.EventSystems.EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.NowEnterGridExpeditionRoom = this;

            E_RoleName e_RoleName = E_RoleName.None;    
            if (Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Count > 0)
            {
                if (Hot.PanelBarRoleListExpedition_.NowPutIndex == -1)
                {
                    Hot.PanelBarRoleListExpedition_.NowPutIndex = 0;
                }
                e_RoleName = Hot.DataNowCellGameArchive.ListRole[Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex[Hot.PanelBarRoleListExpedition_.NowPutIndex]].e_RoleName;
            }

            if (Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Count > 0 && JudgeRoleCanPut(e_RoleName))
            {
                Hot.PanelBarRoleListExpedition_.GetCellRoleExpedition(Hot.PanelBarRoleListExpedition_.NowPutIndex).transform.localPosition += new Vector3(0, -20);

                for (int iY = 0; iY < Hot.DicRoleConfig[e_RoleName].BodySize.Y; iY++)
                {
                    for (int iX = 0; iX < Hot.DicRoleConfig[e_RoleName].BodySize.X; iX++)
                    {
                        Hot.PanelExpeditionRoom_.Grids[Y + iY][X + iX * Hot.VFlip].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgCoverTransparenctGreen);
                    }
                }

                return;
            }
            else
            {
                ImgStatus.sprite = Hot.LoadSprite(E_Res.BorderChoosedGreen);
            }
        });
        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, UnityEngine.EventSystems.EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.NowEnterGridExpeditionRoom = null;

            E_RoleName e_RoleName = E_RoleName.None;
            if (Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Count > 0)
            {
                e_RoleName = Hot.DataNowCellGameArchive.ListRole[Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex[Hot.PanelBarRoleListExpedition_.NowPutIndex]].e_RoleName;
            }

            if (Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Count > 0 && JudgeRoleCanPut(e_RoleName))
            {
                Hot.PanelBarRoleListExpedition_.GetCellRoleExpedition(Hot.PanelBarRoleListExpedition_.NowPutIndex).transform.localPosition += new Vector3(0, 20);

                for (int iY = 0; iY < Hot.DicRoleConfig[e_RoleName].BodySize.Y; iY++)
                {
                    for (int iX = 0; iX < Hot.DicRoleConfig[e_RoleName].BodySize.X; iX++)
                    {
                        Hot.PanelExpeditionRoom_.Grids[Y + iY][X + iX * Hot.VFlip].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                    }
                }

                if ((Hot.VFlip == -1 && X != Hot.BodyMap.X - 1) || (Hot.VFlip == 1 && X != 0))
                {
                    for (int iY = 0; iY < Hot.DicRoleConfig[e_RoleName].BodySize.Y; iY++)
                    {
                        Hot.PanelExpeditionRoom_.Grids[Y + iY][X + -Hot.VFlip].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                    }
                }

                return;
            }
            else
            {
                ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
            }
        });
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "ImgBk":
                E_RoleName e_RoleName = E_RoleName.None;
                if (Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Count > 0)
                {
                    e_RoleName = Hot.DataNowCellGameArchive.ListRole[Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex[Hot.PanelBarRoleListExpedition_.NowPutIndex]].e_RoleName;
                }

                if (Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Count > 0 && JudgeRoleCanPut(e_RoleName))
                {
                    PutListRole(Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex[Hot.PanelBarRoleListExpedition_.NowPutIndex], Hot.PanelBarRoleListExpedition_.NowPutIndex);

                    Hot.DataNowCellGameArchive.ListNowPutRole.Add(Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex[Hot.PanelBarRoleListExpedition_.NowPutIndex]);

                    for (int iY = 0; iY < Hot.DicRoleConfig[e_RoleName].BodySize.Y; iY++)
                    {
                        for (int iX = 0; iX < Hot.DicRoleConfig[e_RoleName].BodySize.X; iX++)
                        {
                            Hot.PanelExpeditionRoom_.Grids[Y + iY][X + iX * Hot.VFlip].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                        }
                    }

                    Hot.PanelBarRoleListExpedition_.GetCellRoleExpedition(Hot.PanelBarRoleListExpedition_.NowPutIndex).transform.localPosition =
                        new Vector3(Hot.PanelBarRoleListExpedition_.GetCellRoleExpedition(Hot.PanelBarRoleListExpedition_.NowPutIndex).transform.localPosition.x, 0);

                    if (Hot.PanelBarRoleListExpedition_.NowPutIndex == Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Count - 1)
                    {
                        Hot.PanelBarRoleListExpedition_.NowPutIndex = -1;
                        Hot.PanelBarRoleListExpedition_.ListNeedPutRoleIndex.Clear();
                        Hot.PanelBarRoleListExpedition_.EnableImgStatus();
                    }

                    Hot.PanelBarRoleListExpedition_.NowPutIndex++;

                    Hot.Data_.Save();

                    return;
                }
                break;
        }
    }

    public bool JudgeRoleCanPut(E_RoleName p_e_RoleName)
    {
        if (p_e_RoleName == E_RoleName.None)
        {
            return false;
        }

        if (Hot.VFlip == -1 && X < Hot.DicRoleConfig[p_e_RoleName].BodySize.X - 1)
        {
            return false;
        }

        if (Y + Hot.DicRoleConfig[p_e_RoleName].BodySize.Y > Hot.BodyMap.Y || 
            X + Hot.DicRoleConfig[p_e_RoleName].BodySize.X * Hot.VFlip > Hot.BodyMap.X)
        {
            return false;
        }

        for (int i1 = 0; i1 < Hot.DicRoleConfig[p_e_RoleName].BodySize.Y; i1++)
        {
            for (int i2 = 0; i2 < Hot.DicRoleConfig[p_e_RoleName].BodySize.X; i2++)
            {
                if (Hot.PanelExpeditionRoom_.Grids[Y + i1][X + i2 * Hot.VFlip].Item == null ||
                    Hot.PanelExpeditionRoom_.Grids[Y + i1][X + i2 * Hot.VFlip].Item == Hot.ChoseCellMiniMapEditor)
                {
                    ;
                }
                else
                {
                    return false;
                }
            }
        }

        switch (Hot.DicRoleConfig[p_e_RoleName].e_MoveType)
        {
            case E_RoleMoveType.Land:
                if (Y != Hot.BodyMap.Y - Hot.DicRoleConfig[p_e_RoleName].BodySize.Y)
                {
                    return false;
                }
                break;
            case E_RoleMoveType.Sky:
                ;
                break;
        }

        return true;
    }

    public void PutListRole(int p_IndexListRole, int p_index)
    {
        Data.IndexListRole = p_IndexListRole;
        Hot.MgrUI_.CreatePanel<PanelCellExpeditionRoom>(false, "/PanelCellExpeditionRoom",
        (panel) =>
        {
            panel.Init(this, true);
            Hot.PanelBarRoleListExpedition_.ListCellRoleExpedition[p_index].CellExpeditionMiniMap = panel;
        });
    }
    public void PutMapObj(DataContainer_CellExpeditionMapObj p_MapObj)
    {
        Data.MapObj = p_MapObj;
        CreateCellRoom();
    }
    public void PutOtherRole(DataContainer_CellRole p_OtherRole)
    {
        Data.OtherRole = p_OtherRole;
        CreateCellRoom();
    }

    private void CreateCellRoom()
    {
        Hot.MgrUI_.CreatePanel<PanelCellExpeditionRoom>(false, "/PanelCellExpeditionRoom",
        (panel) =>
        {
            panel.Init(this, true);
        });
    }
    public void InitGridByMapObject(PanelCellExpeditionRoom p_panel)
    {
        for (int iY = 0; iY < Hot.BodyDicMapObject[Data.MapObj.e_Obj].Y; iY++)
        {
            for (int iX = 0; iX < Hot.BodyDicMapObject[Data.MapObj.e_Obj].X; iX++)
            {
                Hot.PanelExpeditionRoom_.Grids[Y + iY][X + iX].Item = p_panel;
            }
        }
    }
    public void InitGridByRole(E_RoleName p_e_RoleName, PanelCellExpeditionRoom p_panel, int p_VFlip)
    {
        for (int iY = 0; iY < Hot.DicRoleConfig[p_e_RoleName].BodySize.Y; iY++)
        {
            for (int iX = 0; iX < Hot.DicRoleConfig[p_e_RoleName].BodySize.X; iX++)
            {
                Hot.PanelExpeditionRoom_.Grids[Y + iY][X + iX * Hot.VFlip].Item = p_panel;
            }
        }
    }

    public void MoveData()
    {

    }
}
