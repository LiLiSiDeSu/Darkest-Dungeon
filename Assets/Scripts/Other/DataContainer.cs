using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public sealed class DataContainer { }

public class DataContainer_CellGameArchive
{
    public string GameArchiveName = "---";
    public E_GameArchiveLevel e_GameArchiveLevel = E_GameArchiveLevel.None;
    public string Location = "---";
    public string Week = "0";
    public string Time = "0000/00/00 00:00:00";

    public DataContainer_CellGameArchive() { }

    public DataContainer_CellGameArchive(
                                          string GameArchiveName,
                                          E_GameArchiveLevel e_GameArchiveLevel, 
                                          string Location, 
                                          string Week, 
                                          string Time
                                         )
    {
        this.GameArchiveName = GameArchiveName;
        this.e_GameArchiveLevel = e_GameArchiveLevel;
        this.Location = Location;
        this.Week = Week;
        this.Time = Time;
    }
}

public class DataContainer_CellStore
{
    public int Weight;
    public int Capacity;
}