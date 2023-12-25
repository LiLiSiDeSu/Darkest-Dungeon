using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public sealed class GenerateDefaultGameArchiveData : MonoBehaviour
{                          
    private static int DefaultGameArchiveDataCount = 10;

    [MenuItem("-Tools-/Generate/DefaultGameArchiveData", false, 1)]
    private static void Generate()
    {
        MgrJson.GetInstance().filePath = Application.persistentDataPath + "/Data/JsonData";
        Data.GetInstance().PathGameArchiveData = "/GameArchiveData";

        List<DataContainer_CellGameArchive> GameArchiveDataCellList = new();

        for (int i = 0; i < DefaultGameArchiveDataCount; i++)
        {
            GameArchiveDataCellList.Add(new());
        }

        GameArchiveDataCellList[0].GameArchiveName = "Test";
        GameArchiveDataCellList[0].e_GameArchiveLevel = E_GameArchiveLevel.Bloodmoon;

        #region TestData

        #region TownShop

        GameArchiveDataCellList[0].TownShop = new DataContainer_TownShop()
        {
            X = 15,
            Y = 5,
            ListItem = new()
            {
                new()
                {
                    new(E_Item.ItemFoodApple),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.ItemFoodCookie),

                    new(E_Item.None),
                    new(E_Item.ItemFoodRawBeef),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),

                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                },

                new()
                {
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),

                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),

                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                },

                new()
                {
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),

                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.ItemFoodApple),
                    new(E_Item.None),

                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.ItemFoodRawMutton),
                    new(E_Item.None),
                    new(E_Item.None),
                },

                new()
                {
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),

                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),

                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                },

                new()
                {
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),

                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),

                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                    new(E_Item.None),
                },
            }
        };

        #endregion

        GameArchiveDataCellList[0].ListRole = new()
        {
            new DataContainer_CellRole(E_RoleName.Crusader, "cao0", 100, 130, 2, 24, 10),
            new DataContainer_CellRole(E_RoleName.DevilFly, "cao1", 12, 50, 4, 12, 12),
            new DataContainer_CellRole(E_RoleName.PlagueDoctor, "cao2", 120, 5, 5, 22, 7),
            new DataContainer_CellRole(E_RoleName.DevilFly, "cao3", 20, 140, 2, 15, 1),
            new DataContainer_CellRole(E_RoleName.DevilFly, "cao4", 30, 10, 3, 11, 21),
            new DataContainer_CellRole(E_RoleName.Crusader, "cao5", 50, 78, 6, 2, 30),
        };

        GameArchiveDataCellList[0].ResTable = new(10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000);

        GameArchiveDataCellList[0].ListRoleRecruit = new()
        {
            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.Crusader, "cao0", 100, 130, 2, 24, 33),
             new DataContainer_CoinCost(2, 3, 4, 5)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.DevilFly, "cao1", 12, 50, 1, 12, 32),
             new DataContainer_CoinCost(22, 3, 34, 51)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.Crusader, "cao2", 120, 10, 1, 22, 23),
             new DataContainer_CoinCost(232, 332, 411, 55)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.DevilFly, "cao3", 20, 140, 4, 15, 11),
             new DataContainer_CoinCost(22, 31, 42, 523)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.DevilFly, "cao4", 30, 10, 2, 11, 10),
             new DataContainer_CoinCost(22, 31, 42, 523)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.DevilFly, "cao5", 50, 78, 1, 2, 9),
             new DataContainer_CoinCost(22, 31, 42, 523)),
        };

        #region TownStore

        #region 0

        GameArchiveDataCellList[0].ListStore.Add(new("Wood", E_PanelCellTownStore.StoreWood));
        GameArchiveDataCellList[0].ListStore[0].ListItem[0][0] = new DataContainer_CellItem(E_Item.ItemFoodApple);
        GameArchiveDataCellList[0].ListStore[0].ListItem[0][1] = new DataContainer_CellItem(E_Item.None);
        GameArchiveDataCellList[0].ListStore[0].ListItem[0][2] = new DataContainer_CellItem(E_Item.None);
        GameArchiveDataCellList[0].ListStore[0].ListItem[0][3] = new DataContainer_CellItem(E_Item.ItemFoodCoodedMutton);
        GameArchiveDataCellList[0].ListStore[0].ListItem[0][4] = new DataContainer_CellItem(E_Item.None);
        GameArchiveDataCellList[0].ListStore[0].ListItem[0][5] = new DataContainer_CellItem(E_Item.None);
        GameArchiveDataCellList[0].ListStore[0].ListItem[0][6] = new DataContainer_CellItem(E_Item.ItemFoodCookie);
        GameArchiveDataCellList[0].ListStore[0].ListItem[0][7] = new DataContainer_CellItem(E_Item.None);
        GameArchiveDataCellList[0].ListStore[0].ListItem[0][8] = new DataContainer_CellItem(E_Item.None);
        GameArchiveDataCellList[0].ListStore[0].ListItem[0][9] = new DataContainer_CellItem(E_Item.None);

        GameArchiveDataCellList[0].ListStore[0].ListItem[2][6] = new DataContainer_CellItem(E_Item.ItemFoodApple);

        #endregion

        #region 1

        GameArchiveDataCellList[0].ListStore.Add(new("Iron", E_PanelCellTownStore.StoreIron));
        GameArchiveDataCellList[0].ListStore[1].ListItem[0][0] = new DataContainer_CellItem(E_Item.ItemFoodApple);
        GameArchiveDataCellList[0].ListStore[1].ListItem[3][0] = new DataContainer_CellItem(E_Item.ItemFoodApple);
        GameArchiveDataCellList[0].ListStore[1].ListItem[6][2] = new DataContainer_CellItem(E_Item.ItemFoodApple);

        #endregion

        #region 2

        GameArchiveDataCellList[0].ListStore.Add(new("Big!!!", E_PanelCellTownStore.StoreGold));
        
        //GameArchiveDataCellList[0].ListStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_Item.ItemFoodApple),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.ItemFoodCoodedMutton),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.ItemFoodCookie),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //});
        //GameArchiveDataCellList[0].ListStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //});
        //GameArchiveDataCellList[0].ListStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //});
        //GameArchiveDataCellList[0].ListStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //});
        //GameArchiveDataCellList[0].ListStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //});

        //GameArchiveDataCellList[0].ListStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //});
        //GameArchiveDataCellList[0].ListStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //});
        //GameArchiveDataCellList[0].ListStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //});
        //GameArchiveDataCellList[0].ListStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //});
        //GameArchiveDataCellList[0].ListStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //});

        //GameArchiveDataCellList[0].ListStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //});
        //GameArchiveDataCellList[0].ListStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_Item.ItemFoodCoodedMutton),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.ItemFoodCoodedMutton),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.ItemFoodCoodedMutton),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.ItemFoodCoodedMutton),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.ItemFoodCoodedMutton),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //});                
        //GameArchiveDataCellList[0].ListStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),

        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //    new DataContainer_CellItem(E_Item.None),
        //});

        #endregion

        #endregion

        for (int i = 0; i < DefaultGameArchiveDataCount; i++)
        {            
            MgrJson.GetInstance().Save(GameArchiveDataCellList[i], "/GameArchiveData", Data.GetInstance().PathGameArchiveData + i);
        }

        DestroyImmediate(Hot.Data_.gameObject);
        DestroyImmediate(Hot.MgrJson_.gameObject);

        #endregion
    }
}