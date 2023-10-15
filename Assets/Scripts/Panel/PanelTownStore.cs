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

    protected override void Start()
    {
        base.Start();        

        Content = transform.FindSonSonSon("Content");
        RootPanelTownItem = transform.FindSonSonSon("RootPanelTownItem");        
    }

    public void InitContent()
    {
        for (int i = 0;  i < GlobalHot.NowCellGameArchive.DataListCellStore.Count; i++)
        {
            int tempi = i;

            MgrUI.GetInstance().CreatePanelAndPush<PanelCellTownStore>
                             (false, "/PanelCellTownStore", false, false, "PanelCellTownStore",
            (PanelCellTownStore_) =>
            {
                PanelCellTownStore_.transform.SetParent(Content);

                MgrUI.GetInstance().CreatePanelAndPush<PanelTownItem>
                                 (false, "/PanelTownItem", false, false, "PanelTownItem",
                (PanelTownItem_) =>
                {                    
                    PanelTownItem_.transform.SetParent(RootPanelTownItem);
                    PanelCellTownStore_.NowPanelTownStoreItem = PanelTownItem_;
                    PanelTownItem_.FatherPanelCellTownStore = PanelCellTownStore_;
                });

                PanelCellTownStore_.Index = tempi;
                NowIndex++;
            });
        }
    }

    public void SortIndex()
    {

    }
}
