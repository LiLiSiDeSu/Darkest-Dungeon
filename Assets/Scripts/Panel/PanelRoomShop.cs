using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelRoomShop : PanelBase
{    
    private Toggle TogTrigger;
    private Animator AnimatorMinistrantForShop;
    private GameObject Open;
    private GameObject Close;

    public PanelShopCost PanelShopCost_ = new PanelShopCost();
    public PanelShopItem PanelShopItem_ = new PanelShopItem();

    protected override void Awake()
    {
        base.Awake();
        
        AnimatorMinistrantForShop = transform.FindSonSonSon("AnimatorMinistrantForShop").GetComponent<Animator>();
        TogTrigger = transform.FindSonSonSon("TogTrigger").GetComponent<Toggle>();
        Open = transform.FindSonSonSon("Open").gameObject;
        Close = transform.FindSonSonSon("Close").gameObject;        

        Open.SetActive(false);
        Close.SetActive(false);

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

        MgrUI.GetInstance().AddCustomEventListener(transform.FindSonSonSon("TogTrigger").gameObject,
                         UnityEngine.EventSystems.EventTriggerType.PointerEnter, 
                         (param) =>
                         {
                             AnimatorMinistrantForShop.gameObject.SetActive(false);
                             if (TogTrigger.isOn)
                             {
                                 Open.SetActive(true);
                                 Close.SetActive(false);
                             }
                             else
                             {
                                 Open.SetActive(false);
                                 Close.SetActive(true);
                             }
                         });
        MgrUI.GetInstance().AddCustomEventListener(transform.FindSonSonSon("TogTrigger").gameObject,
                         UnityEngine.EventSystems.EventTriggerType.PointerExit,
                         (param) =>
                         {
                             AnimatorMinistrantForShop.gameObject.SetActive(true);
                             Open.SetActive(false);
                             Close.SetActive(false);
                         });        
    }

    protected override void Toggle_OnValueChange(string controlname, bool EventParam)
    {
        base.Toggle_OnValueChange(controlname, EventParam);

        switch (controlname)
        {
            case "TogTrigger":
                if (EventParam)
                {
                    Open.SetActive(true);
                    Close.SetActive(false);
                }
                else
                {
                    Open.SetActive(false);
                    Close.SetActive(true);
                }
                break;
        }
    }
}
