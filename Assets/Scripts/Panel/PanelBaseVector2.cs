using System;
using System.Collections.Generic;
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

    public float LimitAdd = 0f;
    public float LimitReduce = 0f;

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

        Hot.MgrUI_.AddCustomEventListener(AllContent.gameObject, UnityEngine.EventSystems.EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.NowEnterContent = AllContent;
        });
        Hot.MgrUI_.AddCustomEventListener(AllContent.gameObject, UnityEngine.EventSystems.EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.NowEnterContent = null;
        });
        Hot.TriggerEvent_.AddEventListener<KeyCode>
        (E_KeyEvent.KeyHold.ToString(),
        (key) =>
        {
            if (Hot.NowEnterContent != null && Hot.NowEnterContent == AllContent)
            {
                if (key == Hot.MgrInput_.Add && AllContent.localScale.x < LimitAdd)
                {
                    AllContent.localScale += new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime);
                }
                else if (key == Hot.MgrInput_.Reduce && AllContent.localScale.x > LimitReduce)
                {
                    AllContent.localScale -= new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime);
                }
            }
        });
    }

    public virtual void InitGrids(int Y, int X)
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

                Hot.MgrUI_.CreatePanel<T1>(false, (E_PanelName)Enum.Parse(typeof(E_PanelName), typeof(T1).Name),
                (panel) =>
                {
                    Grids[tempiY][tempiX] = panel;

                    panel.Init(tempiX, tempiY, ComponentRoot);

                    panel.ImgBk.transform.SetParent(ImgBkY.transform, false);
                    panel.ImgStatus.transform.SetParent(ImgStatusY.transform, false);

                    if (tempiY == Y - 1 && tempiX == X - 1)
                    {
                        End();
                    }
                });
            }
        }

        ChangeCellSize();
    }

    public virtual void End()
    {

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

    public void EnableImgBkRayCast()
    {
        foreach (var list in Grids)
        {
            foreach (var item in list)
            {
                item.ImgBk.raycastTarget = true;
            }
        }
    }

    public void DisableImgBkRaycast()
    {
        foreach (var list in Grids)
        {
            foreach (var item in list)
            {
                item.ImgBk.raycastTarget = false;
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

    public virtual void ClearAll()
    {
        int tempCount = 0;
        tempCount = ItemContent.childCount;
        for (int i = 0; i < tempCount; i++)
        {
            DestroyImmediate(ItemContent.GetChild(0).gameObject);
        }
        tempCount = ImgBkContent.childCount;
        for (int i = 0; i < tempCount; i++)
        {
            DestroyImmediate(ImgBkContent.GetChild(0).gameObject);
        }
        tempCount = ImgStatusContent.childCount;
        for (int i = 0; i < tempCount; i++)
        {
            DestroyImmediate(ImgStatusContent.GetChild(0).gameObject);
        }
        tempCount = ComponentRoot.childCount;
        for (int i = 0; i < tempCount; i++)
        {
            DestroyImmediate(ComponentRoot.GetChild(0).gameObject);
        }

        Grids.Clear();
        ItemRoot.Clear();
    }
}
