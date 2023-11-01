using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelRoleList : PanelBase,
             IPointerEnterHandler, IPointerExitHandler
{
    private bool IsOpen = true;

    public int NowIndex;    
    public List<DynamicContentStep> ListDynamicContentStep = new();

    public GameObject ScrollView_;
    public GameObject BtnPackUp;
    public GameObject BtnOpen;
    public Transform ImgDecorateFrameTop;
    public Transform ImgDecorateFrameBottom;
    public Image ImgPackUp;
    public Image ImgOpen;

    public Transform RoleContent;    

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>
        ("CertainKeyDown", 
        (key) =>
        {
            if (key == Hot.MgrInput_.PanelRole && Hot.NowIndexCellGameArchive != -1)
            {

                if (Hot.PoolNowPanel_.ListNowPanel.Contains("PanelRoleList"))
                    Hot.MgrUI_.HidePanel(false, Hot.PanelRoleList_.gameObject, "PanelRoleList");
                else
                    Hot.MgrUI_.ShowPanel<PanelRoleList>(true, "PanelRoleList");
            }
        });        

        Hot.CenterEvent_.AddEventListener<bool, int, E_ArrowDirection>
        ("DynamicContentStep", 
        (isInside, index, arrow) => 
        {
            if (isInside)
            {
                Hot.PaddingContentStep_.transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);
                Hot.PaddingContentStep_.transform.SetParent(RoleContent, false);
                Hot.PaddingContentStep_.gameObject.SetActive(true);

                Hot.IndexPaddingContentStep = index;

                switch (arrow)
                {
                    case E_ArrowDirection.Up:
                        Debug.Log(index + " - " + arrow);
                        Hot.e_PaddingArrowDirection = E_ArrowDirection.Up;
                        for (int i = index; i < ListDynamicContentStep.Count; i++)
                        {
                            ListDynamicContentStep[i].transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);
                            ListDynamicContentStep[i].transform.SetParent(RoleContent, false);
                        }
                        break;
                    case E_ArrowDirection.Down:
                        Debug.Log(index + " - " + arrow);
                        Hot.e_PaddingArrowDirection = E_ArrowDirection.Down;
                        for (int i = index + 1; i < ListDynamicContentStep.Count; i++)
                        {
                            ListDynamicContentStep[i].transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);
                            ListDynamicContentStep[i].transform.SetParent(RoleContent, false);
                        }
                        break;
                }
            }            
        });

        ScrollView_ = transform.FindSonSonSon("ScrollView_").gameObject;
        BtnPackUp = transform.FindSonSonSon("BtnPackUp").gameObject;
        BtnOpen = transform.FindSonSonSon("BtnOpen").gameObject;
        ImgDecorateFrameTop = transform.FindSonSonSon("ImgDecorateFrameTop");
        ImgDecorateFrameBottom = transform.FindSonSonSon("ImgDecorateFrameBottom");
        ImgPackUp = transform.FindSonSonSon("ImgPackUp").GetComponent<Image>();
        ImgOpen = transform.FindSonSonSon("ImgOpen").GetComponent<Image>();
        ImgPackUp.alphaHitTestMinimumThreshold = 0.2f;
        ImgOpen.alphaHitTestMinimumThreshold = 0.2f;

        RoleContent = transform.FindSonSonSon("RoleContent");

        BtnOpen.SetActive(false);
    }
    
    #region EventSystem接口实现

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.e_NowPointerLocation = E_NowPointerLocation.PanelRoleList;

        Hot.CanPadding = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.e_NowPointerLocation = E_NowPointerLocation.None;

        Hot.CanPadding = false;

    }

    #endregion

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnPackUp":
                IsOpen = false;                
                BtnPackUp.SetActive(false);
                BtnOpen.SetActive(true);
                ScrollView_.SetActive(false);
                ChangePosImgDecorateFrameBottom();
                break;
            case "BtnOpen":
                IsOpen = true;
                BtnPackUp.SetActive(true);
                BtnOpen.SetActive(false);
                ScrollView_.SetActive(true);
                ChangePosImgDecorateFrameBottom();
                break;
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

    public void InitContent()
    {
        NowIndex = 0;

        for (int i = 0; i < Hot.DataNowCellGameArchive.ListCellRole.Count; i++)
        {
            int tempi = i;

            Hot.MgrUI_.CreatePanel<PanelCellRole>
            (false, "/PanelCellRole", 
            (panel) =>
            {
                panel.Index = tempi;
                panel.CreatePanelCellRoleCanDrag();
                GameObject obj = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "DynamicContentStep");
                obj.name = tempi.ToString();
                obj.transform.SetParent(RoleContent, false);
                obj.GetComponent<DynamicContentStep>().Init(tempi);
                panel.transform.SetParent(obj.GetComponent<DynamicContentStep>().RootPanelCellRole, false);
                ListDynamicContentStep.Add(obj.GetComponent<DynamicContentStep>());
                panel.InitInfo(Hot.DataNowCellGameArchive.ListCellRole[tempi]);           
            });

            NowIndex++;
        }        
    }

    public void Clear()
    {
        ContentStep[] all = RoleContent.GetComponentsInChildren<ContentStep>();
        for (int i = 0; i < all.Length; i++)
        {
            DestroyImmediate(all[i].gameObject);
        }        
    }

    public void SortContent()
    {
        DynamicContentStep[] allDynamicContentStep = transform.GetComponentsInChildren<DynamicContentStep>();
        List<DynamicContentStep> tempList = new List<DynamicContentStep>();
        for (int i = 0; i < allDynamicContentStep.Length; i++)
        {
            tempList.Add(allDynamicContentStep[i]);
            tempList[i].SetIndex(i);
            tempList[i].gameObject.name = i.ToString();
        }
        ListDynamicContentStep = tempList;
        
        PanelCellRole[] all = transform.GetComponentsInChildren<PanelCellRole>();
        List<DataContainer_CellRole> tempData = new List<DataContainer_CellRole>();
        for (int i = 0; i < all.Length; i++)
        {
            tempData.Add(Hot.DataNowCellGameArchive.ListCellRole[all[i].Index]);
            all[i].Index = i;
        }
        Hot.DataNowCellGameArchive.ListCellRole = tempData;

        Hot.Data_.Save();
    }        

    public PanelCellRole GetCellRole()
    {
        return null;
    }

    public void ChangePosPanelCellRole(int sourece, int replace)
    {
        
    }

    private void ChangePosImgDecorateFrameBottom()
    {
        if (IsOpen && ListDynamicContentStep.Count > 0)
            ImgDecorateFrameBottom.transform.localPosition =
                new Vector3(ImgDecorateFrameBottom.transform.localPosition.x, -361f, 0);
        else
            ImgDecorateFrameBottom.transform.position =
                new Vector3(ImgDecorateFrameBottom.transform.position.x,
                ImgDecorateFrameTop.position.y - 40,
                0);
    }    

    public void AddRole(DataContainer_CellRole role, DynamicContentStep dynamicContentStep)
    {
        Hot.DataNowCellGameArchive.ListCellRole.Add(role);

        Hot.MgrUI_.CreatePanel<PanelCellRole>
        (false, "/PanelCellRole",
        (panel) =>
        {            
            panel.Index = Hot.DataNowCellGameArchive.ListCellRole.Count - 1;

            panel.CreatePanelCellRoleCanDrag();

            panel.transform.SetParent(dynamicContentStep.RootPanelCellRole, false);
            SortContent();

            panel.InitInfo(role);

            NowIndex++;
        });        

        Hot.Data_.Save();
    }

    public void RemoveRole(PanelCellRole roleToRemove)
    {
        DestroyImmediate(roleToRemove.PanelCellRoleCanDrag_.gameObject);
        DestroyImmediate(ListDynamicContentStep[roleToRemove.Index].gameObject);
        SortContent();
        
        Hot.Data_.Save();
    }
}
