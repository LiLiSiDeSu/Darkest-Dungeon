using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCellExpeditionTimeLine : PanelBase
{
    public int X;
    public int Y;
    public PanelCellExpeditionRoom CellExpeditionRoom
    {
        get { return Hot.PanelExpeditionRoom_.Grids[Y][X].Item; }
    }

    public Image ImgRolePortrait;

    protected override void Awake()
    {
        base.Awake();

        ImgRolePortrait = transform.FindSonSonSon("ImgRolePortrait").GetComponent<Image>();
    }

    public void Init(int p_X, int p_Y, E_RoleName p_e_RoleName, Transform p_Fahter)
    {
        X = p_X; 
        Y = p_Y;

        transform.SetParent(p_Fahter, false);

        ImgRolePortrait.sprite = Hot.LoadSprite("Portrait" + p_e_RoleName.ToString());
    }
}
