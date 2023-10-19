using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelShopItem : PanelBase
{
    public int NowIndex;    
    public Transform Content;

    protected override void Awake()
    {
        base.Awake();

        Content = transform.FindSonSonSon("Content");        
    }

    public void UpdateContent()
    {
        NowIndex = 0;

        for (int i = 0; i < GlobalHot.NowCellGameArchive.DataListCellShopItem.Count; i++)
        {
            int tempi = i;

            MgrUI.GetInstance().CreatePanelAndPush<PanelCellTownItem>
            (false, "/PanelCellTownItem", callback:
            (panel) =>
            {
                panel.transform.SetParent(Content, false);
                panel.e_Location = E_Location.TownShop;
                panel.Index = NowIndex;
                NowIndex++;
            });
        }
    }

    public void DestroyContent()
    {
        PanelCellTownItem[] all = Content.GetComponentsInChildren<PanelCellTownItem>();
        for (int i = 0; i < all.Length; i++)
            DestroyImmediate(all[i].gameObject);
    }

    public void AddIte()
    {

    }

    public void Subtraction()
    {

    }
}
