using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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
    /// 现在读取的存档Data
    /// </summary>
    public static DataContainer_PanelCellGameArchive DataNowCellGameArchive
    {
        get { return Data_.DataListCellGameArchive[NowIndexCellGameArchive]; }
    }
    /// <summary>
    /// 现在读取的存档的Index
    /// </summary>
    public static int NowIndexCellGameArchive
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
    /// 城镇商店面板在存档里的Data
    /// </summary>
    public static List<DataContainer_PanelCellItem> DataPanelTownShopItem
    {
        get { return DataNowCellGameArchive.DataListCellShopItem; }
    }
    /// <summary>
    /// 诚征商店面板
    /// </summary>
    public static PanelTownShopItem PanelTownShopItem_
    {
        get { return PanelRoomTownShop_.PanelTownShopItem_; }
    }
    /// <summary>
    /// 城镇商店面板娘PoPoCat
    /// </summary>
    public static PanelMinistrantPoPoCat PanelMinistrantPoPoCat_
    {
        get { return PanelRoomTownShop_.PanelMinistrantPoPoCat_; }
    }
    /// <summary>
    /// 城镇仓库面板
    /// </summary>
    public static PanelTownStore PanelTownStore_
    {
        get { return MgrUI_.GetPanel<PanelTownStore>("PanelTownStore"); }
    }    
    /// <summary>
    /// 现在打开的诚征仓库面板Data
    /// </summary>
    public static List<DataContainer_PanelCellItem> DataNowPanelTownItem
    {
        get { return DataNowPanelCellTownStore.DataListCellStoreItem; }
    }
    /// <summary>
    /// 现在打开的城镇仓库在存档中对应的Data
    /// </summary>
    public static DataContainer_PanelCellTownStore DataNowPanelCellTownStore
    {
        get { return DataNowCellGameArchive.DataListCellStore[NowIndexPanelCellTownStore]; }
    }
    /// <summary>
    /// 现在打开的城镇仓库的Index
    /// </summary>
    public static int NowIndexPanelCellTownStore
    {
        get { return NowPanelCellTownStore.Index; }
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

    /// <summary>
    /// 添加Item到指定Cotent
    /// </summary>
    /// <param name="e_AddLocation">添加到哪里</param>
    public static void AddItem(E_Location e_AddLocation)
    {
        int SoureceIndex = NowItem.Index;
        E_Location e_SourceLocation = NowItem.e_Location;

        switch (e_AddLocation)
        {
            case E_Location.PanelTownItem:
                NowItem.transform.SetParent(NowPanelTownItem.Content, false);
                NowItem.e_Location = E_Location.PanelTownItem;
                NowItem.Index = NowPanelTownItem.NowIndex++;
                DataNowPanelCellTownStore.DataListCellStoreItem.Add(MakeItemDataBySourceItem(e_SourceLocation, SoureceIndex));
                DestroySourceItemData(e_SourceLocation, SoureceIndex);
                break;
            case E_Location.PanelTownShopItem:
                NowItem.transform.SetParent(PanelTownShopItem_.Content, false);
                NowItem.e_Location = E_Location.PanelTownShopItem;
                NowItem.Index = PanelTownShopItem_.NowIndex++;
                DataPanelTownShopItem.Add(MakeItemDataBySourceItem(e_SourceLocation, SoureceIndex));
                DestroySourceItemData(e_SourceLocation, SoureceIndex);
                break;
        }                      
    }

    public static DataContainer_PanelCellItem MakeItemDataBySourceItem(E_Location e_SourceLocation, int SoureceIndex)
    {        
        switch (e_SourceLocation)
        {
            case E_Location.PanelTownItem:
                NowPanelTownItem.NowIndex--;
                return DataNowPanelTownItem[SoureceIndex];                
            case E_Location.PanelTownShopItem:
                PanelTownShopItem_.NowIndex--;
                return DataPanelTownShopItem[SoureceIndex];                
        }

        return null;
    }

    private static void DestroySourceItemData(E_Location e_SourceLocation, int SoureceIndex)
    {
        switch (e_SourceLocation)
        {
            case E_Location.PanelTownItem:
                DataNowPanelTownItem.RemoveAt(SoureceIndex);
                break;
            case E_Location.PanelTownShopItem:
                DataPanelTownShopItem.RemoveAt(SoureceIndex);
                break;
        }
    }
}
