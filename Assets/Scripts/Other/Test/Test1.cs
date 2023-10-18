using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Test1 : MonoBehaviour
{
    private void Start()
    {
        DataContainer_PanelCellGameArchive cao = new DataContainer_PanelCellGameArchive();
        MgrJson.GetInstance().Save(cao, "/cao");

        DataContainer_PanelCellGameArchive cc = MgrJson.GetInstance().Load<DataContainer_PanelCellGameArchive>("/cao");
    }
}
