using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCellGridRoomEditor : PanelBase
{
    public int X;
    public int Y;

    public Image ImgBk;
    public Image ImgStatus;

    public PanelCellRoomEditor CellRoomEditor;

    protected override void Awake()
    {
        base.Awake();

        ImgBk = transform.FindSonSonSon("ImgBk").GetComponent<Image>();
        ImgStatus = transform.FindSonSonSon("ImgStatus").GetComponent<Image>();

        ImgBk.alphaHitTestMinimumThreshold = 0.2f;

        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, UnityEngine.EventSystems.EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.NowEnterCellGridRoomEditor = this; 

            if (Hot.e_ChoseObj != E_MapObject.None && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.BodyDicMapObject[Hot.e_ChoseObj].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.BodyDicMapObject[Hot.e_ChoseObj].X; i2++)
                    {
                        Hot.PanelOtherRoomEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctRed");
                    }
                }
            }
            else
            {
                ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctGreen");
            }
        });
        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, UnityEngine.EventSystems.EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.NowEnterCellGridRoomEditor = null;

            if (Hot.e_ChoseObj != E_MapObject.None && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.BodyDicMapObject[Hot.e_ChoseObj].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.BodyDicMapObject[Hot.e_ChoseObj].X; i2++)
                    {
                        Hot.PanelOtherRoomEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
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
                if (Hot.e_ChoseObj != E_MapObject.None && JudgeCanPut())
                {
                    if (Hot.ChoseCellRoomEditor == null)
                    {
                        Hot.MgrUI_.CreatePanel<PanelCellRoomEditor>(false, "/PanelCellRoomEditor",
                        (panel) =>
                        {
                            panel.Init(Hot.e_ChoseObj);
                            panel.RootGrid = this;
                            panel.transform.SetParent(Hot.PanelOtherRoomEditor_.ItemRoot[Y][X], false);
                            panel.transform.localPosition = new(-20, 20);
                            Hot.NowEditorDependency.Map[Y][X].IsHave = true;

                            for (int i1 = 0; i1 < Hot.BodyDicMapObject[Hot.e_ChoseObj].Y; i1++)
                            {
                                for (int i2 = 0; i2 < Hot.BodyDicMapObject[Hot.e_ChoseObj].X; i2++)
                                {
                                    Hot.NowEditorDependency.Map[Y + i1][X + i2].e_Obj = Hot.e_ChoseObj;
                                    Hot.PanelOtherRoomEditor_.Grids[Y + i1][X + i2].CellRoomEditor = panel;
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
                                Hot.PanelOtherRoomEditor_.
                                    Grids[Hot.ChoseCellRoomEditor.RootGrid.Y + i1][Hot.ChoseCellRoomEditor.RootGrid.X + i2].CellRoomEditor = null;
                                Hot.PanelOtherRoomEditor_.Grids[Hot.ChoseCellRoomEditor.RootGrid.Y + i1][Hot.ChoseCellRoomEditor.RootGrid.X + i2].ImgStatus.sprite =
                                    Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                            }
                        }

                        Hot.ChoseCellRoomEditor.RootGrid = this;
                        Hot.ChoseCellRoomEditor.transform.SetParent(Hot.PanelOtherRoomEditor_.ItemRoot[Y][X], false);
                        Hot.ChoseCellRoomEditor.transform.localPosition = new(-20, 20);
                        Hot.NowEditorDependency.Map[Hot.ChoseCellRoomEditor.RootGrid.Y][Hot.ChoseCellRoomEditor.RootGrid.X].IsHave = true;

                        for (int i1 = 0; i1 < Hot.BodyDicMapObject[Hot.ChoseCellRoomEditor.e_Obj].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicMapObject[Hot.ChoseCellRoomEditor.e_Obj].X; i2++)
                            {
                                Hot.NowEditorDependency.Map[Y + i1][X + i2].e_Obj = Hot.ChoseCellRoomEditor.e_Obj;
                                Hot.PanelOtherRoomEditor_.Grids[Y + i1][X + i2].CellRoomEditor = Hot.ChoseCellRoomEditor;
                            }
                        }
                    }
                }
                break;
        }
    }

    public void Init(int x, int y)
    {
        X = x; 
        Y = y;
    }

    public bool JudgeCanPut()
    {
        if (Hot.e_ChoseObj != E_MapObject.None)
        {
            if (Y + Hot.BodyDicMapObject[Hot.e_ChoseObj].Y > Hot.BodyExpeditionRoom.Y ||
                X + Hot.BodyDicMapObject[Hot.e_ChoseObj].X > Hot.BodyExpeditionRoom.X)

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
