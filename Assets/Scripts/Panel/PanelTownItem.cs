using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelTownItem : PanelBaseItem, 
             IPointerEnterHandler, IPointerExitHandler
{        
    public PanelCellTownStore FatherPanelCellTownStore;    
    
    protected override void Awake()
    {
        base.Awake();        

        Content = transform.FindSonSonSon("Content");        

        gameObject.SetActive(false);
    }

    #region EventSystem接口实现

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.NowPanelItem = this;        
        Hot.e_NowPointerLocation = E_Location.PanelTownItem;        

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

    public void Hide()
    {        
        Hot.MgrUI_.HidePanel(false, gameObject, gameObject.name);
    }

    public void Show()
    {
        Hot.MgrUI_.ShowPanel<PanelTownItem>(true, gameObject.name,
            (panel) =>
            {
                panel.transform.SetParent(Hot.PanelTownStore_.RootPanelTownItem, false);
            });
    }     

    public void ShowForBtn()
    {
        if (PoolNowPanel.GetInstance().ListNowPanel.Contains(gameObject.name))
        {
            Hide();
            Show();
            return;
        }
        Show();
    }

    public void InitContent()
    {
        NowIndex = 0;

        for (int i = 0; i < Hot.DataNowCellGameArchive.ListCellStore[FatherPanelCellTownStore.Index].ListCellStoreItem.Count; i++)
        {
            int tempi = i;

            MgrUI.GetInstance().CreatePanelAndPush<PanelCellTownItem>
                             (false, "/PanelCellTownItem", callback :
            (panel) =>
            {
                panel.transform.SetParent(Content, false);
                panel.MemberOf = this;                
                panel.e_Location = E_Location.PanelTownItem;
                panel.e_SpriteNamePanelCellItem = 
                    Hot.DataNowCellGameArchive.ListCellStore[FatherPanelCellTownStore.Index].
                    ListCellStoreItem[tempi].e_SpriteNamePanelCellItem;
                panel.Index = NowIndex;                
                NowIndex++;
            });
        }
    }

    public override void SortContent()
    {
        List<DataContainer_CellItem> data = new List<DataContainer_CellItem>();
        PanelCellTownItem[] all = transform.GetComponentsInChildren<PanelCellTownItem>();
        for (int i = 0; i < all.Length; i++)
        {
            data.Add(Hot.DataNowCellGameArchive.ListCellStore[FatherPanelCellTownStore.Index].ListCellStoreItem[all[i].Index]);            
            all[i].Index = i;            
        }
        Hot.DataNowCellGameArchive.ListCellStore[FatherPanelCellTownStore.Index].ListCellStoreItem = data;
    }
}
