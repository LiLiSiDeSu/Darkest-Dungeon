using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test2 : MonoBehaviour
{
    private void Update()
    {
        Debug.Log(Hot.DataNowCellGameArchive.NowCellMiniMapPos.X + " - " + Hot.DataNowCellGameArchive.NowCellMiniMapPos.Y);
    }
}
