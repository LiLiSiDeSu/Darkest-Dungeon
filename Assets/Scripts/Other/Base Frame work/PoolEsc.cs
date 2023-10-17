using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoolEsc : InstanceBaseAuto_Mono<PoolEsc>
{
    public List<string> ListEsc = new List<string>();    
    public List<GameObject> ListNoInMgrUI = new List<GameObject>();
    public List<UnityAction> ListEscEvent = new List<UnityAction>();

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

    public void AddListNoInMgrUI(GameObject obj, UnityAction callback = null)
    {
        ListEsc.Add(obj.name);
        ListNoInMgrUI.Add(obj);
        ListEscEvent.Add(callback);
    }

    public void RemoveListNoInMgrUI(GameObject obj)
    {
       ListEsc.Remove(obj.name);
       ListNoInMgrUI.Remove(obj);
       ListEscEvent.RemoveAt(ListEscEvent.Count - 1);
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

            ListEscEvent[ListEscEvent.Count - 1]?.Invoke();
        }               
    }
}
