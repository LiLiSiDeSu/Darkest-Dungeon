using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class Hot
{

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

    public static DataContainer_PanelResTable DataPanelResTable
    {
        get { return DataNowCellGameArchive.PanelResTable; }
    }
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
    public static DataContainer_PanelResTable DataPanelResTable_
    {
        get { return DataNowCellGameArchive.PanelResTable; }
    }

    #endregion

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
    public static List<DataContainer_PanelCellItem> DataPanelTownShopItem
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

    /// <summary>
    /// 所有城镇箱子面板
    /// </summary>
    public static PanelTownStore PanelTownStore_
    {
        get { return MgrUI_.GetPanel<PanelTownStore>("PanelTownStore"); }
    }    
    /// <summary>
    /// 现在打开的城镇箱子在存档中对应的Data
    /// </summary>
    public static DataContainer_PanelCellTownStore DataNowPanelCellTownStore
    {
        get { return DataNowCellGameArchive.ListCellStore[NowIndexPanelCellTownStore]; }
    }
    /// <summary>
    /// 现在打开的城镇箱子的Index
    /// </summary>
    public static int NowIndexPanelCellTownStore
    {
        get { return NowPanelCellTownStore.Index; }
    }
    /// <summary>
    /// 现在打开的箱子
    /// </summary>
    public static PanelCellTownStore NowPanelCellTownStore
    {
        get { return PanelTownStore_.NowPanelCellTownStore; }
        set { PanelTownStore_.NowPanelCellTownStore = value; }
    }
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
    public static E_Location e_NowPointerLocation = E_Location.None;

    /// <summary>
    /// 添加Item到指定Cotent
    /// </summary>
    /// <param name="e_AddLocation">添加到哪里</param>
    public static void AddItem(E_Location e_AddLocation)
    {
        int SoureceIndex = DragingItem.Index;
        E_Location e_SourceLocation = DragingItem.e_Location;

        switch (e_AddLocation)
        {
            case E_Location.PanelTownItem:
                DragingItem.transform.SetParent(NowPanelCellTownStore.PanelCellItem_.Content, false);
                DragingItem.e_Location = E_Location.PanelTownItem;
                DragingItem.Index = NowPanelCellTownStore.PanelCellItem_.NowIndex++;
                DataNowPanelCellTownStore.DataListCellStoreItem.Add
                    (new DataContainer_PanelCellItem(E_Location.PanelTownItem, DragingItem.e_SpriteNamePanelCellItem));
                DestroySourceItemData(e_SourceLocation, SoureceIndex);
                break;
            case E_Location.PanelTownShopItem:
                DragingItem.transform.SetParent(PanelTownShopItem_.Content, false);
                DragingItem.e_Location = E_Location.PanelTownShopItem;
                DragingItem.Index = PanelTownShopItem_.NowIndex++;
                DataPanelTownShopItem.Add
                    (new DataContainer_PanelCellItem(E_Location.PanelTownShopItem, DragingItem.e_SpriteNamePanelCellItem));
                DestroySourceItemData(e_SourceLocation, SoureceIndex);
                break;
        }                      
    }

    private static void DestroySourceItemData(E_Location e_SourceLocation, int SoureceIndex)
    {
        switch (e_SourceLocation)
        {
            case E_Location.PanelTownItem:
                NowPanelCellTownStore.PanelCellItem_.NowIndex--;
                DataNowPanelCellTownStore.DataListCellStoreItem.RemoveAt(SoureceIndex);
                break;
            case E_Location.PanelTownShopItem:
                PanelTownShopItem_.NowIndex--;
                DataPanelTownShopItem.RemoveAt(SoureceIndex);
                break;
        }
    }
}
