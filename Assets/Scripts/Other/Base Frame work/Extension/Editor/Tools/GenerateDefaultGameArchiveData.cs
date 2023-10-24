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

        GameArchiveDataCellList[0].ListCellStore = new List<DataContainer_PanelCellTownStore>()
        {
            new DataContainer_PanelCellTownStore(E_SpriteNamePanelCellTownStore.StoreIron),
            new DataContainer_PanelCellTownStore(E_SpriteNamePanelCellTownStore.StoreIron),
            new DataContainer_PanelCellTownStore(E_SpriteNamePanelCellTownStore.StoreWood),
            new DataContainer_PanelCellTownStore(E_SpriteNamePanelCellTownStore.StoreGold),
            new DataContainer_PanelCellTownStore(E_SpriteNamePanelCellTownStore.StoreIron),
            new DataContainer_PanelCellTownStore(E_SpriteNamePanelCellTownStore.StoreIron),
            new DataContainer_PanelCellTownStore(E_SpriteNamePanelCellTownStore.StoreIron),
            new DataContainer_PanelCellTownStore(E_SpriteNamePanelCellTownStore.StoreIron),
            new DataContainer_PanelCellTownStore(E_SpriteNamePanelCellTownStore.StoreIron),
        };

        GameArchiveDataCellList[0].ListCellStore[0].ListCellStoreItem = new List<DataContainer_PanelCellItem>()
        {
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodRawPotato),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodRawChicken),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodApple),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
        };
        GameArchiveDataCellList[0].ListCellStore[1].ListCellStoreItem = new List<DataContainer_PanelCellItem>()
        {
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
        };
        GameArchiveDataCellList[0].ListCellStore[2].ListCellStoreItem = new List<DataContainer_PanelCellItem>()
        {
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodApple),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodApple),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodApple),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodApple),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodApple),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodApple),
        };

        GameArchiveDataCellList[0].ListCellShopItem = new List<DataContainer_PanelCellItem>()
        {
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodRawPotato),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodRawChicken),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodApple),
            new DataContainer_PanelCellItem(E_Location.PanelTownItem, E_SpriteNamePanelCellItem.ItemFoodCookie),
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
