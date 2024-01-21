using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOtherEditorRoom : PanelBaseVector2<PanelCellRoomEditor, PanelGridRoomEditor>
{
    public Image ImgCurrentChoose;

    public Transform ImgRoomBk;

    public Transform ChooseGridContent;
    public Transform ChooseOtherContent;

    protected override void Awake()
    {
        base.Awake();

        ImgRoomBk = transform.FindSonSonSon("ImgRoomBk");

        ChooseGridContent = transform.FindSonSonSon("ChooseGridContent");
        ChooseOtherContent = transform.FindSonSonSon("ChooseOtherContent");

        ImgCurrentChoose = transform.FindSonSonSon("ImgCurrentChoose").GetComponent<Image>();

        Hot.CenterEvent_.AddEventListener("Esc" + "PanelOtherEditorRoom",
        () =>
        {
            Hot.NowEditorDependency = null;
            Hot.NowEnterGridRoomEditor = null;
            Hot.ChoseCellRoomEditor = null;
            Hot.NowEnterCellRoomEditor = null;
            ImgCurrentChoose.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
            Hot.e_ChoseObj = E_MapObject.None;
            Hot.PanelOtherEditorRoom_.ClearImgStatus();
            Hot.PanelOtherEditorRoom_.ClearItem();
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel(E_PanelName.PanelOtherEditorRoom) && key == KeyCode.LeftControl)
            {
                ImgBkContent.gameObject.SetActive(false);
                Hot.NowEnterGridRoomEditor.ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
            }
        });
        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyUp.ToString(),
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel(E_PanelName.PanelOtherEditorRoom) && key == KeyCode.LeftControl)
            {
                ImgBkContent.gameObject.SetActive(true);
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel(E_PanelName.PanelOtherEditorRoom) && key == KeyCode.Mouse1)
            {
                if (Hot.ChoseCellRoomEditor != null)
                {
                    Hot.ChoseCellRoomEditor.ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                    Hot.ChoseCellRoomEditor = null;

                    return;
                }

                if (Hot.NowEnterCellRoomEditor != null)
                {
                    Hot.NowEditorDependency.Map[Hot.NowEnterCellRoomEditor.RootGrid.Y][Hot.NowEnterCellRoomEditor.RootGrid.X].IsHave = false;

                    for (int i1 = 0; i1 < Hot.BodyDicMapObject[Hot.NowEnterCellRoomEditor.e_Obj].Y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.BodyDicMapObject[Hot.NowEnterCellRoomEditor.e_Obj].X; i2++)
                        {
                            Hot.NowEditorDependency.Map[Hot.NowEnterCellRoomEditor.RootGrid.Y + i1]
                                                       [Hot.NowEnterCellRoomEditor.RootGrid.X + i2].e_Obj = E_MapObject.None;
                            Hot.PanelOtherEditorRoom_.Grids[Hot.NowEnterCellRoomEditor.RootGrid.Y + i1]
                                                           [Hot.NowEnterCellRoomEditor.RootGrid.X + i2].Item = null;
                            Hot.PanelOtherEditorRoom_.Grids[Hot.NowEnterCellRoomEditor.RootGrid.Y + i1]
                                                           [Hot.NowEnterCellRoomEditor.RootGrid.X + i2].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                        }
                    }

                    Destroy(Hot.NowEnterCellRoomEditor.gameObject);

                    return;
                }

                if (Hot.e_ChoseObj != E_MapObject.None)
                {
                    if (Hot.NowEnterGridRoomEditor != null)
                    {
                        for (int i1 = 0; i1 < Hot.BodyDicMapObject[Hot.e_ChoseObj].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicMapObject[Hot.e_ChoseObj].X; i2++)
                            {
                                Hot.PanelOtherEditorRoom_.Grids[Hot.NowEnterGridRoomEditor.Y + i1][Hot.NowEnterGridRoomEditor.X + i2].ImgStatus.sprite =
                                    Hot.LoadSprite(E_Res.ImgEmpty);
                            }
                        }
                    }

                    Hot.e_ChoseObj = E_MapObject.None;
                    Hot.PanelOtherEditorRoom_.ImgCurrentChoose.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                }
            }
        });

        LimitAdd = 5f;
        LimitReduce = 1f;

        Init();
    }

    public void Init()
    {
        InitGrids(Hot.BodyMap.Y, Hot.BodyMap.X);
        InitChooseContent();
    }

    public void InitChooseContent()
    {
        foreach (E_MapObject e_Obj in Enum.GetValues(typeof(E_MapObject)))
        {
            if (e_Obj != E_MapObject.None)
            {
                Hot.MgrUI_.CreatePanel<PanelCellRoomEditorChoose>(false, E_PanelName.PanelCellRoomEditorChoose,
                (panel) =>
                {
                    if (e_Obj.ToString().Contains("Grid"))
                    {
                        panel.transform.SetParent(ChooseGridContent, false);
                    }
                    else
                    {
                        panel.transform.SetParent(ChooseOtherContent, false);
                    }

                    panel.Init(e_Obj);
                });
            }
        }
    }

    public void LoadRoomConfig(List<List<PanelGridRoomEditorConfig>> map)
    {
        for (int Y = 0; Y < map.Count; Y++)
        {
            int tempiY = Y;

            for (int iX = 0; iX < map[Y].Count; iX++)
            {
                int tempiX = iX;

                if (map[tempiY][tempiX].IsHave)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellRoomEditor>(false, E_PanelName.PanelCellRoomEditor,
                    (panel) =>
                    {
                        panel.Init(map[tempiY][tempiX].e_Obj, Grids[tempiY][tempiX]);

                        for (int i1 = 0; i1 < Hot.BodyDicMapObject[map[tempiY][tempiX].e_Obj].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicMapObject[map[tempiY][tempiX].e_Obj].X; i2++)
                            {
                                Grids[tempiY + i1][tempiX + i2].Item = panel;
                            }
                        }
                    });
                }
            }
        }
    }

    public void ChangeCurrentChoose(E_MapObject e_MapObject)
    {
        Hot.e_ChoseObj = e_MapObject;
        ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + e_MapObject);
        ImgCurrentChoose.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicMapObject[e_MapObject].X * Hot.BodyGrid.X, Hot.BodyDicMapObject[e_MapObject].Y * Hot.BodyGrid.Y);
    }
}
