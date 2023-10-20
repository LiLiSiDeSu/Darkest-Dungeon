using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelTownShopItem : PanelBase, 
             IPointerEnterHandler, IPointerExitHandler
{
    public int NowIndex;    
    public Transform Content;    

    protected override void Awake()
    {
        base.Awake();

        Content = transform.FindSonSonSon("Content");        
    }

    #region EventSystem接口实现

    public void OnPointerEnter(PointerEventData eventData)
    {        
        Hot.e_NowPointerLocation = E_Location.PanelTownShopItem;

        if (Hot.NowItem != null)
        {
            Hot.NowItem.transform.SetParent(transform, false);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {        
        Hot.e_NowPointerLocation = E_Location.None;
    }

    #endregion

    public void UpdateContent()
    {
        NowIndex = 0;

        for (int i = 0; i < Hot.DataNowCellGameArchive.DataListCellShopItem.Count; i++)
        {
            int tempi = i;

            MgrUI.GetInstance().CreatePanelAndPush<PanelCellTownItem>
            (false, "/PanelCellTownItem", callback:
            (panel) =>
            {
                panel.transform.SetParent(Content, false);
                panel.e_Location = E_Location.PanelTownShopItem;
                panel.e_SpriteNamePanelCellItem = Hot.DataNowCellGameArchive.DataListCellShopItem[tempi].e_SpriteNamePanelCellItem;
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

    public void SortContent()
    {
        PanelCellTownItem[] all = transform.GetComponentsInChildren<PanelCellTownItem>();
        for (int i = 0; i < all.Length; i++)
        {
            all[i].Index = i;
        }
    }
}
