using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBarTown : PanelBase
{
    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyDown", (key) =>
        {
            if (key == Hot.MgrInput_.PanelBar)
            {
                switch (Hot.e_NowPlayerLocation)
                {
                    case E_PlayerLocation.Town:
                        if (Hot.PoolNowPanel_.ListNowPanel.Contains("PanelBarTown"))
                        {
                            Hot.MgrUI_.HidePanel(false, Hot.PanelBarTown_.gameObject, "PanelBarTown");
                        }
                        else
                        {
                            Hot.MgrUI_.ShowPanel<PanelBarTown>(true, "PanelBarTown");
                        }
                        break;
                    case E_PlayerLocation.PrepareExpedition:
                        if (Hot.PoolNowPanel_.ListNowPanel.Contains("PanelBarExpedition"))
                        {
                            Hot.MgrUI_.HidePanel(false, Hot.PanelBarExpedition_.gameObject, "PanelBarExpedition");
                        }
                        else
                        {
                            Hot.MgrUI_.ShowPanel<PanelBarExpedition>(true, "PanelBarExpedition");
                        }
                        break;
                }                
            }
        });

        transform.FindSonSonSon("ImgExpedition").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnExpedition":                
                Hot.MgrUI_.ShowPanel<PanelExpeditionPrepare>(true, "PanelExpeditionPrepare");
                Hot.e_NowPlayerLocation = E_PlayerLocation.PrepareExpedition;
                break;
        }
    }
}
