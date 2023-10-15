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
        
        PathGameArchiveData = "/GameArchiveDataDic";        

        DataListCellGameArchive = MgrXml.GetInstance().Load<List<DataContainer_PanelCellGameArchive>>(PathGameArchiveData);                  
    }

    public void Save()
    {
        MgrXml.GetInstance().Save(DataListCellGameArchive, PathGameArchiveData);
    }
}


