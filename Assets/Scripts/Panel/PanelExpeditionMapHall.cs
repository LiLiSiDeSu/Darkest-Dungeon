using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelExpeditionMapHall : PanelBase
{
    public Transform HallMapContent;
    public Transform RootHallMap;    
    public Dictionary<int, List<PanelCellExpeditionMapGrid>> DicMap = new();    

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelExpeditionMapHall") &&
                !Hot.PoolNowPanel_.ContainPanel("PanelExpeditionMiniMap") &&
                key == Hot.MgrInput_.AddMapSize && HallMapContent.localScale.x < 2f)
            {
                HallMapContent.localScale += new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelExpeditionMapHall") &&
                !Hot.PoolNowPanel_.ContainPanel("PanelExpeditionMiniMap") &&
                key == Hot.MgrInput_.ReduceMapSize && HallMapContent.localScale.x > 1f)
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
            objH.name = "Y" + i1;
            DicMap.Add(i1, new List<PanelCellExpeditionMapGrid>());

            for (int i2 = 0; i2 < 25; i2++)
            {
                GameObject objW = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "PanelCellExpeditionMapW");
                objW.transform.SetParent(objH.transform, false);
                objW.name = "X" + i2;
                DicMap[i1].Add(objW.GetComponent<PanelCellExpeditionMapGrid>());
                DicMap[i1][i2].h = i1;
                DicMap[i1][i2].w = i2;
            }
        }
    }
}
