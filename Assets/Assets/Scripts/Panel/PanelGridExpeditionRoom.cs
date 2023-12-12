using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGridExpeditionRoom : PanelBaseGrid<PanelCellExpeditionRoom>
{
    protected override void Awake()
    {
        base.Awake();

        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, UnityEngine.EventSystems.EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.NowEnterGridExpeditionRoom = this;

            ImgStatus.sprite = Hot.LoadSprite(E_Res.BorderChoosedGreen);
        });
        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, UnityEngine.EventSystems.EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.NowEnterGridExpeditionRoom = null;

            ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
        });
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "ImgBk":
                Debug.Log(Y + " - " + X);
                break;
        }
    }
}
