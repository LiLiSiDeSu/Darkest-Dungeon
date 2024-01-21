using UnityEngine;
using UnityEngine.UI;

public class PanelBarTown : PanelBase
{
    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(), (key) =>
        {
            if (key == Hot.MgrInput_.PanelBar)
            {
                switch (Hot.e_NowPlayerLocation)
                {
                    case E_PlayerLocation.Town:
                        if (Hot.PoolNowPanel_.ContainPanel(E_PanelName.PanelBarTown))
                        {
                            Hot.MgrUI_.HidePanel(false, Hot.PanelBarTown_.gameObject, E_PanelName.PanelBarTown);
                        }
                        else
                        {
                            Hot.MgrUI_.ShowPanel<PanelBarTown>(true, E_PanelName.PanelBarTown);
                        }
                        break;
                    case E_PlayerLocation.PrepareExpedition:
                        if (Hot.PoolNowPanel_.ContainPanel(E_PanelName.PanelBarExpedition))
                        {
                            Hot.MgrUI_.HidePanel(false, Hot.PanelBarExpedition_.gameObject, E_PanelName.PanelBarExpedition);
                        }
                        else
                        {
                            Hot.MgrUI_.ShowPanel<PanelBarExpedition>(true, E_PanelName.PanelBarExpedition);
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
                Hot.e_NowPlayerLocation = E_PlayerLocation.PrepareExpedition;
                Hot.MgrUI_.ShowPanel<PanelExpeditionPrepare>(true, E_PanelName.PanelExpeditionPrepare);
                break;
        }
    }
}
