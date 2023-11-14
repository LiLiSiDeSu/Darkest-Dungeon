using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PanelOtherMapEditor : PanelBase
{    
    public List<List<PanelCellExpeditionMiniMapGrid>> Map = new();

    public Image ImgCurrentChooseRoom;
    public Image ImgCurrentChooseHall;
    
    public InputField IptFileName;
    public InputField IptWidth;
    public InputField IptHeight;

    public Transform MapEditorContent;
    public Transform CellRoomScrollView;
    public Transform CellHallScrollView;
    public Transform CellRoomContent;
    public Transform CellHallContent;

    protected override void Button_OnClick(string controlname)
    {        
        base.Button_OnClick(controlname);       

        switch (controlname)
        {
            case "BtnGenerate":                
                if (IptFileName.text != "" && IptWidth.text != "" && IptHeight.text != "")
                {
                    Generate();                                        
                }
                break;
            case "BtnSave":
                if (IptFileName.text != "" && IptWidth.text != "" && IptHeight.text != "")
                {
                    Save();
                }
                break;
            case "BtnFolder":
                break;
            case "BtnClearMap":
                ClearMap();
                break;
            case "BtnChooseCellRoom":
                if (CellRoomScrollView.gameObject.activeSelf)
                {
                    CellRoomScrollView.gameObject.SetActive(false);
                    ImgCurrentChooseRoom.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                }
                else
                {
                    ImgCurrentChooseHall.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                    CellRoomScrollView.gameObject.SetActive(true);
                    CellHallScrollView.gameObject.SetActive(false);
                }
                break;
            case "BtnChooseCellHall":
                if (CellHallScrollView.gameObject.activeSelf)
                {
                    CellHallScrollView.gameObject.SetActive(false);
                    ImgCurrentChooseHall.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                }
                else
                {
                    ImgCurrentChooseRoom.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                    CellRoomScrollView.gameObject.SetActive(false);
                    CellHallScrollView.gameObject.SetActive(true);
                }
                break;
        }
    }    

    protected override void Awake()
    {
        base.Awake();        

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelOtherMapEditor") &&                
                key == Hot.MgrInput_.AddMapSize && MapEditorContent.localScale.x < 2f)
            {
                MapEditorContent.localScale += new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelOtherMapEditor") &&                
                key == Hot.MgrInput_.ReduceMapSize && MapEditorContent.localScale.x > 1f)
            {
                MapEditorContent.localScale -= new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
            }
        });
        
        ImgCurrentChooseRoom = transform.FindSonSonSon("ImgCurrentChooseRoom").GetComponent<Image>();
        ImgCurrentChooseRoom.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
        ImgCurrentChooseHall = transform.FindSonSonSon("ImgCurrentChooseHall").GetComponent<Image>();
        ImgCurrentChooseHall.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");

        IptFileName = transform.FindSonSonSon("IptFileName").GetComponent<InputField>();
        IptWidth = transform.FindSonSonSon("IptWidth").GetComponent<InputField>();
        IptHeight = transform.FindSonSonSon("IptHeight").GetComponent<InputField>();       

        transform.FindSonSonSon("ImgSave").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgGenerate").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgFolder").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgClearMap").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;

        CellRoomScrollView = transform.FindSonSonSon("CellRoomScrollView");
        CellHallScrollView = transform.FindSonSonSon("CellHallScrollView");
        CellRoomContent = transform.FindSonSonSon("CellRoomContent");
        CellHallContent = transform.FindSonSonSon("CellHallContent");
        MapEditorContent = transform.FindSonSonSon("MapEditorContent");

        InitContent();        

        CellHallScrollView.gameObject.SetActive(false);
        CellRoomScrollView.gameObject.SetActive(false);
    }    

    public void InitContent()
    {
        foreach (E_CellExpeditionMiniMapRoom e_CellExpeditionMiniMapRoom in Enum.GetValues(typeof(E_CellExpeditionMiniMapRoom)))
        {
            if (e_CellExpeditionMiniMapRoom != E_CellExpeditionMiniMapRoom.None)
            {
                Hot.MgrUI_.CreatePanel<PanelCellExpeditionMiniMapChooseRoom>
                (false, "/PanelCellExpeditionMiniMapChooseRoom",
                (panel) =>
                {
                    panel.Init(e_CellExpeditionMiniMapRoom);
                    panel.transform.SetParent(CellRoomContent, false);
                });
            }
        }

        foreach (E_CellExpeditionMiniMapHall e_CellExpeditionMiniMapHall in Enum.GetValues(typeof(E_CellExpeditionMiniMapHall)))
        {
            if (e_CellExpeditionMiniMapHall != E_CellExpeditionMiniMapHall.None)
            {
                Hot.MgrUI_.CreatePanel<PanelCellExpeditionMiniMapChooseHall>(false, "/PanelCellExpeditionMiniMapChooseHall",
                (panel) =>
                {
                    panel.Init(e_CellExpeditionMiniMapHall);
                    panel.transform.SetParent(CellHallContent, false);
                });
            }            
        }
    }

    public void Generate()
    {
        for (int i1 = 0; i1 < int.Parse(IptWidth.text); i1++)
        {
            GameObject obj1 = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "PanelCellExpeditionMiniMapGridH");
            obj1.transform.SetParent(MapEditorContent, false);

            for (int i2 = 0; i2 < int.Parse(IptHeight.text); i2++)
            {
                int tempi2 = i2;
                Map.Add(new());

                Hot.MgrUI_.CreatePanel<PanelCellExpeditionMiniMapGrid>(false, "/PanelCellExpeditionMiniMapGridW",
                (panel) =>
                {
                    panel.Init(i1, tempi2);
                    panel.transform.SetParent(obj1.transform, false);
                    Map[i1].Add(new());
                    Map[i1][tempi2] = panel;
                });
            }
        }
    }

    public void ClearMap()
    {
        foreach (ContentStep item in MapEditorContent.GetComponentsInChildren<ContentStep>())
        {
            Destroy(item.gameObject);
        }
    }

    public void Save()
    {
        DataContainer_ExpeditionMiniMap DataMap = new DataContainer_ExpeditionMiniMap();
        for (int i1 = 0; i1 < Map.Count; i1++)
        {
            DataMap.ListCellMiniMap.Add(new());

            for (int i2 = 0; i2 < Map[i1].Count; i2++)
            {
                DataMap.ListCellMiniMap[i1].Add(new());

                DataMap.ListCellMiniMap[i1][i2].IsHave = Map[i1][i2].IsHave;
                DataMap.ListCellMiniMap[i1][i2].e_CellExpeditionMiniMapRoom = Map[i1][i2].e_CellExpeditionMiniMapRoom;
                DataMap.ListCellMiniMap[i1][i2].e_CellExpeditionMiniMapHall = Map[i1][i2].e_CellExpeditionMiniMapHall;
            }
        }

        Hot.MgrJson_.Save(DataMap, "/MapTemplet", "/TestMap");
    }
}
