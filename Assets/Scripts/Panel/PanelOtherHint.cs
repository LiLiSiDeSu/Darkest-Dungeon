using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PanelOtherHint : PanelBase
{
    public UnityAction<GameObject> DelConfirm;
    public UnityAction<GameObject> DelCancel;

    protected override void Start()
    {
        base.Start();

        transform.FindSonSonSon("ImgConfirm").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgCancel").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnConfirm":
                DelConfirm(gameObject);
                DelConfirm = null;
                DelCancel = null;
                break;

            case "BtnCancel":
                DelCancel(gameObject);
                DelConfirm = null;
                DelCancel = null;
                break;
        }
    }
}
