using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PanelOtherMapEditor : PanelBase
{
    public string PathFolder;

    public List<List<PanelCellMapEditorGrid>> Map = new();
    public List<List<Transform>> DependentObj = new();

    public Image ImgCurrentChooseRoom;
    public Image ImgCurrentChooseHall;
    
    public InputField IptFileName;
    public InputField IptWidth;
    public InputField IptHeight;
    public InputField IptLoad;

    public Transform MapEditorContent;
    public Transform CellRoomScrollView;
    public Transform CellHallScrollView;
    public Transform CellRoomContent;
    public Transform CellHallContent;
    public Transform DependentObjContent;   

    protected override void Awake()
    {
        base.Awake();

        PathFolder = "/MapTemplet";

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelOtherMapEditor") &&                
                key == Hot.MgrInput_.AddMapSize && MapEditorContent.localScale.x < 2f)
            {
                MapEditorContent.localScale += 
                    new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
                DependentObjContent.localScale += 
                    new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelOtherMapEditor") &&                
                key == Hot.MgrInput_.ReduceMapSize && MapEditorContent.localScale.x > 1f)
            {
                MapEditorContent.localScale -= 
                    new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
                DependentObjContent.localScale -= 
                    new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
            }
        });
        
        ImgCurrentChooseRoom = transform.FindSonSonSon("ImgCurrentChooseRoom").GetComponent<Image>();
        ImgCurrentChooseRoom.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
        ImgCurrentChooseHall = transform.FindSonSonSon("ImgCurrentChooseHall").GetComponent<Image>();
        ImgCurrentChooseHall.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");

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
        MapEditorContent = transform.FindSonSonSon("MapEditorContent");
        DependentObjContent = transform.FindSonSonSon("DependentObjContent");

        InitChooseContent();        

        CellHallScrollView.gameObject.SetActive(false);
        CellRoomScrollView.gameObject.SetActive(false);
    }

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
            case "BtnLoad":
                if (File.Exists(Hot.MgrJson_.filePath + PathFolder + "/" + IptLoad.text + ".json"))
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
                    ImgCurrentChooseRoom.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                    Hot.e_NowChooseRoom = E_CellExpeditionMiniMapRoom.None;
                }
                else
                {
                    Hot.e_NowChooseHall = E_CellExpeditionMiniMapHall.None;
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
                    Hot.e_NowChooseHall = E_CellExpeditionMiniMapHall.None;
                }
                else
                {
                    Hot.e_NowChooseRoom = E_CellExpeditionMiniMapRoom.None;
                    ImgCurrentChooseRoom.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");

                    CellRoomScrollView.gameObject.SetActive(false);
                    CellHallScrollView.gameObject.SetActive(true);
                }
                break;
        }
    }

    public void InitChooseContent()
    {
        foreach (E_CellExpeditionMiniMapRoom e_CellExpeditionMiniMapRoom in Enum.GetValues(typeof(E_CellExpeditionMiniMapRoom)))
        {
            if (e_CellExpeditionMiniMapRoom != E_CellExpeditionMiniMapRoom.None)
            {
                Hot.MgrUI_.CreatePanel<PanelCellMapEditorChooseRoom>
                (false, "/PanelCellMapEditorChooseRoom",
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
                Hot.MgrUI_.CreatePanel<PanelCellMapEditorChooseHall>(false, "/PanelCellMapEditorChooseHall",
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
        ClearMap();

        for (int i1 = 0; i1 < int.Parse(IptWidth.text); i1++)
        {
            int tempi1 = i1;
            Map.Add(new());
            DependentObj.Add(new());
            GameObject obj1 = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "PanelCellMapEditorGridH");
            obj1.transform.SetParent(MapEditorContent, false);
            GameObject obj2 = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "PanelCellMapEditorGridH");            
            obj2.transform.SetParent(DependentObjContent, false);

            for (int i2 = 0; i2 < int.Parse(IptHeight.text); i2++)
            {
                int tempi2 = i2;
                Map[tempi1].Add(new());
                DependentObj[tempi1].Add(Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep").transform);
                DependentObj[tempi1][tempi2].SetParent(obj2.transform, false);

                Hot.MgrUI_.CreatePanel<PanelCellMapEditorGrid>(false, "/PanelCellMapEditorGrid",
                (panel) =>
                {
                    panel.transform.SetParent(obj1.transform, false);
                    Map[tempi1][tempi2] = panel;

                    panel.Init(tempi1, tempi2);
                });
            }
        }        
    }

    public void GenerateByLoad(DataContainer_ExpeditionMiniMap MapData)
    {
        for (int i1 = 0; i1 < MapData.ListCellMiniMap.Count; i1++)
        {
            int tempi1 = i1;

            Map.Add(new());
            GameObject obj1 = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "PanelCellMapEditorGridH");
            obj1.transform.SetParent(MapEditorContent, false);

            DependentObj.Add(new());            
            GameObject obj2 = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "PanelCellMapEditorGridH");
            obj2.transform.SetParent(DependentObjContent, false);

            for (int i2 = 0; i2 < MapData.ListCellMiniMap[i1].Count; i2++)
            {
                int tempi2 = i2;

                Map[tempi1].Add(new());

                DependentObj[tempi1].Add(Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep").transform);
                DependentObj[tempi1][tempi2].SetParent(obj2.transform, false);

                Hot.MgrUI_.CreatePanel<PanelCellMapEditorGrid>(false, "/PanelCellMapEditorGrid",
                (panel) =>
                {
                    panel.transform.SetParent(obj1.transform, false);
                    Map[tempi1][tempi2] = panel;

                    panel.Init(tempi1, tempi2, MapData);                    
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

        foreach (Image item in DependentObjContent.GetComponentsInChildren<Image>())
        {
            Destroy(item.gameObject);
        }

        foreach (ContentStep item in DependentObjContent.GetComponentsInChildren<ContentStep>())
        {
            Destroy(item.gameObject);
        }

        Map.Clear();
        DependentObj.Clear();
    }

    public void Save()
    {
        DataContainer_ExpeditionMiniMap MapData = new DataContainer_ExpeditionMiniMap();
        for (int i1 = 0; i1 < Map.Count; i1++)
        {
            MapData.ListCellMiniMap.Add(new());

            for (int i2 = 0; i2 < Map[i1].Count; i2++)
            {
                MapData.ListCellMiniMap[i1].Add(new());

                MapData.ListCellMiniMap[i1][i2].IsHave = Map[i1][i2].IsHave;
                MapData.ListCellMiniMap[i1][i2].e_CellExpeditionMiniMapRoom = Map[i1][i2].e_CellExpeditionMiniMapRoom;
                MapData.ListCellMiniMap[i1][i2].e_CellExpeditionMiniMapHall = Map[i1][i2].e_CellExpeditionMiniMapHall;
            }
        }

        Hot.MgrJson_.Save(MapData, PathFolder, "/" + IptFileName.text);
    }

    public void Load(string fileName)
    {
        ClearMap();

        GenerateByLoad(Hot.MgrJson_.Load<DataContainer_ExpeditionMiniMap>(PathFolder, "/" + fileName,
        (data) =>
        {
            IptFileName.text = IptLoad.text;           
            IptWidth.text = data.ListCellMiniMap[0].Count.ToString();
            IptHeight.text = data.ListCellMiniMap.Count.ToString();
            IptLoad.text = "";
        }));
    }
}