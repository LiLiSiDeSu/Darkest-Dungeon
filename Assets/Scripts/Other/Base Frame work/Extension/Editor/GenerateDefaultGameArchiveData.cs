using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public sealed class GenerateDefaultGameArchiveData : MonoBehaviour
{                          
    private static int DefaultGameArchiveDataCount = 10;

    [MenuItem("Tools/Generate/DefaultGameArchiveData", false, 1)]
    private static void Generate()
    {
        MgrXml.GetInstance().filePath = Application.persistentDataPath + "/Data/XmlData";        
        Data.GetInstance().PathGameArchiveData = "/GameArchiveData";

        List<DataContainer_PanelCellGameArchive> GameArchiveDataCellList = new List<DataContainer_PanelCellGameArchive>();

        for (int i = 0; i < DefaultGameArchiveDataCount; i++)
        {
            GameArchiveDataCellList.Add(new DataContainer_PanelCellGameArchive());            
        }

        #region ²âÊÔÊý¾Ý

        GameArchiveDataCellList[0].DataListCellStore = new List<DataContainer_PanelCellTownStore>()
        {
            new DataContainer_PanelCellTownStore(E_SpriteNamePanelCellTownStore.StoreWood),
            new DataContainer_PanelCellTownStore(E_SpriteNamePanelCellTownStore.StoreIron),
            new DataContainer_PanelCellTownStore(E_SpriteNamePanelCellTownStore.StoreGold),
            new DataContainer_PanelCellTownStore(E_SpriteNamePanelCellTownStore.StoreWood),
        };

        GameArchiveDataCellList[0].DataListCellStore[0].DataListCellItem = new List<DataContainer_PanelCellItem>()
        {
            new DataContainer_PanelCellItem(E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_PanelCellItem(E_SpriteNamePanelCellItem.ItemFoodCookedBeef),
            new DataContainer_PanelCellItem(E_SpriteNamePanelCellItem.ItemFoodRawChicken),
            new DataContainer_PanelCellItem(E_SpriteNamePanelCellItem.ItemFoodApple),
            new DataContainer_PanelCellItem(E_SpriteNamePanelCellItem.ItemFoodRawMutton),
            new DataContainer_PanelCellItem(E_SpriteNamePanelCellItem.ItemFoodCookie),
        };

        GameArchiveDataCellList[0].DataListCellStore[2].DataListCellItem = new List<DataContainer_PanelCellItem>()
        {
            new DataContainer_PanelCellItem(E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_PanelCellItem(E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_PanelCellItem(E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_PanelCellItem(E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_PanelCellItem(E_SpriteNamePanelCellItem.ItemFoodCookie),
            new DataContainer_PanelCellItem(E_SpriteNamePanelCellItem.ItemFoodCookie),
        };

        GameArchiveDataCellList[0].DataResAncestralProperty = 
            new DataContainer_PanelResAncestralProperty(11, 22, 33, 44, 55);

        GameArchiveDataCellList[0].DataResCoin =
            new DataContainer_PanelResCoin(11, 22, 33, 44);

        #endregion

        for (int i = 0; i < DefaultGameArchiveDataCount; i++)
        {            
            MgrXml.GetInstance().Save(GameArchiveDataCellList[i], Data.GetInstance().PathGameArchiveData + i);
        }

        DestroyImmediate(Data.GetInstance().gameObject);
        DestroyImmediate(MgrXml.GetInstance().gameObject);
    }
}
