using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBaseRoleStore : PanelBaseVector2Store
{
    public int IndexListRole;

    protected override void Awake()
    {
        base.Awake();

        Hot.MgrUI_.AddCustomEventListener
        (transform.FindSonSonSon("ImgBkRoleStore").gameObject, UnityEngine.EventSystems.EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.e_NowPointerLocation = E_NowPointerLocation.PanelRoleStore;
        });
        Hot.MgrUI_.AddCustomEventListener
        (transform.FindSonSonSon("ImgBkRoleStore").gameObject, UnityEngine.EventSystems.EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.e_NowPointerLocation = E_NowPointerLocation.None;
        });
    }
}
