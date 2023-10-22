using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelOtherStart : PanelBase
{
    protected override void Start()
    {
        base.Start();

        transform.FindSonSonSon("ImgStart").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnStart":
                MgrUI.GetInstance().HidePanel(false, gameObject, "PanelOtherStart");
                MgrUI.GetInstance().ShowPanel<PanelGameArchiveChoose>
                (false, "PanelGameArchiveChoose", (panel) =>
                {
                    
                });
                break;
        }
    }    
}
