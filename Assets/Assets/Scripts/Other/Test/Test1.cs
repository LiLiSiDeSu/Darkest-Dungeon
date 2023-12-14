using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Test1 : MonoBehaviour
{
    private void Update()
    {
        Debug.Log(Hot.Data_.DataListCellGameArchive[0].NowEventIndex + " - " + Hot.Data_.DataListCellGameArchive[0].e_NowExpeditionLocation);
    }
}
