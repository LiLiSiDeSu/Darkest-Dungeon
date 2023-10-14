using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelTownStore : PanelBase
{
    public int NowIndex = 0;    

    private Transform ContentStore;
    public Transform RootPanelTownStoreItem;

    public PanelCellTownStore NowPanelCellTownStore = new PanelCellTownStore();    

    protected override void Start()
    {
        base.Start();        

        ContentStore = transform.FindSonSonSon("ContentStore");
        RootPanelTownStoreItem = transform.FindSonSonSon("RootPanelTownStoreItem");

        gameObject.SetActive(false);
    }

    public void InitContent()
    {
        for 
        (int i = 0; 
         i < MgrUI.GetInstance().GetPanel<PanelGameArchiveChoose>
         ("PanelGameArchiveChoose").NowPanelGameArchive.DataCellGameArchive.DataListCellStore.Count; 
         i++)
        {
            int tempi = i;

            MgrUI.GetInstance().CreatePanelAndPush<PanelCellTownStore>
                             (false, "/" + MgrUI.GetInstance().GetPanel<PanelGameArchiveChoose>
                             ("PanelGameArchiveChoose").NowPanelGameArchive.DataCellGameArchive.DataListCellStore[tempi].
                             e_PanelCellStorePrefabName.ToString(), 
                             false, false, 
                             MgrUI.GetInstance().GetPanel<PanelGameArchiveChoose>
                             ("PanelGameArchiveChoose").NowPanelGameArchive.DataCellGameArchive.DataListCellStore[tempi].
                             e_PanelCellStorePrefabName.ToString(),
            (PanelCellTownStore_) =>
            {
                PanelCellTownStore_.transform.SetParent(ContentStore);
                PanelCellTownStore_.DataCellStore = 
                                    MgrUI.GetInstance().
                                    GetPanel<PanelGameArchiveChoose>
                                    ("PanelGameArchiveChoose").NowPanelGameArchive.DataCellGameArchive.DataListCellStore[tempi];

                MgrUI.GetInstance().CreatePanelAndPush<PanelTownStoreItem>
                                 (false, "/PanelTownStoreItem", false, false, "PanelTownStoreItem",
                (PanelTownStoreItem_) =>
                {                    
                    PanelTownStoreItem_.transform.SetParent(RootPanelTownStoreItem);
                    PanelCellTownStore_.PanelItem = PanelTownStoreItem_;
                });

                PanelCellTownStore_.IndexCellCellStore = tempi;
                NowIndex++;
            });
        }
    }

    public void SortCellStore()
    {

    }
}
