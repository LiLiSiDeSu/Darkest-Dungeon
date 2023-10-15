using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelTownStore : PanelBase
{
    public int NowIndex = 0;    
    private Transform ContentStore;
    public Transform RootPanelTownItem;

    public PanelCellTownStore NowPanelCellTownStore = new PanelCellTownStore();    

    protected override void Start()
    {
        base.Start();        

        ContentStore = transform.FindSonSonSon("ContentStore");
        RootPanelTownItem = transform.FindSonSonSon("RootPanelTownItem");        
    }

    public void InitContent()
    {
        for 
        (int i = 0; 
         i < MgrUI.GetInstance().GetPanel<PanelGameArchiveChoose>
         ("PanelGameArchiveChoose").NowGameArchive.DataPanelCellGameArchive.DataListCellStore.Count; 
         i++)
        {
            int tempi = i;

            MgrUI.GetInstance().CreatePanelAndPush<PanelCellTownStore>
                             (false, "/PanelCellTownStore", false, false, "PanelCellTownStore",
            (PanelCellTownStore_) =>
            {
                PanelCellTownStore_.transform.SetParent(ContentStore);
                PanelCellTownStore_.DataPanelCellTownStore = 
                                    MgrUI.GetInstance().
                                    GetPanel<PanelGameArchiveChoose>
                                    ("PanelGameArchiveChoose").NowGameArchive.DataPanelCellGameArchive.DataListCellStore[tempi];

                MgrUI.GetInstance().CreatePanelAndPush<PanelTownItem>
                                 (false, "/PanelTownItem", false, false, "PanelTownItem",
                (PanelTownItem_) =>
                {                    
                    PanelTownItem_.transform.SetParent(RootPanelTownItem);
                    PanelCellTownStore_.NowPanelTownStoreItem = PanelTownItem_;
                    PanelTownItem_.FatherPanelCellTownStore = PanelCellTownStore_;
                });

                PanelCellTownStore_.IndexCellTownStore = tempi;
                NowIndex++;
            });
        }
    }

    public void SortCellStore()
    {

    }
}
