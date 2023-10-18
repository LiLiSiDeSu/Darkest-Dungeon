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
            return Data.GetInstance().DataListCellGameArchive[IndexNowCellGameArchive];
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

    public static PanelRoomShop PanelRoomShop_
    {
        get
        {
            return MgrUI.GetInstance().GetPanel<PanelRooms>("PanelRooms").AllPanel["PanelRoomShop"] as PanelRoomShop;
        }
    }
}
