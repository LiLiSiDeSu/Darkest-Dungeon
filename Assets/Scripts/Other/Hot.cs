using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class Hot
{
    #region Config

    public static int StepSanity = 10;

    /// <summary>
    /// 在TranslateNum的基础上添加的倍率
    /// </summary>
    public static int AddTranslateRate = 4;
    /// <summary>
    /// 现在的转换倍率
    /// </summary>
    public static int NowTranslateRate = 1;

    /// <summary>
    /// Add 和 Reduce按下一次增加或减少的值
    /// </summary>
    public static float ValueChangeMapSize = 0.4f;

    /// <summary>
    /// 各个等级升级所需的经验
    /// </summary>
    public static List<int> ListNeedExperienceToUpLevel = new List<int>()
    {
        50,
        55,
        60,
        90,
        100,
        130
    };

    #region Body

    public static m_Vector2 BodyExpeditionRoom = new(48, 18);
    public static m_Vector2 BodyCellGridExpeditionMap = new(40, 40);

    public static m_Vector2 BodySizeCellItem = new(40, 40);
    public static m_Vector2 BodySizeCellMinimap = new(40, 40);

    public static Dictionary<E_MapObject, m_Vector2> BodyDicMapObject = new()
    {
        { E_MapObject.MapObjectGridSoil, new(1, 1) },
        { E_MapObject.MapObjectGridStone, new(1, 1) },

        { E_MapObject.MapObjectGravestoneRect2, new(2, 2) },
        { E_MapObject.MapObjectGravestoneRectLong, new(1, 3) },
    };
    public static Dictionary<E_CellExpeditionMiniMapHall, m_Vector2> BodyDicHall = new()
    {
        { E_CellExpeditionMiniMapHall.CellMapHallDark, new(1, 1) },
        { E_CellExpeditionMiniMapHall.CellMapHallDim, new(1, 1) },
        { E_CellExpeditionMiniMapHall.CellMapHallLight, new(1, 1) },
        { E_CellExpeditionMiniMapHall.CellMapHallBattle, new(1, 1) },
        { E_CellExpeditionMiniMapHall.CellMapHallTrap, new(1, 1) },
        { E_CellExpeditionMiniMapHall.CellMapHallSecret, new(1, 1) },
    };
    public static Dictionary<E_CellExpeditionMiniMapRoom, m_Vector2> BodyDicRoom = new()
    {
        { E_CellExpeditionMiniMapRoom.CellMapRoomBoss, new(4, 4) },
        { E_CellExpeditionMiniMapRoom.CellMapRoomLocked, new(3, 3) },
        { E_CellExpeditionMiniMapRoom.CellMapRoomEmpty, new(3, 3) },
        { E_CellExpeditionMiniMapRoom.CellMapRoomEntrance, new(3, 3) },
        { E_CellExpeditionMiniMapRoom.CellMapRoomUnkown, new(3, 3) },
    };

    public static Dictionary<E_PanelCellTownStore, m_Vector2> BodyDicStore = new()
    {
        { E_PanelCellTownStore.StoreWood, new(10, 5) },
        { E_PanelCellTownStore.StoreIron, new(12, 10) },
        { E_PanelCellTownStore.StoreGold, new(15, 13) },
    };

    public static Dictionary<E_SpriteNamePanelCellItem, m_Vector2> BodyDicItem = new()
    {
        { E_SpriteNamePanelCellItem.ItemFoodCookie, new(1, 1) },
        { E_SpriteNamePanelCellItem.ItemFoodApple, new(3, 3) },
        { E_SpriteNamePanelCellItem.ItemFoodBread, new(1, 2) },

        { E_SpriteNamePanelCellItem.ItemFoodRawBeef, new(2, 3) },
        { E_SpriteNamePanelCellItem.ItemFoodCookedBeef, new(2, 3) },

        { E_SpriteNamePanelCellItem.ItemFoodRawChicken, new(2, 2) },
        { E_SpriteNamePanelCellItem.ItemFoodCoodedChicken, new(2, 2) },

        { E_SpriteNamePanelCellItem.ItemFoodRawMutton, new(2, 2) },
        { E_SpriteNamePanelCellItem.ItemFoodCoodedMutton, new(2, 2) },

        { E_SpriteNamePanelCellItem.ItemFoodRawPotato, new(2, 2) },
        { E_SpriteNamePanelCellItem.ItemFoodCookedPotato, new(2, 2) },
    };

    #endregion

    public static Dictionary<E_SpriteNamePanelCellItem, InfoContainer_Cost> CostDicItem = new()
    {
        { E_SpriteNamePanelCellItem.ItemFoodCookie, new(1, 1, 1, 1, 0, 0, 0, 0, 0) },
        { E_SpriteNamePanelCellItem.ItemFoodApple, new(2, 2, 2, 2, 0, 0, 0, 0, 0) },
        { E_SpriteNamePanelCellItem.ItemFoodBread, new(1, 2, 1, 2, 0, 0, 0, 0, 0) },

        { E_SpriteNamePanelCellItem.ItemFoodRawBeef, new(11, 11, 11, 11, 0, 0, 0, 0, 0) },
        { E_SpriteNamePanelCellItem.ItemFoodCookedBeef, new(11, 11, 13, 12, 0, 0, 0, 0, 0) },

        { E_SpriteNamePanelCellItem.ItemFoodRawChicken, new(21, 13, 122, 11, 0, 0, 0, 0, 0) },
        { E_SpriteNamePanelCellItem.ItemFoodCoodedChicken, new(11, 11, 11, 11, 0, 0, 0, 0, 0) },

        { E_SpriteNamePanelCellItem.ItemFoodRawMutton, new(11, 11, 21, 21, 0, 0, 0, 0, 0) },
        { E_SpriteNamePanelCellItem.ItemFoodCoodedMutton, new(41, 31, 31, 31, 0, 0, 0, 0, 0) },

        { E_SpriteNamePanelCellItem.ItemFoodRawPotato, new(22, 22, 22, 22, 0, 0, 0, 0, 0) },
        { E_SpriteNamePanelCellItem.ItemFoodCookedPotato, new(12, 22, 11, 11, 0, 0, 0, 0, 0) },
    };

    #endregion

    #region 快捷得到BaseFrameWork里的脚本

    public static MgrUI MgrUI_
    {
        get { return MgrUI.GetInstance(); }
    }
    public static Data Data_
    {
        get { return Data.GetInstance(); }
    }
    public static PoolNowPanel PoolNowPanel_
    {
        get { return PoolNowPanel.GetInstance(); }
    }
    public static PoolBuffer PoolBuffer_
    {
        get { return PoolBuffer.GetInstance(); }
    }
    public static MgrInput MgrInput_
    {
        get { return MgrInput.GetInstance(); }
    }
    public static MgrJson MgrJson_
    {
        get { return MgrJson.GetInstance(); }
    }
    public static CenterEvent CenterEvent_
    {
        get { return CenterEvent.GetInstance(); }
    }
    public static MgrRes MgrRes_
    {
        get { return MgrRes.GetInstance(); }
    }

    #endregion

    #region Panel    

    #region Expedition

    public static PanelExpeditionDetails PanelExpeditionDetails_
    {
        get { return MgrUI_.GetPanel<PanelExpeditionDetails>("PanelExpeditionDetails"); }
    }
    public static PanelExpeditionMiniMap PanelExpeditionMiniMap_
    {
        get { return MgrUI_.GetPanel<PanelExpeditionMiniMap>("PanelExpeditionMiniMap"); }
    }
    public static PanelExpeditionPrepare PanelExpeditionPrepare_
    {
        get { return MgrUI_.GetPanel<PanelExpeditionPrepare>("PanelExpeditionPrepare"); }
    }

    #endregion

    #region Bar

    public static PanelBarExpedition PanelBarExpedition_
    {
        get { return MgrUI_.GetPanel<PanelBarExpedition>("PanelBarExpedition"); }
    }
    public static PanelBarTown PanelBarTown_
    {
        get { return MgrUI_.GetPanel<PanelBarTown>("PanelBarTown"); }
    }

    #endregion

    #region Other

    public static PanelOhterResTable PanelOtherResTable_
    {
        get { return MgrUI_.GetPanel<PanelOhterResTable>("PanelOhterResTable"); }
    }
    public static PanelOtherMiniMapEditor PanelOtherMapEditor_
    {
        get { return MgrUI_.GetPanel<PanelOtherMiniMapEditor>("PanelOtherMiniMapEditor"); }
    }
    public static PanelOtherSetting PanelOtherSetting_
    {
        get { return MgrUI_.GetPanel<PanelOtherSetting>("PanelOtherSetting"); }
    }
    public static PanelOtherRoomEditor PanelOtherRoomEditor_
    {
        get { return MgrUI_.GetPanel<PanelOtherRoomEditor>("PanelOtherRoomEditor"); }
    }

    #endregion

    #region Role

    public static PanelRoleDetails PanelRoleDetails_
    {
        get { return MgrUI_.GetPanel<PanelRoleDetails>("PanelRoleDetails"); }
    }
    public static PanelRoleList PanelRoleList_
    {
        get { return MgrUI_.GetPanel<PanelRoleList>("PanelRoleList"); }
    }
    public static PanelRoleGuildRecruit PanelRoleGuildRecruit_
    {
        get { return MgrUI_.GetPanel<PanelRoleGuildRecruit>("PanelRoleGuildRecruit"); }
    }
    public static PanelRoleGuildRecruitCost PanelRoleGuildRecruitCost_
    {
        get { return MgrUI_.GetPanel<PanelRoleGuildRecruitCost>("PanelRoleGuildRecruitCost"); }
    }

    #endregion

    #region GameArchive

    public static PanelGameArchiveChoose PanelGameArchiveChoose_
    {
        get { return MgrUI_.GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose"); }
    }
    public static PanelOtherDestroyArchiveHint PanelOtherDestroyArchiveHint_
    {
        get { return MgrUI_.GetPanel<PanelOtherDestroyArchiveHint>("PanelOtherDestroyArchiveHint"); }
    }

    #endregion

    #region Town    
    /// <summary>
    /// 所有城镇箱子面板
    /// </summary>
    public static PanelTownStore PanelTownStore_
    {
        get { return MgrUI_.GetPanel<PanelTownStore>("PanelTownStore"); }
    }

    #region TownShop

    /// <summary>
    /// 城镇商店花费面板
    /// </summary>
    public static PanelTownShopCost PanelTownShopCost_
    {
        get { return MgrUI_.GetPanel<PanelTownShopCost>("PanelTownShopCost"); }
    }
    /// <summary>
    /// 城镇商店面板娘PoPoCat
    /// </summary>
    public static PanelMinistrantPoPoCat PanelMinistrantPoPoCat_
    {
        get { return MgrUI_.GetPanel<PanelMinistrantPoPoCat>("PanelMinistrantPoPoCat"); }
    }
    /// <summary>
    /// 城镇商店面板
    /// </summary>
    public static PanelTownShopItem PanelTownShopItem_
    {
        get { return MgrUI_.GetPanel<PanelTownShopItem>("PanelTownShopItem"); }
    }

    #endregion

    #endregion

    #region PanelTownRooms

    public static PanelTownRooms PanelTownRooms_
    {
        get { return MgrUI_.GetPanel<PanelTownRooms>("PanelTownRooms"); }
    }
    //---
    public static PanelRoomGuild PanelRoomGuild_
    {
        get { return MgrUI_.GetPanel<PanelRoomGuild>("PanelRoomGuild"); }
    }
    public static PanelRoomGraveyard PanelRoomGraveyard_
    {
        get { return MgrUI_.GetPanel<PanelRoomGraveyard>("PanelRoomGraveyard"); }
    }
    public static PanelRoomTownShop PanelRoomTownShop_
    {
        get { return MgrUI_.GetPanel<PanelRoomTownShop>("PanelRoomTownShop"); }
    }
    public static PanelRoomSmithy PanelRoomSmithy_
    {
        get { return MgrUI_.GetPanel<PanelRoomSmithy>("PanelRoomSmithy"); }
    }
    public static PanelRoomTavern PanelRoomTavern_
    {
        get { return MgrUI_.GetPanel<PanelRoomTavern>("PanelRoomTavern"); }
    }
    public static PanelRoomAbbey PanelRoomAbbey_
    {
        get { return MgrUI_.GetPanel<PanelRoomAbbey>("PanelRoomAbbey"); }
    }
    public static PanelRoomSanitarium PanelRoomSanitarium_
    {
        get { return MgrUI_.GetPanel<PanelRoomSanitarium>("PanelRoomSanitarium"); }
    }
    public static PanelRoomSurvivorMaster PanelRoomSurvivorMaster_
    {
        get { return MgrUI_.GetPanel<PanelRoomSurvivorMaster>("PanelRoomSurvivorMaster"); }
    }

    #endregion

    #endregion

    #region Data

    public static DataContainer_ResTable DataPanelResTable
    {
        get { return DataNowCellGameArchive.ResTable; }
    }
    /// <summary>
    /// 现在读取的存档Data
    /// </summary>
    public static DataContainer_PanelCellGameArchive DataNowCellGameArchive
    {
        get { return Data_.DataListCellGameArchive[NowIndexCellGameArchive]; }
    }

    #endregion

    #region Now    

    #region Other

    public static bool CanBuy = false;
    /// <summary>
    /// 现在鼠标所在的区域
    /// </summary>
    public static E_NowPointerLocation e_NowPointerLocation = E_NowPointerLocation.None;
    /// <summary>
    /// 现在玩家所在的区域(从开发者视角来看)
    /// </summary>
    public static E_PlayerLocation e_NowPlayerLocation = E_PlayerLocation.None;

    #endregion

    #region Dynamic

    public static int PaddingIndex
    {
        get
        {
            if (PaddingContentStep_ == null)
                return 0;

            return PaddingContentStep_.GetComponent<RectTransform>().GetSiblingIndex();
        }
    }
    public static E_ArrowDirection e_PaddingArrowDirection;
    public static DynamicContentStep PaddingContentStep_;
    /// <summary>
    /// 现在进入的DynamicScrollView 现用于 存档 角色名册 城镇箱子 的 动态改变位置
    /// </summary>
    public static PanelBaseDynamicScrollView NowPanelBaseDynamicScrollView_ = null;

    #endregion

    #region GameArchive

    /// <summary>
    /// 当前存档的Index
    /// </summary>
    public static int NowIndexCellGameArchive = -1;

    #endregion

    #region Editor

    public static E_MapObject e_ChoseObj = E_MapObject.None;
    public static E_CellExpeditionMiniMapHall e_ChoseHall = E_CellExpeditionMiniMapHall.None;
    public static E_CellExpeditionMiniMapRoom e_ChoseRoom = E_CellExpeditionMiniMapRoom.None;
    /// <summary>
    /// 现在进入的RoomEditor背景Grid
    /// </summary>
    public static PanelCellGridRoomEditor NowEnterCellGridRoomEditor;
    /// <summary>
    /// 现在进入的 RoomEditor Cell
    /// </summary>
    public static PanelCellRoomEditor NowEnterCellRoomEditor;
    /// <summary>
    /// 现在选择的 RoomEditor Cell
    /// </summary>
    public static PanelCellRoomEditor ChoseCellRoomEditor;
    /// <summary>
    /// 现在的编辑器属于哪个 MiniMap Cell
    /// </summary>
    public static PanelCellMiniMapEditor NowEditorDependency = null;
    /// <summary>
    /// 现在进入的地图编辑器背景Grid
    /// </summary>
    public static PanelCellGridMiniMapEditor NowEnterCellGridMiniMapEditor = null;
    /// <summary>
    /// 现在进入的Mini地图编辑器Cell      
    /// </summary>
    public static PanelCellMiniMapEditor NowEnterCellMiniMapEditor = null;
    /// <summary>
    /// 现在选择的地图编辑器Cell
    /// </summary>
    public static PanelCellMiniMapEditor ChoseCellMapEditor = null;

    #endregion

    #region Expedition

    public static PanelCellExpeditionEvent ChoseExpeditionEvent = null;

    #endregion

    #region Role

    /// <summary>
    /// 现在进入的角色远征格子
    /// </summary>
    public static GameObject NowRootExpeditionRole;
    /// <summary>
    /// 替换的角色肖像
    /// </summary>
    public static GameObject ReplaceRolePortrait;
    /// <summary>
    /// 拖曳的角色肖像
    /// </summary>
    public static GameObject DragingRolePortrait;
    /// <summary>
    /// 现在拖动的角色招募PanelCell
    /// </summary>
    public static PanelCellRoleRecruit DragingPanelCellRoleRecruit;

    #endregion

    #region Item

    /// <summary>
    /// 拖拽的箱子
    /// </summary>
    public static PanelCellTownStore DragingTownStore;
    /// <summary>
    /// 现在进入的可以存储Item的面板
    /// </summary>
    public static PanelBaseVector2Store NowPanelCanStoreItem;
    /// <summary>
    /// 现在选中的物品
    /// </summary>
    public static PanelCellItem ChoseCellItem = null;
    /// <summary>
    /// 现在进入的物品背景格子
    /// </summary>
    public static PanelCellGridTownItem NowEnterCellGridItem = null;

    #endregion    

    #endregion    
}
