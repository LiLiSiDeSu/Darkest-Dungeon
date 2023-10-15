using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public sealed class AllDataContainer { }

public class DataContainer_PanelCellGameArchive
{    
    public E_GameArchiveLevel e_GameArchiveLevel = E_GameArchiveLevel.None;
    public List<DataContainer_PanelCellTownStore> DataListCellStore = new List<DataContainer_PanelCellTownStore>();
    public string GameArchiveName = "---";
    public string Location = "---";
    public string Week = "0";
    public string Time = "0000/00/00 00:00:00";    

    public DataContainer_PanelCellGameArchive() { }
    public DataContainer_PanelCellGameArchive
    (string GameArchiveName, E_GameArchiveLevel e_GameArchiveLevel, string Location, string Week, string Time, 
     List<DataContainer_PanelCellTownStore> DataListCellStore)
    {
        this.GameArchiveName = GameArchiveName;
        this.e_GameArchiveLevel = e_GameArchiveLevel;
        this.Location = Location;
        this.Week = Week;
        this.Time = Time;
        this.DataListCellStore = DataListCellStore;
    }
}

public class DataContainer_PanelCellTownStore
{
    public E_SpriteNamePanelCellTownStore e_SpriteNamePanelCellTownStore = E_SpriteNamePanelCellTownStore.StoreWood;
    public List<DataContainer_PanelCellItem> DataListCellItem = new List<DataContainer_PanelCellItem>();    
    public int NowWeight = 0;    
    public int NowCapacity = 0;    

    public DataContainer_PanelCellTownStore() { }
    public DataContainer_PanelCellTownStore
    (E_SpriteNamePanelCellTownStore e_SpriteNamePanelCellTownStore)
    {
        this.e_SpriteNamePanelCellTownStore = e_SpriteNamePanelCellTownStore;        
    }
}

public class DataContainer_PanelCellItem
{
    public E_SpriteNamePanelCellItem e_SpriteNamePanelCellItem = E_SpriteNamePanelCellItem.ItemFoodCookie;   

    public DataContainer_PanelCellItem() { }
    public DataContainer_PanelCellItem
    (E_SpriteNamePanelCellItem e_SpriteNamePanelCellItem)
    {
        this.e_SpriteNamePanelCellItem = e_SpriteNamePanelCellItem;
    }
}