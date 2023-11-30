using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class PanelOtherRoomEditor : PanelBase
{    
    public List<List<PanelCellGridRoomEditor>> Grids = new();
    public List<List<Transform>> ItemRoot = new();

    public Image ImgCurrentChoose;

    public Transform ImgRoomBk;

    public Transform CellRoomContent;
    public Transform ImgBkContent;
    public Transform ImgStatusContent;
    private Transform ItemContent;
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

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyDown",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelOtherRoomEditor") && key == Hot.MgrInput_.Cancel)
            {
                Hot.e_ChoseObj = E_MapObject.None;
                Hot.PanelOtherRoomEditor_.ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelOtherRoomEditor"))
            {
                if (key == Hot.MgrInput_.Add)
                {
                    ImgRoomBk.localScale +=
                        new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime);
                }

                if (ImgRoomBk.localScale.x > 1f && key == Hot.MgrInput_.Reduce)
                {
                    ImgRoomBk.localScale -=
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
            glg.cellSize = new(Hot.BodyCellGridExpeditionMap.X, Hot.BodyCellGridExpeditionMap.Y);
            glg.constraintCount = 1;
            glg.childAlignment = TextAnchor.MiddleCenter;

            for (int i2 = 0; i2 < Hot.BodyExpeditionRoom.X; i2++)
            {
                int tempi2 = i2;

                Grids[tempi1].Add(new());

                GameObject obj2 = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep");
                obj2.transform.SetParent(obj1.transform, false);

                ItemRoot[tempi1].Add(obj2.transform);

                Hot.MgrUI_.CreatePanel<PanelCellGridRoomEditor>(false, "/PanelCellGridRoomEditor",
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

    public void GenerateByData(List<List<PanelCellGridRoomEditorConfig>> map)
    {        
        
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
    }
}
