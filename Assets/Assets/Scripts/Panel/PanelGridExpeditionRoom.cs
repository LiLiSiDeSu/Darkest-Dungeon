using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGridExpeditionRoom : PanelBaseGrid
{
    public PanelCellExpeditionRoom CellExpeditionRoom;

    protected override void Awake()
    {
        base.Awake();

        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, UnityEngine.EventSystems.EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.NowEnterGridExpeditionRoom = this;

            ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "BorderChoosedGreen");
        });
        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, UnityEngine.EventSystems.EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.NowEnterGridExpeditionRoom = null;

            ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
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
