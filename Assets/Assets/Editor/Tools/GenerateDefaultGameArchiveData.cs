using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
                    new(E_SpriteNamePanelCellItem.ItemFoodApple),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.ItemFoodCookie),

                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.ItemFoodRawBeef),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),

                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                },

                new()
                {
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),

                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),

                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                },

                new()
                {
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),

                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.ItemFoodApple),
                    new(E_SpriteNamePanelCellItem.None),

                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.ItemFoodRawMutton),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                },

                new()
                {
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),

                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),

                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                },

                new()
                {
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),

                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),

                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                    new(E_SpriteNamePanelCellItem.None),
                },
            }
        };

        #endregion

        GameArchiveDataCellList[0].ListCellRole = new List<DataContainer_CellRole>()
        {
            new DataContainer_CellRole(E_RoleName.Crusader, "cao1", 2, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_RoleName.LiLiSi, "cao2", 3, 99, 30, 29, 200, 10),
            new DataContainer_CellRole(E_RoleName.PlagueDoctor, "cao3", 4, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_RoleName.PlagueDoctor, "cao4", 4, 99, 1, 46, 200, 1),
            new DataContainer_CellRole(E_RoleName.LiLiSi, "cao5", 2, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_RoleName.Crusader, "cao6", 3, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_RoleName.Crusader, "cao5", 2, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_RoleName.LiLiSi, "cao4", 2, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_RoleName.Crusader, "cao3", 2, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_RoleName.LiLiSi, "cao2", 2, 99, 40, 46, 200, 10),
            new DataContainer_CellRole(E_RoleName.LiLiSi, "cao1", 2, 99, 40, 46, 200, 10),
        };

        GameArchiveDataCellList[0].ResTable = new DataContainer_ResTable(10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000);

        GameArchiveDataCellList[0].ListCellRoleRecruit = new List<DataContainer_CellRoleRecruit>()
        {
            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.Crusader, "cao1", 2, 99, 40, 46, 200, 10),
             new DataContainer_CoinCost(2, 3, 4, 5)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.LiLiSi, "cao10", 2, 99, 40, 10, 200, 2),
             new DataContainer_CoinCost(22, 3, 34, 51)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.Crusader, "cao5", 2, 99, 40, 46, 200, 10),
             new DataContainer_CoinCost(232, 332, 411, 55)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.LiLiSi, "cao4", 4, 99, 1, 46, 200, 1),
             new DataContainer_CoinCost(22, 31, 42, 523)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.Crusader, "cao3", 4, 99, 40, 46, 200, 10),
             new DataContainer_CoinCost(22, 31, 42, 523)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.LiLiSi, "cao4", 4, 99, 1, 46, 200, 1),
             new DataContainer_CoinCost(22, 31, 42, 523)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.Crusader, "cao4", 4, 99, 1, 46, 200, 1),
             new DataContainer_CoinCost(22, 31, 42, 523)),

            new DataContainer_CellRoleRecruit
            (new DataContainer_CellRole(E_RoleName.Crusader, "cao4", 4, 99, 1, 46, 200, 1),
             new DataContainer_CoinCost(22, 31, 42, 523))
        };

        #region TownStore

        #region 0

        GameArchiveDataCellList[0].ListCellStore.Add(new("Wood", E_PanelCellTownStore.StoreWood));
        GameArchiveDataCellList[0].ListCellStore[0].ListItem[0][0] = new DataContainer_CellItem(E_SpriteNamePanelCellItem.ItemFoodApple);
        GameArchiveDataCellList[0].ListCellStore[0].ListItem[0][1] = new DataContainer_CellItem(E_SpriteNamePanelCellItem.None);
        GameArchiveDataCellList[0].ListCellStore[0].ListItem[0][2] = new DataContainer_CellItem(E_SpriteNamePanelCellItem.None);
        GameArchiveDataCellList[0].ListCellStore[0].ListItem[0][3] = new DataContainer_CellItem(E_SpriteNamePanelCellItem.ItemFoodCoodedMutton);
        GameArchiveDataCellList[0].ListCellStore[0].ListItem[0][4] = new DataContainer_CellItem(E_SpriteNamePanelCellItem.None);
        GameArchiveDataCellList[0].ListCellStore[0].ListItem[0][5] = new DataContainer_CellItem(E_SpriteNamePanelCellItem.None);
        GameArchiveDataCellList[0].ListCellStore[0].ListItem[0][6] = new DataContainer_CellItem(E_SpriteNamePanelCellItem.ItemFoodCookie);
        GameArchiveDataCellList[0].ListCellStore[0].ListItem[0][7] = new DataContainer_CellItem(E_SpriteNamePanelCellItem.None);
        GameArchiveDataCellList[0].ListCellStore[0].ListItem[0][8] = new DataContainer_CellItem(E_SpriteNamePanelCellItem.None);
        GameArchiveDataCellList[0].ListCellStore[0].ListItem[0][9] = new DataContainer_CellItem(E_SpriteNamePanelCellItem.None);

        GameArchiveDataCellList[0].ListCellStore[0].ListItem[2][6] = new DataContainer_CellItem(E_SpriteNamePanelCellItem.ItemFoodApple);

        #endregion

        #region 1

        GameArchiveDataCellList[0].ListCellStore.Add(new("Iron", E_PanelCellTownStore.StoreIron));
        GameArchiveDataCellList[0].ListCellStore[1].ListItem[0][0] = new DataContainer_CellItem(E_SpriteNamePanelCellItem.ItemFoodApple);
        GameArchiveDataCellList[0].ListCellStore[1].ListItem[3][0] = new DataContainer_CellItem(E_SpriteNamePanelCellItem.ItemFoodApple);
        GameArchiveDataCellList[0].ListCellStore[1].ListItem[6][2] = new DataContainer_CellItem(E_SpriteNamePanelCellItem.ItemFoodApple);

        #endregion

        #region 2

        GameArchiveDataCellList[0].ListCellStore.Add(new("Big!!!", E_PanelCellTownStore.StoreGold));
        
        //GameArchiveDataCellList[0].ListCellStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.ItemFoodApple),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.ItemFoodCoodedMutton),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.ItemFoodCookie),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //});
        //GameArchiveDataCellList[0].ListCellStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //});
        //GameArchiveDataCellList[0].ListCellStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //});
        //GameArchiveDataCellList[0].ListCellStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //});
        //GameArchiveDataCellList[0].ListCellStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //});

        //GameArchiveDataCellList[0].ListCellStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //});
        //GameArchiveDataCellList[0].ListCellStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //});
        //GameArchiveDataCellList[0].ListCellStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //});
        //GameArchiveDataCellList[0].ListCellStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //});
        //GameArchiveDataCellList[0].ListCellStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //});

        //GameArchiveDataCellList[0].ListCellStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //});
        //GameArchiveDataCellList[0].ListCellStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.ItemFoodCoodedMutton),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.ItemFoodCoodedMutton),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.ItemFoodCoodedMutton),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.ItemFoodCoodedMutton),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.ItemFoodCoodedMutton),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //});                
        //GameArchiveDataCellList[0].ListCellStore[2].ListItem.Add(new()
        //{
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),

        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
        //    new DataContainer_CellItem(E_SpriteNamePanelCellItem.None),
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