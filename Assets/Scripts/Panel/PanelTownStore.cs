using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanelTownStore : PanelBase
{
    public int PanelCellStoreNowIndex = 0;    

    private Transform Content;

    protected override void Start()
    {
        base.Start();

        Content = transform.FindSonSonSon("Content");        

        gameObject.SetActive(false);
    }

    public void InitContent()
    {
        for 
        (int i = 0; 
         i < MgrUI.GetInstance().GetPanel<PanelGameArchiveChoose>
         ("PanelGameArchiveChoose").NowGameArchive.DataCellGameArchive.DataListCellStore.Count; 
         i++)
        {
            int tempi = i;
            MgrUI.GetInstance().CreatePanelAndPush<PanelCellStore>
                             (false, "/PanelCellStore", false, false, "PanelCellStore",
            (panel) =>
            {
                panel.transform.parent = Content;
                panel.DataCellStore = 
                                    MgrUI.GetInstance().
                                    GetPanel<PanelGameArchiveChoose>
                                    ("PanelGameArchiveChoose").NowGameArchive.DataCellGameArchive.DataListCellStore[tempi];
                panel.IndexCellCellStore = tempi;
                PanelCellStoreNowIndex++;
            });
        }
    }

    public void SortCellStore()
    {

    }
}
