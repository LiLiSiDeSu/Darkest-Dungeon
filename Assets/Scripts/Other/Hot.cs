using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class Hot
{
    /// <summary>
    /// 快捷得到MgrUI
    /// </summary>
    public static MgrUI MgrUI_
    {
        get { return MgrUI.GetInstance(); }
    }
    /// <summary>
    /// 快捷得到Data
    /// </summary>
    public static Data Data_
    {
        get { return Data.GetInstance(); }
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
    /// <summary>
    /// 现在读取的存档
    /// </summary>
    public static DataContainer_PanelCellGameArchive NowCellGameArchive
    {
        get { return Data_.DataListCellGameArchive[IndexNowCellGameArchive]; }
    }
    /// <summary>
    /// 现在读取的存档的Index
    /// </summary>
    public static int IndexNowCellGameArchive
    {
        get { return MgrUI_.GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose").IndexNowCellGameArchive; }

        set { MgrUI_.GetPanel<PanelGameArchiveChoose>("PanelGameArchiveChoose").IndexNowCellGameArchive = value; }
    }
    //---
    /// <summary>
    /// 城镇商店
    /// </summary>
    public static PanelRoomTownShop PanelRoomTownShop_
    {
        get { return MgrUI_.GetPanel<PanelRooms>("PanelRooms").AllPanel["PanelRoomTownShop"] as PanelRoomTownShop; }
    }
    /// <summary>
    /// 城镇商店花费面板
    /// </summary>
    public static PanelShopCost PanelShopCost_
    {
        get { return PanelRoomTownShop_.PanelShopCost_; }
    }
    /// <summary>
    /// 诚征商店面板
    /// </summary>
    public static PanelTownShopItem PanelTownShopItem_
    {
        get { return PanelRoomTownShop_.PanelTownShopItem_; }
    }

    public static PanelMinistrantPoPoCat PanelMinistrantPoPoCat_
    {
        get { return PanelRoomTownShop_.PanelMinistrantPoPoCat_; }
    }
    //---
    public static PanelTownStore PanelTownStore_
    {
        get { return MgrUI_.GetPanel<PanelTownStore>("PanelTownStore"); }
    }    
    /// <summary>
    /// 现在打开的城镇仓库
    /// </summary>
    public static PanelCellTownStore NowPanelCellTownStore
    {
        get { return PanelTownStore_.NowPanelCellTownStore; }                            
    }
    /// <summary>
    /// 现在打开的物品栏
    /// </summary>
    public static PanelTownItem NowPanelTownItem
    {
        get { return NowPanelCellTownStore.PanelCellItem_; }
    }
    //---
    public static PanelStoreAncestralProperty PanelStoreAncestralProperty_
    {
        get { return MgrUI_.GetPanel<PanelStoreAncestralProperty>("PanelStoreAncestralProperty"); }
    }

    public static PanelStoreCoin PanelStoreCoin_
    {
        get { return MgrUI_.GetPanel<PanelStoreCoin>("PanelStoreCoin"); }
    }
    //---
    /// <summary>
    /// 拖拽的物品
    /// </summary>
    public static PanelCellTownItem NowItem;
    /// <summary>
    /// 拖拽的箱子
    /// </summary>
    public static PanelCellTownStore DragingTownStore;
    /// <summary>
    /// 光标所在地区
    /// </summary>
    public static E_Location e_NowPointerLocation = E_Location.None;
}
