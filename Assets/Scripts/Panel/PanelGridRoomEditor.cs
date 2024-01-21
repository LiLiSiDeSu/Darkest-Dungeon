public class PanelGridRoomEditor : PanelBaseGrid<PanelCellRoomEditor>
{
    protected override void Awake()
    {
        base.Awake();

        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, UnityEngine.EventSystems.EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.NowEnterGridRoomEditor = this;

            if (Hot.e_ChoseObj != E_MapObject.None && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.BodyDicMapObject[Hot.e_ChoseObj].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.BodyDicMapObject[Hot.e_ChoseObj].X; i2++)
                    {
                        Hot.PanelOtherEditorRoom_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgCoverTransparenctRed);
                    }
                }
            }
            else
            {
                ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgCoverTransparenctGreen);
            }
        });
        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, UnityEngine.EventSystems.EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.NowEnterGridRoomEditor = null;

            if (Hot.e_ChoseObj != E_MapObject.None && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.BodyDicMapObject[Hot.e_ChoseObj].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.BodyDicMapObject[Hot.e_ChoseObj].X; i2++)
                    {
                        Hot.PanelOtherEditorRoom_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                    }
                }
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
                if (Hot.e_ChoseObj != E_MapObject.None && JudgeCanPut())
                {
                    if (Hot.ChoseCellRoomEditor == null)
                    {
                        Hot.MgrUI_.CreatePanel<PanelCellRoomEditor>(false, E_PanelName.PanelCellRoomEditor,
                        (panel) =>
                        {
                            panel.Init(Hot.e_ChoseObj, this);
                            Hot.NowEditorDependency.Map[Y][X].IsHave = true;

                            for (int i1 = 0; i1 < Hot.BodyDicMapObject[Hot.e_ChoseObj].Y; i1++)
                            {
                                for (int i2 = 0; i2 < Hot.BodyDicMapObject[Hot.e_ChoseObj].X; i2++)
                                {
                                    Hot.NowEditorDependency.Map[Y + i1][X + i2].e_Obj = Hot.e_ChoseObj;
                                    Hot.PanelOtherEditorRoom_.Grids[Y + i1][X + i2].Item = panel;
                                }
                            }
                        });
                    }

                    if (Hot.ChoseCellRoomEditor != null)
                    {
                        Hot.NowEditorDependency.Map[Hot.ChoseCellRoomEditor.RootGrid.Y][Hot.ChoseCellRoomEditor.RootGrid.X].IsHave = false;

                        for (int i1 = 0; i1 < Hot.BodyDicMapObject[Hot.ChoseCellRoomEditor.e_Obj].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicMapObject[Hot.ChoseCellRoomEditor.e_Obj].X; i2++)
                            {
                                Hot.NowEditorDependency.Map[Hot.ChoseCellRoomEditor.RootGrid.Y + i1][Hot.ChoseCellRoomEditor.RootGrid.X + i2].e_Obj = E_MapObject.None;
                                Hot.PanelOtherEditorRoom_.
                                    Grids[Hot.ChoseCellRoomEditor.RootGrid.Y + i1][Hot.ChoseCellRoomEditor.RootGrid.X + i2].Item = null;
                                Hot.PanelOtherEditorRoom_.Grids[Hot.ChoseCellRoomEditor.RootGrid.Y + i1][Hot.ChoseCellRoomEditor.RootGrid.X + i2].ImgStatus.sprite =
                                    Hot.LoadSprite(E_Res.ImgEmpty);
                            }
                        }

                        Hot.ChoseCellRoomEditor.RootGrid = this;
                        Hot.ChoseCellRoomEditor.transform.SetParent(Hot.PanelOtherEditorRoom_.ItemRoot[Y][X], false);
                        Hot.ChoseCellRoomEditor.transform.localPosition = new(-20, 20);
                        Hot.NowEditorDependency.Map[Hot.ChoseCellRoomEditor.RootGrid.Y][Hot.ChoseCellRoomEditor.RootGrid.X].IsHave = true;

                        for (int i1 = 0; i1 < Hot.BodyDicMapObject[Hot.ChoseCellRoomEditor.e_Obj].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicMapObject[Hot.ChoseCellRoomEditor.e_Obj].X; i2++)
                            {
                                Hot.NowEditorDependency.Map[Y + i1][X + i2].e_Obj = Hot.ChoseCellRoomEditor.e_Obj;
                                Hot.PanelOtherEditorRoom_.Grids[Y + i1][X + i2].Item = Hot.ChoseCellRoomEditor;
                            }
                        }
                    }
                }
                break;
        }
    }

    public bool JudgeCanPut()
    {
        if (Hot.e_ChoseObj != E_MapObject.None)
        {
            if (Y + Hot.BodyDicMapObject[Hot.e_ChoseObj].Y > Hot.BodyMap.Y ||
                X + Hot.BodyDicMapObject[Hot.e_ChoseObj].X > Hot.BodyMap.X)

            {
                return false;
            }

            for (int i1 = 0; i1 < Hot.BodyDicMapObject[Hot.e_ChoseObj].Y; i1++)
            {
                for (int i2 = 0; i2 < Hot.BodyDicMapObject[Hot.e_ChoseObj].X; i2++)
                {
                    if (Hot.NowEditorDependency.Map[i1 + Y][i2 + X].e_Obj == E_MapObject.None)
                    {
                        ;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }
}
