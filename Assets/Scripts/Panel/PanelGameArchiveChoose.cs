using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelGameArchiveChoose : PanelBase
{       
    public int NowIndex = 0;
    public int IndexNowCellGameArchive = -1;

    public Transform Content;    

    protected override void Start()
    {
        base.Start();

        Content = transform.FindSonSonSon("Content");
        transform.FindSonSonSon("ImgBackStartPanel").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgAddpanelGameArchivCell").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;

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
                    panel.transform.SetParent(Content, false);
                    panel.Index = NowIndex;
                    NowIndex += 1;
                    Data.GetInstance().DataListCellGameArchive.Add(new DataContainer_PanelCellGameArchive());
                    Data.GetInstance().Save(panel.Index);
                });
                break;
        }
    }
    
    private void InitContent()
    {
        for (int i = 0; i < Data.GetInstance().DataListCellGameArchive.Count; i++)
        {
            int tempi = i;
            MgrUI.GetInstance().CreatePanelAndPush<PanelCellGameArchive>
                             (false, "/PanelCellGameArchive", false, false, "PanelCellGameArchive", 
            (panel) =>
            {
                panel.transform.SetParent(Content, false);                
                panel.Index = NowIndex;
                NowIndex += 1;
            });
        } 
    }

    public void SortCellGameArchive()
    {
        PanelCellGameArchive[] all = Content.GetComponentsInChildren<PanelCellGameArchive>();
        for (int i = 0; i < all.Length; i++)
        {
            all[i].Index = i;            
        }
    }
}
