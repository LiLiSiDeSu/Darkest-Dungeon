using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelRoomTownShop : PanelBase
{        
    public PanelTownShopCost PanelShopCost_ = new PanelTownShopCost();
    public PanelTownShopItem PanelTownShopItem_ = new PanelTownShopItem();
    public PanelMinistrantPoPoCat PanelMinistrantPoPoCat_ = new PanelMinistrantPoPoCat();

    protected override void Awake()
    {
        base.Awake();               

        MgrUI.GetInstance().CreatePanel<PanelTownShopCost>
        ("/PanelTownShopCost",
        (panel) =>
        {
            PanelShopCost_ = panel;
            panel.transform.SetParent(transform, false);
        });
        MgrUI.GetInstance().CreatePanel<PanelTownShopItem>
        ("/PanelTownShopItem",
        (panel) =>
        {
            PanelTownShopItem_ = panel;
            panel.transform.SetParent(transform, false);
        });
        MgrUI.GetInstance().CreatePanel<PanelMinistrantPoPoCat>
        ("/PanelMinistrantPoPoCat",
        (panel) =>
        {
            PanelMinistrantPoPoCat_ = panel;
            panel.transform.SetParent(transform, false);
        });
    }
}
