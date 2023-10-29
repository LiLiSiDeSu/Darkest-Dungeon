using UnityEngine;

public sealed class AllEnum : MonoBehaviour { }

public enum E_GameArchiveLevel
{
    None,
    Bright,
    Darkness,
    Bloodmoon
}

public enum E_SpriteNamePanelCellTownStore
{
    StoreWood,
    StoreIron,
    StoreGold
}

public enum E_SpriteNamePanelCellItem
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

public enum E_SpriteNameCoin
{
    ResCoinCopper,
    ResCoinSilver,
    ResCoinGold,
    ResCoinPlatinum
}

public enum E_SpriteNameRoleStatus
{
    RoleStatusNone,
    RoleStatusExpedition,
    RoleStatusPrepareExpedition
}

public enum E_SpriteNamePortraitRole
{
    PortraitNone,
    PortraitPlagueDoctor,
    PortraitAbomination,
    PortraitAntiquarian,
    PortraitArbalest,
    PortraitBountyHunter,
    PortraitCrusader,
    PortraitGraveRobber,
    PortraitHellion,
    PortraitHighwayman,
    PortraitHoundmaster,
    PortraitJester,
    PortraitLeper,
    PortraitManAtArms,
    PortraitMusketeer,
    PortraitOccultist,    
    PortraitShieldbreaker,
    PortraitVestal
}

public enum E_SpriteNameAncestralProperty
{
    ResAncestralPropertyStatue,
    ResAncestralPropertyDeed,
    ResAncestralPropertyPicture,
    ResAncestralPropertyBadge,
    ResAncestralPropertyCrystal
}

public enum E_StatusItemGrid
{
    None,
    Have
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
    TownPrepareExpedition,
    TownExpedition
}

public enum E_Location
{    
    None,
    PanelTownItem,
    PanelTownShopItem
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