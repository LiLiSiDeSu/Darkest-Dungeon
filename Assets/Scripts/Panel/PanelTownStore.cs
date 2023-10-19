using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelTownStore : PanelBase
{
    public int NowIndex = 0;        
    public Transform RootPanelTownItem;
    public Transform Content;

    public PanelCellTownStore NowPanelCellTownStore = new PanelCellTownStore();    

    protected override void Awake()
    {
        base.Awake();        

        Content = transform.FindSonSonSon("Content");
        RootPanelTownItem = transform.FindSonSonSon("RootPanelTownItem");        
    }

    public void UpdateContent()
    {
        NowIndex = 0;

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
            DestroyImmediate(all[i].PanelCellItem_.gameObject);
            DestroyImmediate(all[i].gameObject);
        }
    }

    public void SortIndex()
    {

    }

    public void Add()
    {

    }

    public void Subtraction()
    {

    }
}
