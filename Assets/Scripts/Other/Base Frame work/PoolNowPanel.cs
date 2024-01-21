using System.Collections.Generic;

public class PoolNowPanel : InstanceBaseAuto_Mono<PoolNowPanel>
{
    public List<string> ListNowPanel = new();

    public bool ContainPanel(string panelName)
    {
        return ListNowPanel.Contains(panelName);
    }
    public bool ContainPanel(E_PanelName p_e_PanelName)
    {
        return ListNowPanel.Contains(p_e_PanelName.ToString());
    }
}
