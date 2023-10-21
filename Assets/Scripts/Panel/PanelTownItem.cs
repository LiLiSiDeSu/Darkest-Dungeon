using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelTownItem : PanelBase, 
             IPointerEnterHandler, IPointerExitHandler
{    
    public int NowIndex;
    public PanelCellTownStore FatherPanelCellTownStore;
    public Transform Content;
    
    protected override void Awake()
    {
        base.Awake();        

        Content = transform.FindSonSonSon("Content");        

        gameObject.SetActive(false);
    }

    #region EventSystem接口实现

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.NowPanelCellTownStore = FatherPanelCellTownStore;
        Hot.e_NowPointerLocation = E_Location.PanelTownItem;        

        if (Hot.DragingItem != null)
        {
            Hot.DragingItem.transform.SetParent(transform, false);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {        
        Hot.e_NowPointerLocation = E_Location.None;
    }

    #endregion

    public void Hide()
    {        
        Hot.MgrUI_.HidePanel(false, gameObject, gameObject.name);
    }

    public void Show()
    {        
        if (!PoolNowPanel.GetInstance().ListNowPanel.Contains(gameObject.name))
        {
            Hot.MgrUI_.ShowPanel<PanelTownItem>(true, gameObject.name,
            (panel) =>
            {
                panel.transform.SetParent(Hot.PanelTownStore_.RootPanelTownItem, false);
            });
        }
    }     

    public void UpdateContent()
    {
        NowIndex = 0;

        for (int i = 0; i < Hot.DataNowCellGameArchive.ListCellStore[FatherPanelCellTownStore.Index].DataListCellStoreItem.Count; i++)
        {
            int tempi = i;

            MgrUI.GetInstance().CreatePanelAndPush<PanelCellTownItem>
                             (false, "/PanelCellTownItem", callback :
            (panel) =>
            {
                panel.transform.SetParent(Content, false);
                panel.e_Location = E_Location.PanelTownItem;
                panel.e_SpriteNamePanelCellItem = 
                    Hot.DataNowCellGameArchive.ListCellStore[FatherPanelCellTownStore.Index].
                    DataListCellStoreItem[tempi].e_SpriteNamePanelCellItem;
                panel.Index = NowIndex;                
                NowIndex++;
            });
        }
    }

    public void SortContent()
    {
        PanelCellTownItem[] all = transform.GetComponentsInChildren<PanelCellTownItem>();
        for (int i = 0; i < all.Length; i++)
        {
            all[i].Index = i;
        }
    }

    public void Add()
    {

    }

    public void Subtraction()
    {

    }    
}
