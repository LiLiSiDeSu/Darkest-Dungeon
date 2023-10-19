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

public enum E_StoreCoinLevel
{    
    Silver,
    Gold,
    Platinum
}

public enum E_Location
{
    TownStore,
    TownShop
}

public enum E_PoPoCatStatus
{
    Open,
    Close
}