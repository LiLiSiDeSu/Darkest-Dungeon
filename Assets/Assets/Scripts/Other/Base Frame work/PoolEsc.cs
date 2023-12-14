using System.Collections.Generic;
using UnityEngine;

public class PoolEsc : InstanceBaseAuto_Mono<PoolEsc>
{
    public List<string> ListEsc = new();        

    private void Start()
    {
        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(), (key) =>
        {
            if (key == KeyCode.Escape)
            {
                HideTop();
            }
        });
    }

    /// <summary>
    /// 隐藏所有加入PoolEsc的面板并执行面板对应的Esc事件
    /// </summary>
    public void HideAllAndInvokeEvent()
    {
        int tempCount = ListEsc.Count;
        for (int i = 0; i < tempCount; i++)
            HideTop();
    }

    /// <summary>
    /// 只是隐藏所有加入PoolEsc的面板但不执行面板对应的Esc事件
    /// </summary>
    public void HideAllOnly()
    {
        int tempCount = ListEsc.Count;

        for (int i = 0; i < tempCount; i++)
        {
            if (ListEsc.Count > 0)
            {
                //这里的判断是为了防止加入了PoolEsc但没有加入MgrUI的DicPanel中的面板
                //在执行下面Hot.MgrUI_.GetPanel(ListEsc[^1]).gameObject的逻辑时的空引用报错
                if (Hot.MgrUI_.ContainPanel(ListEsc[^1]))
                    PoolBuffer.GetInstance().
                        Push(false, Hot.MgrUI_.GetPanel(ListEsc[^1]).gameObject, ListEsc[^1]);

                PoolNowPanel.GetInstance().ListNowPanel.Remove(ListEsc[^1]);

                ListEsc.Remove(ListEsc[^1]);
            }
        }
    }

    /// <summary>
    /// 隐藏在PoolEsc顶端的面板
    /// </summary>
    public void HideTop()
    {
        if (ListEsc.Count > 0)
        {
            Hot.CenterEvent_.EventTrigger("Esc" + ListEsc[^1]);

            //这里的判断是为了防止加入了PoolEsc但没有加入MgrUI的DicPanel中的面板
            //在执行下面Hot.MgrUI_.GetPanel(ListEsc[^1]).gameObject的逻辑时的空引用报错
            if (Hot.MgrUI_.ContainPanel(ListEsc[^1]))
            {
                PoolBuffer.GetInstance().Push(false, Hot.MgrUI_.GetPanel(ListEsc[^1]).gameObject, ListEsc[^1]);
            }

            PoolNowPanel.GetInstance().ListNowPanel.Remove(ListEsc[^1]);

            ListEsc.Remove(ListEsc[^1]);
        }               
    }
}
