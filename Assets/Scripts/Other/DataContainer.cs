using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public sealed class DataContainer { }

public class DataContainer_CellGameArchive
{
    public string GameArchiveName = "---";
    public E_GameArchiveLevel e_GameArchiveLevel = E_GameArchiveLevel.None;
    public string Location = "---";
    public string Week = "0";
    public string Time = "0000/00/00 00:00:00";
    public List<DataContainer_CellStore> DataListCellStore = new List<DataContainer_CellStore>();

    public DataContainer_CellGameArchive() { }
    public DataContainer_CellGameArchive
    (string GameArchiveName, E_GameArchiveLevel e_GameArchiveLevel, string Location, string Week, string Time, 
     List<DataContainer_CellStore> DataListCellStore)
    {
        this.GameArchiveName = GameArchiveName;
        this.e_GameArchiveLevel = e_GameArchiveLevel;
        this.Location = Location;
        this.Week = Week;
        this.Time = Time;
        this.DataListCellStore = DataListCellStore;
    }
}

public class DataContainer_CellStore
{
    public E_PanelCellStorePrefabName e_PanelCellStorePrefabName = E_PanelCellStorePrefabName.PanelCellStoreWood;
    public int MaxWeight = 0;
    public int NowWeight = 0;
    public int MaxCapacity = 0;
    public int NowCapacity = 0;

    public DataContainer_CellStore() { }
    public DataContainer_CellStore
    (E_PanelCellStorePrefabName e_PanelCellStorePrefabName)
    {
        this.e_PanelCellStorePrefabName = e_PanelCellStorePrefabName;        
    }
}

public class DataContainer_
{

}