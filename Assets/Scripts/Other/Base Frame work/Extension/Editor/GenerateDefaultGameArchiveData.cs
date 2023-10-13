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

        GameArchiveDataCellList[0].DataListCellStore = new List<DataContainer_CellStore>()
        { 
            new DataContainer_CellStore(100, 200),
            new DataContainer_CellStore(120, 103),
            new DataContainer_CellStore(200, 220),
            new DataContainer_CellStore(103, 20),
        };

        MgrXml.GetInstance().Save(GameArchiveDataCellList, StartDataAndMgr.GetInstance().PathGameArchiveData);

        DestroyImmediate(StartDataAndMgr.GetInstance().gameObject);
        DestroyImmediate(MgrXml.GetInstance().gameObject);
    }
}
