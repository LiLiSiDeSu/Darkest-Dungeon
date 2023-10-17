using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class GlobalHot
{
    public static DataContainer_PanelCellGameArchive NowCellGameArchive
    {
        get
        {
            return Data.GetInstance().DataListCellGameArchive
                   [MgrUI.GetInstance().GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose").IndexNowCellGameArchive];
        }        
    }    

    public static int IndexNowCellGameArchive
    {
        get
        {
            return MgrUI.GetInstance().GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose").IndexNowCellGameArchive;
        }

        set
        {
            MgrUI.GetInstance().GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose").IndexNowCellGameArchive = value;
        }
    }
}
