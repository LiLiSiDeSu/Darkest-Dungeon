using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellMapEditorGrid : PanelBase
{
    public int X;
    public int Y;

    public Image ImgBk;
    public Image ImgStatus;

    public PanelCellMapEditor CellMapEditor;

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

            if ((Hot.e_NowChooseHall != E_CellExpeditionMiniMapHall.None || Hot.e_NowChooseRoom != E_CellExpeditionMiniMapRoom.None) && JudgeCanPut())
            {
                if (Hot.e_NowChooseHall != E_CellExpeditionMiniMapHall.None)
                {
                    for (int i1 = 0; i1 < Hot.DicHallBody[Hot.e_NowChooseHall].y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.DicHallBody[Hot.e_NowChooseHall].x; i2++)
                        {
                            Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctRed");
                        }
                    }
                }

                if (Hot.e_NowChooseRoom != E_CellExpeditionMiniMapRoom.None)
                {
                    for (int i1 = 0; i1 < Hot.DicRoomBody[Hot.e_NowChooseRoom].y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.DicRoomBody[Hot.e_NowChooseRoom].x; i2++)
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

            if ((Hot.e_NowChooseHall != E_CellExpeditionMiniMapHall.None || Hot.e_NowChooseRoom != E_CellExpeditionMiniMapRoom.None) && JudgeCanPut())
            {
                if (Hot.e_NowChooseHall != E_CellExpeditionMiniMapHall.None)
                {
                    for (int i1 = 0; i1 < Hot.DicHallBody[Hot.e_NowChooseHall].y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.DicHallBody[Hot.e_NowChooseHall].x; i2++)
                        {
                            Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                        }
                    }
                }

                if (Hot.e_NowChooseRoom != E_CellExpeditionMiniMapRoom.None)
                {
                    for (int i1 = 0; i1 < Hot.DicRoomBody[Hot.e_NowChooseRoom].y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.DicRoomBody[Hot.e_NowChooseRoom].x; i2++)
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
                if ((Hot.e_NowChooseHall != E_CellExpeditionMiniMapHall.None || Hot.e_NowChooseRoom != E_CellExpeditionMiniMapRoom.None) && JudgeCanPut())
                {
                    if (Hot.NowCellMapEditor == null)
                    {
                        if (Hot.e_NowChooseHall != E_CellExpeditionMiniMapHall.None)
                        {
                            Hot.MgrUI_.CreatePanel<PanelCellMapEditor>(false, "/PanelCellMapEditor",
                            (panel) =>
                            {
                                panel.transform.SetParent(Hot.PanelOtherMapEditor_.ItemRoot[Y][X], false);
                                panel.transform.transform.localPosition = new Vector3(-20, 20);
                                panel.RootGrid = this;                                
                                panel.e_Hall = Hot.e_NowChooseHall;

                                panel.ImgCellMapEditor.sprite = Hot.MgrRes_.Load<Sprite>("Art/CellMapHall" + panel.e_Hall);
                                panel.ChangeHallSize();

                                for (int i1 = 0; i1 < Hot.DicHallBody[Hot.e_NowChooseHall].y; i1++)
                                {
                                    for (int i2 = 0; i2 < Hot.DicHallBody[Hot.e_NowChooseHall].x; i2++)
                                    {
                                        Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMapEditor = panel;
                                    }
                                }
                            });
                        }

                        if (Hot.e_NowChooseRoom != E_CellExpeditionMiniMapRoom.None)
                        {
                            Hot.MgrUI_.CreatePanel<PanelCellMapEditor>(false, "/PanelCellMapEditor",
                            (panel) =>
                            {
                                panel.transform.SetParent(Hot.PanelOtherMapEditor_.ItemRoot[Y][X], false);
                                panel.transform.transform.localPosition = new Vector3(-20, 20);
                                panel.RootGrid = this;
                                panel.e_Room = Hot.e_NowChooseRoom;

                                panel.ImgCellMapEditor.sprite = Hot.MgrRes_.Load<Sprite>("Art/CellMapRoom" + panel.e_Room);
                                panel.ChangeRoomSize();

                                for (int i1 = 0; i1 < Hot.DicRoomBody[Hot.e_NowChooseRoom].y; i1++)
                                {
                                    for (int i2 = 0; i2 < Hot.DicRoomBody[Hot.e_NowChooseRoom].x; i2++)
                                    {
                                        Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMapEditor = panel;
                                    }
                                }
                            });
                        }
                    }
                    else
                    {
                        if (Hot.e_NowChooseHall != E_CellExpeditionMiniMapHall.None)
                        {
                            for (int i1 = 0; i1 < Hot.DicHallBody[Hot.e_NowChooseHall].y; i1++)
                            {
                                for (int i2 = 0; i2 < Hot.DicHallBody[Hot.e_NowChooseHall].x; i2++)
                                {
                                    Hot.PanelOtherMapEditor_.Grids[Hot.NowCellMapEditor.RootGrid.Y + i1][Hot.NowCellMapEditor.RootGrid.X + i2].CellMapEditor = null;
                                }
                            }

                            for (int i1 = 0; i1 < Hot.DicHallBody[Hot.e_NowChooseHall].y; i1++)
                            {
                                for (int i2 = 0; i2 < Hot.DicHallBody[Hot.e_NowChooseHall].x; i2++)
                                {
                                    Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMapEditor = Hot.NowCellMapEditor;
                                }
                            }
                        }

                        if (Hot.e_NowChooseRoom != E_CellExpeditionMiniMapRoom.None)
                        {
                            for (int i1 = 0; i1 < Hot.DicRoomBody[Hot.e_NowChooseRoom].y; i1++)
                            {
                                for (int i2 = 0; i2 < Hot.DicRoomBody[Hot.e_NowChooseRoom].x; i2++)
                                {
                                    Hot.PanelOtherMapEditor_.Grids[Hot.NowCellMapEditor.RootGrid.Y + i1][Hot.NowCellMapEditor.RootGrid.X + i2].CellMapEditor = null;
                                }
                            }

                            for (int i1 = 0; i1 < Hot.DicRoomBody[Hot.e_NowChooseRoom].y; i1++)
                            {
                                for (int i2 = 0; i2 < Hot.DicRoomBody[Hot.e_NowChooseRoom].x; i2++)
                                {
                                    Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMapEditor = Hot.NowCellMapEditor;
                                }
                            }
                        }
                    }

                    if (Hot.e_NowChooseHall != E_CellExpeditionMiniMapHall.None)
                    {
                        for (int i1 = 0; i1 < Hot.DicHallBody[Hot.e_NowChooseHall].y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.DicHallBody[Hot.e_NowChooseHall].x; i2++)
                            {
                                Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                            }
                        }
                    }

                    if (Hot.e_NowChooseRoom != E_CellExpeditionMiniMapRoom.None)
                    {
                        for (int i1 = 0; i1 < Hot.DicRoomBody[Hot.e_NowChooseRoom].y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.DicRoomBody[Hot.e_NowChooseRoom].x; i2++)
                            {
                                Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                            }
                        }
                    }
                }
                break;
        }
    }    

    public bool JudgeCanPut()
    {
        if (Hot.NowCellMapEditor != null)
        {
            if (Hot.e_NowChooseHall != E_CellExpeditionMiniMapHall.None)
            {
                if (Y + Hot.DicHallBody[Hot.e_NowChooseHall].y > int.Parse(Hot.PanelOtherMapEditor_.IptHeight.text) ||
                    X + Hot.DicHallBody[Hot.e_NowChooseHall].x > int.Parse(Hot.PanelOtherMapEditor_.IptWidth.text))

                {
                    return false;
                }

                for (int i1 = 0; i1 < Hot.DicHallBody[Hot.e_NowChooseHall].y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.DicHallBody[Hot.e_NowChooseHall].x; i2++)
                    {
                        if (Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMapEditor == null || 
                            Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMapEditor == Hot.NowCellMapEditor)
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

            if (Hot.e_NowChooseRoom != E_CellExpeditionMiniMapRoom.None)
            {
                if (Y + Hot.DicRoomBody[Hot.e_NowChooseRoom].y > int.Parse(Hot.PanelOtherMapEditor_.IptHeight.text) ||
                    X + Hot.DicRoomBody[Hot.e_NowChooseRoom].x > int.Parse(Hot.PanelOtherMapEditor_.IptWidth.text))
                {
                    return false;
                }

                for (int i1 = 0; i1 < Hot.DicRoomBody[Hot.e_NowChooseRoom].y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.DicRoomBody[Hot.e_NowChooseRoom].x; i2++)
                    {
                        if (Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMapEditor == null || 
                            Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMapEditor == Hot.NowCellMapEditor)
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
            if (Hot.e_NowChooseHall != E_CellExpeditionMiniMapHall.None)
            {
                if (Y + Hot.DicHallBody[Hot.e_NowChooseHall].y > int.Parse(Hot.PanelOtherMapEditor_.IptHeight.text) ||
                    X + Hot.DicHallBody[Hot.e_NowChooseHall].x > int.Parse(Hot.PanelOtherMapEditor_.IptWidth.text))

                {
                    return false;
                }

                for (int i1 = 0; i1 < Hot.DicHallBody[Hot.e_NowChooseHall].y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.DicHallBody[Hot.e_NowChooseHall].x; i2++)
                    {
                        if (Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMapEditor == null)
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

            if (Hot.e_NowChooseRoom != E_CellExpeditionMiniMapRoom.None)
            {
                if (Y + Hot.DicRoomBody[Hot.e_NowChooseRoom].y > int.Parse(Hot.PanelOtherMapEditor_.IptHeight.text) ||
                    X + Hot.DicRoomBody[Hot.e_NowChooseRoom].x > int.Parse(Hot.PanelOtherMapEditor_.IptWidth.text))
                {
                    return false;
                }

                for (int i1 = 0; i1 < Hot.DicRoomBody[Hot.e_NowChooseRoom].y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.DicRoomBody[Hot.e_NowChooseRoom].x; i2++)
                    {
                        if (Hot.PanelOtherMapEditor_.Grids[Y + i1][X + i2].CellMapEditor == null)
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
