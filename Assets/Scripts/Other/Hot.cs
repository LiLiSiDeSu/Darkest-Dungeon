using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Hot
{
    #region Config

    public static int ExpeditionTimeLineLength = 30;
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

    public static Dictionary<E_RoleName, RoleConfig> DicRoleConfig = MgrJson_.Load<Dictionary<E_RoleName, RoleConfig>>("", "/Config");

    #region Body

    public static my_VectorInt2 BodyMap = new(48, 18);
    public static my_VectorInt2 BodyGrid = new(40, 40);
    public static my_VectorInt2 BodySizeCellItem = new(40, 40);
    public static my_VectorInt2 BodySizeCellMinimap = new(40, 40);

    public static Dictionary<E_MapObject, my_VectorInt2> BodyDicMapObject = new()
    {
        { E_MapObject.MapObjectGridSoil, new(1, 1) },
        { E_MapObject.MapObjectGridStone, new(1, 1) },

        { E_MapObject.MapObjectGravestoneRect2, new(2, 2) },
        { E_MapObject.MapObjectGravestoneRectLong, new(1, 3) },

        { E_MapObject.MapObjectWall1, new(3, 3) },
        { E_MapObject.MapObjectWall2, new(3, 3) },

        { E_MapObject.MapObjectPlatform0, new(2, 1) },

        { E_MapObject.MapObjectStoreWide0, new(2, 1) },
        { E_MapObject.MapObjectStoreWide1, new(2, 1) },
        { E_MapObject.MapObjectStoreWide2, new(2, 1) },

        { E_MapObject.MapObjectStoreWood, new(2, 2) },
        { E_MapObject.MapObjectStoreIron, new(2, 2) },
        { E_MapObject.MapObjectStoreGold, new(2, 2) },

        { E_MapObject.MapObjectStore0, new(2, 2) },
        { E_MapObject.MapObjectStore1, new(2, 2) },
        { E_MapObject.MapObjectStore4, new(2, 2) },
    };

    public static Dictionary<E_CellMiniMap, my_VectorInt2> BodyDicCellMiniMap = new()
    {
        { E_CellMiniMap.CellMiniMapRoomBoss, new(3, 3) },
        { E_CellMiniMap.CellMiniMapRoomLocked, new(3, 3) },
        { E_CellMiniMap.CellMiniMapRoomEmpty, new(3, 3) },
        { E_CellMiniMap.CellMiniMapRoomEntrance, new(3, 3) },
        { E_CellMiniMap.CellMiniMapRoomUnkown, new(3, 3) },

        { E_CellMiniMap.CellMiniMapHallDark, new(1, 1) },
        { E_CellMiniMap.CellMiniMapHallDim, new(1, 1) },
        { E_CellMiniMap.CellMiniMapHallLight, new(1, 1) },
        { E_CellMiniMap.CellMiniMapHallBattle, new(1, 1) },
        { E_CellMiniMap.CellMiniMapHallTrap, new(1, 1) },
        { E_CellMiniMap.CellMiniMapHallSecret, new(1, 1) },
    };

    public static Dictionary<E_PanelCellTownStore, my_VectorInt2> BodyDicStore = new()
    {
        { E_PanelCellTownStore.StoreWood, new(10, 5) },
        { E_PanelCellTownStore.StoreIron, new(12, 10) },
        { E_PanelCellTownStore.StoreGold, new(15, 13) },
    };

    public static Dictionary<E_Item, my_VectorInt2> BodyDicItem = new()
    {
        { E_Item.ItemFoodCookie, new(1, 1) },
        { E_Item.ItemFoodApple, new(3, 3) },
        { E_Item.ItemFoodBread, new(1, 2) },

        { E_Item.ItemFoodRawBeef, new(2, 3) },
        { E_Item.ItemFoodCookedBeef, new(2, 3) },

        { E_Item.ItemFoodRawChicken, new(2, 2) },
        { E_Item.ItemFoodCoodedChicken, new(2, 2) },

        { E_Item.ItemFoodRawMutton, new(2, 2) },
        { E_Item.ItemFoodCoodedMutton, new(2, 2) },

        { E_Item.ItemFoodRawPotato, new(2, 2) },
        { E_Item.ItemFoodCookedPotato, new(2, 2) },
    };

    #endregion

    public static Dictionary<E_Item, InfoContainer_Cost> CostDicItem = new()
    {
        { E_Item.ItemFoodCookie, new(1, 1, 1, 1, 0, 0, 0, 0, 0) },
        { E_Item.ItemFoodApple, new(2, 2, 2, 2, 0, 0, 0, 0, 0) },
        { E_Item.ItemFoodBread, new(1, 2, 1, 2, 0, 0, 0, 0, 0) },

        { E_Item.ItemFoodRawBeef, new(11, 11, 11, 11, 0, 0, 0, 0, 0) },
        { E_Item.ItemFoodCookedBeef, new(11, 11, 13, 12, 0, 0, 0, 0, 0) },

        { E_Item.ItemFoodRawChicken, new(21, 13, 122, 11, 0, 0, 0, 0, 0) },
        { E_Item.ItemFoodCoodedChicken, new(11, 11, 11, 11, 0, 0, 0, 0, 0) },

        { E_Item.ItemFoodRawMutton, new(11, 11, 21, 21, 0, 0, 0, 0, 0) },
        { E_Item.ItemFoodCoodedMutton, new(41, 31, 31, 31, 0, 0, 0, 0, 0) },

        { E_Item.ItemFoodRawPotato, new(22, 22, 22, 22, 0, 0, 0, 0, 0) },
        { E_Item.ItemFoodCookedPotato, new(12, 22, 11, 11, 0, 0, 0, 0, 0) },
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
    public static TriggerEvent TriggerEvent_
    {
        get { return TriggerEvent.GetInstance(); }
    }
    public static MgrRes MgrRes_
    {
        get { return MgrRes.GetInstance(); }
    }

    #endregion

    #region Panel    

    #region Expedition

    public static PanelBarRoleListExpedition PanelBarRoleListExpedition_
    {
        get { return MgrUI_.GetPanel<PanelBarRoleListExpedition>(E_PanelName.PanelBarRoleListExpedition); }
    }
    public static PanelExpeditionRoleDetails PanelExpeditionRoleDetails_
    {
        get { return MgrUI_.GetPanel<PanelExpeditionRoleDetails>(E_PanelName.PanelExpeditionRoleDetails); }
    }
    public static PanelExpeditionRoom PanelExpeditionRoom_
    {
        get { return MgrUI_.GetPanel<PanelExpeditionRoom>(E_PanelName.PanelExpeditionRoom); }
    }
    public static PanelExpeditionDetails PanelExpeditionDetails_
    {
        get { return MgrUI_.GetPanel<PanelExpeditionDetails>(E_PanelName.PanelExpeditionDetails); }
    }
    public static PanelExpeditionMiniMap PanelExpeditionMiniMap_
    {
        get { return MgrUI_.GetPanel<PanelExpeditionMiniMap>(E_PanelName.PanelExpeditionMiniMap); }
    }
    public static PanelExpeditionPrepare PanelExpeditionPrepare_
    {
        get { return MgrUI_.GetPanel<PanelExpeditionPrepare>(E_PanelName.PanelExpeditionPrepare); }
    }
    public static PanelBarExpeditionTimeLine PanelBarExpeditionTimeLine_
    {
        get { return MgrUI_.GetPanel<PanelBarExpeditionTimeLine>(E_PanelName.PanelBarExpeditionTimeLine); }
    }

    #endregion

    #region Bar

    public static PanelBarExpedition PanelBarExpedition_
    {
        get { return MgrUI_.GetPanel<PanelBarExpedition>(E_PanelName.PanelBarExpedition); }
    }
    public static PanelBarTown PanelBarTown_
    {
        get { return MgrUI_.GetPanel<PanelBarTown>(E_PanelName.PanelBarTown); }
    }

    #endregion

    #region Other

    public static PanelOhterResTable PanelOtherResTable_
    {
        get { return MgrUI_.GetPanel<PanelOhterResTable>(E_PanelName.PanelOhterResTable); }
    }
    public static PanelOtherSetting PanelOtherSetting_
    {
        get { return MgrUI_.GetPanel<PanelOtherSetting>(E_PanelName.PanelOtherSetting); }
    }

    #endregion

    #region Role

    public static PanelRoleDetails PanelRoleDetails_
    {
        get { return MgrUI_.GetPanel<PanelRoleDetails>(E_PanelName.PanelRoleDetails); }
    }
    public static PanelBarRoleList PanelBarRoleList_
    {
        get { return MgrUI_.GetPanel<PanelBarRoleList>(E_PanelName.PanelBarRoleList); }
    }
    public static PanelRoleGuildRecruit PanelRoleGuildRecruit_
    {
        get { return MgrUI_.GetPanel<PanelRoleGuildRecruit>(E_PanelName.PanelRoleGuildRecruit); }
    }
    public static PanelRoleGuildRecruitCost PanelRoleGuildRecruitCost_
    {
        get { return MgrUI_.GetPanel<PanelRoleGuildRecruitCost>(E_PanelName.PanelRoleGuildRecruitCost); }
    }

    #endregion

    #region GameArchive

    public static PanelGameArchiveChoose PanelGameArchiveChoose_
    {
        get { return MgrUI_.GetPanel<PanelGameArchiveChoose>(E_PanelName.PanelGameArchiveChoose); }
    }
    public static PanelOtherDestroyArchiveHint PanelOtherDestroyArchiveHint_
    {
        get { return MgrUI_.GetPanel<PanelOtherDestroyArchiveHint>(E_PanelName.PanelOtherDestroyArchiveHint); }
    }

    #endregion

    #region Town    

    public static PanelBarTownStore PanelBarTownStore_
    {
        get { return MgrUI_.GetPanel<PanelBarTownStore>(E_PanelName.PanelBarTownStore); }
    }

    #region TownShop

    public static PanelTownShopCost PanelTownShopCost_
    {
        get { return MgrUI_.GetPanel<PanelTownShopCost>(E_PanelName.PanelTownShopCost); }
    }

    public static PanelTownShopItem PanelTownShopItem_
    {
        get { return MgrUI_.GetPanel<PanelTownShopItem>(E_PanelName.PanelTownShopItem); }
    }

    #endregion

    #endregion

    #region PanelTownRooms

    public static PanelTownRooms PanelTownRooms_
    {
        get { return MgrUI_.GetPanel<PanelTownRooms>(E_PanelName.PanelTownRooms); }
    }
    
    public static PanelRoomGuild PanelRoomGuild_
    {
        get { return MgrUI_.GetPanel<PanelRoomGuild>(E_PanelName.PanelRoomGuild); }
    }
    public static PanelRoomGraveyard PanelRoomGraveyard_
    {
        get { return MgrUI_.GetPanel<PanelRoomGraveyard>(E_PanelName.PanelRoomGraveyard); }
    }
    public static PanelRoomTownShop PanelRoomTownShop_
    {
        get { return MgrUI_.GetPanel<PanelRoomTownShop>(E_PanelName.PanelRoomTownShop); }
    }
    public static PanelRoomSmithy PanelRoomSmithy_
    {
        get { return MgrUI_.GetPanel<PanelRoomSmithy>(E_PanelName.PanelRoomSmithy); }
    }
    public static PanelRoomTavern PanelRoomTavern_
    {
        get { return MgrUI_.GetPanel<PanelRoomTavern>(E_PanelName.PanelRoomTavern); }
    }
    public static PanelRoomAbbey PanelRoomAbbey_
    {
        get { return MgrUI_.GetPanel<PanelRoomAbbey>(E_PanelName.PanelRoomAbbey); }
    }
    public static PanelRoomSanitarium PanelRoomSanitarium_
    {
        get { return MgrUI_.GetPanel<PanelRoomSanitarium>(E_PanelName.PanelRoomSanitarium); }
    }
    public static PanelRoomSurvivorMaster PanelRoomSurvivorMaster_
    {
        get { return MgrUI_.GetPanel<PanelRoomSurvivorMaster>(E_PanelName.PanelRoomSurvivorMaster); }
    }

    #endregion

    #region Editor

    public static PanelOtherEditorRoom PanelOtherEditorRoom_
    {
        get { return MgrUI_.GetPanel<PanelOtherEditorRoom>(E_PanelName.PanelOtherEditorRoom); }
    }
    public static PanelOtherEditorMiniMap PanelOtherEditorMiniMap_
    {
        get { return MgrUI_.GetPanel<PanelOtherEditorMiniMap>(E_PanelName.PanelOtherEditorMiniMap); }
    }
    public static PanelOtherEditorRoleConfig PanelOtherEditorRoleConfig_
    {
        get { return MgrUI_.GetPanel<PanelOtherEditorRoleConfig>(E_PanelName.PanelOtherEditorRoleConfig); }
    }

    #endregion

    #endregion

    #region Data

    public static DataContainer_ResTable DataPanelResTable
    {
        get { return DataNowCellGameArchive.ResTable; }
    }

    public static DataContainer_CellGameArchive DataNowCellGameArchive
    {
        get { return Data_.DataListCellGameArchive[NowIndexCellGameArchive]; }
    }

    #endregion

    #region Now    

    #region Other

    public static Transform NowEnterContent;
    public static int VFlip = 1;
    public static bool CanBuy = false;

    public static E_NowPointerLocation e_NowPointerLocation = E_NowPointerLocation.None;
    public static E_PlayerLocation e_NowPlayerLocation = E_PlayerLocation.None;

    #endregion

    #region Dynamic

    public static int PaddingIndex
    {
        get
        {
            if (PaddingContentStep_ == null)
            {
                return 0;
            }

            return PaddingContentStep_.GetComponent<RectTransform>().GetSiblingIndex();
        }
    }
    public static E_WSAD e_PaddingArrowDirection;
    public static DynamicContentStep PaddingContentStep_;
    /// <summary>
    /// 现在进入的DynamicScrollView 现用于 存档 角色名册 城镇箱子 的 动态改变位置
    /// </summary>
    public static PanelBaseDynamicScrollView NowPanelBaseDynamicScrollView_ = null;

    #endregion

    #region GameArchive

    public static int NowIndexCellGameArchive = -1;

    #endregion

    #region Editor

    public static E_MapObject e_ChoseObj = E_MapObject.None;
    public static E_CellMiniMap e_ChoseRoom = E_CellMiniMap.None;
    /// <summary>
    /// 现在进入的RoomEditor Grid
    /// </summary>
    public static PanelGridRoomEditor NowEnterGridRoomEditor;
    /// <summary>
    /// 现在进入的RoomEditor Cell
    /// </summary>
    public static PanelCellRoomEditor NowEnterCellRoomEditor;
    /// <summary>
    /// 现在选择的RoomEditor Cell
    /// </summary>
    public static PanelCellRoomEditor ChoseCellRoomEditor;
    /// <summary>
    /// 现在的编辑器属于哪个MiniMap Cell
    /// </summary>
    public static PanelCellMiniMapEditor NowEditorDependency;
    /// <summary>
    /// 现在进入的MiniMap编辑器背景Grid
    /// </summary>
    public static PanelBaseGrid<PanelCellMiniMapEditor> NowEnterGridMiniMapEditor;
    /// <summary>
    /// 现在进入的MiniMap编辑器Cell      
    /// </summary>
    public static PanelCellMiniMapEditor NowEnterCellMiniMapEditor;
    /// <summary>
    /// 现在选择的MiniMap编辑器Cell
    /// </summary>
    public static PanelCellMiniMapEditor ChoseCellMiniMapEditor;

    public static PanelCellRoleConfig NowEnterCellRoleConfig;
    public static PanelGridRoleConfig NowEnterGridRoleConfig;
    public static PanelCellRoleConfig ChoseCellRoleConfig;

    #endregion

    #region Expedition

    public static PanelCellExpeditionEvent NowExpeditionEvent;
    public static PanelCellExpeditionMiniMap NowInCellExpeditionMiniMap;
    public static PanelGridExpeditionRoom NowEnterGridExpeditionRoom;
    public static PanelCellExpeditionRoom ChoseCellExpeditionRoom;

    #endregion

    #region Role

    public static PanelCellExpeditionRolePrepareRoot NowEnterExpeditionRolePrepareRoot;
    public static PanelCellRolePortraitCanDrag ReplaceRolePortraitCanDrag;
    public static PanelCellRolePortraitCanDrag DragingRolePortraitCanDrag;
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
    public static PanelGridTownItem NowEnterGridItem = null;

    #endregion

    #endregion

    #region Function

    public static Sprite LoadSprite(E_Res p_e_name)
    {
        return MgrRes_.Load<Sprite>("Art/" + p_e_name);
    }
    public static Sprite LoadSprite(string p_name)
    {
        return MgrRes_.Load<Sprite>("Art/" + p_name);
    }

    public static GameObject CreateContentStepY(int p_index, Transform p_father)
    {
        GameObject obj = MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep");
        obj.transform.SetParent(p_father, false);
        obj.name = p_index.ToString();
        GridLayoutGroup glg = obj.AddComponent<GridLayoutGroup>();
        glg.constraint = GridLayoutGroup.Constraint.FixedRowCount;
        glg.constraintCount = 1;
        glg.childAlignment = TextAnchor.MiddleCenter;
        glg.cellSize = new(BodyGrid.X, BodyGrid.Y);

        return obj;
    }

    public static GameObject CreateContentStepX(int p_index, Transform p_father)
    {
        GameObject obj = MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep");
        obj.transform.SetParent(p_father.transform, false);
        obj.name = p_index.ToString();

        return obj;
    }

    #endregion
}
