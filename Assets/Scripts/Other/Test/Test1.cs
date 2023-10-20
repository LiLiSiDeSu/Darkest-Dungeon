using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Test1 : MonoBehaviour
{
    private void Update()
    {
        Debug.Log("PanelTownItem" + Hot.DataNowPanelTownItem[Hot.DataNowPanelTownItem.Count - 1]);
        Debug.Log("Shop: " + Hot.DataPanelTownShopItem[Hot.DataPanelTownShopItem.Count - 1]);
    }
}
