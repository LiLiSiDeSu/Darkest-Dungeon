using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBaseGrid : PanelBase
{
    public int X;
    public int Y;

    public Image ImgBk;
    public Image ImgStatus;

    protected override void Awake()
    {
        base.Awake();

        ImgBk = transform.FindSonSonSon("ImgBk").GetComponent<Image>();
        ImgStatus = transform.FindSonSonSon("ImgStatus").GetComponent<Image>();
    }

    public void Init(int p_X, int p_Y, Transform father)
    {
        X = p_X;
        Y = p_Y;

        transform.SetParent(father, false);
        gameObject.name = p_Y.ToString();
    }
}
