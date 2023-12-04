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
            Hot.NowEnterCellGridMiniMapEditor = this;

            Debug.Log(Y + " - " + X);

            if (Hot.e_ChoseRoom != E_CellMiniMapRoom.None && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.BodyDicRoom[Hot.e_ChoseRoom].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.BodyDicRoom[Hot.e_ChoseRoom].X; i2++)
                    {
                        Hot.PanelOtherMiniMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctRed");
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
            Hot.NowEnterCellGridMiniMapEditor = null;

            if (Hot.e_ChoseRoom != E_CellMiniMapRoom.None && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.BodyDicRoom[Hot.e_ChoseRoom].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.BodyDicRoom[Hot.e_ChoseRoom].X; i2++)
                    {
                        Hot.PanelOtherMiniMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
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
                if (Hot.e_ChoseRoom != E_CellMiniMapRoom.None && JudgeCanPut())
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

                            for (int i1 = 0; i1 < Hot.BodyDicRoom[Hot.e_ChoseRoom].Y; i1++)
                            {
                                for (int i2 = 0; i2 < Hot.BodyDicRoom[Hot.e_ChoseRoom].X; i2++)
                                {
                                    Hot.PanelOtherMiniMapEditor_.Grids[Y + i1][X + i2].CellMiniMapEditor = panel;
                                }
                            }

                            if (Hot.e_ChoseRoom == E_CellMiniMapRoom.CellMapRoomEntrance)
                            {
                                Hot.PanelOtherMiniMapEditor_.EntrancePos.X = X;
                                Hot.PanelOtherMiniMapEditor_.EntrancePos.Y = Y;

                                Hot.PanelOtherMiniMapEditor_.ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                                Hot.e_ChoseRoom = E_CellMiniMapRoom.None;
                            }   
                        });
                    }

                    //移动PanelCellMiniMapEditor
                    if (Hot.ChoseCellMiniMapEditor != null)
                    {
                        if (Hot.e_ChoseRoom != E_CellMiniMapRoom.None)
                        {
                            for (int i1 = 0; i1 < Hot.BodyDicRoom[Hot.e_ChoseRoom].Y; i1++)
                            {
                                for (int i2 = 0; i2 < Hot.BodyDicRoom[Hot.e_ChoseRoom].X; i2++)
                                {
                                    Hot.PanelOtherMiniMapEditor_.Grids[Hot.ChoseCellMiniMapEditor.RootGrid.Y + i1][Hot.ChoseCellMiniMapEditor.RootGrid.X + i2].CellMiniMapEditor = null;
                                }
                            }

                            for (int i1 = 0; i1 < Hot.BodyDicRoom[Hot.e_ChoseRoom].Y; i1++)
                            {
                                for (int i2 = 0; i2 < Hot.BodyDicRoom[Hot.e_ChoseRoom].X; i2++)
                                {
                                    Hot.PanelOtherMiniMapEditor_.Grids[Y + i1][X + i2].CellMiniMapEditor = Hot.ChoseCellMiniMapEditor;
                                }
                            }
                        }

                        Hot.ChoseCellMiniMapEditor.transform.SetParent(Hot.PanelOtherMiniMapEditor_.ItemRoot[Y][X], false);
                        Hot.ChoseCellMiniMapEditor.transform.localPosition = new(-20, 20);
                        Hot.ChoseCellMiniMapEditor.RootGrid = this;
                    }

                    //清空status
                    if (Hot.e_ChoseRoom != E_CellMiniMapRoom.None)
                    {
                        for (int i1 = 0; i1 < Hot.BodyDicRoom[Hot.e_ChoseRoom].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicRoom[Hot.e_ChoseRoom].X; i2++)
                            {
                                Hot.PanelOtherMiniMapEditor_.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                            }
                        }
                    }
                }
                break;
        }
    }    

    public void Init(int p_X, int p_Y, Transform father)
    {
        X = p_X; 
        Y = p_Y;

        transform.SetParent(father, false);
        gameObject.name = p_Y.ToString();
    }

    public bool JudgeCanPut()
    {
        if (Hot.e_ChoseRoom != E_CellMiniMapRoom.None)
        {
            if (Y + Hot.BodyDicRoom[Hot.e_ChoseRoom].Y > int.Parse(Hot.PanelOtherMiniMapEditor_.IptHeight.text) ||
                X + Hot.BodyDicRoom[Hot.e_ChoseRoom].X > int.Parse(Hot.PanelOtherMiniMapEditor_.IptWidth.text))
            {
                return false;
            }

            for (int i1 = 0; i1 < Hot.BodyDicRoom[Hot.e_ChoseRoom].Y; i1++)
            {
                for (int i2 = 0; i2 < Hot.BodyDicRoom[Hot.e_ChoseRoom].X; i2++)
                {
                    if (Hot.PanelOtherMiniMapEditor_.Grids[Y + i1][X + i2].CellMiniMapEditor == null ||
                        Hot.PanelOtherMiniMapEditor_.Grids[Y + i1][X + i2].CellMiniMapEditor == Hot.ChoseCellMiniMapEditor)
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
