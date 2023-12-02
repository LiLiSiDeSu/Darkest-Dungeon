using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelRoomTownShop : PanelBase
{        
    protected override void Awake()
    {
        base.Awake();               

        MgrUI.GetInstance().CreatePanel<PanelTownShopCost>
        (true, "/PanelTownShopCost",
        (panel) =>
        {            
            panel.transform.SetParent(transform.FindSonSonSon("PanelTownShopCostRoot"), false);
        });
        MgrUI.GetInstance().CreatePanel<PanelTownShopItem>
        (true, "/PanelTownShopItem",
        (panel) =>
        {
            panel.transform.SetParent(transform.FindSonSonSon("PanelTownShopItemRoot"), false);            
        });
        MgrUI.GetInstance().CreatePanel<PanelMinistrantPoPoCat>
        (true, "/PanelMinistrantPoPoCat",
        (panel) =>
        {
            panel.transform.SetParent(transform.FindSonSonSon("PanelMinistrantPoPoCatRoot"), false);
        });
    }
}
