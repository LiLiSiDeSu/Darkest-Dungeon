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
    /// AddMapSize 和 ReduceMapSize按下一次增加或减少的值
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

    public static Vector2 SizeCellItemBody = new(40, 40);

    public static Dictionary<E_PanelCellTownStore, Vector2> DicStoreBody = new()
    {
        { E_PanelCellTownStore.StoreWood, new Vector2(10, 5) },
        { E_PanelCellTownStore.StoreIron, new Vector2(12, 10) },
        { E_PanelCellTownStore.StoreGold, new Vector2(15, 13) },
    };

    public static Dictionary<E_SpriteNamePanelCellItem, Vector2> DicItemBody = new()
    {
        { E_SpriteNamePanelCellItem.ItemFoodCookie, new Vector2(1, 1) },
        { E_SpriteNamePanelCellItem.ItemFoodApple, new Vector2(3, 3) },
        { E_SpriteNamePanelCellItem.ItemFoodBread, new Vector2(1, 2) },

        { E_SpriteNamePanelCellItem.ItemFoodRawBeef, new Vector2(2, 3) },
        { E_SpriteNamePanelCellItem.ItemFoodCookedBeef, new Vector2(2, 3) },

        { E_SpriteNamePanelCellItem.ItemFoodRawChicken, new Vector2(2, 2) },
        { E_SpriteNamePanelCellItem.ItemFoodCoodedChicken, new Vector2(2, 2) },

        { E_SpriteNamePanelCellItem.ItemFoodRawMutton, new Vector2(2, 2) },
        { E_SpriteNamePanelCellItem.ItemFoodCoodedMutton, new Vector2(2, 2) },               

        { E_SpriteNamePanelCellItem.ItemFoodRawPotato, new Vector2(2, 2) },     
        { E_SpriteNamePanelCellItem.ItemFoodCookedPotato, new Vector2(2, 2) },        
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
    
    public static PanelOtherMapEditor PanelOtherMapEditor_
    {
        get { return MgrUI_.GetPanel<PanelOtherMapEditor>("PanelOtherMapEditor"); }
    }
    public static PanelExpeditionMiniMap PanelExpeditionMiniMap_
    {
        get { return MgrUI_.GetPanel<PanelExpeditionMiniMap>("PanelExpeditionMiniMap"); }
    }
    public static PanelExpeditionPrepare PanelExpeditionPrepare_
    {
        get { return MgrUI_.GetPanel<PanelExpeditionPrepare>("PanelExpeditionPrepare"); }
    }
    public static PanelRoleGuildRecruit PanelRoleGuildRecruit_
    {
        get { return MgrUI_.GetPanel<PanelRoleGuildRecruit>("PanelRoleGuildRecruit"); }
    }
    public static PanelRoleGuildRecruitCost PanelRoleGuildRecruitCost_
    {
        get { return MgrUI_.GetPanel<PanelRoleGuildRecruitCost>("PanelRoleGuildRecruitCost"); }
    }
    public static PanelOtherSetting PanelOtherSetting_
    {
        get { return MgrUI_.GetPanel<PanelOtherSetting>(""); }        
    }
    public static PanelBarExpedition PanelBarExpedition_
    {
        get { return MgrUI_.GetPanel<PanelBarExpedition>("PanelBarExpedition"); }
    }
    public static PanelBarTown PanelBarTown_
    {
        get { return MgrUI_.GetPanel<PanelBarTown>("PanelBarTown"); }
    }
    public static PanelRoleDetails PanelRoleDetails_
    {
        get { return MgrUI_.GetPanel<PanelRoleDetails>("PanelRoleDetails"); }
    }
    public static PanelRoleList PanelRoleList_
    {
        get { return MgrUI_.GetPanel<PanelRoleList>("PanelRoleList"); }
    }
    /// <summary>
    /// 所有城镇箱子面板
    /// </summary>
    public static PanelTownStore PanelTownStore_
    {
        get { return MgrUI_.GetPanel<PanelTownStore>("PanelTownStore"); }
    }    
    public static PanelOhterResTable PanelOtherResTable_
    {
        get { return MgrUI_.GetPanel<PanelOhterResTable>("PanelOhterResTable"); }
    }    
    public static PanelGameArchiveChoose PanelGameArchiveChoose_
    {
        get { return MgrUI_.GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose"); }
    }    
    public static PanelOtherDestroyArchiveHint PanelOtherDestroyArchiveHint_
    {
        get { return MgrUI_.GetPanel<PanelOtherDestroyArchiveHint>("PanelOtherDestroyArchiveHint"); }
    }
    /// <summary>
    /// 城镇商店
    /// </summary>
    public static PanelRoomTownShop PanelRoomTownShop_
    {
        get { return MgrUI_.GetPanel<PanelRooms>("PanelRooms").AllPanel["PanelRoomTownShop"] as PanelRoomTownShop; }
    }
    /// <summary>
    /// 城镇商店面板在存档里的Data
    /// </summary>
    public static List<DataContainer_CellItem> DataPanelTownShopItem
    {
        get { return DataNowCellGameArchive.ListCellShopItem; }
    }
    /// <summary>
    /// 城镇商店花费面板
    /// </summary>
    public static PanelTownShopCost PanelShopCost_
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
    
    public static E_CellExpeditionMiniMapHall e_NowChooseHall = E_CellExpeditionMiniMapHall.None;
    public static E_CellExpeditionMiniMapRoom e_NowChooseRoom = E_CellExpeditionMiniMapRoom.None;
    public static E_ArrowDirection e_PaddingArrowDirection;
    public static DynamicContentStep PaddingContentStep_;
    /// <summary>
    /// 现在进入的DynamicScrollView 现用于 存档 角色名册 城镇箱子 的 动态改变位置
    /// </summary>
    public static PanelBaseDynamicScrollView NowPanelBaseDynamicScrollView_ = null;
    /// <summary>
    /// 现在选中的物品
    /// </summary>
    public static PanelCellItem NowCellItem = null;
    /// <summary>
    /// 现在拖动的角色招募PanelCell
    /// </summary>
    public static PanelCellRoleRecruit DragingPanelCellRoleRecruit;
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
    /// 拖拽的箱子
    /// </summary>
    public static PanelCellTownStore DragingTownStore;
    /// <summary>
    /// 现在进入的可以存储Item的面板
    /// </summary>
    public static PanelBaseVector2Store NowPanelCanStoreItem;
    /// <summary>
    /// 当前存档的Index
    /// </summary>
    public static int NowIndexCellGameArchive = -1;
    /// <summary>
    /// 现在鼠标所在的区域
    /// </summary>
    public static E_NowPointerLocation e_NowPointerLocation = E_NowPointerLocation.None;  
    /// <summary>
    /// 现在玩家所在的区域(从开发者视角来看)
    /// </summary>
    public static E_PlayerLocation e_NowPlayerLocation = E_PlayerLocation.None;    

    #endregion
}
