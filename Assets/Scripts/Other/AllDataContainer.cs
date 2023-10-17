using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public sealed class AllDataContainer { }

public class DataContainer_PanelCellGameArchive
{    
    public E_GameArchiveLevel e_GameArchiveLevel = E_GameArchiveLevel.None;
    public List<DataContainer_PanelCellTownStore> DataListCellStore = new List<DataContainer_PanelCellTownStore>();
    public DataContainer_PanelStoreAncestralProperty DataResAncestralProperty = new DataContainer_PanelStoreAncestralProperty();
    public DataContainer_PanelStoreCoin DataResCoin = new DataContainer_PanelStoreCoin();
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

public class DataContainer_PanelStoreAncestralProperty
{
    public int NowStatue = 0;
    public int NowDeed = 0;
    public int NowBadge = 0;
    public int NowPicture = 0;
    public int NowCrystal = 0;

    public int MaxStatue = 10;
    public int MaxDeed = 10;
    public int MaxBadge = 10;
    public int MaxPicture = 10;
    public int MaxCrystal = 10;

    //Rate

    public DataContainer_PanelStoreAncestralProperty() { }
    public DataContainer_PanelStoreAncestralProperty
    (int NowStatue, int NowDeed, int NowBadge, int NowPicture, int NowCrystal)
    {
        this.NowStatue = NowStatue;
        this.NowDeed = NowDeed;
        this.NowBadge = NowBadge;
        this.NowPicture = NowPicture;
        this.NowCrystal = NowCrystal;
    }
}

public class DataContainer_PanelStoreCoin
{
    public int NowCopper = 0;
    public int NowSilver = 0;
    public int NowGold = 0;
    public int NowPlatinum = 0;       

    public int RateCopperToSilver = 100;
    public int RateSilverToGold = 100;
    public int RateGoldToPlatinum = 100;

    public E_StoreCoinLevel e_StoreCoinLevel = E_StoreCoinLevel.Silver;
    public int StoreCoinLevel = 1;

    public DataContainer_PanelStoreCoin() { }
    public DataContainer_PanelStoreCoin
    (int NowCopper, int NowSilver, int NowGold, int NowPlatinum,      
     E_StoreCoinLevel e_StoreCoinLevel, int StoreCoinLevel)
    {
        this.NowCopper = NowCopper;
        this.NowSilver = NowSilver;
        this.NowGold = NowGold;
        this.NowPlatinum = NowPlatinum;        
        this.e_StoreCoinLevel = e_StoreCoinLevel;
        this.StoreCoinLevel = StoreCoinLevel;
    }
}