using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class PanelOtherRoomEditor : PanelBaseVector2<PanelGridRoomEditor>
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

        Hot.CenterEvent_.AddEventListener("Esc" + "PanelOtherRoomEditor",
        () =>
        {
            Hot.NowEditorDependency = null;
            Hot.NowEnterGridRoomEditor = null;
            Hot.ChoseCellRoomEditor = null;
            Hot.NowEnterCellRoomEditor = null;
            ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
            Hot.e_ChoseObj = E_MapObject.None;
            Hot.PanelOtherRoomEditor_.ClearList();
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
                    AllContent.localScale +=
                        new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime);
                }

                if (AllContent.localScale.x > 1f && key == Hot.MgrInput_.Reduce)
                {
                    AllContent.localScale -=
                        new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime);
                }
            }
        });

        Init();
    }

    public void Init()
    {
        InitGrid(Hot.BodyExpeditionRoom.Y, Hot.BodyExpeditionRoom.X);
        InitChooseContent();
    }

    public void InitChooseContent()
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

    public void ChangeCurrentChoose(E_MapObject e_MapObject)
    {
        Hot.e_ChoseObj = e_MapObject;
        ImgCurrentChoose.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + e_MapObject);
        ImgCurrentChoose.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicMapObject[e_MapObject].X * Hot.BodySizeGridExpeditionMap.X, Hot.BodyDicMapObject[e_MapObject].Y * Hot.BodySizeGridExpeditionMap.Y);
    }

    public override void ClearList()
    {
        foreach (var list in ItemRoot)
        {
            foreach (var item in list)
            {
                if (item.childCount > 0)
                {
                    Destroy(item.GetChild(0).gameObject);
                }
            }
        }

        foreach (var list in Grids)
        {
            foreach (var item in list)
            {
                item.CellRoomEditor = null;
                item.ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
            }
        }
    }
}
