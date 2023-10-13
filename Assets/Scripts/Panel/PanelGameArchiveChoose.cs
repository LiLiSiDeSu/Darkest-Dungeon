using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelGameArchiveChoose : PanelBase
{       
    public int PanelGameArchiveCellNowIndex = 0;    

    public Transform Content;        

    protected override void Start()
    {
        base.Start();

        Content = transform.FindSonSonSon("Content");
        transform.FindSonSonSon("BtnBackStartPanel").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;

        InitContent();
        
        gameObject.SetActive(false);
    }    

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnBackStartPanel":
                MgrUI.GetInstance().HidePanel(false, gameObject, "PanelGameArchiveChoose");
                MgrUI.GetInstance().ShowPanel<PanelOtherStart>
                (false, "PanelOtherStart", (panel) =>
                {

                });
                break;

            case "BtnAddpanelGameArchivCell":
                MgrUI.GetInstance().CreatePanelAndPush<PanelCellGameArchive>
                (false, "/PanelCellGameArchive", false, false, "PanelCellGameArchive",
                (panel) =>
                {
                    panel.transform.SetParent(Content, false);
                    panel.IndexGameArchiveCell = PanelGameArchiveCellNowIndex;
                    PanelGameArchiveCellNowIndex += 1;
                    StartDataAndMgr.GetInstance().ListGameArchiveDataCell.Add(new DataContainer_CellGameArchive());
                    MgrXml.GetInstance().Save(StartDataAndMgr.GetInstance().ListGameArchiveDataCell, 
                                              StartDataAndMgr.GetInstance().PathGameArchiveData);                    
                });
                break;
        }
    }
    
    private void InitContent()
    {
        for (int i = 0; i < StartDataAndMgr.GetInstance().ListGameArchiveDataCell.Count; i++)
        {
            int tempi = i;
            MgrUI.GetInstance().CreatePanelAndPush<PanelCellGameArchive>
                             (false, "/PanelCellGameArchive", false, false, "PanelCellGameArchive", 
            (panel) =>
            {
                panel.transform.SetParent(Content, false);
                panel.GameArchiveCellData = StartDataAndMgr.GetInstance().ListGameArchiveDataCell[tempi];
                panel.IndexGameArchiveCell = PanelGameArchiveCellNowIndex;
                PanelGameArchiveCellNowIndex += 1;
            });
        } 
    }

    public void GameArchiveCellSort()
    {
        PanelCellGameArchive[] all = Content.GetComponentsInChildren<PanelCellGameArchive>();
        for (int i = 0; i < all.Length; i++)
        {
            all[i].IndexGameArchiveCell = i;            
        }
    }
}
