using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public sealed class AllDataOrInfoContainer { }

public class DataContainer_PanelCellGameArchive
{
    public string GameArchiveName = "";
    public E_ExpeditionLocation e_ExpeditionLocation = E_ExpeditionLocation.Town;    
    public string Week = "0";
    public string Time = "0000/00/00 00:00:00";

    public E_GameArchiveLevel e_GameArchiveLevel = E_GameArchiveLevel.None;
    public DataContainer_ResTable ResTable = new();    
    public List<DataContainer_CellTownStore> ListCellStore = new();        
    public List<DataContainer_CellRole> ListCellRole = new();
    public List<DataContainer_CellRoleRecruit> ListCellRoleRecruit = new();

    public DataContainer_TownShop TownShop = new();

    public DataContainer_ExpeditionPrepare ExpeditionPrepare = new();    

    public DataContainer_PanelCellGameArchive() { }
    public DataContainer_PanelCellGameArchive
    (string GameArchiveName, E_GameArchiveLevel e_GameArchiveLevel, E_ExpeditionLocation e_ExpeditionLocation, string Week, string Time, 
    List<DataContainer_CellTownStore> ListCellStore)
    {
        this.GameArchiveName = GameArchiveName;
        this.e_GameArchiveLevel = e_GameArchiveLevel;
        this.e_ExpeditionLocation = e_ExpeditionLocation;
        this.Week = Week;
        this.Time = Time;
        this.ListCellStore = ListCellStore;
    }
}

#region Role

public class DataContainer_CellRole
{
    public E_RoleName e_RoleName = E_RoleName.Crusader;
    public E_RoleStatus e_RoleStatus = E_RoleStatus.None;
    public int IndexExpedition = -1;
    public int IndexPrepareExpedition = -1;
    public string Name = "Town";
    public int NowLevel = 0;
    //每个人的资质不同 MaxLevel也会不同 也会受各种加成的影响
    public int MaxLevel = 0;
    public int NowExperience = 0;
    public int NowSanity = 0;
    public int MaxSanity = 0;
    public int LimitToSanityExplosion = 0;

    public DataContainer_CellRole() { }
    public DataContainer_CellRole
    (E_RoleName e_RoleName,
     E_RoleStatus e_RoleStatus,
     string Name,
     int NowLevel, int MaxLevel, int NowExperience,
     int NowSanity, int MaxSanity, int LimitToSanityExplosion)
    {
        this.e_RoleName = e_RoleName;
        this.e_RoleStatus = e_RoleStatus;
        this.Name = Name;
        this.NowLevel = NowLevel;
        this.MaxLevel = MaxLevel;
        this.NowExperience = NowExperience;
        this.NowSanity = NowSanity;
        this.MaxSanity = MaxSanity;
        this.LimitToSanityExplosion = LimitToSanityExplosion;
    }
}

public class DataContainer_CellRoleRecruit
{
    public DataContainer_CellRole Role = new();
    public DataContainer_CoinCost Cost = new();

    public DataContainer_CellRoleRecruit() { }
    public DataContainer_CellRoleRecruit
    (DataContainer_CellRole Role, DataContainer_CoinCost Cost)
    {
        this.Role = Role;
        this.Cost = Cost;
    }
}

#endregion

#region Expedition

public class DataContainer_ExpeditionPrepare
{
    public List<DataContainer_ExpeditionMiniMap> BloodCourtyard = new();
    public List<DataContainer_ExpeditionMiniMap> Lair = new();
    public List<DataContainer_ExpeditionMiniMap> Farm = new();
    public List<DataContainer_ExpeditionMiniMap> Wilds = new();
    public List<DataContainer_ExpeditionMiniMap> Ruins = new();
    public List<DataContainer_ExpeditionMiniMap> Sea = new();
    public List<DataContainer_ExpeditionMiniMap> Darkest = new();

    public List<DataContainer_ExpeditionMiniMap> this[E_ExpeditionLocation e_ExpeditionLocation]
    {
        get
        {
            return e_ExpeditionLocation switch
            {
                E_ExpeditionLocation.BloodCourtyard => BloodCourtyard,
                E_ExpeditionLocation.Lair => Lair,
                E_ExpeditionLocation.Farm => Farm,
                E_ExpeditionLocation.Wilds => Wilds,
                E_ExpeditionLocation.Ruins => Ruins,
                E_ExpeditionLocation.Darkest => Darkest,
                E_ExpeditionLocation.Sed => Sea,
                _ => null,
            };
        }

        set
        {
            switch (e_ExpeditionLocation)
            {
                case E_ExpeditionLocation.BloodCourtyard:
                    BloodCourtyard = value;
                    break;
                case E_ExpeditionLocation.Lair:
                    Lair = value;
                    break;
                case E_ExpeditionLocation.Farm:
                    Farm = value;
                    break;
                case E_ExpeditionLocation.Wilds:
                    Wilds = value;
                    break;
                case E_ExpeditionLocation.Ruins:
                    Ruins = value;
                    break;
                case E_ExpeditionLocation.Darkest:
                    Darkest = value;
                    break;
                case E_ExpeditionLocation.Sed:
                    Sea = value;
                    break;
            }
        }
    }

