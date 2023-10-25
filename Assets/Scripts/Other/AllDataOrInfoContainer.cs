using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public sealed class AllDataOrInfoContainer { }

public class DataContainer_PanelCellGameArchive
{    
    public E_GameArchiveLevel e_GameArchiveLevel = E_GameArchiveLevel.None;
    public DataContainer_ResTable PanelResTable = new DataContainer_ResTable();
    public List<DataContainer_CellTownStore> ListCellStore = new List<DataContainer_CellTownStore>();    
    public List<DataContainer_CellItem> ListCellShopItem = new List<DataContainer_CellItem>();
    public List<DataContainer_CellRole> ListCellRole = new List<DataContainer_CellRole>();

    public string GameArchiveName = "---";
    public string Location = "---";
    public string Week = "0";
    public string Time = "0000/00/00 00:00:00";    

    public DataContainer_PanelCellGameArchive() { }
    public DataContainer_PanelCellGameArchive
    (string GameArchiveName, E_GameArchiveLevel e_GameArchiveLevel, string Location, string Week, string Time, 
    List<DataContainer_CellTownStore> ListCellStore)
    {
        this.GameArchiveName = GameArchiveName;
        this.e_GameArchiveLevel = e_GameArchiveLevel;
        this.Location = Location;
        this.Week = Week;
        this.Time = Time;
        this.ListCellStore = ListCellStore;
    }
}

public class DataContainer_CellRole
{
    public E_SpriteNamePortraitRole e_SpriteNamePortraitRole = E_SpriteNamePortraitRole.PortraitNone;
    public string Name = "---";
    public int NowLevel = 0;    
    //每个人的资质不同 MaxLevel也会不同 也会受各种加成的影响
    public int MaxLevel = 0;
    public int NowExperience = 0;
    public int NowSanity = 0;
    public int MaxSanity = 0;    
    public int SanityExplosionLimit = 0;

    public DataContainer_CellRole() { }
    public DataContainer_CellRole
    (E_SpriteNamePortraitRole e_SpriteNamePortraitRole,
     string Name,
     int NowLevel, int MaxLevel, int NowExperience,
     int NowSanity, int MaxSanity, int SanityExplosionLimit)
    {
        this.e_SpriteNamePortraitRole = e_SpriteNamePortraitRole;
        this.Name = Name;
        this.NowLevel = NowLevel;
        this.MaxLevel = MaxLevel;
        this.NowExperience = NowExperience;
        this.NowSanity = NowSanity;
        this.MaxSanity = MaxSanity;
        this.SanityExplosionLimit = SanityExplosionLimit;
    }
}

public class DataContainer_CellTownStore
{
    public E_SpriteNamePanelCellTownStore e_SpriteNamePanelCellTownStore = E_SpriteNamePanelCellTownStore.StoreWood;
    public List<DataContainer_CellItem> ListCellStoreItem = new List<DataContainer_CellItem>();    
    public int NowWeight = 0;    
    public int NowCapacity = 0;    

    public DataContainer_CellTownStore() { }
    public DataContainer_CellTownStore
    (E_SpriteNamePanelCellTownStore e_SpriteNamePanelCellTownStore)
    {        
        this.e_SpriteNamePanelCellTownStore = e_SpriteNamePanelCellTownStore;        
    }
}

public class DataContainer_CellItem
{
    public E_Location e_Location = E_Location.PanelTownItem;
    public E_SpriteNamePanelCellItem e_SpriteNamePanelCellItem = E_SpriteNamePanelCellItem.ItemFoodCookie;   

    public DataContainer_CellItem() { }
    public DataContainer_CellItem
    (E_Location e_Location, E_SpriteNamePanelCellItem e_SpriteNamePanelCellItem)
    {     
        this.e_Location = e_Location;
        this.e_SpriteNamePanelCellItem = e_SpriteNamePanelCellItem;
    }
}

public class DataContainer_ResTable
{
    public int NowStoreDebris = 0;

    #region AncestralProperty

    public int NowStatue = 0;
    public int NowDeed = 0;
    public int NowBadge = 0;
    public int NowPicture = 0;
    public int NowCrystal = 0;

