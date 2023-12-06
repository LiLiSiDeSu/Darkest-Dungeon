using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PanelExpeditionRoom : PanelBase
{
    public List<List<PanelGridExpeditionRoom>> Grids = new();
    public List<List<Transform>> ItemRoot = new();

    public Transform ImgRoomBk;

    public Transform CellRoomContent;
    public Transform ImgBkContent;
    public Transform ImgStatusContent;
    public Transform ItemContent;
    public Transform ComponentRoot;

    protected override void Awake()
    {
        base.Awake();

        ImgRoomBk = transform.FindSonSonSon("ImgRoomBk");

        CellRoomContent = transform.FindSonSonSon("CellRoomContent");
        ImgBkContent = transform.FindSonSonSon("ImgBkContent");
        ImgStatusContent = transform.FindSonSonSon("ImgStatusContent");
        ItemContent = transform.FindSonSonSon("ItemContent");
        ComponentRoot = transform.FindSonSonSon("ComponentRoot");

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyDown",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelExpeditionRoom") && key == Hot.MgrInput_.LeftControl)
            {
                ImgBkContent.gameObject.SetActive(false);
                Hot.NowEnterGridExpeditionRoom.ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
            }
        });
        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyUp",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelExpeditionRoom") && key == Hot.MgrInput_.LeftControl)
            {
                ImgBkContent.gameObject.SetActive(true);
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelExpeditionRoom") && !Hot.PoolNowPanel_.ContainPanel("PanelExpeditionMiniMap"))
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

                Hot.MgrUI_.CreatePanel<PanelGridExpeditionRoom>(false, "/PanelGridExpeditionRoom",
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

    public void LoadRoomData(int p_x, int p_y)
    {
        ClearRoom();

        List<List<DataContainer_CellExpeditionMapGrid>> Map = Hot.NowExpeditionEvent.DataExpedition.ListCellMiniMap[p_y][p_x].Map;

        for (int Y = 0; Y < Map.Count; Y++)
        {
            int tempY = Y;

            for (int X = 0; X < Map[Y].Count; X++)
            {
                int tempX = X;

                if (Map[tempY][tempX].Obj.e_Obj != E_MapObject.None)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellExpeditionRoom>(false, "/PanelCellExpeditionRoom",
                    (panel) =>
                    {
                        panel.Init(Map[tempY][tempX].Obj.e_Obj, Grids[tempY][tempX]);
                        panel.transform.SetParent(ItemRoot[tempY][tempX], false);
                        panel.transform.localPosition = new(-20, 20);

                        for (int Y = 0; Y < Hot.BodyDicMapObject[panel.e_Obj].Y; Y++)
                        {
                            for (int X = 0; X < Hot.BodyDicMapObject[panel.e_Obj].X; X++)
                            {
                                Grids[tempY + Y][tempX + X].CellExpeditionRoom = panel;
                            }
                        }
                    });
                }
            }
        }
    }

    public void ClearRoom()
    {
        foreach (List<PanelGridExpeditionRoom> list in Grids)
        {
            foreach (PanelGridExpeditionRoom item in list)
            {
                if (item.CellExpeditionRoom != null)
                {
                    Destroy(item.CellExpeditionRoom.gameObject);
                    item.CellExpeditionRoom = null;
                }
            }
        }
    }
}