    public DataContainer_ExpeditionPrepare() { }
    public DataContainer_ExpeditionPrepare
    (List<DataContainer_ExpeditionMiniMap> bloodCourtyard, List<DataContainer_ExpeditionMiniMap> lair, List<DataContainer_ExpeditionMiniMap> farm,
     List<DataContainer_ExpeditionMiniMap> wilds, List<DataContainer_ExpeditionMiniMap> ruins, List<DataContainer_ExpeditionMiniMap> sed,
     List<DataContainer_ExpeditionMiniMap> darkest)
    {
        BloodCourtyard = bloodCourtyard;
        Lair = lair;
        Farm = farm;
        Wilds = wilds;
        Ruins = ruins;
        Sea = sed;
        Darkest = darkest;
    }
}

public class DataContainer_CellExpeditionObject
{

}

#region Map

public class DataContainer_ExpeditionMiniMap
{
    public E_DungeonLevel e_dungeonLevel = E_DungeonLevel.Zero;
    public E_DungeonSize e_dungeonSize = E_DungeonSize.Small;
    public E_ExpeditionEvent e_ExpeditionEvent = E_ExpeditionEvent.Boss0;

    public List<List<DataContainer_CellExpeditionMiniMap>> ListCellMiniMap = new();

    public DataContainer_ExpeditionMiniMap() { }
    public DataContainer_ExpeditionMiniMap
    (E_DungeonLevel e_dungeonLevel, E_DungeonSize e_dungeonSize,
     E_ExpeditionEvent e_ExpeditionEvent)
    {
        this.e_dungeonLevel = e_dungeonLevel;
        this.e_dungeonSize = e_dungeonSize;
        this.e_ExpeditionEvent = e_ExpeditionEvent;
    }
}

public class DataContainer_CellExpeditionMiniMap
{
    public bool IsHave = false;
    public E_CellExpeditionMiniMapHall e_CellExpeditionMiniMapHall = E_CellExpeditionMiniMapHall.None;
    public E_CellExpeditionMiniMapRoom e_CellExpeditionMiniMapRoom = E_CellExpeditionMiniMapRoom.None;            

    public List<List<DataContainer_CellExpeditionMapGrid>> Map = new();
}

public class DataContainer_CellExpeditionMapGrid
{
    //当前远征地图格子所拥有的角色
    public DataContainer_CellRole Role = new();

    //当前远征地图格子所拥有的物体
    public DataContainer_CellExpeditionObject Object = new();
}

#endregion

#endregion


public class DataContainer_CellTownStore
{
    public string Name = "没有名字";    
    public E_PanelCellTownStore e_PanelCellTownStore = E_PanelCellTownStore.StoreWood;
    public List<List<DataContainer_CellItem>> ListItem = new();       

    public DataContainer_CellTownStore() { }
    public DataContainer_CellTownStore
    (string name,
     E_PanelCellTownStore e_SpriteNamePanelCellTownStore)
    {
        Name = name;
        this.e_PanelCellTownStore = e_SpriteNamePanelCellTownStore;        
    }
}

public class DataContainer_TownShop
{
    public int X;
    public int Y;

    public List<List<DataContainer_CellItem>> ListItem = new();
}

public class DataContainer_CellItem
{    
    public E_SpriteNamePanelCellItem e_SpriteNamePanelCellItem = E_SpriteNamePanelCellItem.None;   

    public DataContainer_CellItem() { }
    public DataContainer_CellItem
    (E_SpriteNamePanelCellItem e_SpriteNamePanelCellItem)
    {             
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
    public DataContainer_ResTable
    (int NowCopper, int NowSilver, int NowGold, int NowPlatinum ,
     int NowLevelCopper, int NowLevelSilver, int NowLevelGold, int NowLevelPlatinum) 
    {
        this.NowCopper = NowCopper;
        this.NowSilver = NowSilver;
        this.NowGold = NowGold;
        this.NowPlatinum = NowPlatinum;
        this.NowLevelCopper = NowLevelCopper;
        this.NowLevelSilver = NowLevelSilver;
        this.NowLevelGold = NowLevelGold;
        this.NowLevelPlatinum = NowLevelPlatinum;
    }
}

public class DataContainer_CoinCost
{
    public int Copper;
    public int Silver;
    public int Gold;
    public int Platinum;
    public DataContainer_CoinCost() { }
    public DataContainer_CoinCost
    (int Copper, int Silver, int Gold, int Platinum) 
    {
        this.Copper = Copper;
        this.Silver = Silver;
        this.Gold = Gold;
        this.Platinum = Platinum;
    }
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
