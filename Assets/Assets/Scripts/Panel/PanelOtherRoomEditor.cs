using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class PanelOtherRoomEditor : PanelBase
{    
    public List<List<PanelGridRoomEditor>> Grids = new();
    public List<List<Transform>> ItemRoot = new();

    public Image ImgCurrentChoose;

    public Transform ImgRoomBk;

    public Transform CellRoomContent;
    public Transform ImgBkContent;
    public Transform ImgStatusContent;
    public Transform ItemContent;
    public Transform ComponentRoot;

    public Transform ChooseGridContent;
    public Transform ChooseOtherContent;

    protected override void Awake()
    {
        base.Awake();

        ImgRoomBk = transform.FindSonSonSon("ImgRoomBk");

        CellRoomContent = transform.FindSonSonSon("CellRoomContent");
        ImgBkContent = transform.FindSonSonSon("ImgBkContent");
        ImgStatusContent = transform.FindSonSonSon("ImgStatusContent");
        ItemContent = transform.FindSonSonSon("ItemContent");
        ComponentRoot = transform.FindSonSonSon("ComponentRoot");

        ChooseGridContent = transform.FindSonSonSon("ChooseGridContent");
        ChooseOtherContent = transform.FindSonSonSon("ChooseOtherContent");

        ImgCurrentChoose = transform.FindSonSonSon("ImgCurrentChoose").GetComponent<Image>();

        Hot.CenterEvent_.AddEventListener("Esc" + "PanelOtherRoomEditor",
        () =>
        {
            Hot.NowEditorDependency = null;
            Hot.NowEnterGridRoomEditor = null;
            Hot.ChoseCellRoomEditor = null;
            Hot.NowEnterCellRoomEditor = null;
            ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
            Hot.e_ChoseObj = E_MapObject.None;
            Hot.PanelOtherRoomEditor_.Clear();
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyDown",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelOtherRoomEditor") && key == Hot.MgrInput_.LeftControl)
            {
                ImgBkContent.gameObject.SetActive(false);
                Hot.NowEnterGridRoomEditor.ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
            }
        });
        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyUP",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelOtherRoomEditor") && key == Hot.MgrInput_.LeftControl)
            {
                ImgBkContent.gameObject.SetActive(true);
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyDown",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelOtherRoomEditor") && key == Hot.MgrInput_.Mouse1)
            {
                if (Hot.ChoseCellRoomEditor != null)
                {
                    Hot.ChoseCellRoomEditor.ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
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
                            Hot.NowEditorDependency.Map[Hot.NowEnterCellRoomEditor.RootGrid.Y + i1][Hot.NowEnterCellRoomEditor.RootGrid.X + i2].e_Obj = E_MapObject.None;
                            Hot.PanelOtherRoomEditor_.Grids[Hot.NowEnterCellRoomEditor.RootGrid.Y + i1][Hot.NowEnterCellRoomEditor.RootGrid.X + i2].CellRoomEditor = null;
                            Hot.PanelOtherRoomEditor_.Grids[Hot.NowEnterCellRoomEditor.RootGrid.Y + i1][Hot.NowEnterCellRoomEditor.RootGrid.X + i2].ImgStatus.sprite =
                                Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                        }
                    }

                    Destroy(Hot.NowEnterCellRoomEditor.gameObject);

                    return;
                }

                if (Hot.e_ChoseObj != E_MapObject.None)
                {
                    if(Hot.NowEnterGridRoomEditor != null)
                    {
                        for (int i1 = 0; i1 < Hot.BodyDicMapObject[Hot.e_ChoseObj].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicMapObject[Hot.e_ChoseObj].X; i2++)
                            {
                                Hot.PanelOtherRoomEditor_.Grids[Hot.NowEnterGridRoomEditor.Y + i1][Hot.NowEnterGridRoomEditor.X + i2].ImgStatus.sprite =
                                    Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                            }
                        }
                    }

                    Hot.e_ChoseObj = E_MapObject.None;
                    Hot.PanelOtherRoomEditor_.ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                }
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelOtherRoomEditor"))
            {
                if (key == Hot.MgrInput_.Add)
                {
                    CellRoomContent.localScale +=
                        new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime);
                }

                if (CellRoomContent.localScale.x > 1f && key == Hot.MgrInput_.Reduce)
                {
                    CellRoomContent.localScale -=
                        new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime);
                }
            }
        });

        Init();
    }

    public void Init()
    {
        InitGrid();
        InitContent();
    }

    public void InitContent()
    {
        foreach (E_MapObject e_Obj in Enum.GetValues(typeof(E_MapObject)))
        {
            if (e_Obj != E_MapObject.None)
            {
                Hot.MgrUI_.CreatePanel<PanelCellRoomEditorChoose>(false, "/PanelCellRoomEditorChoose",
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

    public void InitGrid()
    {
        for (int i1 = 0; i1 < Hot.BodyExpeditionRoom.Y; i1++)
        {
            int tempi1 = i1;

            Grids.Add(new());
            ItemRoot.Add(new());

            GameObject obj1 = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep");
            obj1.transform.SetParent(ItemContent, false);
            GridLayoutGroup glg = obj1.AddComponent<GridLayoutGroup>();
            glg.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            glg.cellSize = new(Hot.BodySizeGridExpeditionMap.X, Hot.BodySizeGridExpeditionMap.Y);
            glg.constraintCount = 1;
            glg.childAlignment = TextAnchor.MiddleCenter;

            for (int i2 = 0; i2 < Hot.BodyExpeditionRoom.X; i2++)
            {
                int tempi2 = i2;

                Grids[tempi1].Add(new());

                GameObject obj2 = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep");
                obj2.transform.SetParent(obj1.transform, false);

                ItemRoot[tempi1].Add(obj2.transform);

                Hot.MgrUI_.CreatePanel<PanelGridRoomEditor>(false, "/PanelGridRoomEditor",
                (panel) =>
                {
                    Grids[tempi1][tempi2] = panel;

                    panel.transform.SetParent(ComponentRoot, false);
                    panel.ImgBk.transform.SetParent(ImgBkContent, false);
                    panel.ImgStatus.transform.SetParent(ImgStatusContent, false);

                    panel.Init(tempi2, tempi1);
                });
            }
        }
    }

    public void ChangeCurrentChoose(E_MapObject e_MapObject)
    {
        Hot.e_ChoseObj = e_MapObject;
        ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + e_MapObject);
        ImgCurrentChoose.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicMapObject[e_MapObject].X * Hot.BodySizeGridExpeditionMap.X, Hot.BodyDicMapObject[e_MapObject].Y * Hot.BodySizeGridExpeditionMap.Y);
    }

    public void LoadRoomConfig(List<List<PanelCellGridRoomEditorConfig>> map)
    {        
        for (int Y = 0; Y < map.Count; Y++)
        {
            int tempiY = Y;

            for (int iX = 0; iX < map[Y].Count; iX++)
            {
                int tempiX = iX;

                if (map[tempiY][tempiX].IsHave)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellRoomEditor>(false, "/PanelCellRoomEditor",
                    (panel) =>
                    {
                        panel.Init(map[tempiY][tempiX].e_Obj, Grids[tempiY][tempiX]);
                        panel.transform.SetParent(ItemRoot[tempiY][tempiX], false);
                        panel.transform.localPosition = new(-20, 20);

                        for (int i1 = 0; i1 < Hot.BodyDicMapObject[map[tempiY][tempiX].e_Obj].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicMapObject[map[tempiY][tempiX].e_Obj].X; i2++)
                            {
                                Grids[tempiY + i1][tempiX + i2].CellRoomEditor = panel;
                            }
                        }
                    });
                }
            }
        }
    }        

    public void Clear()
    {
        foreach (List<Transform> list in ItemRoot)
        {
            foreach (Transform item in list)
            {
                if (item.childCount > 0)
                {
                    Destroy(item.GetChild(0).gameObject);
                }
            }
        }

        foreach (List<PanelGridRoomEditor> list in Grids)
        {
            foreach (PanelGridRoomEditor item in list)
            {
                item.CellRoomEditor = null;
                item.ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
            }
        }
    }
}
