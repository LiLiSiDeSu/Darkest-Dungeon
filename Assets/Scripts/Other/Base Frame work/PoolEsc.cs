using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolEsc : InstanceBaseAuto_Mono<PoolEsc>
{
    public List<string> ListEsc = new List<string>();

    protected override void Start()
    {
        base.Start();        

        CenterEvent.GetInstance().AddEventListener<KeyCode>("CertainKeyDown", (key) =>
        {
            if (key == MgrInput.GetInstance().Esc)
            {                
                HideTop();
            }
        });
    }

    public void HideAll()
    {
        for (int i = 0; i < ListEsc.Count; i++)
            HideTop();
    }

    public void HideTop()
    {
        if (ListEsc.Count > 0)
        {
            PoolBuffer.GetInstance().Push
            (false, MgrUI.GetInstance().GetPanel(ListEsc[ListEsc.Count - 1]).gameObject, ListEsc[ListEsc.Count - 1]);

            PoolNowPanel.GetInstance().ListNowPanel.Remove(ListEsc[ListEsc.Count - 1]);

            ListEsc.RemoveAt(ListEsc.Count - 1);           
        }            
    }
}
