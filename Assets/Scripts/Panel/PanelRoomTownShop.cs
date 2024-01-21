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
        (true, E_PanelName.PanelTownShopCost,
        (panel) =>
        {
            panel.transform.SetParent(transform.FindSonSonSon("PanelTownShopCostRoot"), false);
        });
        MgrUI.GetInstance().CreatePanel<PanelTownShopItem>
        (true, E_PanelName.PanelTownShopItem,
        (panel) =>
        {
            panel.transform.SetParent(transform.FindSonSonSon("PanelTownShopItemRoot"), false);
        });
        MgrUI.GetInstance().CreatePanel<PanelMinistrantPoPoCat>
        (true, E_PanelName.PanelMinistrantPoPoCat,
        (panel) =>
        {
            panel.transform.SetParent(transform.FindSonSonSon("PanelMinistrantPoPoCatRoot"), false);
        });
    }
}
