using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTownItem : PanelBase
{
    public int NowIndex = 0;
    public PanelCellTownStore FatherPanelCellTownStore;
    private Transform ContentItem;

    protected override void Start()
    {
        base.Start();

        ContentItem = transform.FindSonSonSon("ContentItem");

        InitContent();

        gameObject.SetActive(false);
    }

    public void Show(PanelCellTownStore NowPanelCellTownStore)
    {
        if (MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").NowPanelCellTownStore == NowPanelCellTownStore)
        {
            PoolEsc.GetInstance().RemoveListNoInMgrUI
                               (MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").NowPanelCellTownStore.NowPanelTownStoreItem.gameObject);
            MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").NowPanelCellTownStore = null;
            gameObject.SetActive(false);
            return;
        }

        if (MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").NowPanelCellTownStore != null)
        {
            PoolEsc.GetInstance().RemoveListNoInMgrUI
                               (MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").NowPanelCellTownStore.NowPanelTownStoreItem.gameObject);
            MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").NowPanelCellTownStore.NowPanelTownStoreItem.gameObject.SetActive(false);
        }
        MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").NowPanelCellTownStore = NowPanelCellTownStore;
        PoolEsc.GetInstance().AddListNoInMgrUI(gameObject);
        gameObject.SetActive(true);
    } 

    public void InitContent()
    {
        for (int i = 0; i < FatherPanelCellTownStore.DataPanelCellTownStore.DataListCellItem.Count; i++)
        {
            int tempi = i;

            MgrUI.GetInstance().CreatePanelAndPush<PanelCellTownItem>
                             (false, "/PanelCellTownItem", callback :
            (panel) =>
            {
                panel.transform.SetParent(ContentItem);
                panel.DataPanelCellTownItem = FatherPanelCellTownStore.DataPanelCellTownStore.DataListCellItem[tempi];
                panel.IndexPanelCellItem = NowIndex;
                NowIndex++;
            });
        }
    }
}
