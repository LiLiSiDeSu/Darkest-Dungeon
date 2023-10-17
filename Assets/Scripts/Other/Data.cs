using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Data : InstanceBaseAuto_Mono<Data>
{    
    public string PathGameArchiveData;    
    
    public List<DataContainer_PanelCellGameArchive> DataListCellGameArchive = new List<DataContainer_PanelCellGameArchive>();

    protected override void Start()
    {
        base.Start();

        PathGameArchiveData = "/GameArchiveData";

        if (!File.Exists(MgrXml.GetInstance().filePath))
        {
            Directory.CreateDirectory(MgrXml.GetInstance().filePath);
        }

        string[] AllPathGameArchive = Directory.GetFiles(MgrXml.GetInstance().filePath);        
        
        for (int i = 0; i < AllPathGameArchive.Length; i++)
        {
            DataListCellGameArchive.Add(MgrXml.GetInstance().Load<DataContainer_PanelCellGameArchive>(PathGameArchiveData + i));
        }
    }

    /// <summary>
    /// 保存指定存档
    /// </summary>
    /// <param name="index">要被保存的存档的Index</param>
    public void Save(int index)
    {
        MgrXml.GetInstance().Save(DataListCellGameArchive[index], PathGameArchiveData + index);
    }

    public void Save()
    {
        Save(GlobalHot.IndexNowCellGameArchive);
    }

    public void SaveAll()
    {
        for (int i = 0; i < DataListCellGameArchive.Count; i++)
            Save(i);
    }

    /// <summary>
    /// 删除指定存档
    /// </summary>
    /// <param name="index">要被删除的存档的Index</param>
    public void Destroy(int index)
    {                
        for (int i = index; i < DataListCellGameArchive.Count - 1; i++)
        {
            File.Copy(MgrXml.GetInstance().filePath + PathGameArchiveData + (i + 1) + ".xml",
                      MgrXml.GetInstance().filePath + PathGameArchiveData + i + ".xml", true);            
        }
            

        File.Delete(MgrXml.GetInstance().filePath + PathGameArchiveData + (DataListCellGameArchive.Count - 1) + ".xml");
        DataListCellGameArchive.RemoveAt(index);
    }
}


