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
            new DataContainer_CellTownStore(E_SpriteNamePanelCellTownStore.StoreIron),
            new DataContainer_CellTownStore(E_SpriteNamePanelCellTownStore.StoreIron),
            new DataContainer_CellTownStore(E_SpriteNamePanelCellTownStore.StoreWood),
            new DataContainer_CellTownStore(E_SpriteNamePanelCellTownStore.StoreGold),
            new DataContainer_CellTownStore(E_SpriteNamePanelCellTownStore.StoreIron),
            new DataContainer_CellTownStore(E_SpriteNamePanelCellTownStore.StoreIron),
            new DataContainer_CellTownStore(E_SpriteNamePanelCellTownStore.StoreIron),
            new DataContainer_CellTownStore(E_SpriteNamePanelCellTownStore.StoreIron),
            new DataContainer_CellTownStore(E_SpriteNamePanelCellTownStore.StoreIron),
        };

        GameArchiveDataCellList[0].ListCellStore[0].ListCellStoreItem = new List<DataContainer_CellItem>()
        {
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodRawPotato),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodRawChicken),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodApple),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
        };
        GameArchiveDataCellList[0].ListCellStore[1].ListCellStoreItem = new List<DataContainer_CellItem>()
        {
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
        };
        GameArchiveDataCellList[0].ListCellStore[2].ListCellStoreItem = new List<DataContainer_CellItem>()
        {
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodApple),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodApple),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodApple),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodApple),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodApple),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodApple),
        };

        GameArchiveDataCellList[0].ListCellShopItem = new List<DataContainer_CellItem>()
        {
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodRawPotato),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodRawChicken),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodApple),
            new DataContainer_CellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
        };

        GameArchiveDataCellList[0].ListCellRole = new List<DataContainer_CellRole>()
        {
            new DataContainer_CellRole(E_SpriteNamePortraitRole.PortraitPlagueDoctor, E_SpriteNameRoleStatus.RoleStatusNone, "cao1", 2, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_SpriteNamePortraitRole.PortraitCrusader, E_SpriteNameRoleStatus.RoleStatusNone, "cao2", 3, 99, 30, 29, 200, 10),
            new DataContainer_CellRole(E_SpriteNamePortraitRole.PortraitHighwayman, E_SpriteNameRoleStatus.RoleStatusNone, "cao3", 4, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_SpriteNamePortraitRole.PortraitVestal, E_SpriteNameRoleStatus.RoleStatusNone, "cao4", 4, 99, 1, 46, 200, 1),
            new DataContainer_CellRole(E_SpriteNamePortraitRole.PortraitManAtArms, E_SpriteNameRoleStatus.RoleStatusNone, "cao5", 2, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_SpriteNamePortraitRole.PortraitLeper, E_SpriteNameRoleStatus.RoleStatusNone, "cao6", 3, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_SpriteNamePortraitRole.PortraitJester, E_SpriteNameRoleStatus.RoleStatusNone, "cao7", 2, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_SpriteNamePortraitRole.PortraitMusketeer, E_SpriteNameRoleStatus.RoleStatusNone, "cao8", 1, 99, 40, 50, 200, 3),
            new DataContainer_CellRole(E_SpriteNamePortraitRole.PortraitShieldbreaker, E_SpriteNameRoleStatus.RoleStatusNone, "cao9", 0, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_SpriteNamePortraitRole.PortraitBountyHunter, E_SpriteNameRoleStatus.RoleStatusNone, "cao10", 2, 99, 40, 10, 200, 2),
        };

        GameArchiveDataCellList[0].ResTable = new DataContainer_ResTable(10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000);

        GameArchiveDataCellList[0].ListCellRoleRecruit = new List<DataContainer_CellRoleRecruit>()
        {
            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_SpriteNamePortraitRole.PortraitPlagueDoctor, E_SpriteNameRoleStatus.RoleStatusNone, "cao1", 2, 99, 40, 46, 200, 10),
             new DataContainer_CoinCost(2, 3, 4, 5)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_SpriteNamePortraitRole.PortraitBountyHunter, E_SpriteNameRoleStatus.RoleStatusNone, "cao10", 2, 99, 40, 10, 200, 2),
             new DataContainer_CoinCost(22, 3, 34, 51)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_SpriteNamePortraitRole.PortraitManAtArms, E_SpriteNameRoleStatus.RoleStatusNone, "cao5", 2, 99, 40, 46, 200, 10),
             new DataContainer_CoinCost(232, 332, 411, 55)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_SpriteNamePortraitRole.PortraitVestal, E_SpriteNameRoleStatus.RoleStatusNone, "cao4", 4, 99, 1, 46, 200, 1),
             new DataContainer_CoinCost(22, 31, 42, 523)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_SpriteNamePortraitRole.PortraitHighwayman, E_SpriteNameRoleStatus.RoleStatusNone, "cao3", 4, 99, 40, 46, 200, 10),
             new DataContainer_CoinCost(22, 31, 42, 523)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_SpriteNamePortraitRole.PortraitVestal, E_SpriteNameRoleStatus.RoleStatusNone, "cao4", 4, 99, 1, 46, 200, 1),
             new DataContainer_CoinCost(22, 31, 42, 523)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_SpriteNamePortraitRole.PortraitVestal, E_SpriteNameRoleStatus.RoleStatusNone, "cao4", 4, 99, 1, 46, 200, 1),
             new DataContainer_CoinCost(22, 31, 42, 523)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_SpriteNamePortraitRole.PortraitVestal, E_SpriteNameRoleStatus.RoleStatusNone, "cao4", 4, 99, 1, 46, 200, 1),
             new DataContainer_CoinCost(22, 31, 42, 523))
        };

        #endregion

        for (int i = 0; i < DefaultGameArchiveDataCount; i++)
        {            
            MgrJson.GetInstance().Save(GameArchiveDataCellList[i], Data.GetInstance().PathGameArchiveData + i);
        }

        DestroyImmediate(Hot.Data_.gameObject);
        DestroyImmediate(Hot.MgrJson_.gameObject);
    }
}
