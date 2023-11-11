using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public sealed class GenerateDefaultGameArchiveData : MonoBehaviour
{                          
    private static int DefaultGameArchiveDataCount = 10;

    [MenuItem("-Tools-/Generate/DefaultGameArchiveData #&%_1", false, 1)]
    private static void Generate()
    {
        MgrJson.GetInstance().filePath = Application.persistentDataPath + "/Data/JsonData";
        Data.GetInstance().PathGameArchiveData = "/GameArchiveData";

        List<DataContainer_PanelCellGameArchive> GameArchiveDataCellList = new List<DataContainer_PanelCellGameArchive>();

        for (int i = 0; i < DefaultGameArchiveDataCount; i++)
        {
            GameArchiveDataCellList.Add(new DataContainer_PanelCellGameArchive());
        }

        #region TestData

        GameArchiveDataCellList[0].ListCellStore = new List<DataContainer_CellTownStore>()
        {
            new DataContainer_CellTownStore(E_PanelCellTownStore.StoreIron),
            new DataContainer_CellTownStore(E_PanelCellTownStore.StoreIron),
            new DataContainer_CellTownStore(E_PanelCellTownStore.StoreWood),
            new DataContainer_CellTownStore(E_PanelCellTownStore.StoreGold),
            new DataContainer_CellTownStore(E_PanelCellTownStore.StoreIron),
            new DataContainer_CellTownStore(E_PanelCellTownStore.StoreIron),
            new DataContainer_CellTownStore(E_PanelCellTownStore.StoreIron),
            new DataContainer_CellTownStore(E_PanelCellTownStore.StoreIron),
            new DataContainer_CellTownStore(E_PanelCellTownStore.StoreIron),
        };

        GameArchiveDataCellList[0].ListCellStore[0].ListCellStoreItem = new List<DataContainer_CellItem>()
        {
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodCookie),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodRawPotato),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodRawChicken),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodCookie),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodApple),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodCookie),
        };
        GameArchiveDataCellList[0].ListCellStore[1].ListCellStoreItem = new List<DataContainer_CellItem>()
        {
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodCookie),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodCookie),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodCookie),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodCookie),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodCookie),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodCookie),
        };
        GameArchiveDataCellList[0].ListCellStore[2].ListCellStoreItem = new List<DataContainer_CellItem>()
        {
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodApple),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodApple),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodApple),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodApple),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodApple),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodApple),
        };

        GameArchiveDataCellList[0].ListCellShopItem = new List<DataContainer_CellItem>()
        {
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodCookie),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodRawPotato),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodRawChicken),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodCookie),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodApple),
            new DataContainer_CellItem(E_Location.TownItem, E_PanelCellItem.ItemFoodCookie),
        };

        GameArchiveDataCellList[0].ListCellRole = new List<DataContainer_CellRole>()
        {
            new DataContainer_CellRole(E_RoleName.Crusader, E_RoleStatus.None, "cao1", 2, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_RoleName.LiLiSi, E_RoleStatus.None, "cao2", 3, 99, 30, 29, 200, 10),
            new DataContainer_CellRole(E_RoleName.Crusader, E_RoleStatus.None, "cao3", 4, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_RoleName.LiLiSi, E_RoleStatus.None, "cao4", 4, 99, 1, 46, 200, 1),
            new DataContainer_CellRole(E_RoleName.LiLiSi, E_RoleStatus.None, "cao5", 2, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_RoleName.Crusader, E_RoleStatus.None, "cao6", 3, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_RoleName.Crusader, E_RoleStatus.None, "cao7", 2, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_RoleName.LiLiSi, E_RoleStatus.None, "cao8", 1, 99, 40, 50, 200, 3),
            new DataContainer_CellRole(E_RoleName.LiLiSi, E_RoleStatus.None, "cao9", 0, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_RoleName.LiLiSi, E_RoleStatus.None, "cao10", 2, 99, 40, 10, 200, 2),
        };

        GameArchiveDataCellList[0].ResTable = new DataContainer_ResTable(10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000);

        GameArchiveDataCellList[0].ListCellRoleRecruit = new List<DataContainer_CellRoleRecruit>()
        {
            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.Crusader, E_RoleStatus.None, "cao1", 2, 99, 40, 46, 200, 10),
             new DataContainer_CoinCost(2, 3, 4, 5)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.LiLiSi, E_RoleStatus.None, "cao10", 2, 99, 40, 10, 200, 2),
             new DataContainer_CoinCost(22, 3, 34, 51)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.Crusader, E_RoleStatus.None, "cao5", 2, 99, 40, 46, 200, 10),
             new DataContainer_CoinCost(232, 332, 411, 55)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.LiLiSi, E_RoleStatus.None, "cao4", 4, 99, 1, 46, 200, 1),
             new DataContainer_CoinCost(22, 31, 42, 523)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.Crusader, E_RoleStatus.None, "cao3", 4, 99, 40, 46, 200, 10),
             new DataContainer_CoinCost(22, 31, 42, 523)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.LiLiSi, E_RoleStatus.None, "cao4", 4, 99, 1, 46, 200, 1),
             new DataContainer_CoinCost(22, 31, 42, 523)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.Crusader, E_RoleStatus.None, "cao4", 4, 99, 1, 46, 200, 1),
             new DataContainer_CoinCost(22, 31, 42, 523)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.Crusader, E_RoleStatus.None, "cao4", 4, 99, 1, 46, 200, 1),
             new DataContainer_CoinCost(22, 31, 42, 523))
        };

        GameArchiveDataCellList[0].Expedition = new DataContainer_Expedition(
        new List<DataContainer_Map>()
        {
            new DataContainer_Map(E_DungeonLevel.Zero, E_DungeonSize.Middle, E_ExpeditionEvent.Boss1),
            new DataContainer_Map(E_DungeonLevel.One, E_DungeonSize.Large, E_ExpeditionEvent.Boss1),
            new DataContainer_Map(E_DungeonLevel.Blood, E_DungeonSize.Middle, E_ExpeditionEvent.Boss1),
            new DataContainer_Map(E_DungeonLevel.Zero, E_DungeonSize.Small, E_ExpeditionEvent.Boss1),
            new DataContainer_Map(E_DungeonLevel.Zero, E_DungeonSize.Large, E_ExpeditionEvent.Boss1),
            new DataContainer_Map(E_DungeonLevel.One, E_DungeonSize.Middle, E_ExpeditionEvent.Boss1),
            new DataContainer_Map(E_DungeonLevel.One, E_DungeonSize.Small, E_ExpeditionEvent.Boss1),
        },
        new List<DataContainer_Map>()
        {
            new DataContainer_Map(E_DungeonLevel.Zero, E_DungeonSize.Middle, E_ExpeditionEvent.Boss2),
            new DataContainer_Map(E_DungeonLevel.One, E_DungeonSize.Middle, E_ExpeditionEvent.Boss2),
            new DataContainer_Map(E_DungeonLevel.Blood, E_DungeonSize.Middle, E_ExpeditionEvent.Boss2),
            new DataContainer_Map(E_DungeonLevel.Zero, E_DungeonSize.Middle, E_ExpeditionEvent.Boss2),
            new DataContainer_Map(E_DungeonLevel.Zero, E_DungeonSize.Middle, E_ExpeditionEvent.Boss2),
            new DataContainer_Map(E_DungeonLevel.One, E_DungeonSize.Middle, E_ExpeditionEvent.Boss2),
            new DataContainer_Map(E_DungeonLevel.One, E_DungeonSize.Middle, E_ExpeditionEvent.Boss2),
        },
        new List<DataContainer_Map>()
        {
            new DataContainer_Map(E_DungeonLevel.Blood, E_DungeonSize.Middle, E_ExpeditionEvent.Boss0),
            new DataContainer_Map(E_DungeonLevel.Blood, E_DungeonSize.Large, E_ExpeditionEvent.Boss0),
            new DataContainer_Map(E_DungeonLevel.Blood, E_DungeonSize.Middle, E_ExpeditionEvent.Boss0),
            new DataContainer_Map(E_DungeonLevel.Blood, E_DungeonSize.Small, E_ExpeditionEvent.Boss0),
            new DataContainer_Map(E_DungeonLevel.Blood, E_DungeonSize.Large, E_ExpeditionEvent.Boss0),
            new DataContainer_Map(E_DungeonLevel.Blood, E_DungeonSize.Middle, E_ExpeditionEvent.Boss1),
            new DataContainer_Map(E_DungeonLevel.Blood, E_DungeonSize.Small, E_ExpeditionEvent.Boss1),
        },
        new List<DataContainer_Map>()
        {
            new DataContainer_Map(E_DungeonLevel.Zero, E_DungeonSize.Small, E_ExpeditionEvent.Gather2),
            new DataContainer_Map(E_DungeonLevel.One, E_DungeonSize.Small, E_ExpeditionEvent.Shrieker2),
            new DataContainer_Map(E_DungeonLevel.Blood, E_DungeonSize.Large, E_ExpeditionEvent.Shrieker1),
            new DataContainer_Map(E_DungeonLevel.Zero, E_DungeonSize.Small, E_ExpeditionEvent.Shrieker0),
            new DataContainer_Map(E_DungeonLevel.Zero, E_DungeonSize.Large, E_ExpeditionEvent.Shrieker1),
            new DataContainer_Map(E_DungeonLevel.One, E_DungeonSize.Small, E_ExpeditionEvent.Shrieker2),
            new DataContainer_Map(E_DungeonLevel.One, E_DungeonSize.Small, E_ExpeditionEvent.Shrieker2),
        },
        new List<DataContainer_Map>()
        {
            new DataContainer_Map(E_DungeonLevel.Zero, E_DungeonSize.Middle, E_ExpeditionEvent.BossDarkest),
            new DataContainer_Map(E_DungeonLevel.Zero, E_DungeonSize.Large, E_ExpeditionEvent.BossDarkest),
            new DataContainer_Map(E_DungeonLevel.Zero, E_DungeonSize.Middle, E_ExpeditionEvent.BossDarkest),
            new DataContainer_Map(E_DungeonLevel.Zero, E_DungeonSize.Small, E_ExpeditionEvent.BossDarkest),
            new DataContainer_Map(E_DungeonLevel.Zero, E_DungeonSize.Large, E_ExpeditionEvent.BossDarkest),
            new DataContainer_Map(E_DungeonLevel.Zero, E_DungeonSize.Middle, E_ExpeditionEvent.BossDarkest),
            new DataContainer_Map(E_DungeonLevel.Zero, E_DungeonSize.Small, E_ExpeditionEvent.BossDarkest),
        },
        new List<DataContainer_Map>()
        {
            new DataContainer_Map(E_DungeonLevel.One, E_DungeonSize.Middle, E_ExpeditionEvent.CleanseCrystal),
            new DataContainer_Map(E_DungeonLevel.One, E_DungeonSize.Large, E_ExpeditionEvent.Gather1),
            new DataContainer_Map(E_DungeonLevel.One, E_DungeonSize.Middle, E_ExpeditionEvent.Gather0),
            new DataContainer_Map(E_DungeonLevel.One, E_DungeonSize.Small, E_ExpeditionEvent.CleanseCrystal),
            new DataContainer_Map(E_DungeonLevel.One, E_DungeonSize.Large, E_ExpeditionEvent.Gather1),
            new DataContainer_Map(E_DungeonLevel.One, E_DungeonSize.Middle, E_ExpeditionEvent.Gather1),
            new DataContainer_Map(E_DungeonLevel.One, E_DungeonSize.Small, E_ExpeditionEvent.CleanseCrystal),
        }, new List<DataContainer_Map>()
        {            
            new DataContainer_Map(E_DungeonLevel.Blood, E_DungeonSize.Small, E_ExpeditionEvent.Cleanse0),
            new DataContainer_Map(E_DungeonLevel.Blood, E_DungeonSize.Large, E_ExpeditionEvent.Cleanse1),
            new DataContainer_Map(E_DungeonLevel.Blood, E_DungeonSize.Middle, E_ExpeditionEvent.Cleanse2),
            new DataContainer_Map(E_DungeonLevel.Blood, E_DungeonSize.Small, E_ExpeditionEvent.Cleanse1),
        });

        #endregion

        for (int i = 0; i < DefaultGameArchiveDataCount; i++)
        {            
            MgrJson.GetInstance().Save(GameArchiveDataCellList[i], Data.GetInstance().PathGameArchiveData + i);
        }

        DestroyImmediate(Hot.Data_.gameObject);
        DestroyImmediate(Hot.MgrJson_.gameObject);
    }
}
