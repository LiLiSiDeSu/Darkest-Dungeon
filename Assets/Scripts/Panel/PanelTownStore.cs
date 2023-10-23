using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelTownStore : PanelBase, 
             IPointerEnterHandler, IPointerExitHandler
{
    public int NowIndex = 0;        
    public Transform RootPanelTownItem;
    public Transform Content;      

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>("CertainKeyDown", (key) =>
        {
            if (key == Hot.MgrInput_.PanelTownStore)
            {

                if (Hot.PoolNowPanel_.ListNowPanel.Contains("PanelTownStore"))
                {
                    Hot.MgrUI_.HidePanel
                        (false, Hot.PanelTownStore_.gameObject, "PanelTownStore");
                }
                Hot.MgrUI_.ShowPanel<PanelTownStore>(true, "PanelTownStore");
            }
        });

        Content = transform.FindSonSonSon("Content");
        RootPanelTownItem = transform.FindSonSonSon("RootPanelTownItem");        
    }

    #region EventSystem接口实现

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    #endregion

    public void UpdateContent()
    {
        NowIndex = 0;

        for (int i = 0;  i < Hot.DataNowCellGameArchive.ListCellStore.Count; i++)
        {
            int tempi = i;

            MgrUI.GetInstance().CreatePanelAndPush<PanelCellTownStore>
                             (true, "/PanelCellTownStore", false, false, "PanelCellTownStore" + tempi,
            (PanelCellTownStore_) =>
            {
                PanelCellTownStore_.gameObject.name += tempi;
                PanelCellTownStore_.transform.SetParent(Content, false);

                MgrUI.GetInstance().CreatePanelAndPush<PanelTownItem>
                                 (true, "/PanelTownItem", true, true, "PanelTownItem" + tempi,
                (PanelTownItem_) =>
                {
                    PanelTownItem_.gameObject.name += tempi;
                    PanelTownItem_.transform.SetParent(RootPanelTownItem, false);
                    PanelCellTownStore_.PanelCellItem_ = PanelTownItem_;
                    PanelTownItem_.FatherPanelCellTownStore = PanelCellTownStore_;                    
                    PanelTownItem_.UpdateContent();
                });

                PanelCellTownStore_.Index = NowIndex;
                NowIndex++;
            });
        }
    }

    /// <summary>
    /// 删除Content下的物体 用于重新读档
    /// </summary>
    public void ClearContent()
    {        
        PanelCellTownStore[] all = Content.GetComponentsInChildren<PanelCellTownStore>();
        for (int i = 0; i < all.Length; i++)
        {            
            Hot.MgrUI_.DicPanel.Remove(all[i].PanelCellItem_.gameObject.name);
            if (Hot.PoolBuffer_.ContainKey(all[i].PanelCellItem_.gameObject.name))
                Hot.PoolBuffer_.DicPool.Remove(all[i].PanelCellItem_.gameObject.name);
            Hot.MgrUI_.DicPanel.Remove(all[i].gameObject.name);
            DestroyImmediate(all[i].PanelCellItem_.gameObject);
            DestroyImmediate(all[i].gameObject);
        }
    }

    public void SortContent()
    {
        PanelCellTownStore[] all = transform.GetComponentsInChildren<PanelCellTownStore>();
        for (int i = 0; i < all.Length; i++)
        {
            all[i].gameObject.name += i;
            all[i].Index = i;
        }
    }
}
