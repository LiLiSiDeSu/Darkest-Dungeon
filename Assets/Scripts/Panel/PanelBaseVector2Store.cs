using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBaseVector2Store : PanelBase
{
    public int NowCapacity = 0;

    public Transform AllContent;
    public Transform ImgBkContent;
    public Transform ImgStatusContent;
    public Transform ItemContent;
    public Transform ComponentRoot;

    public List<List<PanelCellTownItemGrid>> Grids = new();
    public List<List<Transform>> ItemRoot = new();

    public void ChangeSize()
    {
        ImgBkContent.GetComponent<GridLayoutGroup>().cellSize = new(Hot.SizeCellItemBody.X, Hot.SizeCellItemBody.Y);
        ItemContent.GetComponent<GridLayoutGroup>().cellSize = new(Hot.SizeCellItemBody.X, Hot.SizeCellItemBody.Y);
        ImgStatusContent.GetComponent<GridLayoutGroup>().cellSize = new(Hot.SizeCellItemBody.X, Hot.SizeCellItemBody.Y);

        foreach (GridLayoutGroup item in ItemContent.GetComponentsInChildren<GridLayoutGroup>())
        {
            item.cellSize = new(Hot.SizeCellItemBody.X, Hot.SizeCellItemBody.Y);
        }

        foreach (List<Transform> listItem in ItemRoot)
        {
            foreach (Transform item in listItem)
            {
                if (item.childCount > 0)
                {
                    item.GetComponentInChildren<PanelCellItem>().ChangeSize();
                }
            }
        }
    }

    public virtual void InitInfo() { }

    public virtual void UpdateInfoByAdd(E_SpriteNamePanelCellItem e_SpriteNamePanelCellItem) { }    

    public virtual void UpdateInfoBySubtract(E_SpriteNamePanelCellItem e_SpriteNamePanelCellItem) { }

    public virtual void ClearList()
    {
        Grids.Clear();
        ItemRoot.Clear();
    }
}
