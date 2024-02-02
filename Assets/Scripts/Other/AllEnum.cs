using UnityEngine;

public sealed class AllEnum : MonoBehaviour { }

public enum E_PanelName
{
    PanelOtherEditorRoleConfig,
    PanelOtherEditorRoom,
    PanelOtherEditorMiniMap,
    PanelCellRoomEditor,

    PanelCellRoleConfigChooseSkill,
    PanelCellRoleConfigChooseRole,
    PanelCellRoleConfig,
    PanelGridRoleConfig,
    PanelCellRoleConfigRoleSkill,
    
    PanelCellGameArchive,
    PanelCellTownStore,
    PanelCellExpeditionRole,
    PanelCellExpeditionTimeLine,
    PanelCellRoleSkill,
    PanelCellItem,
    PanelCellExpeditionRolePrepareRoot,
    PanelCellRolePortraitCanDrag,
    PanelCellRole,
    PanelCellRoomEditorChoose,
    PanelGridTownItem,
    PanelCellExpeditionRoom,
    PanelExpeditionRoleDetails,
    PanelCellRoleRecruit,
    PanelTownShopCost,
    PanelTownShopItem,
    PanelMinistrantPoPoCat,
    PanelTranslateAncestralProperty,
    PanelTranslateCoinAncestralProperty,
    PanelTranslateCoinCoin,
    PanelRoleGuildRecruit,
    PanelRoleGuildRecruitCost,
    PanelExpeditionDetails,
    PanelCellExpeditionRoleSkill,
    PanelCellExpeditionEvent,
    PanelCellMiniMapEditor,
    PanelCellMiniMapEditorChoose,
    PanelCellExpeditionMiniMap,
    PanelGridMiniMapEditor,

    PanelGridExpeditionMiniMap,
    PanelGridExpeditionRoom,
    PanelGridRoomEditor,
    PanelGridRoomEditorConfig,

    PanelTownRooms,
    PanelRoomSanitarium,
    PanelRoomAbbey,
    PanelRoomSurvivorMaster,
    PanelRoomTavern,
    PanelRoomSmithy,
    PanelRoomTownShop,
    PanelRoomGraveyard,
    PanelRoomGuild,

    PanelExpeditionRoom,
    PanelExpeditionMiniMap,
    PanelExpeditionPrepare,

    PanelBarRoleList,
    PanelBarTownStore,
    PanelBarExpeditionTimeLine,
    PanelBarRoleListExpedition,
    PanelBarExpedition,
    PanelBarTown,
    
    PanelRoleDetails,

    PanelTown,
    PanelTownItem,

    PanelGameArchiveChooseLevel,
    PanelGameArchiveChoose,

    PanelOtherSetting,
    PanelOhterResTable,
    PanelOtherDestroyArchiveHint,
    PanelOtherStart,
}

public enum E_RoleSkillArea
{
    None,
    Role,
    Skill,
}

public enum E_KeyEvent
{
    KeyUp,
    KeyDown,
    KeyHold,
}

public enum E_RoleMoveType
{
    Land,
    Sky,
}

public enum E_Res
{
    ImgEmpty,
    ImgCoverTransparenctGreen,
    ImgCoverTransparenctRed,

    BorderChoosedGreen,
    BorderChoosedRed,

    CellRoleSkillArea,
}

public enum E_MapObject
{
    None,

    MapObjectGridSoil,
    MapObjectGridStone,

    MapObjectGravestoneRect2,
    MapObjectGravestoneRectLong,

    MapObjectWall1,
    MapObjectWall2,

    MapObjectStoreWood,
    MapObjectStoreIron,
    MapObjectStoreGold,

    MapObjectStore0,
    MapObjectStore1,
    MapObjectStore4,

    MapObjectStoreWide0,
    MapObjectStoreWide1,
    MapObjectStoreWide2,

    MapObjectPlatform0,
}

public enum E_CellMiniMap
{
    None,

    CellMiniMapHallDark,
    CellMiniMapHallDim,
    CellMiniMapHallLight,
    CellMiniMapHallBattle,
    CellMiniMapHallTrap,
    CellMiniMapHallSecret,

    CellMiniMapRoomBoss,
    CellMiniMapRoomEmpty,
    CellMiniMapRoomEntrance,
    CellMiniMapRoomLocked,
    CellMiniMapRoomUnkown,
}

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

public enum E_Skill
{
    None,

    SkillForwardUpCut,
    SkillForwardDownCut,
}

public enum E_Item
{
    None,

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

public enum E_AncestralProperty
{
    Statue,
    Deed,
    Picture,
    Badge,
    Crystal
}
public enum E_SpriteNameCoin
{
    Copper,
    Silver,
    Gold,
    Platinum
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
    None,
    Crusader,
    PlagueDoctor,
    DevilFly,
}

public enum E_ExpeditionLocation
{
    Town,

    BloodCourtyard,
    Lair,
    Farm,
    Wilds,
    Ruins,
    Darkest,
    Sea
}

public enum E_RoleLocation
{
    None,
    RoleList,
    GuildRecruit,
}

public enum E_PlayerLocation
{
    None,
    Town,
    ChooseGameArchive,
    PrepareExpedition,
    OnExpedition
}

public enum E_NowPointerLocation
{
    None,
    PanelTownStore,
    PanelTownItem,
    PanelTownShopItem,
    PanelBarExpedition,
    PanelRoleList,
    PanelGameArchiveChoose,
    PanelRoleGuildRecruit,
    PanelRoleStore,
}

public enum E_ItemLocation
{
    None,
    PanelTownItem,
    TownShopItem,
    PanelRoleStore,
}

public enum E_WSAD
{
    W,
    S,
    A,
    D
}

public enum E_PoPoCatStatus
{
    Open,
    Close
}