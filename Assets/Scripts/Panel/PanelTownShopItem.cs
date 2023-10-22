using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelTownShopItem : PanelBaseItem, 
             IPointerEnterHandler, IPointerExitHandler
{   
    protected override void Awake()
    {
        base.Awake();

        Content = transform.FindSonSonSon("Content");        
    }

    #region EventSystem接口实现

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.NowPanelItem = this;
        Hot.e_NowPointerLocation = E_Location.PanelTownShopItem;

        if (Hot.DragingItem != null)
        {
            Hot.DragingItem.transform.SetParent(transform, false);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.NowPanelItem = null;
        Hot.e_NowPointerLocation = E_Location.None;
    }

    #endregion

    public void UpdateContent()
    {
        NowIndex = 0;

        for (int i = 0; i < Hot.DataNowCellGameArchive.ListCellShopItem.Count; i++)
        {
            int tempi = i;

            MgrUI.GetInstance().CreatePanelAndPush<PanelCellTownItem>
            (false, "/PanelCellTownItem", callback:
            (panel) =>
            {
                panel.transform.SetParent(Content, false);
                panel.MemberOf = this;
                panel.e_Location = E_Location.PanelTownShopItem;
                panel.e_SpriteNamePanelCellItem = Hot.DataNowCellGameArchive.ListCellShopItem[tempi].e_SpriteNamePanelCellItem;
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

    public override void SortContent()
    {
        List<DataContainer_PanelCellItem> data = new List<DataContainer_PanelCellItem>();
        PanelCellTownItem[] all = transform.GetComponentsInChildren<PanelCellTownItem>();
        for (int i = 0; i < all.Length; i++)
        {
            data.Add(Hot.DataNowCellGameArchive.ListCellShopItem[all[i].Index]);
            all[i].Index = i;            
        }
        Hot.DataNowCellGameArchive.ListCellShopItem = data;
    }
}
