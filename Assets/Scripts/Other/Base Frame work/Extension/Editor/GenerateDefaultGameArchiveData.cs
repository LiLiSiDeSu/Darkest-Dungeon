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
        StartDataAndMgr.GetInstance().PathGameArchiveData = "/GameArchiveDataDic";

        List<DataContainer_CellGameArchive> GameArchiveDataCellList = new List<DataContainer_CellGameArchive>();

        for (int i = 0; i < DefaultGameArchiveDataCount; i++)
        {
            GameArchiveDataCellList.Add(new DataContainer_CellGameArchive());
        }

        //ÁÙÊ±²âÊÔÊý¾Ý
        GameArchiveDataCellList[0].DataListCellStore = new List<DataContainer_CellStore>()
        { 
            new DataContainer_CellStore(E_PanelCellStorePrefabName.PanelCellStoreWood),
            new DataContainer_CellStore(E_PanelCellStorePrefabName.PanelCellStoreIron),
            new DataContainer_CellStore(E_PanelCellStorePrefabName.PanelCellStoreGold),
            new DataContainer_CellStore(E_PanelCellStorePrefabName.PanelCellStoreWood),
        };

        MgrXml.GetInstance().Save(GameArchiveDataCellList, StartDataAndMgr.GetInstance().PathGameArchiveData);

        DestroyImmediate(StartDataAndMgr.GetInstance().gameObject);
        DestroyImmediate(MgrXml.GetInstance().gameObject);
    }
}
