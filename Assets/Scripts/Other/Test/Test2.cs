using UnityEngine;

public class Test2 : PanelBase
{
    private void Update()
    {
        Debug.Log(Hot.DataNowCellGameArchive.NowCellMiniMapPos.X + " - " + Hot.DataNowCellGameArchive.NowCellMiniMapPos.Y);
    }
}
