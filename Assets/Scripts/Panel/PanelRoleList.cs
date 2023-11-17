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
    public List<DynamicContentStepForPanelCellRole> ListDynamicContentStep = new();

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

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyDown", 
        (key) =>
        {
            if (Hot.e_NowPlayerLocation != E_PlayerLocation.OnExpedition && key == Hot.MgrInput_.PanelRole)
            {

                if (Hot.PoolNowPanel_.ListNowPanel.Contains("PanelRoleList"))
                    Hot.MgrUI_.HidePanel(false, Hot.PanelRoleList_.gameObject, "PanelRoleList");
                else
                    Hot.MgrUI_.ShowPanel<PanelRoleList>(true, "PanelRoleList");
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
                GameObject obj = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "DynamicContentStepForPanelCellRole");
                obj.name = tempi.ToString();
                obj.transform.SetParent(RoleContent, false);
                obj.GetComponent<DynamicContentStepForPanelCellRole>().Init(tempi);
                panel.transform.SetParent(obj.GetComponent<DynamicContentStepForPanelCellRole>().DependentObjRoot, false);
                ListDynamicContentStep.Add(obj.GetComponent<DynamicContentStepForPanelCellRole>());
                panel.InitInfo(Hot.DataNowCellGameArchive.ListCellRole[tempi]);           
            });

            NowIndex++;
        }        
    }

    public void ClearContent()
    {
        ContentStep[] all = RoleContent.GetComponentsInChildren<ContentStep>();
        for (int i = 0; i < all.Length; i++)
        {
            DestroyImmediate(all[i].gameObject);
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

    public void AddRole(DataContainer_CellRole role, DynamicContentStepForPanelCellRole dynamicContentStep)
    {
        Hot.DataNowCellGameArchive.ListCellRole.Add(role);

        Hot.MgrUI_.CreatePanel<PanelCellRole>
        (false, "/PanelCellRole",
        (panel) =>
        {            
            panel.Index = Hot.DataNowCellGameArchive.ListCellRole.Count - 1;

            panel.CreatePanelCellRoleCanDrag();

            panel.transform.SetParent(dynamicContentStep.DependentObjRoot, false);
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
