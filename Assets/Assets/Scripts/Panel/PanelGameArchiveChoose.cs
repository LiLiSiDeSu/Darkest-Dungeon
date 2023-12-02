using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelGameArchiveChoose : PanelBaseDynamicScrollView
{                   
    protected override void Start()
    {
        base.Start();        

        Content = transform.FindSonSonSon("GameArchiveContent");

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
                MgrUI.GetInstance().ShowPanel<PanelOtherStart>(false, "PanelOtherStart");
                break;

            case "BtnAddpanelGameArchivCell":
                AddGameArchive();
                break;
        }
    }
    
    public override void InitContent()
    {
        for (int i = 0; i < Data.GetInstance().DataListCellGameArchive.Count; i++)
        {
            int tempi = i;
            MgrUI.GetInstance().CreatePanelAndPush<PanelCellGameArchive>
            (false, "/PanelCellGameArchive", false, false, "PanelCellGameArchive", 
            (panel) =>
            {                                                                
                panel.Index = tempi;                
                GameObject obj = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "DynamicContentStepFor" + panel.PrefabsDynamicContentStepSuffix);
                obj.name = tempi.ToString();
                obj.transform.SetParent(Content, false);
                obj.GetComponent<DynamicContentStep>().Init(tempi);
                panel.transform.SetParent(obj.GetComponent<DynamicContentStep>().DependentObjRoot, false);
                ListDynamicContentStep.Add(obj.GetComponent<DynamicContentStep>());

                panel.Init(Hot.Data_.DataListCellGameArchive[tempi]);
            });

            NowIndex += 1;
        } 
    }

    public override void SortContent()
    {
        DynamicContentStep[] allDynamicContentStep = transform.GetComponentsInChildren<DynamicContentStep>();
        List<DynamicContentStep> tempList = new();
        for (int i = 0; i < allDynamicContentStep.Length; i++)
        {
            tempList.Add(allDynamicContentStep[i]);
            tempList[i].SetIndex(i);
            tempList[i].gameObject.name = i.ToString();
        }
        ListDynamicContentStep = tempList;

        PanelCellGameArchive[] all = Content.GetComponentsInChildren<PanelCellGameArchive>();
        List<DataContainer_PanelCellGameArchive> allData = new();
        for (int i = 0; i < all.Length; i++)
        {
            allData.Add(Hot.Data_.DataListCellGameArchive[all[i].Index]);
            all[i].Index = i;            
        }

        Hot.Data_.DataListCellGameArchive = allData;

        Hot.Data_.SaveAll();
    }

    public void AddGameArchive()
    {
        MgrUI.GetInstance().CreatePanelAndPush<PanelCellGameArchive>
        (false, "/PanelCellGameArchive", false, false, "PanelCellGameArchive",
        (panel) =>
        {
            panel.Index = NowIndex;                        
            GameObject obj = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "DynamicContentStepFor" + panel.PrefabsDynamicContentStepSuffix);
            obj.name = panel.Index.ToString();
            obj.transform.SetParent(Content, false);
            obj.GetComponent<DynamicContentStep>().Init(panel.Index);
            panel.transform.SetParent(obj.GetComponent<DynamicContentStep>().DependentObjRoot, false);
            ListDynamicContentStep.Add(obj.GetComponent<DynamicContentStep>());            

            Hot.Data_.DataListCellGameArchive.Add(new DataContainer_PanelCellGameArchive());
            panel.Init(Hot.Data_.DataListCellGameArchive[panel.Index]);
            Hot.Data_.Save(panel.Index);

            SortContent();

            NowIndex += 1;
        });        
    }    
}
