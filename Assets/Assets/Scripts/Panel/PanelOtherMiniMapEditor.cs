using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PanelOtherMiniMapEditor : PanelBase
{
    public string PathFolder;

    public my_Vector2 EntrancePos = my_Vector2.m_One;

    public List<List<PanelCellGridMiniMapEditor>> Grids = new();
    public List<List<Transform>> ItemRoot = new();

    public Image ImgCurrentChoose;
    
    public InputField IptFileName;
    public InputField IptWidth;
    public InputField IptHeight;
    public InputField IptLoad;
    
    public Transform CellRoomScrollView;
    public Transform CellRoomContent;
    public Transform CellHallScrollView;
    public Transform CellHallContent;

    public Transform AllContent;
    public Transform ImgBkContent;
    public Transform ImgStatusContent;
    public Transform ItemContent;
    public Transform ComponentRoot;

    public Transform RootPanelChangeMapSize;
    public InputField IptX;
    public InputField IptY;

    protected override void Awake()
    {
        base.Awake();

        PathFolder = "/MapTemplet";

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyDown",
        (key) =>
        {
            if (Hot.NowEnterCellMiniMapEditor != null && key == Hot.MgrInput_.Return)
            {
                Hot.MgrUI_.ShowPanel<PanelOtherRoomEditor>(true, "PanelOtherRoomEditor");
                Hot.NowEditorDependency = Hot.NowEnterCellMiniMapEditor;
                Hot.PanelOtherRoomEditor_.LoadRoomConfig(Hot.NowEditorDependency.Map);
            }
        });

        //这里可以用PoolInvoke来优化
        //但以后再说吧
        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyDown", 
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelOtherMiniMapEditor") && key == Hot.MgrInput_.Mouse1)
            {
                //取消现在选择的CellMapEditor
                if (Hot.ChoseCellMiniMapEditor != null)
                {
                    Hot.ChoseCellMiniMapEditor.ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                    Hot.ChoseCellMiniMapEditor.ImgCellMiniMapEditor.raycastTarget = true;
                    Hot.ChoseCellMiniMapEditor = null;

                    ClearGridsImgStatus();

                    return;
                }

                //删除创建的MiniMapCell
                if (Hot.NowEnterCellMiniMapEditor != null) 
                {
                    for (int i1 = 0; i1 < Hot.BodyDicRoom[Hot.NowEnterCellMiniMapEditor.e_Room].Y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.BodyDicRoom[Hot.NowEnterCellMiniMapEditor.e_Room].X; i2++)
                        {
                            Hot.PanelOtherMiniMapEditor_.Grids[Hot.NowEnterCellMiniMapEditor.RootGrid.Y + i1][Hot.NowEnterCellMiniMapEditor.RootGrid.X + i2].CellMiniMapEditor = null;
                        }
                    }

                    if (Hot.NowEnterCellMiniMapEditor.e_Room == E_CellMiniMapRoom.CellMapRoomEntrance)
                    {
                        EntrancePos = my_Vector2.m_One;
                    }

                    Destroy(Hot.NowEnterCellMiniMapEditor.gameObject);
                }

                //取消现在选择的MiniMapCell类型
                ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                Hot.e_ChoseRoom = E_CellMiniMapRoom.None;

                ClearGridsImgStatus();
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelOtherMiniMapEditor"))
            {
                if (key == Hot.MgrInput_.Add)
                {
                    AllContent.localScale +=
                        new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime);
                    AllContent.localScale +=
                        new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime);
                }
                else if (key == Hot.MgrInput_.Reduce)
                {
                    AllContent.localScale -=
                        new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
                    AllContent.localScale -=
                        new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
                }
            }            
        });

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

        AllContent = transform.FindSonSonSon("AllContent");
        ImgBkContent = transform.FindSonSonSon("ImgBkContent");
        ImgStatusContent = transform.FindSonSonSon("ImgStatusContent");
        ItemContent = transform.FindSonSonSon("ItemContent");
        ComponentRoot = transform.FindSonSonSon("ComponentRoot");

        RootPanelChangeMapSize = transform.FindSonSonSon("RootPanelChangeMapSize");
        IptX = transform.FindSonSonSon("IptX").GetComponent<InputField>();
        IptY = transform.FindSonSonSon("IptY").GetComponent<InputField>();
        transform.FindSonSonSon("ImgChangeMapSize").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;

        InitChooseContent();        

        CellHallScrollView.gameObject.SetActive(false);
        CellRoomScrollView.gameObject.SetActive(false);
        RootPanelChangeMapSize.gameObject.SetActive(false);
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnChangeMapSize":
                if (RootPanelChangeMapSize.gameObject.activeSelf)
                {
                    if (ItemRoot.Count > 0 && IptX.text != "" && IptY.text != "")
                    {
                        ChangeMapSize();
                    }
                    else
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
                    GenerateGrid();
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
                ClearMap();
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
                Hot.e_ChoseRoom = E_CellMiniMapRoom.None;
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
                Hot.e_ChoseRoom = E_CellMiniMapRoom.None;
                Hot.PanelOtherMiniMapEditor_.ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                CellRoomScrollView.gameObject.SetActive(false);                
                break;
        }
    }

    public void InitChooseContent()
    {
        foreach (E_CellMiniMapRoom e_CellExpeditionRoom in Enum.GetValues(typeof(E_CellMiniMapRoom)))
        {
            if (e_CellExpeditionRoom != E_CellMiniMapRoom.None)
            {
                Hot.MgrUI_.CreatePanel<PanelCellMiniMapEditorChoose>
                (false, "/PanelCellMiniMapEditorChoose",
                (panel) =>
                {
                    panel.Init(e_CellExpeditionRoom);
                    
                    if (e_CellExpeditionRoom.ToString().Contains("Room"))
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
        if (!JudegeCanReduceMapSize())
        {
            return;
        }

        if (int.Parse(IptY.text) > 0)
        {
            int tempCount = Grids[0].Count;

            for (int i1 = 0; i1 < int.Parse(IptY.text); i1++)
            {
                Grids.Add(new());
                ItemRoot.Add(new());

                GameObject ItemY = CreateContentStepY(Grids.Count - 1, ItemContent);
                ItemY.transform.SetParent(ItemContent, false);
                GameObject ImgBkY = CreateContentStepY(Grids.Count - 1, ImgBkContent);
                ImgBkY.transform.SetParent(ImgBkContent, false);
                GameObject ImgStatusY = CreateContentStepY(Grids.Count - 1, ImgStatusContent);
                ImgStatusY.transform.SetParent(ImgStatusContent, false);

                for (int i2 = 0; i2 < tempCount; i2++)
                {
                    int tempi2 = i2;

                    GameObject objX = CreateContentStepX(tempi2, ItemY.transform);
                    ItemRoot[i1].Add(objX.transform);

                    Hot.MgrUI_.CreatePanel<PanelCellGridMiniMapEditor>(false, "/PanelCellGridMiniMapEditor",
                    (panel) =>
                    {
                        panel.Init(tempi2, Grids.Count - 1, ComponentRoot);
                        Grids[^1].Add(panel);

                        panel.ImgBk.transform.SetParent(ImgBkY.transform, false);
                        panel.ImgStatus.transform.SetParent(ImgStatusY.transform, false);
                    });
                }
            }
        }
        else if (int.Parse(IptY.text) < 0)
        {

        }
        else if (int.Parse(IptY.text) == 0)
        {
            ;
        }

        if (int.Parse(IptX.text) > 0)
        {
            for (int iY = 0; iY < Grids.Count; iY++)
            {
                int tempY = iY;

                for (int iX = 0; iX < int.Parse(IptX.text); iX++)
                {
                    GameObject itemX = CreateContentStepX(iX, ItemContent.Find(tempY.ToString()));
                    ItemRoot[tempY].Add(itemX.transform);

                    Hot.MgrUI_.CreatePanel<PanelCellGridMiniMapEditor>(false, "/PanelCellGridMiniMapEditor",
                    (panel) =>
                    {
                        Grids[tempY].Add(panel);
                        panel.Init(Grids[tempY].Count - 1, tempY, ComponentRoot);

                        panel.ImgBk.transform.SetParent(ImgBkContent.Find(tempY.ToString()), false);
                        panel.ImgStatus.transform.SetParent(ImgStatusContent.Find(tempY.ToString()), false);
                    });
                }
            }
        }
        else if (int.Parse(IptX.text) < 0)
        {

        }
        else if (int.Parse(IptX.text) == 0)
        {
            ;
        }
    }

    public bool JudegeCanReduceMapSize()
    {
        return true;
    }

    public void GenerateGrid()
    {        
        ClearMap();

        (AllContent as RectTransform).sizeDelta =
            new(int.Parse(IptWidth.text) * Hot.BodySizeCellMinimap.X,
                int.Parse(IptHeight.text) * Hot.BodySizeCellMinimap.Y);

        for (int iY = 0; iY < int.Parse(IptHeight.text); iY++)
        {
            int tempiY = iY;

            Grids.Add(new());
            ItemRoot.Add(new());

            GameObject ImgBkY = CreateContentStepY(tempiY, ImgBkContent);
            GameObject ImgStatusY = CreateContentStepY(tempiY, ImgStatusContent);
            GameObject ItemY = CreateContentStepY(tempiY, ItemContent);

            for (int iX = 0; iX < int.Parse(IptWidth.text); iX++)
            {
                int tempiX = iX;

                Grids[tempiY].Add(new());

                GameObject ItemX = CreateContentStepX(tempiX, ItemY.transform);

                ItemRoot[tempiY].Add(ItemX.transform);

                Hot.MgrUI_.CreatePanel<PanelCellGridMiniMapEditor>(false, "/PanelCellGridMiniMapEditor",
                (PanelCellMapEditorGrid_) =>
                {
                    Grids[tempiY][tempiX] = PanelCellMapEditorGrid_;

                    PanelCellMapEditorGrid_.Init(tempiX, tempiY, ComponentRoot);

                    PanelCellMapEditorGrid_.ImgBk.transform.SetParent(ImgBkY.transform, false);
                    PanelCellMapEditorGrid_.ImgStatus.transform.SetParent(ImgStatusY.transform, false);
                });
            }
        }

        ChangeCellSize();
    }

    public GameObject CreateContentStepY(int p_index, Transform father)
    {
        GameObject obj = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep");
        obj.transform.SetParent(father, false);
        obj.name = p_index.ToString();
        GridLayoutGroup glg = obj.AddComponent<GridLayoutGroup>();
        glg.constraint = GridLayoutGroup.Constraint.FixedRowCount;
        glg.constraintCount = 1;
        glg.childAlignment = TextAnchor.MiddleCenter;
        glg.cellSize = new(Hot.BodyCellGridExpeditionMap.X, Hot.BodyCellGridExpeditionMap.Y);

        return obj;
    }

    public GameObject CreateContentStepX(int p_index, Transform father)
    {
        GameObject obj = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep");
        obj.transform.SetParent(father.transform, false);
        obj.name = p_index.ToString();

        return obj;
    }

    public void GenerateGridByLoadData(DataContainer_Expedition MapData)
    {
        ClearMap();

        (AllContent as RectTransform).sizeDelta =
            new(int.Parse(IptWidth.text) * Hot.BodySizeCellMinimap.X,
                int.Parse(IptHeight.text) * Hot.BodySizeCellMinimap.Y);

        transform.FindSonSonSon("ImgBkContent").GetComponent<GridLayoutGroup>().constraintCount = int.Parse(IptWidth.text);
        transform.FindSonSonSon("ImgStatusContent").GetComponent<GridLayoutGroup>().constraintCount = int.Parse(IptWidth.text);

        EntrancePos = MapData.EntrancePos;

        for (int i1 = 0; i1 < MapData.ListCellMiniMap.Count; i1++)
        {
            int tempi1 = i1;

            Grids.Add(new());
            ItemRoot.Add(new());

            GameObject obj1 = CreateContentStepY(tempi1, ItemContent);

            for (int i2 = 0; i2 < MapData.ListCellMiniMap[tempi1].Count; i2++)
            {
                int tempi2 = i2;

                Grids[tempi1].Add(new());

                GameObject obj2 = CreateContentStepX(tempi2, obj1.transform);

                ItemRoot[tempi1].Add(obj2.transform);

                Hot.MgrUI_.CreatePanel<PanelCellGridMiniMapEditor>(false, "/PanelCellGridMiniMapEditor",
                (PanelCellMapEditorGrid_) =>
                {
                    Grids[tempi1][tempi2] = PanelCellMapEditorGrid_;

                    PanelCellMapEditorGrid_.transform.SetParent(ComponentRoot, false);
                    PanelCellMapEditorGrid_.ImgBk.transform.SetParent(ImgBkContent, false);
                    PanelCellMapEditorGrid_.ImgStatus.transform.SetParent(ImgStatusContent, false);

                    PanelCellMapEditorGrid_.X = tempi2;
                    PanelCellMapEditorGrid_.Y = tempi1;                    
                });
            }
        }

        GenerateItemByLoad(MapData);

        ChangeCellSize();
    }

    public void GenerateItemByLoad(DataContainer_Expedition MapData)
    {
        for (int i1 = 0; i1 < Grids.Count; i1++)
        {
            int tempi1 = i1;

            for (int i2 = 0; i2 < Grids[tempi1].Count; i2++)
            {
                int tempi2 = i2;

                if (MapData.ListCellMiniMap[tempi1][tempi2].e_Room != E_CellMiniMapRoom.None)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellMiniMapEditor>(false, "/PanelCellMiniMapEditor",
                    (PanelCellMiniMapEditor_) =>
                    {
                        PanelCellMiniMapEditor_.transform.SetParent(ItemRoot[tempi1][tempi2].transform, false);
                        PanelCellMiniMapEditor_.transform.localPosition = new Vector3(-20, 20);

                        PanelCellMiniMapEditor_.RootGrid = Grids[tempi1][tempi2];

                        for (int i3 = 0; i3 < Hot.BodyDicRoom[MapData.ListCellMiniMap[tempi1][tempi2].e_Room].Y; i3++)
                        {
                            for (int i4 = 0; i4 < Hot.BodyDicRoom[MapData.ListCellMiniMap[tempi1][tempi2].e_Room].X; i4++)
                            {
                                Grids[tempi1 + i3][tempi2 + i4].CellMiniMapEditor = PanelCellMiniMapEditor_;
                            }
                        }

                        //Init Map
                        PanelCellMiniMapEditor_.Init(MapData.ListCellMiniMap[tempi1][tempi2].e_Room);

                        for (int i5 = 0; i5 < Hot.BodyExpeditionRoom.Y; i5++)
                        {
                            int tempi5 = i5;

                            for (int i6 = 0; i6 < Hot.BodyExpeditionRoom.X; i6++)
                            {
                                int tempi6 = i6;

                                PanelCellMiniMapEditor_.Map[tempi5][tempi6].Init(tempi5, tempi6);

                                if (MapData.ListCellMiniMap[tempi1][tempi2].Map[tempi5][tempi6].Obj.e_Obj != E_MapObject.None)
                                {
                                    PanelCellMiniMapEditor_.Map[tempi5][tempi6].IsHave = true;

                                    for (int j1 = 0; j1 < Hot.BodyDicMapObject[MapData.ListCellMiniMap[tempi1][tempi2].Map[tempi5][tempi6].Obj.e_Obj].Y; j1++)
                                    {
                                        for (int j2 = 0; j2 < Hot.BodyDicMapObject[MapData.ListCellMiniMap[tempi1][tempi2].Map[tempi5][tempi6].Obj.e_Obj].X; j2++)
                                        {
                                            PanelCellMiniMapEditor_.Map[tempi5 + j1][tempi6 + j2].e_Obj = MapData.ListCellMiniMap[tempi1][tempi2].Map[tempi5][tempi6].Obj.e_Obj;
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
        GenerateGridByLoadData(Hot.MgrJson_.Load<DataContainer_Expedition>(PathFolder + "/Editor", "/" + fileName,
        (data) =>
        {
            IptFileName.text = IptLoad.text;
            IptLoad.text = "";
            IptWidth.text = data.ListCellMiniMap[0].Count.ToString();
            IptHeight.text = data.ListCellMiniMap.Count.ToString();
        }));
    }

    public void ClearGridsImgStatus()
    {
        foreach (List<PanelCellGridMiniMapEditor> list in Grids)
        {
            foreach (PanelCellGridMiniMapEditor item in list)
            {
                item.ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
            }
        }
    }

    public void ClearMap()
    {
        EntrancePos = my_Vector2.m_One;

        foreach (List<PanelCellGridMiniMapEditor> list in Grids)
        {
            foreach (PanelCellGridMiniMapEditor item in list)
            {
                Destroy(item.ImgBk.gameObject);
                Destroy(item.ImgStatus.gameObject);
                Destroy(item.gameObject);                
            }
        }

        foreach (ContentStep item in ItemContent.GetComponentsInChildren<ContentStep>())
        {
            Destroy(item.gameObject);
        }

        Grids.Clear();
        ItemRoot.Clear();
    }

    public void Save()
    {
        DataContainer_Expedition MapData = new()
        {
            EntrancePos = EntrancePos
        };

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
                    MapData.ListCellMiniMap[i1].Add(new() 
                    { 
                        e_Room = ItemRoot[i1][i2].GetComponentInChildren<PanelCellMiniMapEditor>().e_Room,
                        Map = new(),
                    });

                    //保存Map 
                    for (int i3 = 0; i3 < ItemRoot[i1][i2].GetComponentInChildren<PanelCellMiniMapEditor>().Map.Count; i3++)
                    {
                        MapData.ListCellMiniMap[i1][i2].Map.Add(new());

                        for (int i4 = 0; i4 < ItemRoot[i1][i2].GetComponentInChildren<PanelCellMiniMapEditor>().Map[i3].Count; i4++)
                        {
                            MapData.ListCellMiniMap[i1][i2].Map[i3].Add(new());

                            if (ItemRoot[i1][i2].GetComponentInChildren<PanelCellMiniMapEditor>().Map[i3][i4].IsHave)
                            {
                                MapData.ListCellMiniMap[i1][i2].Map[i3][i4] = new()
                                {
                                    Obj = new()
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

    public void ChangeCellSize()
    {
        foreach (GridLayoutGroup item in ItemContent.GetComponentsInChildren<GridLayoutGroup>())
        {
            item.cellSize = new(Hot.BodySizeCellItem.X, Hot.BodySizeCellItem.Y);
        }
        foreach (GridLayoutGroup item in ImgBkContent.GetComponentsInChildren<GridLayoutGroup>())
        {
            item.cellSize = new(Hot.BodySizeCellItem.X, Hot.BodySizeCellItem.Y);
        }
        foreach (GridLayoutGroup item in ImgStatusContent.GetComponentsInChildren<GridLayoutGroup>())
        {
            item.cellSize = new(Hot.BodySizeCellItem.X, Hot.BodySizeCellItem.Y);
        }

        foreach (List<Transform> listItem in ItemRoot)
        {
            foreach (Transform item in listItem)
            {
                if (item.childCount > 0)
                {
                    item.GetComponentInChildren<PanelCellItem>().ChangeSize();
                }
            }
        }
    }
}