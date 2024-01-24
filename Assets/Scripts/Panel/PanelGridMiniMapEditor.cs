using UnityEngine.EventSystems;

public class PanelGridMiniMapEditor : PanelBaseGrid<PanelCellMiniMapEditor>
{
    protected override void Awake()
    {
        base.Awake();

        Hot.MgrUI_.AddCustomEventListener
        (ImgBk.gameObject, EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.NowEnterGridMiniMapEditor = this;

            if (Hot.e_ChoseRoom != E_CellMiniMap.None && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].X; i2++)
                    {
                        Hot.PanelOtherEditorMiniMap_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgCoverTransparenctRed);
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
            Hot.NowEnterGridMiniMapEditor = null;

            if (Hot.e_ChoseRoom != E_CellMiniMap.None && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].X; i2++)
                    {
                        Hot.PanelOtherEditorMiniMap_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
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
                if (Hot.e_ChoseRoom != E_CellMiniMap.None && JudgeCanPut())
                {
                    //Create
                    if (Hot.ChoseCellMiniMapEditor == null)
                    {
                        Hot.MgrUI_.CreatePanel<PanelCellMiniMapEditor>
                        (false, E_PanelName.PanelCellMiniMapEditor,
                        (panel) =>
                        {
                            panel.Init(Hot.e_ChoseRoom, this);

                            for (int i1 = 0; i1 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].Y; i1++)
                            {
                                for (int i2 = 0; i2 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].X; i2++)
                                {
                                    Hot.PanelOtherEditorMiniMap_.Grids[Y + i1][X + i2].Item = panel;
                                }
                            }

                            if (Hot.e_ChoseRoom == E_CellMiniMap.CellMiniMapRoomEntrance)
                            {
                                Hot.PanelOtherEditorMiniMap_.EntrancePos.X = X;
                                Hot.PanelOtherEditorMiniMap_.EntrancePos.Y = Y;

                                Hot.PanelOtherEditorMiniMap_.ImgCurrentChoose.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                                Hot.e_ChoseRoom = E_CellMiniMap.None;
                            }
                        });
                    }

                    //Move
                    else if (Hot.ChoseCellMiniMapEditor != null)
                    {
                        for (int i1 = 0; i1 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].X; i2++)
                            {
                                Hot.PanelOtherEditorMiniMap_.Grids[Hot.ChoseCellMiniMapEditor.RootGrid.Y + i1][Hot.ChoseCellMiniMapEditor.RootGrid.X + i2].Item = null;
                            }
                        }

                        for (int i1 = 0; i1 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].X; i2++)
                            {
                                Hot.PanelOtherEditorMiniMap_.Grids[Y + i1][X + i2].Item = Hot.ChoseCellMiniMapEditor;
                            }
                        }

                        if (Hot.ChoseCellMiniMapEditor.e_CellMiniMap == E_CellMiniMap.CellMiniMapRoomEntrance)
                        {
                            Hot.PanelOtherEditorMiniMap_.EntrancePos = new(X, Y);
                        }

                        Hot.ChoseCellMiniMapEditor.transform.SetParent(Hot.PanelOtherEditorMiniMap_.ItemRoot[Y][X], false);
                        Hot.ChoseCellMiniMapEditor.transform.localPosition = new(-20, 20);
                        Hot.ChoseCellMiniMapEditor.RootGrid = this;
                    }

                    //Clear ImgStatus
                    if (Hot.e_ChoseRoom != E_CellMiniMap.None)
                    {
                        for (int i1 = 0; i1 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].X; i2++)
                            {
                                Hot.PanelOtherEditorMiniMap_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                            }
                        }
                    }
                }
                break;
        }
    }

    public bool JudgeCanPut()
    {
        if (Y + Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].Y > Hot.PanelOtherEditorMiniMap_.Grids.Count ||
            X + Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].X > Hot.PanelOtherEditorMiniMap_.Grids[0].Count)
        {
            return false;
        }

        for (int i1 = 0; i1 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].Y; i1++)
        {
            for (int i2 = 0; i2 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].X; i2++)
            {
                if (Hot.PanelOtherEditorMiniMap_.Grids[Y + i1][X + i2].Item == null ||
                    Hot.PanelOtherEditorMiniMap_.Grids[Y + i1][X + i2].Item == Hot.ChoseCellMiniMapEditor)
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
