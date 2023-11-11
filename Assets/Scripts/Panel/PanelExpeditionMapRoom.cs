using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelExpeditionMapRoom : PanelBase
{
    public Transform RoomMapContent;
    public Transform RootRoomMap;

    public Dictionary<int, List<PanelCellExpeditionMap>> DicMap = new();    

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold", 
        (key) =>
        {            
            if (Hot.NowIndexCellGameArchive != -1 && key == Hot.MgrInput_.AddMapSize && RoomMapContent.localScale.x < 2f)
            {
                RoomMapContent.localScale += new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
            }            
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.NowIndexCellGameArchive != -1 && key == Hot.MgrInput_.ReduceMapSize && RoomMapContent.localScale.x > 1f)
            {
                RoomMapContent.localScale -= new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
            }            
        });

        RoomMapContent = transform.FindSonSonSon("RoomMapContent");
        RootRoomMap = transform.FindSonSonSon("RootRoomMap");
        InitMap();        
    }

    public void InitMap()
    {
        for (int i1 = 0; i1 < 9; i1++)
        {
            GameObject objH = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "PanelCellExpeditionMapH");
            objH.transform.SetParent(RootRoomMap, false);
            objH.name = "H" + i1;
            DicMap.Add(i1, new List<PanelCellExpeditionMap>());

            for (int i2 = 0; i2 < 25; i2++)
            {
                GameObject objW = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "PanelCellExpeditionMapW");
                objW.transform.SetParent(objH.transform, false);
                objW.name = "W" + i2;
                DicMap[i1].Add(objW.GetComponent<PanelCellExpeditionMap>());
                DicMap[i1][i2].h = i1;
                DicMap[i1][i2].w = i2;
            }
        }
    }
}
