using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public static class Hot
{
    public static GraphicRaycaster raycaster;
    public static PointerEventData pointerData;

    #region Config

    public static int StepSanity = 10;

    /// <summary>
    /// ��TranslateNum�Ļ��������ӵı���
    /// </summary>
    public static int AddTranslateRate = 4;
    /// <summary>
    /// ���ڵ�ת������
    /// </summary>
    public static int NowTranslateRate = 1;

    /// <summary>
    /// Add �� Reduce����һ�����ӻ���ٵ�ֵ
    /// </summary>
    public static float ValueChangeMapSize = 0.4f;

    /// <summary>
    /// �����ȼ���������ľ���
    /// </summary>
    public static List<int> ListNeedExperienceToUpLevel = new()
    {
        50,
        55,
        60,
        90,
        100,
        130
    };

    public static Dictionary<E_RoleName, RoleConfig> DicRoleConfig = new()
    {
        { E_RoleName.LiLiSi, new() { StoreSize = new(20, 7) } },
        { E_RoleName.Crusader, new() { StoreSize = new(20, 9) } },
        { E_RoleName.PlagueDoctor, new() { StoreSize = new(15, 6) } },
    };

    #region Body

    public static my_Vector2 BodySizeMap = new(48, 18);
    public static my_Vector2 BodySizeGrid = new(40, 40);
    public static my_Vector2 BodySizeCellItem = new(40, 40);
    public static my_Vector2 BodySizeCellMinimap = new(40, 40);

    public static Dictionary<E_MapObject, my_Vector2> BodyDicMapObject = new()
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
    
    public static Dictionary<E_CellMiniMap, my_Vector2> BodyDicCellMiniMap = new()
    {
        { E_CellMiniMap.CellMiniMapRoomBoss, new(4, 4) },
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

    public static Dictionary<E_PanelCellTownStore, my_Vector2> BodyDicStore = new()
    {
        { E_PanelCellTownStore.StoreWood, new(10, 5) },
        { E_PanelCellTownStore.StoreIron, new(12, 10) },
        { E_PanelCellTownStore.StoreGold, new(15, 13) },
    };

    public static Dictionary<E_SpriteNamePanelCellItem, my_Vector2> BodyDicItem = new()
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

    #region ��ݵõ�BaseFrameWork��Ľű�

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

    public static PanelExpeditionRoleDetails PanelExpeditionRoleDetails_
    {
        get { return MgrUI_.GetPanel<PanelExpeditionRoleDetails>("PanelExpeditionRoleDetails"); }
    }
    public static PanelExpeditionRoom PanelExpeditionRoom_
    {
        get { return MgrUI_.GetPanel<PanelExpeditionRoom>("PanelExpeditionRoom"); }
    }
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
    public static PanelOtherMiniMapEditor PanelOtherMiniMapEditor_
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
    /// ���г����������
    /// </summary>
    public static PanelTownStore PanelTownStore_
    {
        get { return MgrUI_.GetPanel<PanelTownStore>("PanelTownStore"); }
    }

    #region TownShop

    /// <summary>
    /// �����̵껨�����
    /// </summary>
    public static PanelTownShopCost PanelTownShopCost_
    {
        get { return MgrUI_.GetPanel<PanelTownShopCost>("PanelTownShopCost"); }
    }
    /// <summary>
    /// �����̵������PoPoCat
    /// </summary>
    public static PanelMinistrantPoPoCat PanelMinistrantPoPoCat_
    {
        get { return MgrUI_.GetPanel<PanelMinistrantPoPoCat>("PanelMinistrantPoPoCat"); }
    }
    /// <summary>
    /// �����̵����
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
    /// ���ڶ�ȡ�Ĵ浵Data
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
    /// ����������ڵ�����
    /// </summary>
    public static E_NowPointerLocation e_NowPointerLocation = E_NowPointerLocation.None;
    /// <summary>
    /// ����������ڵ�����(�ӿ������ӽ�����)
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
    /// ���ڽ����DynamicScrollView ������ �浵 ��ɫ���� �������� �� ��̬�ı�λ��
    /// </summary>
    public static PanelBaseDynamicScrollView NowPanelBaseDynamicScrollView_ = null;

    #endregion

    #region GameArchive

    /// <summary>
    /// ��ǰ�浵��Index
    /// </summary>
    public static int NowIndexCellGameArchive = -1;

    #endregion

    #region Editor

    public static E_MapObject e_ChoseObj = E_MapObject.None;
    public static E_CellMiniMap e_ChoseRoom = E_CellMiniMap.None;
    /// <summary>
    /// ���ڽ����RoomEditor Grid
    /// </summary>
    public static PanelGridRoomEditor NowEnterGridRoomEditor;
    /// <summary>
    /// ���ڽ����RoomEditor Cell
    /// </summary>
    public static PanelCellRoomEditor NowEnterCellRoomEditor;
    /// <summary>
    /// ����ѡ���RoomEditor Cell
    /// </summary>
    public static PanelCellRoomEditor ChoseCellRoomEditor;
    /// <summary>
    /// ���ڵı༭�������ĸ�MiniMap Cell
    /// </summary>
    public static PanelCellMiniMapEditor NowEditorDependency = null;
    /// <summary>
    /// ���ڽ����MiniMap�༭������Grid
    /// </summary>
    public static PanelBaseGrid<PanelCellMiniMapEditor> NowEnterGridMiniMapEditor = null;
    /// <summary>
    /// ���ڽ����MiniMap�༭��Cell      
    /// </summary>
    public static PanelCellMiniMapEditor NowEnterCellMiniMapEditor = null;
    /// <summary>
    /// ����ѡ���MiniMap�༭��Cell
    /// </summary>
    public static PanelCellMiniMapEditor ChoseCellMiniMapEditor = null;

    #endregion

    #region Expedition

    public static PanelCellExpeditionEvent NowExpeditionEvent;    
    public static PanelCellExpeditionMiniMap NowEnterCellExpeditionMiniMap;
    public static PanelGridExpeditionRoom NowEnterGridExpeditionRoom;
    public static PanelCellExpeditionRoom NowEnterCellExpeditionRoom;

    #endregion

    #region Role

    public static PanelCellExpeditionRolePrepareRoot NowEnterExpeditionRolePrepareRoot;
    public static PanelCellRolePortraitCanDrag ReplaceRolePortraitCanDrag;
    public static PanelCellRolePortraitCanDrag DragingRolePortraitCanDrag;
    /// <summary>
    /// �����϶��Ľ�ɫ��ļPanelCell
    /// </summary>
    public static PanelCellRoleRecruit DragingPanelCellRoleRecruit;

    #endregion

    #region Item

    /// <summary>
    /// ��ק������
    /// </summary>
    public static PanelCellTownStore DragingTownStore;
    /// <summary>
    /// ���ڽ���Ŀ��Դ洢Item�����
    /// </summary>
    public static PanelBaseVector2Store NowPanelCanStoreItem;
    /// <summary>
    /// ����ѡ�е���Ʒ
    /// </summary>
    public static PanelCellItem ChoseCellItem = null;
    /// <summary>
    /// ���ڽ������Ʒ��������
    /// </summary>
    public static PanelGridTownItem NowEnterCellGridItem = null;

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
        glg.cellSize = new(BodySizeGrid.X, BodySizeGrid.Y);

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