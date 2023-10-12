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
        StartDataAndMgr.GetInstance().PathGameArchiveDataDirectory = MgrXml.GetInstance().filePath + "/GameArchiveData";
        StartDataAndMgr.GetInstance().PathGameArchiveData = "/GameArchiveData" + "/GameArchiveDataDic";

        if (!File.Exists(StartDataAndMgr.GetInstance().PathGameArchiveDataDirectory))
            Directory.CreateDirectory(StartDataAndMgr.GetInstance().PathGameArchiveDataDirectory);

        List<Container_GameArchiveDataCell> GameArchiveDataCellList = new List<Container_GameArchiveDataCell>();

        for (int i = 0; i < DefaultGameArchiveDataCount; i++)
        {
            GameArchiveDataCellList.Add(new Container_GameArchiveDataCell());
        }

        MgrXml.GetInstance().Save(GameArchiveDataCellList, StartDataAndMgr.GetInstance().PathGameArchiveData);

        DestroyImmediate(StartDataAndMgr.GetInstance().gameObject);
        DestroyImmediate(MgrXml.GetInstance().gameObject);
    }
}
