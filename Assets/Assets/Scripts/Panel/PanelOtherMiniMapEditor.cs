using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PanelOtherMiniMapEditor : PanelBaseVector2<PanelCellMiniMapEditor, PanelGridMiniMapEditor>
{
    public string PathFolder;

    public my_Vector2 EntrancePos = new();

    public Image ImgCurrentChoose;

    public InputField IptFileName;
    public InputField IptWidth;
    public InputField IptHeight;
    public InputField IptLoad;

    public Transform CellRoomScrollView;
    public Transform CellRoomContent;
    public Transform CellHallScrollView;
    public Transform CellHallContent;

    public Transform RootPanelChangeMapSize;
    public InputField IptChangeX;
    public InputField IptChangeY;

    protected override void Awake()
    {
        base.Awake();

        PathFolder = "/MapTemplet";

        ImgCurrentChoose = transform.FindSonSonSon("ImgCurrentChoose").GetComponent<Image>();
        ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");

        IptFileName = transform.FindSonSonSon("IptFileName").GetComponent<InputField>();
        IptWidth = transform.FindSonSonSon("IptWidth").GetComponent<InputField>();
        IptHeight = transform.FindSonSonSon("IptHeight").GetComponent<InputField>();
        IptLoad = transform.FindSonSonSon("IptLoad").GetComponent<InputField>();

        transform.FindSonSonSon("ImgSave").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgGenerate").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgLoad").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgClearMap").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;

        CellRoomScrollView = transform.FindSonSonSon("CellRoomScrollView");
        CellHallScrollView = transform.FindSonSonSon("CellHallScrollView");
        CellRoomContent = transform.FindSonSonSon("CellRoomContent");
        CellHallContent = transform.FindSonSonSon("CellHallContent");

        RootPanelChangeMapSize = transform.FindSonSonSon("RootPanelChangeMapSize");
        IptChangeX = transform.FindSonSonSon("IptChangeX").GetComponent<InputField>();
        IptChangeY = transform.FindSonSonSon("IptChangeY").GetComponent<InputField>();
        transform.FindSonSonSon("ImgChangeMapSize").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;

        InitChooseContent();

        CellHallScrollView.gameObject.SetActive(false);
        CellRoomScrollView.gameObject.SetActive(false);
        RootPanelChangeMapSize.gameObject.SetActive(false);
        IptChangeX.text = "0";
        IptChangeY.text = "0";

        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (Hot.NowEnterCellMiniMapEditor != null && key == KeyCode.Return)
            {
                Hot.MgrUI_.ShowPanel<PanelOtherRoomEditor>(true, "PanelOtherRoomEditor");
                Hot.NowEditorDependency = Hot.NowEnterCellMiniMapEditor;
                Hot.PanelOtherRoomEditor_.LoadRoomConfig(Hot.NowEditorDependency.Map);
            }
        });

        //这里可以用PoolInvoke来优化
        //但以后再说吧
        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelOtherMiniMapEditor") && key == KeyCode.Mouse1)
            {
                ClearImgStatus();

                //取消现在选择的CellMapEditor
                if (Hot.ChoseCellMiniMapEditor != null)
                {
                    if (Hot.ChoseCellMiniMapEditor.e_Room == E_CellMiniMap.CellMiniMapRoomEntrance)
                    {
                        CancelNowChoseRoomType();
                    }

                    Hot.ChoseCellMiniMapEditor.ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                    Hot.ChoseCellMiniMapEditor.ImgItem.raycastTarget = true;
                    Hot.ChoseCellMiniMapEditor = null;

                    return;
                }

                //删除创建的MiniMapCell
                if (Hot.NowEnterCellMiniMapEditor != null)
                {
                    for (int i1 = 0; i1 < Hot.BodyDicCellMiniMap[Hot.NowEnterCellMiniMapEditor.e_Room].Y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.BodyDicCellMiniMap[Hot.NowEnterCellMiniMapEditor.e_Room].X; i2++)
                        {
                            Hot.PanelOtherMiniMapEditor_.Grids[Hot.NowEnterCellMiniMapEditor.RootGrid.Y + i1][Hot.NowEnterCellMiniMapEditor.RootGrid.X + i2].Item = null;
                        }
                    }

                    if (Hot.NowEnterCellMiniMapEditor.e_Room == E_CellMiniMap.CellMiniMapRoomEntrance)
                    {
                        EntrancePos = new();
                    }

                    Destroy(Hot.NowEnterCellMiniMapEditor.gameObject);
                }

                CancelNowChoseRoomType();
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyHold.ToString(),
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelOtherMiniMapEditor"))
            {
                if (AllContent.localScale.x < 5f && key == Hot.MgrInput_.Add)
                {
                    AllContent.localScale += new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime);
                }
                else if (AllContent.localScale.x > 1f && key == Hot.MgrInput_.Reduce)
                {
                    AllContent.localScale -= new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
                }
            }
        });
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnChangeMapSize":
                if (RootPanelChangeMapSize.gameObject.activeSelf)
                {
                    if (ItemRoot.Count > 0)
                    {
                        ChangeMapSize();
                    }
                    if (int.Parse(IptChangeX.text) == 0 && int.Parse(IptChangeY.text) == 0)
                    {
                        RootPanelChangeMapSize.gameObject.SetActive(false);
                    }
                }
                else
                {
                    RootPanelChangeMapSize.gameObject.SetActive(true);
                }
                break;
            case "BtnGenerate":
                if (IptFileName.text != "" && IptWidth.text != "" && IptHeight.text != "" && int.Parse(IptWidth.text) > 0 && int.Parse(IptHeight.text) > 0)
                {
                    InitGrids(int.Parse(IptHeight.text), int.Parse(IptWidth.text));
                }
                break;
            case "BtnSave":
                if (IptFileName.text != "" && IptWidth.text != "" && IptHeight.text != "" && EntrancePos.X != -1)
                {
                    Save();
                }
                break;
            case "BtnLoad":
                if (File.Exists(Hot.MgrJson_.filePath + PathFolder + "/Editor" + "/" + IptLoad.text + ".json"))
                {
                    Load(IptLoad.text);
                }
                break;
            case "BtnClearMap":
                ClearList();
                IptFileName.text = "";
                IptWidth.text = "";
                IptHeight.text = "";
                break;
            case "BtnChooseCellRoom":
                if (CellRoomScrollView.gameObject.activeSelf)
                {
                    CellRoomScrollView.gameObject.SetActive(false);
                }
                else
                {
                    CellRoomScrollView.gameObject.SetActive(true);
                }
                Hot.e_ChoseRoom = E_CellMiniMap.None;
                Hot.PanelOtherMiniMapEditor_.ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                CellHallScrollView.gameObject.SetActive(false);
                break;
            case "BtnChooseCellHall":
                if (CellHallScrollView.gameObject.activeSelf)
                {
                    CellHallScrollView.gameObject.SetActive(false);
                }
                else
                {
                    CellHallScrollView.gameObject.SetActive(true);
                }
                Hot.e_ChoseRoom = E_CellMiniMap.None;
                Hot.PanelOtherMiniMapEditor_.ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                CellRoomScrollView.gameObject.SetActive(false);
                break;
        }
    }

    public void CancelNowChoseRoomType()
    {
        ImgCurrentChoose.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
        Hot.e_ChoseRoom = E_CellMiniMap.None;
    }

    public void InitChooseContent()
    {
        foreach (E_CellMiniMap e_CellExpeditionRoom in Enum.GetValues(typeof(E_CellMiniMap)))
        {
            if (e_CellExpeditionRoom != E_CellMiniMap.None)
            {
                Hot.MgrUI_.CreatePanel<PanelCellMiniMapEditorChoose>
                (false, "/PanelCellMiniMapEditorChoose",
                (panel) =>
                {
                    panel.Init(e_CellExpeditionRoom);

                    if (e_CellExpeditionRoom.ToString().Contains("Map"))
                    {
                        panel.transform.SetParent(CellRoomContent, false);
                    }
                    if (e_CellExpeditionRoom.ToString().Contains("Hall"))
                    {
                        panel.transform.SetParent(CellHallContent, false);
                    }
                });
            }
        }
    }

    public void ChangeMapSize()
    {
        if (int.Parse(IptChangeY.text) > 0)
        {
            for (int i = 0; i < int.Parse(IptChangeY.text); i++)
            {
                int GridsCount = Grids.Count;

                Grids.Add(new());
                ItemRoot.Add(new());

                GameObject ItemY = Hot.CreateContentStepY(Grids.Count - 1, ItemContent);
                ItemY.transform.SetParent(ItemContent, false);
                GameObject ImgBkY = Hot.CreateContentStepY(Grids.Count - 1, ImgBkContent);
                ImgBkY.transform.SetParent(ImgBkContent, false);
                GameObject ImgStatusY = Hot.CreateContentStepY(Grids.Count - 1, ImgStatusContent);
                ImgStatusY.transform.SetParent(ImgStatusContent, false);

                for (int i2 = 0; i2 < Grids[0].Count; i2++)
                {
                    int tempi2 = i2;

                    GameObject objX = Hot.CreateContentStepX(tempi2, ItemY.transform);
                    ItemRoot[GridsCount].Add(objX.transform);

                    Hot.MgrUI_.CreatePanel<PanelGridMiniMapEditor>(false, "/PanelGridMiniMapEditor",
                    (panel) =>
                    {
                        panel.Init(tempi2, GridsCount, ComponentRoot);
                        Grids[GridsCount].Add(panel);

                        panel.ImgBk.transform.SetParent(ImgBkY.transform, false);
                        panel.ImgStatus.transform.SetParent(ImgStatusY.transform, false);
                    });
                }
            }

            IptHeight.text = (int.Parse(IptHeight.text) + int.Parse(IptChangeY.text)).ToString();
        }
        else if (int.Parse(IptChangeY.text) < 0 && (int.Parse(IptChangeY.text) + int.Parse(IptHeight.text)) > 0)
        {
            for (int i = 0; i < -int.Parse(IptChangeY.text); i++)
            {
                if (JudgeCanReduceY())
                {
                    DestroyImmediate(ImgBkContent.GetChild(ImgBkContent.childCount - 1).gameObject);
                    DestroyImmediate(ImgStatusContent.GetChild(ImgStatusContent.childCount - 1).gameObject);
                    DestroyImmediate(ItemContent.GetChild(ItemContent.childCount - 1).gameObject);
                    ItemRoot.RemoveAt(ItemRoot.Count - 1);
                    for (int c = 0; c < Grids[^1].Count; c++)
                    {
                        DestroyImmediate(Grids[^1][c].gameObject);
                    }
                    Grids.RemoveAt(Grids.Count - 1);
                    IptHeight.text = (int.Parse(IptHeight.text) - 1).ToString();
                }
                else
                {
                    break;
                }
            }
        }

        if (int.Parse(IptChangeX.text) > 0)
        {
            for (int i = 0; i < int.Parse(IptChangeX.text); i++)
            {
                for (int iY = 0; iY < Grids.Count; iY++)
                {
                    int tempY = iY;

                    GameObject itemX = Hot.CreateContentStepX(Grids.Count, ItemContent.Find(tempY.ToString()));
                    ItemRoot[tempY].Add(itemX.transform);

                    Hot.MgrUI_.CreatePanel<PanelGridMiniMapEditor>(false, "/PanelGridMiniMapEditor",
                    (panel) =>
                    {
                        Grids[tempY].Add(panel);
                        panel.Init(Grids[tempY].Count - 1, tempY, ComponentRoot);

                        panel.ImgBk.transform.SetParent(ImgBkContent.Find(tempY.ToString()), false);
                        panel.ImgStatus.transform.SetParent(ImgStatusContent.Find(tempY.ToString()), false);
                    });
                }
            }

            IptWidth.text = (int.Parse(IptWidth.text) + int.Parse(IptChangeX.text)).ToString();
        }
        else if (int.Parse(IptChangeX.text) < 0 && (int.Parse(IptChangeX.text) + int.Parse(IptWidth.text)) > 0)
        {
            for (int i = 0; i < -int.Parse(IptChangeX.text); i++)
            {
                if (JudgeCanReduceX())
                {
                    for (int y = 0; y < Grids.Count; y++)
                    {
                        DestroyImmediate(Grids[y][^1].ImgBk.gameObject);
                        DestroyImmediate(Grids[y][^1].ImgStatus.gameObject);
                        DestroyImmediate(ItemContent.Find(y.ToString()).GetChild(ItemContent.Find(y.ToString()).childCount - 1).gameObject);
                        ItemRoot[y].RemoveAt(ItemRoot[y].Count - 1);
                        DestroyImmediate(Grids[y][^1].gameObject);
                        Grids[y].RemoveAt(Grids[y].Count - 1);
                    }

                    IptWidth.text = (int.Parse(IptWidth.text) - 1).ToString();
                }
                else
                {
                    break;
                }
            }
        }

        (AllContent as RectTransform).sizeDelta = new(int.Parse(IptWidth.text) * Hot.BodySizeCellMinimap.X, int.Parse(IptHeight.text) * Hot.BodySizeCellMinimap.Y);
    }

    public bool JudgeCanReduceY()
    {
        for (int i = 0; i < Grids[^1].Count; i++)
        {
            if (Grids[^1][i].Item != null)
            {
                return false;
            }
        }

        return true;
    }

    public bool JudgeCanReduceX()
    {
        for (int i = 0; i < Grids.Count; i++)
        {
            if (Grids[i][^1].Item != null)
            {
                return false;
            }
        }

        return true;
    }

    public override void InitGrids(int Y, int X)
    {
        ClearList();

        base.InitGrids(Y, X);
    }

    public void GenerateGridByLoadData(DataContainer_ExpeditionMiniMap MapData)
    {
        (AllContent as RectTransform).sizeDelta = new(int.Parse(IptWidth.text) * Hot.BodySizeCellMinimap.X, int.Parse(IptHeight.text) * Hot.BodySizeCellMinimap.Y);

        InitGrids(MapData.ListCellMiniMap.Count, MapData.ListCellMiniMap[0].Count);

        EntrancePos = MapData.EntrancePos;

        GenerateItemByLoad(MapData);
    }

    public void GenerateItemByLoad(DataContainer_ExpeditionMiniMap MapData)
    {
        for (int i1 = 0; i1 < Grids.Count; i1++)
        {
            int tempi1 = i1;

            for (int i2 = 0; i2 < Grids[tempi1].Count; i2++)
            {
                int tempi2 = i2;

                if (MapData.ListCellMiniMap[tempi1][tempi2].e_CellMiniMap != E_CellMiniMap.None)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellMiniMapEditor>(false, "/PanelCellMiniMapEditor",
                    (PanelCellMiniMapEditor_) =>
                    {
                        E_CellMiniMap e_CellMiniMap = MapData.ListCellMiniMap[tempi1][tempi2].e_CellMiniMap;
                        for (int i3 = 0; i3 < Hot.BodyDicCellMiniMap[e_CellMiniMap].Y; i3++)
                        {
                            for (int i4 = 0; i4 < Hot.BodyDicCellMiniMap[e_CellMiniMap].X; i4++)
                            {
                                Grids[tempi1 + i3][tempi2 + i4].Item = PanelCellMiniMapEditor_;
                            }
                        }

                        PanelCellMiniMapEditor_.Init(e_CellMiniMap, Grids[tempi1][tempi2]);

                        for (int i5 = 0; i5 < Hot.BodyMap.Y; i5++)
                        {
                            int tempi5 = i5;

                            for (int i6 = 0; i6 < Hot.BodyMap.X; i6++)
                            {
                                int tempi6 = i6;

                                PanelCellMiniMapEditor_.Map[tempi5][tempi6].Init(tempi5, tempi6);

                                if (MapData.ListCellMiniMap[tempi1][tempi2].Map[tempi5][tempi6].MapObj != null &&
                                    MapData.ListCellMiniMap[tempi1][tempi2].Map[tempi5][tempi6].MapObj.e_Obj != E_MapObject.None)
                                {
                                    PanelCellMiniMapEditor_.Map[tempi5][tempi6].IsHave = true;

                                    E_MapObject e_Obj = MapData.ListCellMiniMap[tempi1][tempi2].Map[tempi5][tempi6].MapObj.e_Obj;
                                    for (int j1 = 0; j1 < Hot.BodyDicMapObject[e_Obj].Y; j1++)
                                    {
                                        for (int j2 = 0; j2 < Hot.BodyDicMapObject[e_Obj].X; j2++)
                                        {
                                            PanelCellMiniMapEditor_.Map[tempi5 + j1][tempi6 + j2].e_Obj = e_Obj;
                                        }
                                    }
                                }
                            }
                        }
                    });
                }
            }
        }
    }

    public void Load(string fileName)
    {
        GenerateGridByLoadData(Hot.MgrJson_.Load<DataContainer_ExpeditionMiniMap>(PathFolder + "/Editor", "/" + fileName,
        (data) =>
        {
            IptFileName.text = IptLoad.text;
            IptLoad.text = "";
            IptWidth.text = data.ListCellMiniMap[0].Count.ToString();
            IptHeight.text = data.ListCellMiniMap.Count.ToString();
        }));
    }

    public override void ClearList()
    {
        EntrancePos = new();

        base.ClearList();
    }

    public void Save()
    {
        DataContainer_ExpeditionMiniMap MapData = new(EntrancePos);

        for (int i1 = 0; i1 < ItemRoot.Count; i1++)
        {
            MapData.ListCellMiniMap.Add(new());

            for (int i2 = 0; i2 < ItemRoot[i1].Count; i2++)
            {
                if (ItemRoot[i1][i2].childCount == 0)
                {
                    MapData.ListCellMiniMap[i1].Add(new());
                }
                else
                {
                    MapData.ListCellMiniMap[i1].Add(new());
                    MapData.ListCellMiniMap[i1][i2] = new(ItemRoot[i1][i2].GetComponentInChildren<PanelCellMiniMapEditor>().e_Room);

                    for (int i3 = 0; i3 < ItemRoot[i1][i2].GetComponentInChildren<PanelCellMiniMapEditor>().Map.Count; i3++)
                    {
                        for (int i4 = 0; i4 < ItemRoot[i1][i2].GetComponentInChildren<PanelCellMiniMapEditor>().Map[i3].Count; i4++)
                        {
                            if (ItemRoot[i1][i2].GetComponentInChildren<PanelCellMiniMapEditor>().Map[i3][i4].IsHave)
                            {
                                MapData.ListCellMiniMap[i1][i2].Map[i3][i4] = new()
                                {
                                    MapObj = new()
                                    {
                                        e_Obj = ItemRoot[i1][i2].GetComponentInChildren<PanelCellMiniMapEditor>().Map[i3][i4].e_Obj,
                                    }
                                };
                            }
                        }
                    }
                }
            }
        }

        Hot.MgrJson_.Save(MapData, PathFolder + "/Editor", "/" + IptFileName.text);
    }
}
