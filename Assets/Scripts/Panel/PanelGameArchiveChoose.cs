using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelGameArchiveChoose : PanelBase
{       
    public int NowIndex = 0;    

    public Transform Content;
    public PanelCellGameArchive NowGameArchive = new PanelCellGameArchive();

    protected override void Start()
    {
        base.Start();

        Content = transform.FindSonSonSon("Content");
        transform.FindSonSonSon("BtnBackStartPanel").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;

        InitContent();                
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
                    panel.transform.parent = Content;
                    panel.IndexCellGameArchive = NowIndex;
                    NowIndex += 1;
                    MgrData.GetInstance().DataListCellGameArchive.Add(new DataContainer_PanelCellGameArchive());
                    MgrData.GetInstance().Save();
                });
                break;
        }
    }
    
    private void InitContent()
    {
        for (int i = 0; i < MgrData.GetInstance().DataListCellGameArchive.Count; i++)
        {
            int tempi = i;
            MgrUI.GetInstance().CreatePanelAndPush<PanelCellGameArchive>
                             (false, "/PanelCellGameArchive", false, false, "PanelCellGameArchive", 
            (panel) =>
            {
                panel.transform.SetParent(Content, false);
                panel.DataPanelCellGameArchive = MgrData.GetInstance().DataListCellGameArchive[tempi];
                panel.IndexCellGameArchive = NowIndex;
                NowIndex += 1;
            });
        } 
    }

    public void SortCellGameArchive()
    {
        PanelCellGameArchive[] all = Content.GetComponentsInChildren<PanelCellGameArchive>();
        for (int i = 0; i < all.Length; i++)
        {
            all[i].IndexCellGameArchive = i;            
        }
    }
}
