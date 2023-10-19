using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelRoomShop : PanelBase
{        
    public PanelShopCost PanelShopCost_ = new PanelShopCost();
    public PanelShopItem PanelShopItem_ = new PanelShopItem();
    public PanelMinistrantPoPoCat PanelMinistrantPoPoCat_ = new PanelMinistrantPoPoCat();

    protected override void Awake()
    {
        base.Awake();               

        MgrUI.GetInstance().CreatePanel<PanelShopCost>
        ("/PanelShopCost",
        (panel) =>
        {
            PanelShopCost_ = panel;
            panel.transform.SetParent(transform, false);
        });
        MgrUI.GetInstance().CreatePanel<PanelShopItem>
        ("/PanelShopItem",
        (panel) =>
        {
            PanelShopItem_ = panel;
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
