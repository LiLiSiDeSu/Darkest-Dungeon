using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoolEsc : InstanceBaseAuto_Mono<PoolEsc>
{
    public List<string> ListEsc = new();        

    private void Start()
    {
        Hot.CenterEvent_.AddEventListener<KeyCode>("CertainKeyDown", (key) =>
        {
            if (key == Hot.MgrInput_.Esc)            
                HideTop();
        });
    }

    public void RemoveListNoInMgrUI(GameObject obj)
    {
       ListEsc.Remove(obj.name);       
    }

    public void HideAll()
    {
        int tempCount = ListEsc.Count;
        for (int i = 0; i < tempCount; i++)
            HideTop();
    }

    public void HideTop()
    {
        if (ListEsc.Count > 0)
        {
            Hot.CenterEvent_.EventTrigger("Esc" + ListEsc[ListEsc.Count - 1]);

            PoolBuffer.GetInstance().Push
                (false, MgrUI.GetInstance().GetPanel(ListEsc[ListEsc.Count - 1]).gameObject, ListEsc[ListEsc.Count - 1]);

            PoolNowPanel.GetInstance().ListNowPanel.Remove(ListEsc[ListEsc.Count - 1]);

            ListEsc.RemoveAt(ListEsc.Count - 1);
        }               
    }
}
