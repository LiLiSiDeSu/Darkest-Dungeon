using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelExpeditionMapHall : PanelBase
{
    public Transform HallMapContent;
    public Transform RootHallMap;    
    public Dictionary<int, List<PanelCellExpeditionMap>> DicMap = new();    

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.NowIndexCellGameArchive != -1 && key == Hot.MgrInput_.AddMapSize && HallMapContent.localScale.x < 2f)
            {
                HallMapContent.localScale += new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.NowIndexCellGameArchive != -1 && key == Hot.MgrInput_.ReduceMapSize && HallMapContent.localScale.x > 1f)
            {
                HallMapContent.localScale -= new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
            }
        });

        HallMapContent = transform.FindSonSonSon("HallMapContent");
        RootHallMap = transform.FindSonSonSon("RootHallMap");

        Init();
    }

    public void Init()
    {
        for (int i1 = 0; i1 < 6; i1++)
        {
            GameObject objH = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "PanelCellExpeditionMapH");
            objH.transform.SetParent(RootHallMap, false);
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