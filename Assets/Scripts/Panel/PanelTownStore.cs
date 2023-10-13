using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanelTownStore : PanelBase
{
    public int NowIndex = 0;    

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
            MgrUI.GetInstance().CreatePanelAndPush<PanelCellTownStore>
                             (false, "/PanelCellTownStore", false, false, "PanelCellTownStore",
            (panel) =>
            {
                panel.transform.parent = Content;
                panel.DataCellStore = 
                                    MgrUI.GetInstance().
                                    GetPanel<PanelGameArchiveChoose>
                                    ("PanelGameArchiveChoose").NowGameArchive.DataCellGameArchive.DataListCellStore[tempi];
                panel.IndexCellCellStore = tempi;
                NowIndex++;
            });
        }
    }

    public void SortCellStore()
    {

    }
}
