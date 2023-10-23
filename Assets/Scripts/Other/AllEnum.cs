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

public enum E_Location
{    
    None,
    PanelTownItem,
    PanelTownShopItem
}

public enum E_ArrowDirection
{
    Up,
    Down
}

public enum E_PoPoCatStatus
{
    Open,
    Close
}