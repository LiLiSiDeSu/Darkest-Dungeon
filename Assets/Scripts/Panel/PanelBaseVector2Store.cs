using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBaseVector2Store : PanelBase
{
    public Transform AllContent;
    public Transform ImgBkContent;
    public Transform ImgStatusContent;
    public Transform ImgItemContent;
    public Transform ComponentRoot;

    public List<List<PanelCellTownItemGrid>> Grids = new();
    public List<List<Transform>> ItemRoot = new();

    public void ChangeSize()
    {
        ImgBkContent.GetComponent<GridLayoutGroup>().cellSize = Hot.SizeCellItemBody;
        ImgItemContent.GetComponent<GridLayoutGroup>().cellSize = Hot.SizeCellItemBody;
        ImgStatusContent.GetComponent<GridLayoutGroup>().cellSize = Hot.SizeCellItemBody;

        foreach (GridLayoutGroup item in ImgItemContent.GetComponentsInChildren<GridLayoutGroup>())
        {
            item.cellSize = Hot.SizeCellItemBody;
        }
    }
}
