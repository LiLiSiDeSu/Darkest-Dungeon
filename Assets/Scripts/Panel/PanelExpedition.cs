using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelExpedition : PanelBase
{
    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener("Esc" + "PanelExpedition",
        () =>
        {
            Hot.e_NowPlayerLocation = E_PlayerLocation.Town;
        });
    }
}
