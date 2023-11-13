using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolNowPanel : InstanceBaseAuto_Mono<PoolNowPanel>
{
    public List<string> ListNowPanel = new List<string>();

    public bool ContainPanel(string panelName)
    {
        return ListNowPanel.Contains(panelName);
    }
}
