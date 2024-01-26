using UnityEngine.EventSystems;

public class PanelGridRoleConfig : PanelBaseGrid<PanelCellRoleConfig>
{
    protected override void Awake()
    {
        base.Awake();

        Hot.MgrUI_.AddCustomEventListener
        (ImgBk.gameObject, EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.NowEnterGridRoleConfig = this;

            if (Hot.ChoseCellRoleConfig != null && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.DicRoleConfig[Hot.PanelOtherEditorRoleConfig_.e_ChoseRoleName].SizeBody.Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.DicRoleConfig[Hot.PanelOtherEditorRoleConfig_.e_ChoseRoleName].SizeBody.X; i2++)
                    {
                        Hot.PanelOtherEditorRoleConfig_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgCoverTransparenctRed);
                    }
                }
            }
            else
            {
                ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgCoverTransparenctGreen);
            }
        });

        Hot.MgrUI_.AddCustomEventListener
        (ImgBk.gameObject, EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.NowEnterGridRoleConfig = null;

            if (Hot.ChoseCellRoleConfig != null && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.DicRoleConfig[Hot.PanelOtherEditorRoleConfig_.e_ChoseRoleName].SizeBody.Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.DicRoleConfig[Hot.PanelOtherEditorRoleConfig_.e_ChoseRoleName].SizeBody.X; i2++)
                    {
                        Hot.PanelOtherEditorRoleConfig_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                    }
                }
            }
            else
            {
                ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
            }
        });

        ImgBk.alphaHitTestMinimumThreshold = 0.2f;
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "ImgBk":
                E_RoleName e_RoleName = Hot.PanelOtherEditorRoleConfig_.e_ChoseRoleName;

                //Create
                if (Hot.ChoseCellRoleConfig == null && 
                    Hot.PanelOtherEditorRoleConfig_.e_ChoseSkill != E_Skill.None &&
                    Hot.DicRoleConfig[e_RoleName].DicSkill.ContainsKey(Hot.PanelOtherEditorRoleConfig_.e_ChoseSkill))
                {
                    Hot.MgrUI_.CreatePanel<PanelCellRoleConfig>
                    (false, E_PanelName.PanelCellRoleConfig,
                    (panel) =>
                    {
                        panel.Init(E_RoleName.None, this);

                        Hot.PanelOtherEditorRoleConfig_.Grids[Y][X].Item = panel;

                        Hot.PanelOtherEditorRoleConfig_.SkillAreaNum++;
                    });
                }
                //Move
                else if (Hot.ChoseCellRoleConfig != null && JudgeCanPut())
                {
                    for (int i1 = 0; i1 < Hot.DicRoleConfig[e_RoleName].SizeBody.Y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.DicRoleConfig[e_RoleName].SizeBody.X; i2++)
                        {
                            Hot.PanelOtherEditorRoleConfig_.Grids[Hot.ChoseCellRoleConfig.RootGrid.Y + i1][Hot.ChoseCellRoleConfig.RootGrid.X + i2].Item = null;
                        }
                    }

                    for (int i1 = 0; i1 < Hot.DicRoleConfig[e_RoleName].SizeBody.Y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.DicRoleConfig[e_RoleName].SizeBody.X; i2++)
                        {
                            Hot.PanelOtherEditorRoleConfig_.Grids[Y + i1][X + i2].Item = Hot.ChoseCellRoleConfig;
                        }
                    }

                    //Clear ImgStatus
                    if (e_RoleName != E_RoleName.None)
                    {
                        for (int i1 = 0; i1 < Hot.DicRoleConfig[e_RoleName].SizeBody.Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.DicRoleConfig[e_RoleName].SizeBody.X; i2++)
                            {
                                Hot.PanelOtherEditorRoleConfig_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                            }
                        }
                    }

                    Hot.ChoseCellRoleConfig.transform.SetParent(Hot.PanelOtherEditorRoleConfig_.ItemRoot[Y][X], false);
                    Hot.ChoseCellRoleConfig.transform.localPosition = new(-20, 20);
                    Hot.ChoseCellRoleConfig.RootGrid = this;
                }
                break;
        }
    }

    public bool JudgeCanPut()
    {
        E_RoleName e_RoleName = Hot.PanelOtherEditorRoleConfig_.e_ChoseRoleName;
        
        if (Y + Hot.DicRoleConfig[e_RoleName].SizeBody.Y > Hot.PanelOtherEditorRoleConfig_.Grids.Count ||
            X + Hot.DicRoleConfig[e_RoleName].SizeBody.X > Hot.PanelOtherEditorRoleConfig_.Grids[0].Count)
        {
            return false;
        }

        for (int i1 = 0; i1 < Hot.DicRoleConfig[e_RoleName].SizeBody.Y; i1++)
        {
            for (int i2 = 0; i2 < Hot.DicRoleConfig[e_RoleName].SizeBody.X; i2++)
            {
                if (Hot.PanelOtherEditorRoleConfig_.Grids[Y + i1][X + i2].Item == null ||
                    Hot.PanelOtherEditorRoleConfig_.Grids[Y + i1][X + i2].Item == Hot.ChoseCellRoleConfig)
                {
                    ;
                }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }
}
