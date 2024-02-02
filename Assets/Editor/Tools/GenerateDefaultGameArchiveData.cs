using System.Collections.Generic;
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

        Dictionary<E_RoleName, RoleConfig> DicRoleConfig = new()
        {
            {
                E_RoleName.Crusader,
                new(E_RoleMoveType.Land,
                    new()
                    {
                        50, 55, 60, 90,
                        100, 130, 150,
                    },
                    new()
                    {
                        {
                            E_Skill.SkillForwardUpCut,
                            new(new(),new()
                            {

                            })
                        },
                        {
                            E_Skill.SkillForwardDownCut,
                            new(new(),new()
                            {

                            })
                        },
                    },
                    200, 300, 50, 100,
                    10, 4,
                    new(20, 9),
                    new(3, 5),
                    new(4, 3, 3, 7))
            },
            {
                E_RoleName.PlagueDoctor,
                new(E_RoleMoveType.Land,
                    new()
                    {
                        50, 55, 60, 90,
                        100, 130, 150,
                    },
                    new()
                    {
                        {
                            E_Skill.SkillForwardUpCut,
                            new(new(),new()
                            {

                            })
                        },
                        {
                            E_Skill.SkillForwardDownCut,
                            new(new(),new()
                            {

                            })
                        },
                    },
                    200, 300, 50, 120,
                    10, 7,
                    new(15, 6),
                    new(2, 3),
                    new(5, 2, 4, 6))
            },
            {
                E_RoleName.DevilFly,
                new(E_RoleMoveType.Sky,
                    new()
                    {
                        50, 55, 60, 90,
                        100, 130, 150,
                    },
                    new()
                    {
                        {
                            E_Skill.SkillForwardDownCut,
                            new(new(),new()
                            {

                            })
                        },
                    },
                    200, 300, 50, 150,
                    10, 10,
                    new(6, 4),
                    new(2, 3),
                    new(4, 4, 4, 4))
            },
        };
        //Hot.MgrJson_.Save(DicRoleConfig, "", "/Config");

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

        Debug.Log("GenerateDefaultGameArchiveData Done!!!");

        #endregion
    }
}