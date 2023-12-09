using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBaseGrid<T> : PanelBase
       where T : PanelBaseCellVector2, new()
{
    public int X;
    public int Y;

    public Image ImgBk;
    public Image ImgStatus;

    public T Item;

    protected override void Awake()
    {
        base.Awake();

        ImgBk = transform.FindSonSonSon("ImgBk").GetComponent<Image>();
        ImgStatus = transform.FindSonSonSon("ImgStatus").GetComponent<Image>();

        ImgBk.alphaHitTestMinimumThreshold = 0.2f;
    }

    public void Init(int p_X, int p_Y, Transform father)
    {
        X = p_X;
        Y = p_Y;

        ImgBk.gameObject.name = X.ToString();
        ImgStatus.gameObject.name = X.ToString();

        transform.SetParent(father, false);
        gameObject.name = p_Y.ToString();
    }
}
