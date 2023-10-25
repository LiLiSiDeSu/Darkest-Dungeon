using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class Hot
{
    #region 配置

    public static int StepSanity = 10;

    public static List<int> ListNeedExperienceToUpLevel = new List<int>()
    {
        50,
        55,
        60,
        90,
        100,
        130
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

    /// <summary>
    /// 角色清单面板
    /// </summary>
    public static PanelRoleList PanelRole_
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
    /// <summary>
    /// 资源面板
    /// </summary>
    public static PanelOhterResTable PanelOtherResTable_
    {
        get { return MgrUI_.GetPanel<PanelOhterResTable>("PanelOhterResTable"); }
    }
    /// <summary>
    /// 存档选择面板
    /// </summary>
    public static PanelGameArchiveChoose PanelGameArchiveChoose_
    {
        get { return MgrUI_.GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose"); }
    }
    /// <summary>
    /// 删除存档提示面板
    /// </summary>
    public static PanelOtherDestroyArchiveHint PanelOtherDestroyArchiveHint_
    {
        get { return MgrUI_.GetPanel<PanelOtherDestroyArchiveHint>("PanelOtherDestroyArchiveHint"); }
    }

    #endregion

    #region 城镇商店

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
        get { return PanelRoomTownShop_.PanelShopCost_; }
    }
    /// <summary>
    /// 城镇商店面板娘PoPoCat
    /// </summary>
    public static PanelMinistrantPoPoCat PanelMinistrantPoPoCat_
    {
        get { return PanelRoomTownShop_.PanelMinistrantPoPoCat_; }
    }
    /// <summary>
    /// 城镇商店面板
    /// </summary>
    public static PanelTownShopItem PanelTownShopItem_
    {
        get { return PanelRoomTownShop_.PanelTownShopItem_; }
    }

    #endregion

    #region Data

    public static DataContainer_ResTable DataPanelResTable
    {
        get { return DataNowCellGameArchive.PanelResTable; }
    }
    public static DataContainer_CellTownStore DataNowPanelStore
    {
        get
        {
            if (NowPanelItem != null && NowPanelItem is PanelTownItem)
            {
                return DataNowCellGameArchive.ListCellStore[(NowPanelItem as PanelTownItem).FatherPanelCellTownStore.Index];
            }
            return null;
        }
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

    /// <summary>
    /// 在TranslateNum的基础上添加的倍率
    /// </summary>
    public static int AddTranslateRate = 4;
    /// <summary>
    /// 现在的转换倍率
    /// </summary>
    public static int NowTranslateRate = 1;
    /// <summary>
    /// 拖拽的物品
    /// </summary>
    public static PanelCellTownItem DragingItem;
    /// <summary>
    /// 光标进入的物品
    /// </summary>
    public static PanelCellTownItem NowItem;
    /// <summary>
    /// 拖拽的箱子
    /// </summary>
    public static PanelCellTownStore DragingTownStore;
    /// <summary>
    /// 光标所在地区
    /// </summary>
    /// <summary>
    /// 现在读取的存档的Index
    /// </summary>
    public static int NowIndexCellGameArchive = -1;
    /// <summary>
    /// 光标现在区域的类型
    /// </summary>
    public static E_Location e_NowPointerLocation = E_Location.None;
    /// <summary>
    /// 现在进入的PanelItem
    /// </summary>
    public static PanelBaseItem NowPanelItem;

    #endregion

    /// <summary>
    /// 添加Item到指定Cotent
    /// </summary>
    /// <param name="e_AddLocation">添加到哪里</param>
    public static void AddItem(E_Location e_AddLocation)
    {
        switch (e_AddLocation)
        {
            case E_Location.PanelTownItem:
                DragingItem.transform.SetParent(NowPanelItem.Content, false);
                DragingItem.e_Location = E_Location.PanelTownItem;
                DragingItem.Index = NowPanelItem.NowIndex++;
                DataNowPanelStore.ListCellStoreItem.Add
                    (new DataContainer_CellItem(E_Location.PanelTownItem, DragingItem.e_SpriteNamePanelCellItem));                
                break;
            case E_Location.PanelTownShopItem:
                DragingItem.transform.SetParent(PanelTownShopItem_.Content, false);
                DragingItem.e_Location = E_Location.PanelTownShopItem;
                DragingItem.Index = PanelTownShopItem_.NowIndex++;
                DataPanelTownShopItem.Add
                    (new DataContainer_CellItem(E_Location.PanelTownShopItem, DragingItem.e_SpriteNamePanelCellItem));                
                break;
        }                      
    }
}
