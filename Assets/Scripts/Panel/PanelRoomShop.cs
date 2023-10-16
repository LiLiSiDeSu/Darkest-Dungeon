using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelRoomShop : PanelBase
{
    private Animator PoPoCat;
    private Toggle TogTrigger;
    private Animator AnimatorMinistrantForShop;
    private GameObject Open;
    private GameObject Close;    

    protected override void Start()
    {
        base.Start();        

        AnimatorMinistrantForShop = transform.FindSonSonSon("AnimatorMinistrantForShop").GetComponent<Animator>();
        TogTrigger = transform.FindSonSonSon("TogTrigger").GetComponent<Toggle>();
        Open = transform.FindSonSonSon("Open").gameObject;
        Close = transform.FindSonSonSon("Close").gameObject;
        PoPoCat = transform.FindSonSonSon("TogTrigger").GetComponent<Animator>();

        Open.SetActive(false);
        Close.SetActive(false);

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
