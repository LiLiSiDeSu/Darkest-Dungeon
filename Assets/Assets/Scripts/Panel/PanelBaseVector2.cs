using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBaseVector2<T> : PanelBase
       where T : PanelBaseGrid, new()
{
    public Transform AllContent;
    public Transform ImgBkContent;
    public Transform ImgStatusContent;
    public Transform ItemContent;
    public Transform ComponentRoot;

    public List<List<T>> Grids = new();
    public List<List<Transform>> ItemRoot = new();

    protected override void Awake()
    {
        base.Awake();

        AllContent = transform.FindSonSonSon("AllContent");
        ImgBkContent = transform.FindSonSonSon("ImgBkContent");
        ItemContent = transform.FindSonSonSon("ItemContent");
        ImgStatusContent = transform.FindSonSonSon("ImgStatusContent");
        ComponentRoot = transform.FindSonSonSon("ComponentRoot");
    }

    public void InitGrid(int Y, int X)
    {
        (AllContent as RectTransform).sizeDelta = new(X * Hot.BodySizeCellMinimap.X, Y * Hot.BodySizeCellMinimap.Y);

        for (int iY = 0; iY < Y; iY++)
        {
            int tempiY = iY;

            Grids.Add(new());
            ItemRoot.Add(new());

            GameObject ImgBkY = Hot.CreateContentStepY(tempiY, ImgBkContent);
            GameObject ImgStatusY = Hot.CreateContentStepY(tempiY, ImgStatusContent);
            GameObject ItemY = Hot.CreateContentStepY(tempiY, ItemContent);

            for (int iX = 0; iX < X; iX++)
            {
                int tempiX = iX;

                Grids[tempiY].Add(new());

                GameObject ItemX = Hot.CreateContentStepX(tempiX, ItemY.transform);

                ItemRoot[tempiY].Add(ItemX.transform);

                Hot.MgrUI_.CreatePanel<T>(false, "/" + typeof(T).Name,
                (panel) =>
                {
                    Grids[tempiY][tempiX] = panel;

                    panel.Init(tempiX, tempiY, ComponentRoot);

                    panel.ImgBk.transform.SetParent(ImgBkY.transform, false);
                    panel.ImgStatus.transform.SetParent(ImgStatusY.transform, false);
                });
            }
        }

        ChangeCellSize();
    }

    public void ChangeCellSize()
    {
        foreach (GridLayoutGroup item in ItemContent.GetComponentsInChildren<GridLayoutGroup>())
        {
            item.cellSize = new(Hot.BodySizeCellMinimap.X, Hot.BodySizeCellMinimap.Y);
        }
        foreach (GridLayoutGroup item in ImgBkContent.GetComponentsInChildren<GridLayoutGroup>())
        {
            item.cellSize = new(Hot.BodySizeCellMinimap.X, Hot.BodySizeCellMinimap.Y);
        }
        foreach (GridLayoutGroup item in ImgStatusContent.GetComponentsInChildren<GridLayoutGroup>())
        {
            item.cellSize = new(Hot.BodySizeCellMinimap.X, Hot.BodySizeCellMinimap.Y);
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

    public virtual void ClearList()
    {
        Grids.Clear();
        ItemRoot.Clear();
    }
}
