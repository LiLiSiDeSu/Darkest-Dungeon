using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellGridMiniMapEditor : PanelBase
{
    public int X;
    public int Y;

    public Image ImgBk;
    public Image ImgStatus;

    public PanelCellMiniMapEditor CellMiniMapEditor;

    protected override void Awake()
    {
        base.Awake();

        ImgBk = transform.FindSonSonSon("ImgBk").GetComponent<Image>();
        ImgStatus = transform.FindSonSonSon("ImgStatus").GetComponent<Image>();

        ImgBk.alphaHitTestMinimumThreshold = 0.2f;

        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.NowMapEditorGrid = this;

            if ((Hot.e_ChoseHall != E_CellExpeditionMiniMapHall.None || Hot.e_ChoseRoom != E_CellExpeditionMiniMapRoom.None) && JudgeCanPut())
            {
                if (Hot.e_ChoseHall != E_CellExpeditionMiniMapHall.None)
                {
                    for (int i1 = 0; i1 < Hot.DicHallBody[Hot.e_ChoseHall].Y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.DicHallBody[Hot.e_ChoseHall].X; i2++)
                        {
                            Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctRed");
                        }
                    }
                }

                if (Hot.e_ChoseRoom != E_CellExpeditionMiniMapRoom.None)
                {
                    for (int i1 = 0; i1 < Hot.DicRoomBody[Hot.e_ChoseRoom].Y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.DicRoomBody[Hot.e_ChoseRoom].X; i2++)
                        {
                            Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctRed");
                        }
                    }
                }
            }
            else
            {
                ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctGreen");
            }
        });

        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.NowMapEditorGrid = null;

            if ((Hot.e_ChoseHall != E_CellExpeditionMiniMapHall.None || Hot.e_ChoseRoom != E_CellExpeditionMiniMapRoom.None) && JudgeCanPut())
            {
                if (Hot.e_ChoseHall != E_CellExpeditionMiniMapHall.None)
                {
                    for (int i1 = 0; i1 < Hot.DicHallBody[Hot.e_ChoseHall].Y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.DicHallBody[Hot.e_ChoseHall].X; i2++)
                        {
                            Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                        }
                    }
                }

                if (Hot.e_ChoseRoom != E_CellExpeditionMiniMapRoom.None)
                {
                    for (int i1 = 0; i1 < Hot.DicRoomBody[Hot.e_ChoseRoom].Y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.DicRoomBody[Hot.e_ChoseRoom].X; i2++)
                        {
                            Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                        }
                    }
                }
            }
            else
            {
                ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
            }
        });
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "ImgBk":
                if ((Hot.e_ChoseHall != E_CellExpeditionMiniMapHall.None || Hot.e_ChoseRoom != E_CellExpeditionMiniMapRoom.None) && JudgeCanPut())
                {
                    if (Hot.ChoseMapEditor == null)    //创建
                    {
                        if (Hot.e_ChoseHall != E_CellExpeditionMiniMapHall.None)
                        {
                            Hot.MgrUI_.CreatePanel<PanelCellMiniMapEditor>(false, "/PanelCellMiniMapEditor",
                            (panel) =>
                            {
                                panel.transform.SetParent(Hot.PanelOtherMapEditor_.ItemRoot[Y][X], false);
                                panel.transform.transform.localPosition = new Vector3(-20, 20);
                                panel.RootGrid = this;

                                panel.Init(E_CellExpeditionMiniMapRoom.None, Hot.e_ChoseHall);

                                for (int i1 = 0; i1 < Hot.DicHallBody[Hot.e_ChoseHall].Y; i1++)
                                {
                                    for (int i2 = 0; i2 < Hot.DicHallBody[Hot.e_ChoseHall].X; i2++)
                                    {
                                        Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMiniMapEditor = panel;
                                    }
                                }
                            });
                        }

                        if (Hot.e_ChoseRoom != E_CellExpeditionMiniMapRoom.None)
                        {
                            Hot.MgrUI_.CreatePanel<PanelCellMiniMapEditor>(false, "/PanelCellMiniMapEditor",
                            (panel) =>
                            {
                                panel.transform.SetParent(Hot.PanelOtherMapEditor_.ItemRoot[Y][X], false);
                                panel.transform.transform.localPosition = new Vector3(-20, 20);
                                panel.RootGrid = this;

                                panel.Init(Hot.e_ChoseRoom, E_CellExpeditionMiniMapHall.None);

                                for (int i1 = 0; i1 < Hot.DicRoomBody[Hot.e_ChoseRoom].Y; i1++)
                                {
                                    for (int i2 = 0; i2 < Hot.DicRoomBody[Hot.e_ChoseRoom].X; i2++)
                                    {
                                        Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMiniMapEditor = panel;
                                    }
                                }

                                if (Hot.e_ChoseRoom == E_CellExpeditionMiniMapRoom.CellMapRoomEntrance)
                                {
                                    Hot.PanelOtherMapEditor_.EntrancePos.X = X;
                                    Hot.PanelOtherMapEditor_.EntrancePos.Y = Y;

                                    Hot.PanelOtherMapEditor_.ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                                    Hot.e_ChoseHall = E_CellExpeditionMiniMapHall.None;
                                    Hot.e_ChoseRoom = E_CellExpeditionMiniMapRoom.None;
                                }
                            });
                        }
                    }
                    else //移动
                    {
                        if (Hot.e_ChoseHall != E_CellExpeditionMiniMapHall.None)
                        {
                            for (int i1 = 0; i1 < Hot.DicHallBody[Hot.e_ChoseHall].Y; i1++)
                            {
                                for (int i2 = 0; i2 < Hot.DicHallBody[Hot.e_ChoseHall].X; i2++)
                                {
                                    Hot.PanelOtherMapEditor_.Grids[Hot.ChoseMapEditor.RootGrid.Y + i1][Hot.ChoseMapEditor.RootGrid.X + i2].CellMiniMapEditor = null;
                                }
                            }

                            for (int i1 = 0; i1 < Hot.DicHallBody[Hot.e_ChoseHall].Y; i1++)
                            {
                                for (int i2 = 0; i2 < Hot.DicHallBody[Hot.e_ChoseHall].X; i2++)
                                {
                                    Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMiniMapEditor = Hot.ChoseMapEditor;
                                }
                            }
                        }

                        if (Hot.e_ChoseRoom != E_CellExpeditionMiniMapRoom.None)
                        {
                            for (int i1 = 0; i1 < Hot.DicRoomBody[Hot.e_ChoseRoom].Y; i1++)
                            {
                                for (int i2 = 0; i2 < Hot.DicRoomBody[Hot.e_ChoseRoom].X; i2++)
                                {
                                    Hot.PanelOtherMapEditor_.Grids[Hot.ChoseMapEditor.RootGrid.Y + i1][Hot.ChoseMapEditor.RootGrid.X + i2].CellMiniMapEditor = null;
                                }
                            }

                            for (int i1 = 0; i1 < Hot.DicRoomBody[Hot.e_ChoseRoom].Y; i1++)
                            {
                                for (int i2 = 0; i2 < Hot.DicRoomBody[Hot.e_ChoseRoom].X; i2++)
                                {
                                    Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMiniMapEditor = Hot.ChoseMapEditor;
                                }
                            }
                        }

                        Hot.ChoseMapEditor.transform.SetParent(Hot.PanelOtherMapEditor_.ItemRoot[Y][X], false);
                        Hot.ChoseMapEditor.transform.localPosition = new(-20, 20);
                        Hot.ChoseMapEditor.RootGrid = this;
                    }

                    #region 清空status

                    if (Hot.e_ChoseHall != E_CellExpeditionMiniMapHall.None)
                    {
                        for (int i1 = 0; i1 < Hot.DicHallBody[Hot.e_ChoseHall].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.DicHallBody[Hot.e_ChoseHall].X; i2++)
                            {
                                Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                            }
                        }
                    }

                    if (Hot.e_ChoseRoom != E_CellExpeditionMiniMapRoom.None)
                    {
                        for (int i1 = 0; i1 < Hot.DicRoomBody[Hot.e_ChoseRoom].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.DicRoomBody[Hot.e_ChoseRoom].X; i2++)
                            {
                                Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                            }
                        }
                    }

                    #endregion
                }
                break;
        }
    }    

    public bool JudgeCanPut()
    {
        if (Hot.ChoseMapEditor != null)
        {
            if (Hot.e_ChoseHall != E_CellExpeditionMiniMapHall.None)
            {
                if (Y + Hot.DicHallBody[Hot.e_ChoseHall].Y > int.Parse(Hot.PanelOtherMapEditor_.IptHeight.text) ||
                    X + Hot.DicHallBody[Hot.e_ChoseHall].X > int.Parse(Hot.PanelOtherMapEditor_.IptWidth.text))

                {
                    return false;
                }

                for (int i1 = 0; i1 < Hot.DicHallBody[Hot.e_ChoseHall].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.DicHallBody[Hot.e_ChoseHall].X; i2++)
                    {
                        if (Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMiniMapEditor == null || 
                            Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMiniMapEditor == Hot.ChoseMapEditor)
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

            if (Hot.e_ChoseRoom != E_CellExpeditionMiniMapRoom.None)
            {
                if (Y + Hot.DicRoomBody[Hot.e_ChoseRoom].Y > int.Parse(Hot.PanelOtherMapEditor_.IptHeight.text) ||
                    X + Hot.DicRoomBody[Hot.e_ChoseRoom].X > int.Parse(Hot.PanelOtherMapEditor_.IptWidth.text))
                {
                    return false;
                }

                for (int i1 = 0; i1 < Hot.DicRoomBody[Hot.e_ChoseRoom].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.DicRoomBody[Hot.e_ChoseRoom].X; i2++)
                    {
                        if (Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMiniMapEditor == null || 
                            Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMiniMapEditor == Hot.ChoseMapEditor)
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
        }
        else
        {
            if (Hot.e_ChoseHall != E_CellExpeditionMiniMapHall.None)
            {
                if (Y + Hot.DicHallBody[Hot.e_ChoseHall].Y > int.Parse(Hot.PanelOtherMapEditor_.IptHeight.text) ||
                    X + Hot.DicHallBody[Hot.e_ChoseHall].X > int.Parse(Hot.PanelOtherMapEditor_.IptWidth.text))

                {
                    return false;
                }

                for (int i1 = 0; i1 < Hot.DicHallBody[Hot.e_ChoseHall].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.DicHallBody[Hot.e_ChoseHall].X; i2++)
                    {
                        if (Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMiniMapEditor == null)
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

            if (Hot.e_ChoseRoom != E_CellExpeditionMiniMapRoom.None)
            {
                if (Y + Hot.DicRoomBody[Hot.e_ChoseRoom].Y > int.Parse(Hot.PanelOtherMapEditor_.IptHeight.text) ||
                    X + Hot.DicRoomBody[Hot.e_ChoseRoom].X > int.Parse(Hot.PanelOtherMapEditor_.IptWidth.text))
                {
                    return false;
                }

                for (int i1 = 0; i1 < Hot.DicRoomBody[Hot.e_ChoseRoom].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.DicRoomBody[Hot.e_ChoseRoom].X; i2++)
                    {
                        if (Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMiniMapEditor == null)
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
        }

        return true;
    }    
}
