using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelGameArchiveChoose : PanelBase,
             IPointerEnterHandler, IPointerExitHandler
{       
    public int NowIndex = 0;    

    public Transform GameArchiveContent;

    public List<DynamicContentStepForPanelCellRole> ListDynamicContentStep = new();

    protected override void Start()
    {
        base.Start();

        Hot.CenterEvent_.AddEventListener<bool, int, E_ArrowDirection>
        ("DynamicContentStepForPanelCellRole",
        (isInside, index, arrow) =>
        {
            if (isInside)
            {
                Hot.PaddingContentStep_.transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);                

                switch (Hot.e_NowPointerLocation)
                {
                    case E_NowPointerLocation.PanelRoleList:
                        Hot.PaddingContentStep_.transform.SetParent(Hot.PanelRoleList_.RoleContent, false);
                        break;
                    case E_NowPointerLocation.PanelGameArchiveChoose:
                        Hot.PaddingContentStep_.transform.SetParent(Hot.PanelGameArchiveChoose_.GameArchiveContent, false);
                        break;
                }

                Hot.PaddingContentStep_.gameObject.SetActive(true);

                Hot.IndexPaddingContentStep = index;

                switch (arrow)
                {
                    case E_ArrowDirection.Up:
                        Debug.Log(index + " - " + arrow);
                        Hot.e_PaddingArrowDirection = E_ArrowDirection.Up;
                        for (int i = index; i < ListDynamicContentStep.Count; i++)
                        {                            
                            switch (Hot.e_NowPointerLocation)
                            {
                                case E_NowPointerLocation.PanelRoleList:
                                    Hot.PanelRoleList_.ListDynamicContentStep[i].transform.
                                        SetParent(Hot.MgrUI_.UIBaseCanvas, false);
                                    Hot.PanelRoleList_.ListDynamicContentStep[i].transform.
                                        SetParent(Hot.PanelRoleList_.RoleContent, false);
                                    break;
                                case E_NowPointerLocation.PanelGameArchiveChoose:
                                    Hot.PanelGameArchiveChoose_.ListDynamicContentStep[i].transform.
                                        SetParent(Hot.MgrUI_.UIBaseCanvas, false);
                                    Hot.PanelGameArchiveChoose_.ListDynamicContentStep[i].transform.
                                        SetParent(Hot.PanelGameArchiveChoose_.GameArchiveContent, false);
                                    break;
                            }
                        }
                        break;
                    case E_ArrowDirection.Down:
                        Debug.Log(index + " - " + arrow);
                        Hot.e_PaddingArrowDirection = E_ArrowDirection.Down;
                        for (int i = index + 1; i < ListDynamicContentStep.Count; i++)
                        {
                            switch (Hot.e_NowPointerLocation)
                            {
                                case E_NowPointerLocation.PanelRoleList:
                                    Hot.PanelRoleList_.ListDynamicContentStep[i].transform.
                                        SetParent(Hot.MgrUI_.UIBaseCanvas, false);
                                    Hot.PanelRoleList_.ListDynamicContentStep[i].transform.
                                        SetParent(Hot.PanelRoleList_.RoleContent, false);
                                    break;
                                case E_NowPointerLocation.PanelGameArchiveChoose:
                                    Hot.PanelGameArchiveChoose_.ListDynamicContentStep[i].transform.
                                        SetParent(Hot.MgrUI_.UIBaseCanvas, false);
                                    Hot.PanelGameArchiveChoose_.ListDynamicContentStep[i].transform.
                                        SetParent(Hot.PanelGameArchiveChoose_.GameArchiveContent, false);
                                    break;
                            }
                        }
                        break;
                }
            }
        });

        GameArchiveContent = transform.FindSonSonSon("GameArchiveContent");

        transform.FindSonSonSon("ImgBackStartPanel").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgAddpanelGameArchivCell").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;

        InitContent();                
    }

    #region EventSystem接口实现

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.e_NowPointerLocation = E_NowPointerLocation.PanelGameArchiveChoose;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.e_NowPointerLocation = E_NowPointerLocation.None;

    }

    #endregion

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
    
    private void InitContent()
    {
        for (int i = 0; i < Data.GetInstance().DataListCellGameArchive.Count; i++)
        {
            int tempi = i;
            MgrUI.GetInstance().CreatePanelAndPush<PanelCellGameArchive>
                             (false, "/PanelCellGameArchive", false, false, "PanelCellGameArchive", 
            (panel) =>
            {                                                                
                panel.Index = tempi;                
                GameObject obj = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "DynamicContentStepForPanelCellGameArchive");
                obj.name = tempi.ToString();
                obj.transform.SetParent(GameArchiveContent, false);
                obj.GetComponent<DynamicContentStepForPanelCellRole>().Init(tempi);
                panel.transform.SetParent(obj.GetComponent<DynamicContentStepForPanelCellRole>().DependentObjRoot, false);
                ListDynamicContentStep.Add(obj.GetComponent<DynamicContentStepForPanelCellRole>());
                panel.Init(Hot.Data_.DataListCellGameArchive[tempi]);
            });

            NowIndex += 1;
        } 
    }

    public void EnableDetection()
    {
        for (int i = 0; i < ListDynamicContentStep.Count; i++)
        {
            ListDynamicContentStep[i].SetRootDetectionAreaActive(true);
        }
    }

    public void DisableDetection()
    {
        for (int i = 0; i < ListDynamicContentStep.Count; i++)
        {
            ListDynamicContentStep[i].SetRootDetectionAreaActive(false);
        }
    }

    public void SortContent()
    {
        DynamicContentStepForPanelCellRole[] allDynamicContentStep = transform.GetComponentsInChildren<DynamicContentStepForPanelCellRole>();
        List<DynamicContentStepForPanelCellRole> tempList = new();
        for (int i = 0; i < allDynamicContentStep.Length; i++)
        {
            tempList.Add(allDynamicContentStep[i]);
            tempList[i].SetIndex(i);
            tempList[i].gameObject.name = i.ToString();
        }
        ListDynamicContentStep = tempList;

        PanelCellGameArchive[] all = GameArchiveContent.GetComponentsInChildren<PanelCellGameArchive>();
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
            GameObject obj = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "DynamicContentStepForPanelCellGameArchive");
            obj.name = panel.Index.ToString();
            obj.transform.SetParent(GameArchiveContent, false);
            obj.GetComponent<DynamicContentStepForPanelCellRole>().Init(panel.Index);
            panel.transform.SetParent(obj.GetComponent<DynamicContentStepForPanelCellRole>().DependentObjRoot, false);
            ListDynamicContentStep.Add(obj.GetComponent<DynamicContentStepForPanelCellRole>());            
            Hot.Data_.DataListCellGameArchive.Add(new DataContainer_PanelCellGameArchive());
            panel.Init(Hot.Data_.DataListCellGameArchive[panel.Index]);
            Hot.Data_.Save(panel.Index);

            SortContent();

            NowIndex += 1;
        });        
    }
}
