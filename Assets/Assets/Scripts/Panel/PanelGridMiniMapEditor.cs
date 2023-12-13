using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelGridMiniMapEditor : PanelBaseGrid<PanelCellMiniMapEditor>
{
    protected override void Awake()
    {
        base.Awake();

        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.NowEnterGridMiniMapEditor = this;

            if (Hot.e_ChoseRoom != E_CellMiniMap.None && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].X; i2++)
                    {
                        Hot.PanelOtherMiniMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgCoverTransparenctRed);
                    }
                }
            }
            else
            {
                ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgCoverTransparenctGreen);
            }
        });

        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.NowEnterGridMiniMapEditor = null;

            if (Hot.e_ChoseRoom != E_CellMiniMap.None && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].X; i2++)
                    {
                        Hot.PanelOtherMiniMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
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
                    if (Hot.ChoseCellMiniMapEditor == null)
                    {
                        //创建PanelCellMiniMapEditor
                        Hot.MgrUI_.CreatePanel<PanelCellMiniMapEditor>(false, "/PanelCellMiniMapEditor",
                        (panel) =>
                        {
                            panel.transform.SetParent(Hot.PanelOtherMiniMapEditor_.ItemRoot[Y][X], false);
                            panel.transform.transform.localPosition = new Vector3(-20, 20);
                            panel.RootGrid = this;

                            panel.Init(Hot.e_ChoseRoom);

                            for (int i1 = 0; i1 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].Y; i1++)
                            {
                                for (int i2 = 0; i2 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].X; i2++)
                                {
                                    Hot.PanelOtherMiniMapEditor_.Grids[Y + i1][X + i2].Item = panel;
                                }
                            }

                            if (Hot.e_ChoseRoom == E_CellMiniMap.CellMiniMapRoomEntrance)
                            {
                                Hot.PanelOtherMiniMapEditor_.EntrancePos.X = X;
                                Hot.PanelOtherMiniMapEditor_.EntrancePos.Y = Y;

                                Hot.PanelOtherMiniMapEditor_.ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                                Hot.e_ChoseRoom = E_CellMiniMap.None;
                            }   
                        });
                    }

                    //移动存在的PanelCellMiniMapEditor
                    if (Hot.ChoseCellMiniMapEditor != null)
                    {
                        for (int i1 = 0; i1 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].X; i2++)
                            {
                                Hot.PanelOtherMiniMapEditor_.Grids[Hot.ChoseCellMiniMapEditor.RootGrid.Y + i1][Hot.ChoseCellMiniMapEditor.RootGrid.X + i2].Item = null;
                            }
                        }

                        for (int i1 = 0; i1 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].X; i2++)
                            {
                                Hot.PanelOtherMiniMapEditor_.Grids[Y + i1][X + i2].Item = Hot.ChoseCellMiniMapEditor;
                            }
                        }

                        if (Hot.ChoseCellMiniMapEditor.e_Room == E_CellMiniMap.CellMiniMapRoomEntrance)
                        {
                            Hot.PanelOtherMiniMapEditor_.EntrancePos = new(X, Y);
                        }

                        Hot.ChoseCellMiniMapEditor.transform.SetParent(Hot.PanelOtherMiniMapEditor_.ItemRoot[Y][X], false);
                        Hot.ChoseCellMiniMapEditor.transform.localPosition = new(-20, 20);
                        Hot.ChoseCellMiniMapEditor.RootGrid = this;
                    }

                    //清空status
                    if (Hot.e_ChoseRoom != E_CellMiniMap.None)
                    {
                        for (int i1 = 0; i1 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].X; i2++)
                            {
                                Hot.PanelOtherMiniMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                            }
                        }
                    }
                }
                break;
        }
    }

    public bool JudgeCanPut()
    {
        if (Hot.e_ChoseRoom != E_CellMiniMap.None)
        {
            if (Y + Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].Y > int.Parse(Hot.PanelOtherMiniMapEditor_.IptHeight.text) ||
                X + Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].X > int.Parse(Hot.PanelOtherMiniMapEditor_.IptWidth.text))
            {
                return false;
            }

            for (int i1 = 0; i1 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].Y; i1++)
            {
                for (int i2 = 0; i2 < Hot.BodyDicCellMiniMap[Hot.e_ChoseRoom].X; i2++)
                {
                    if (Hot.PanelOtherMiniMapEditor_.Grids[Y + i1][X + i2].Item == null ||
                        Hot.PanelOtherMiniMapEditor_.Grids[Y + i1][X + i2].Item == Hot.ChoseCellMiniMapEditor)
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
