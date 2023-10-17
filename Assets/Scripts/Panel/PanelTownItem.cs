using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTownItem : PanelBase
{    
    public int NowIndex;
    public PanelCellTownStore FatherPanelCellTownStore;
    private Transform Content;

    protected override void Start()
    {
        base.Start();

        Content = transform.FindSonSonSon("Content");

        InitContent();   

        gameObject.SetActive(false);
    }

    public void Show(PanelCellTownStore NowPanelCellTownStore)
    {
        if (MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").NowPanelCellTownStore == NowPanelCellTownStore)
        {
            PoolEsc.GetInstance().RemoveListNoInMgrUI(gameObject);
            MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").NowPanelCellTownStore = null;            
            gameObject.SetActive(false);
            return;
        }

        if (MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").NowPanelCellTownStore != null)
        {
            PoolEsc.GetInstance().RemoveListNoInMgrUI(gameObject);
            MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").NowPanelCellTownStore.NowPanelTownStoreItem.gameObject.SetActive(false);
        }
        MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").NowPanelCellTownStore = NowPanelCellTownStore;
        PoolEsc.GetInstance().AddListNoInMgrUI(gameObject, 
        () => 
        {
            MgrUI.GetInstance().GetPanel<PanelTownStore>("PanelTownStore").NowPanelCellTownStore = null;            
        });
        gameObject.SetActive(true);
    } 

    public void InitContent()
    {
        for (int i = 0; i < GlobalHot.NowCellGameArchive.DataListCellStore[FatherPanelCellTownStore.Index].DataListCellItem.Count; i++)
        {
            int tempi = i;

            MgrUI.GetInstance().CreatePanelAndPush<PanelCellTownItem>
                             (false, "/PanelCellTownItem", callback :
            (panel) =>
            {
                panel.transform.SetParent(Content);               
                panel.Index = NowIndex;
                NowIndex++;
            });
        }
    }
}
