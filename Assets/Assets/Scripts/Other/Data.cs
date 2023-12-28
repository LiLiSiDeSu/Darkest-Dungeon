using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

public class Data : InstanceBaseAuto_Mono<Data>
{
    public string PathGameArchiveData = "";
    
    public List<DataContainer_CellGameArchive> DataListCellGameArchive = new();

    private void Start()
    {        
        PathGameArchiveData = "/GameArchiveData";

        if (!File.Exists(MgrJson.GetInstance().filePath))
        {
            Directory.CreateDirectory(MgrJson.GetInstance().filePath);
        }

        string[] AllPathGameArchive = Directory.GetFiles(MgrJson.GetInstance().filePath + "/GameArchiveData");
        
        for (int i = 0; i < AllPathGameArchive.Length; i++)
        {
            DataListCellGameArchive.
                Add(MgrJson.GetInstance().Load<DataContainer_CellGameArchive>("/GameArchiveData", PathGameArchiveData + i));
        }
    }

    /// <summary>
    /// 保存指定存档
    /// </summary>
    /// <param name="index">要被保存的存档的Index</param>
    public void Save(int index)
    {
        Task.Run(() => 
        { 
            MgrJson.GetInstance().Save(DataListCellGameArchive[index], "/GameArchiveData", PathGameArchiveData + index); 
        });
    }

    /// <summary>
    /// 保存当前存档
    /// </summary>
    public void Save()
    {
        Save(Hot.NowIndexCellGameArchive);
    }

    /// <summary>
    /// 保存所有存档
    /// </summary>
    public void SaveAll()
    {
        for (int i = 0; i < DataListCellGameArchive.Count; i++)
        {
            Save(i);
        }
    }

    /// <summary>
    /// 删除指定存档
    /// </summary>
    /// <param name="index">要被删除的存档的Index</param>
    /// <param name="IsRemoveDataListCellGameArchive">是否要移除DataListCellGameArchive里的数据</param>
    public void Remove(int index, bool IsRemoveDataListCellGameArchive = true)
    {                
        for (int i = index; i < DataListCellGameArchive.Count - 1; i++)
        {
            File.Copy(Hot.MgrJson_.filePath + PathGameArchiveData + PathGameArchiveData + (i + 1) + ".json",
                      Hot.MgrJson_.filePath + PathGameArchiveData + PathGameArchiveData + i + ".json", true);            
        }
            

        File.Delete(Hot.MgrJson_.filePath + PathGameArchiveData + PathGameArchiveData + 
            (DataListCellGameArchive.Count - 1) + ".json");

        if (IsRemoveDataListCellGameArchive)
        {
            DataListCellGameArchive.RemoveAt(index);
        }
    }
}