    public int NowLevelStatue = 1;
    public int NowLevelDeed = 1;
    public int NowLevelBadge = 1;
    public int NowLevelPicture = 1;
    public int NowLevelCrystal = 1;

    public int LevelUpNeedBadge = 10;
    public int LevelUpNeedStatue = 20;
    public int LevelUpNeedPicture = 40;
    public int LevelUpNeedDeed = 80;
    public int LevelUpNeedCrystal = 160;

    public int LevelStepStatue = 10;
    public int LevelStepDeed = 10;
    public int LevelStepBadge = 10;
    public int LevelStepPicture = 10;
    public int LevelStepCrystal = 10;

    public int LevelMaxStatue = 100;
    public int LevelMaxDeed = 100;
    public int LevelMaxBadge = 100;
    public int LevelMaxPicture = 100;
    public int LevelMaxCrystal = 100;

    //Ancestral Property
    //  Badge 1 --Standard
    //  Statue 2
    //  Picture 4
    //  Deed 8
    //  Crystal 16
    //--
    public int RateStatueToDeed = 4;
    public int RateStatueToPicture = 2;
    public int RateStatueToBadge = 2;
    public int RateStatueToCrystal = 8;
    public int RateDeedToPicture = 2;
    public int RateDeedToBadge = 8;
    public int RateDeedToCrystal = 2;
    public int RatePictureToBadge = 4;
    public int RatePictureToCrystal = 4;
    public int RateBadgeToCrystal = 16;

    #endregion

    #region Coin

    public int NowCopper = 0;
    public int NowSilver = 0;
    public int NowGold = 0;
    public int NowPlatinum = 0;

    public int NowLevelCopper = 1;
    public int NowLevelSilver = 1;
    public int NowLevelGold = 1;
    public int NowLevelPlatinum = 1;

    public int LevelUpNeedCopper = 1;
    public int LevelUpNeedSilver = 10;
    public int LevelUpNeedGold = 50;
    public int LevelUpNeedPlatinum = 100;

    public int LevelStepCopper = 1000;
    public int LevelStepSilver = 50;
    public int LevelStepGold = 10;
    public int LevelStepPlatinum = 5;

    public int LevelMaxCopper = 100;
    public int LevelMaxSilver = 100;
    public int LevelMaxGold = 100;
    public int LevelMaxPlatinum = 100;

    public int RateCopperToSilver = 100;
    public int RateSilverToGold = 100;
    public int RateGoldToPlatinum = 100;

    #endregion

    #region CoinToAncestralProperty    

    public int RateBadgeToCopper = 10000;
    public int RateStatueToCopper = 20000;
    public int RatePictureToCopper = 40000;
    public int RateDeedToCopper = 80000;
    public int RateCrystalToCopper = 160000;

    public int RateBadgeToSilver = 100;
    public int RateStatueToSilver = 200;
    public int RatePictureToSilver = 400;
    public int RateDeedToSilver = 800;
    public int RateCrystalToSilver = 1600;

    public int RateBadgeToGold = 1;
    public int RateStatueToGold = 2;
    public int RatePictureToGold = 4;
    public int RateDeedToGold = 8;
    public int RateCrystalToGold = 16;

    #endregion

    public DataContainer_ResTable() { }
}

public class InfoContainer_Cost
{
    public int Copper;
    public int Silver;
    public int Gold;
    public int Platinum;

    public int Statue;
    public int Deed;
    public int Badge;
    public int Picture;
    public int Crystal;

    public InfoContainer_Cost() { } 
    public InfoContainer_Cost
    (int copper, int silver, int gold, int platinum, 
     int statue, int deed, int badge, int picture, int crystal)
    {
        Copper = copper;
        Silver = silver;
        Gold = gold;
        Platinum = platinum;
        Statue = statue;
        Deed = deed;
        Badge = badge;
        Picture = picture;
        Crystal = crystal;
    }   
}


//特殊的类 用于PanelCellItem 记录打折信息 PriceOffSet 或者其他
//......
