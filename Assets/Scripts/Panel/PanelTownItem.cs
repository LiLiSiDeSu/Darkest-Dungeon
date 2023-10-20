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
        Hot.e_NowPointerLocation = E_Location.PanelTownItem;

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

    public void Show(PanelCellTownStore NowPanelCellTownStore)
    {
        if (Hot.PanelTownStore_.NowPanelCellTownStore == NowPanelCellTownStore)
        {
            PoolEsc.GetInstance().RemoveListNoInMgrUI(gameObject);
            Hot.PanelTownStore_.NowPanelCellTownStore = null;            
            gameObject.SetActive(false);
            return;
        }

        if (Hot.PanelTownStore_.NowPanelCellTownStore != null)
        {
            PoolEsc.GetInstance().RemoveListNoInMgrUI(gameObject);
            Hot.PanelTownStore_.NowPanelCellTownStore.PanelCellItem_.gameObject.SetActive(false);
        }
        Hot.PanelTownStore_.NowPanelCellTownStore = NowPanelCellTownStore;
        PoolEsc.GetInstance().AddListNoInMgrUI(gameObject, 
        () => 
        {
            Hot.PanelTownStore_.NowPanelCellTownStore = null;            
        });
        gameObject.SetActive(true);
    }     

    public void UpdateContent()
    {
        NowIndex = 0;

        for (int i = 0; i < Hot.DataNowCellGameArchive.DataListCellStore[FatherPanelCellTownStore.Index].DataListCellStoreItem.Count; i++)
        {
            int tempi = i;

            MgrUI.GetInstance().CreatePanelAndPush<PanelCellTownItem>
                             (false, "/PanelCellTownItem", callback :
            (panel) =>
            {
                panel.transform.SetParent(Content, false);
                panel.e_Location = E_Location.PanelTownItem;
                panel.e_SpriteNamePanelCellItem = 
                    Hot.DataNowCellGameArchive.DataListCellStore[FatherPanelCellTownStore.Index].
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
