using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTownStoreItem : PanelBase
{
    public int NowIndex = 0;

    private Transform Content;

    protected override void Start()
    {
        base.Start();

        Content = transform.FindSonSonSon("Content");

        gameObject.SetActive(false);
    }
}
