using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Data : InstanceBaseAuto_Mono<Data>
{
    public string PathGameArchiveData = "";
    
    public List<DataContainer_PanelCellGameArchive> DataListCellGameArchive = new();

    private void Awake()
    {
        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyDown",
        (key) =>
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.S))
            {
                if (Hot.NowIndexCellGameArchive != -1)
                {
                    Hot.Data_.Save();
                    Debug.Log("Save");
                }
                else
                {
                    Hot.Data_.SaveAll();
                    Debug.Log("SaveAll");
                }
                //������������
            }
        });
    }

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
                Add(MgrJson.GetInstance().Load<DataContainer_PanelCellGameArchive>("/GameArchiveData", PathGameArchiveData + i));
        }
    }

    /// <summary>
    /// ����ָ���浵
    /// </summary>
    /// <param name="index">Ҫ������Ĵ浵��Index</param>
    public void Save(int index)
    {
        MgrJson.GetInstance().Save(DataListCellGameArchive[index], "/GameArchiveData", PathGameArchiveData + index);
    }

    /// <summary>
    /// ���浱ǰ�浵
    /// </summary>
    public void Save()
    {
        Save(Hot.NowIndexCellGameArchive);
    }

    /// <summary>
    /// �������д浵
    /// </summary>
    public void SaveAll()
    {
        for (int i = 0; i < DataListCellGameArchive.Count; i++)
            Save(i);
    }

    /// <summary>
    /// ɾ��ָ���浵
    /// </summary>
    /// <param name="index">Ҫ��ɾ���Ĵ浵��Index</param>
    /// <param name="IsRemoveDataListCellGameArchive">�Ƿ�Ҫ�Ƴ�DataListCellGameArchive�������</param>
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

