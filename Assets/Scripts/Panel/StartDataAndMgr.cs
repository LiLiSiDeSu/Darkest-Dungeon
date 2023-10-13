using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StartDataAndMgr : InstanceBaseAuto_Mono<StartDataAndMgr>
{
    public string PathGameArchiveDataDirectory;
    public string PathGameArchiveData;

    public List<DataContainer_CellGameArchive> ListGameArchiveDataCell = new List<DataContainer_CellGameArchive>();

    protected override void Start()
    {
        base.Start();

        PathGameArchiveDataDirectory = MgrXml.GetInstance().filePath + "/GameArchiveData";
        PathGameArchiveData = "/GameArchiveData" + "/GameArchiveDataDic";        

        ListGameArchiveDataCell = MgrXml.GetInstance().Load<List<DataContainer_CellGameArchive>>(PathGameArchiveData);                  
    }
}


