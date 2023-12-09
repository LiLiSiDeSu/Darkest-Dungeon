using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PanelBaseVector2<T0, T1> : PanelBase
       where T0 : PanelBaseCellVector2, new()
       where T1 : PanelBaseGrid<T0>, new()
{
    public Transform AllContent;
    public Transform ImgBkContent;
    public Transform ImgStatusContent;
    public Transform ItemContent;
    public Transform ComponentRoot;

    public List<List<PanelBaseGrid<T0>>> Grids = new();
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

    public virtual void InitGrid(int Y, int X)
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

                Hot.MgrUI_.CreatePanel<T1>(false, "/" + typeof(T1).Name,
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

    public virtual void ChangeCellSize()
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

        foreach (var list in Grids)
        {
            foreach (var item in list)
            {
                item.Item?.ChangeCellSize();
            }
        }
    }

    public virtual void ClearImgStatus()
    {
        foreach (var list in Grids)
        {
            foreach (var item in list)
            {
                item.ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
            }
        }
    }

    public virtual void ClearItem()
    {
        foreach (var list in Grids)
        {
            foreach (var item in list)
            {
                if (item.Item != null)
                {
                    Destroy(item.Item.gameObject);
                    item.Item = null;
                }
            }
        }
    }

    public virtual void ClearList()
    {
        foreach (var list in Grids)
        {
            foreach (var item in list)
            {
                Destroy(item.gameObject);
            }
        }
        foreach (var item in ImgBkContent.GetComponentsInChildren<ContentStep>())
        {
            Destroy(item.gameObject);
        }
        foreach (var item in ImgStatusContent.GetComponentsInChildren<ContentStep>())
        {
            Destroy(item.gameObject);
        }
        foreach (var item in ItemContent.GetComponentsInChildren<ContentStep>())
        {
            Destroy(item.gameObject);
        }

        Grids.Clear();
        ItemRoot.Clear();
    }
}
