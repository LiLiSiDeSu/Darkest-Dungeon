using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StartDataAndMgr : InstanceBaseAuto_Mono<StartDataAndMgr>
{
    public string PathGameArchiveDataDirectory;
    public string PathGameArchiveData;
    public List<Container_GameArchiveDataCell> ListGameArchiveDataCell = new List<Container_GameArchiveDataCell>();

    protected override void Start()
    {
        base.Start();

        PathGameArchiveDataDirectory = MgrXml.GetInstance().filePath + "/GameArchiveData";
        PathGameArchiveData = "/GameArchiveData" + "/GameArchiveDataDic";        

        ListGameArchiveDataCell = MgrXml.GetInstance().Load<List<Container_GameArchiveDataCell>>(PathGameArchiveData);                  
    }
}


