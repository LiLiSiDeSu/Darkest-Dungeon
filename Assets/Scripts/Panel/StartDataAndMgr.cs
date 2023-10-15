using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StartDataAndMgr : InstanceBaseAuto_Mono<StartDataAndMgr>
{    
    public string PathGameArchiveData;

    public List<DataContainer_PanelCellGameArchive> DataListCellGameArchive = new List<DataContainer_PanelCellGameArchive>();

    protected override void Start()
    {
        base.Start();
        
        PathGameArchiveData = "/GameArchiveDataDic";        

        DataListCellGameArchive = MgrXml.GetInstance().Load<List<DataContainer_PanelCellGameArchive>>(PathGameArchiveData);                  
    }
}


