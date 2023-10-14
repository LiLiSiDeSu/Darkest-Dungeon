using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTownStoreItem : PanelBase
{
    private Transform ContentItem;

    protected override void Start()
    {
        base.Start();

        ContentItem = transform.FindSonSonSon("ContentItem");

        gameObject.SetActive(false);
    }

    public void Show(PanelCellTownStore NowPanelCellTownStore)
    {
        if (MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").NowPanelCellTownStore != null)
        {
            PoolEsc.GetInstance().RemoveListNoInMgrUI
                               (MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").NowPanelCellTownStore.PanelItem.gameObject);
            MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").NowPanelCellTownStore.PanelItem.gameObject.SetActive(false);
        }
        MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").NowPanelCellTownStore = NowPanelCellTownStore;
        PoolEsc.GetInstance().AddListNoInMgrUI(gameObject);        
        gameObject.SetActive(true);
    } 
}
