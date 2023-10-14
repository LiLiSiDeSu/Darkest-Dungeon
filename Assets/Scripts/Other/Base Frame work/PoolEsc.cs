using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolEsc : InstanceBaseAuto_Mono<PoolEsc>
{
    public List<string> ListEsc = new List<string>();
    public List<GameObject> ListNoInMgrUI = new List<GameObject>();

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

    public void AddListNoInMgrUI(GameObject obj)
    {
        ListEsc.Add(obj.name);
        ListNoInMgrUI.Add(obj);
    }

    public void RemoveListNoInMgrUI(GameObject obj)
    {
       ListEsc.Remove(obj.name);
       ListNoInMgrUI.Remove(obj);
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
            if (MgrUI.GetInstance().DicPanel.ContainsKey((ListEsc[ListEsc.Count - 1])))
            {
                PoolBuffer.GetInstance().Push
                (false, MgrUI.GetInstance().GetPanel(ListEsc[ListEsc.Count - 1]).gameObject, ListEsc[ListEsc.Count - 1]);

                PoolNowPanel.GetInstance().ListNowPanel.Remove(ListEsc[ListEsc.Count - 1]);

                ListEsc.RemoveAt(ListEsc.Count - 1);
            }
            else
            {
                ListNoInMgrUI[ListNoInMgrUI.Count - 1].SetActive(false);
                ListEsc.RemoveAt(ListEsc.Count - 1);
                ListNoInMgrUI.RemoveAt(ListNoInMgrUI.Count - 1);
            }
        }            
    }
}
