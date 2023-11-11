using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PanelExpeditionMiniMap : PanelBase
{
    public Transform ExpeditionMap;

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyDown", (key) =>
        {
            if (Hot.e_NowPlayerLocation == E_PlayerLocation.OnExpedition && key == Hot.MgrInput_.ExpeditionMiniMap)
            {
                if (Hot.PoolNowPanel_.ListNowPanel.Contains("PanelExpeditionMiniMap"))
                    Hot.MgrUI_.HidePanel(false, Hot.PanelExpeditionMiniMap_.gameObject, "PanelExpeditionMiniMap");
                else
                    Hot.MgrUI_.ShowPanel<PanelExpeditionMiniMap>(true, "PanelExpeditionMiniMap");
            }
        });

        ExpeditionMap = transform.FindSonSonSon("ExpeditionMiniMap");
    }
}
