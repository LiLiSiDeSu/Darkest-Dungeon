using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelTownStore : PanelBase
{
    public int NowIndex = 0;    
    private Transform Content;
    public Transform RootPanelTownItem;

    public PanelCellTownStore NowPanelCellTownStore = new PanelCellTownStore();    

    protected override void Awake()
    {
        base.Awake();        

        Content = transform.FindSonSonSon("Content");
        RootPanelTownItem = transform.FindSonSonSon("RootPanelTownItem");        
    }

    public void UpdateContent()
    {
        for (int i = 0;  i < GlobalHot.NowCellGameArchive.DataListCellStore.Count; i++)
        {
            int tempi = i;

            MgrUI.GetInstance().CreatePanelAndPush<PanelCellTownStore>
                             (false, "/PanelCellTownStore", false, false, "PanelCellTownStore",
            (PanelCellTownStore_) =>
            {
                PanelCellTownStore_.transform.SetParent(Content, false);

                MgrUI.GetInstance().CreatePanelAndPush<PanelTownItem>
                                 (false, "/PanelTownItem", false, false, "PanelTownItem",
                (PanelTownItem_) =>
                {                    
                    PanelTownItem_.transform.SetParent(RootPanelTownItem, false);
                    PanelCellTownStore_.NowPanelTownStoreItem = PanelTownItem_;
                    PanelTownItem_.FatherPanelCellTownStore = PanelCellTownStore_;
                    PanelTownItem_.UpdateContent();
                });

                PanelCellTownStore_.Index = tempi;
                NowIndex++;
            });
        }
    }

    /// <summary>
    /// 删除Content下的物体 用于重新读档
    /// </summary>
    public void DestroyContent()
    {
        PanelCellTownStore[] all = Content.GetComponentsInChildren<PanelCellTownStore>();
        for (int i = 0; i < all.Length; i++)
        {
            DestroyImmediate(all[i].NowPanelTownStoreItem.gameObject);
            DestroyImmediate(all[i].gameObject);
        }
    }

    public void SortIndex()
    {

    }
}
