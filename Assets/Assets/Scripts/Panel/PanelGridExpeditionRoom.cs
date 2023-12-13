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
            ImgStatus.sprite = Hot.LoadSprite(E_Res.BorderChoosedGreen);
        });
        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, UnityEngine.EventSystems.EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.NowEnterGridExpeditionRoom = null;
            ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
        });
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "ImgBk":
                
                break;
        }
    }

    public bool JudgeCanPut()
    {
        return true;
    }

    public void PutMapObj(DataContainer_CellExpeditionMapObj p_MapObj)
    {
        Data.MapObj = p_MapObj;

        Hot.MgrUI_.CreatePanel<PanelCellExpeditionRoom>(false, "/PanelCellExpeditionRoom",
        (panel) =>
        {
            panel.transform.SetParent(Hot.PanelExpeditionRoom_.ItemRoot[Y][X], false);
            InitGridByMapObject(panel);
        });
    }
    public void PutListRole(int p_IndexListRole)
    {
        Data.IndexListRole = p_IndexListRole;
        CreateCellRoomByRole(Hot.DataNowCellGameArchive.ListCellRole[Data.IndexListRole].e_RoleName);
    }
    public void PutOtherRole(DataContainer_CellRole p_OtherRole)
    {
        Data.OtherRole = p_OtherRole;
        CreateCellRoomByRole(Data.OtherRole.e_RoleName);
    }

    private void CreateCellRoomByRole(E_RoleName e_RoleName)
    {
        Hot.MgrUI_.CreatePanel<PanelCellExpeditionRoom>(false, "/PanelCellExpeditionRoom",
        (panel) =>
        {
            panel.transform.SetParent(Hot.PanelExpeditionRoom_.ItemRoot[Y][X], false);
            InitGridByRole(e_RoleName, panel);
        });
    }
    public void InitGridByMapObject(PanelCellExpeditionRoom p_panel)
    {
        for (int iY = 0; iY < Hot.BodyDicMapObject[Data.MapObj.e_Obj].Y; iY++)
        {
            for (int iX = 0; iX < Hot.BodyDicMapObject[Data.MapObj.e_Obj].X; iX++)
            {
                Hot.PanelExpeditionRoom_.Grids[iY + Y][iX + X].Item = p_panel;
            }
        }
    }
    public void InitGridByRole(E_RoleName e_RoleName, PanelCellExpeditionRoom p_panel)
    {
        for (int iY = 0; iY < Hot.DicRoleConfig[e_RoleName].BodySize.Y; iY++)
        {
            for (int iX = 0; iX < Hot.DicRoleConfig[e_RoleName].BodySize.X; iX++)
            {
                Hot.PanelExpeditionRoom_.Grids[iY + Y][iX + X].Item = p_panel;
            }
        }
    }

    public void MoveData()
    {

    }
}
