using UnityEngine;

public sealed class AllEnum : MonoBehaviour { }

public enum E_GameArchiveLevel
{
    None,
    Bright,
    Darkness,
    Bloodmoon
}

public enum E_PanelCellTownStore
{
    StoreWood,
    StoreIron,
    StoreGold
}

public enum E_PanelCellItem
{
    ItemFoodCookie,
    ItemFoodApple,
    ItemFoodBread,
    ItemFoodRawBeef,
    ItemFoodRawChicken,
    ItemFoodRawMutton,
    ItemFoodRawPotato,    
    ItemFoodCookedBeef,
    ItemFoodCoodedChicken,
    ItemFoodCoodedMutton,
    ItemFoodCookedPotato,
}

public enum E_Coin
{
    Copper,
    Silver,
    Gold,
    Platinum
}

public enum E_RoleStatus
{
    None,
    Expedition,
    PrepareExpedition
}

public enum E_DungeonSize
{
    Small,
    Middle,
    Large
}

public enum E_DungeonLevel
{
    Zero,
    One,
    Blood
}

public enum E_ExpeditionEvent
{
    Boss0,
    Boss1,
    Boss2,
    BossCrystal,
    BossDarkest,

    Gather0,
    Gather1,
    Gather2,

    Cleanse0,
    Cleanse1,
    Cleanse2,
    CleanseCrystal,

    Explore0,
    Explore1,
    Explore2,

    Shrieker0,
    Shrieker1,
    Shrieker2
}

public enum E_RoleAction
{
    Await,
    Charge,
}

public enum E_RoleName
{        
    Crusader,
    LiLiSi,
}

public enum E_AncestralProperty
{
    Statue,
    Deed,
    Picture,
    Badge,
    Crystal
}

public enum E_ExpeditionLocation
{
    BloodCourtyard,
    Lair,
    Farm,
    Wilds,
    Ruins,
    Darkest,
    Sed
}

public enum E_PlayerLocation
{
    None,
    Town,
    PrepareExpedition,
    OnExpedition
}

public enum E_NowPointerLocation
{
    None,
    PanelTownItem,
    PanelTownShopItem,
    PanelRoleList,
    PanelTownPrepareExpedition,
    PanelTownExpedition
}

public enum E_Location
{    
    None,
    TownItem,
    TownShopItem
}

public enum E_ArrowDirection
{
    Up,
    Down,
    Left,
    Right
}

public enum E_PoPoCatStatus
{
    Open,
    Close
}