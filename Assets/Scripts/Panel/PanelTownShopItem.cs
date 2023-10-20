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

        for (int i = 0; i < Hot.NowCellGameArchive.DataListCellShopItem.Count; i++)
        {
            int tempi = i;

            MgrUI.GetInstance().CreatePanelAndPush<PanelCellTownItem>
            (false, "/PanelCellTownItem", callback:
            (panel) =>
            {
                panel.transform.SetParent(Content, false);
                panel.e_Location = E_Location.PanelTownShopItem;
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

    /// <summary>
    /// 把别的Content下指定的Item添加到指定位置
    /// </summary>
    /// <param name="e_AddLocation">添加到哪里</param>
    public void AddItem(E_Location e_AddLocation)
    {
        switch (e_AddLocation)
        {            
            case E_Location.PanelTownItem:
                Hot.NowItem.e_Location = E_Location.PanelTownItem;
                Hot.NowItem.Index = NowIndex;
                NowIndex++;
                break;
            case E_Location.PanelTownShopItem:
                break;           
        }
    }

    /// <summary>
    /// 删除Content下指定的Item
    /// </summary>
    /// <param name="e_SubtractionLocation">从哪删除</param>
    public void Subtraction(E_Location e_SubtractionLocation)
    {

    }
}
