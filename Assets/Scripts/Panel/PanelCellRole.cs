using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellRole : PanelBaseCell,
             IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image ImgRolePortrait;
    public Image ImgProgress;
    public Image ImgRoleLevelBk;
    public Image ImgRoleStatus;
    public Image ImgPanelBk;
    public Text TxtRoleName;
    public Text TxtRoleLevel;

    public Transform Root;
    public Transform RootPortrait;
    public Transform RootSanityValueBar;    

    public Vector2 DragOffSet;

    public PanelCellRoleCanDrag PanelCellRoleCanDrag_;

    public List<GameObject> ListImgCellSanity = new List<GameObject>();   

    protected override void Awake()
    {
        base.Awake();

        ImgRolePortrait = transform.FindSonSonSon("ImgRolePortrait").GetComponent<Image>();
        ImgProgress = transform.FindSonSonSon("ImgProgress").GetComponent<Image>();
        ImgRoleLevelBk = transform.FindSonSonSon("ImgRoleLevelBk").GetComponent<Image>();
        ImgRoleStatus = transform.FindSonSonSon("ImgRoleStatus").GetComponent<Image>();
        ImgPanelBk = transform.FindSonSonSon("ImgPanelBk").GetComponent<Image>();

        TxtRoleName = transform.FindSonSonSon("TxtRoleName").GetComponent<Text>();
        TxtRoleLevel = transform.FindSonSonSon("TxtRoleLevel").GetComponent<Text>();

        Root = transform.FindSonSonSon("Root");
        RootPortrait = transform.FindSonSonSon("RootPortrait");
        RootSanityValueBar = transform.FindSonSonSon("RootSanityValueBar");

        ImgRolePortrait.alphaHitTestMinimumThreshold = 0.2f;
    }

    #region EventSystem

    public void OnPointerEnter(PointerEventData eventData)
    {
        Root.localPosition = new Vector3(0, 0, 0);        
    }

    public void OnPointerExit(PointerEventData eventData)
    {    
        Root.localPosition = new Vector3(30, 0, 0);        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ImgPanelBk.raycastTarget = false;
        DragOffSet = new Vector2(transform.position.x, transform.position.y) - eventData.position;

        transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);
        Hot.PanelRoleList_.ListDynamicContentStep[Index].gameObject.SetActive(false);

        Hot.PaddingContentStep_ = 
            Hot.MgrRes_.Load<GameObject>("Prefabs/" + "PaddingContentStep").GetComponent<PaddingContentStep>();        

        Hot.PanelRoleList_.EnableDetection();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + DragOffSet;
    }    

    public void OnEndDrag(PointerEventData eventData)
    {
        ImgPanelBk.raycastTarget = true;
        Hot.PanelRoleList_.DisableDetection();

        Hot.PanelRoleList_.ListDynamicContentStep[Index].gameObject.SetActive(true);
        transform.SetParent(Hot.PanelRoleList_.ListDynamicContentStep[Index].RootPanelCellRole, false);
        transform.localPosition = Vector3.zero;
    }
    
    #endregion

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnRolePortrait":                
                Hot.PanelRoleDetails_.UpdateInfo(Hot.DataNowCellGameArchive.ListCellRole[Index]);
                Hot.MgrUI_.ShowPanel<PanelRoleDetails>(true, "PanelRoleDetails",
                (panel) =>
                {
                    panel.NowRole = this;
                    panel.BtnDismiss.SetActive(true);
                });                
                break;
        }
    }

    public void CreatePanelCellRoleCanDrag()
    {
        if (Hot.DataNowCellGameArchive.ListCellRole[Index].e_SpriteNameRoleStatus == E_SpriteNameRoleStatus.RoleStatusNone)
        {
            Hot.MgrUI_.CreatePanel<PanelCellRoleCanDrag>(false, "/PanelCellRoleCanDrag",
            (panel) =>
            {
                panel.transform.SetParent(RootPortrait, false);
                panel.RectRolePortraitCanDrag.sizeDelta = new Vector2(80, 80);
                panel.PanelCellRole_ = this;
                PanelCellRoleCanDrag_ = panel;
                panel.InitSprite();
            });
        }
    }

    public void InitInfo()
    {
        ImgRolePortrait.sprite =
            Hot.MgrRes_.Load<Sprite>("Art/" + Hot.DataNowCellGameArchive.ListCellRole[Index].e_SpriteNamePortraitRole);        

        TxtRoleName.text = Hot.DataNowCellGameArchive.ListCellRole[Index].Name;
        TxtRoleLevel.text = Hot.DataNowCellGameArchive.ListCellRole[Index].NowLevel.ToString();

        TxtRoleName.text = Hot.DataNowCellGameArchive.ListCellRole[Index].Name;        
        ChangeSanityExplosionLimit();
        UpdateLevelInfo();
        UpdateSanityInfo();
        UpdateExperience();
        ChangeRoleStatus(Hot.DataNowCellGameArchive.ListCellRole[Index].e_SpriteNameRoleStatus);
    }

    /// <summary>
    /// 改变RootSanityValueBar下的ImgCellSanity的数量
    /// 记住一定要在UpdateSanityInfo前调用
    /// </summary>
    public void ChangeSanityExplosionLimit()
    {
        if (ListImgCellSanity.Count < Hot.DataNowCellGameArchive.ListCellRole[Index].LimitToSanityExplosion)
        {
            int v1 = Hot.DataNowCellGameArchive.ListCellRole[Index].LimitToSanityExplosion - ListImgCellSanity.Count;

            for 
            (int i = 0; i < v1; i++)
            {
                ListImgCellSanity.Add(Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ImgCellSanity"));
                ListImgCellSanity[i].transform.SetParent(RootSanityValueBar, false);
                ListImgCellSanity[i].GetComponent<Image>().sprite = 
                    Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanityValueNone");
            }
        }

        if (ListImgCellSanity.Count > Hot.DataNowCellGameArchive.ListCellRole[Index].LimitToSanityExplosion)
        {
            int v1 = ListImgCellSanity.Count - Hot.DataNowCellGameArchive.ListCellRole[Index].LimitToSanityExplosion;

            for
            (int i = 0; i < v1; i++)
            {
                ListImgCellSanity.RemoveAt(ListImgCellSanity.Count - 1);
            }
        }
    }

    public void ChangeName(string NameToChange)
    {
        Hot.DataNowCellGameArchive.ListCellRole[Index].Name = NameToChange;
        
        TxtRoleName.text = NameToChange;
        Hot.Data_.Save();
    }

    public void ChangeSanity(int ValueToChange)
    {
        Hot.DataNowCellGameArchive.ListCellRole[Index].NowSanity += ValueToChange;

        UpdateSanityInfo();
        Hot.Data_.Save();
    }

    public void ChangeExperience()
    {
        Hot.Data_.Save();
    }

    public void ChangeLevel(int ValueToChange)
    {
        Hot.DataNowCellGameArchive.ListCellRole[Index].NowLevel += ValueToChange;
        if
        (Hot.DataNowCellGameArchive.ListCellRole[Index].NowLevel > Hot.DataNowCellGameArchive.ListCellRole[Index].MaxLevel)
         Hot.DataNowCellGameArchive.ListCellRole[Index].NowLevel = Hot.DataNowCellGameArchive.ListCellRole[Index].MaxLevel;

        UpdateLevelInfo();
        Hot.Data_.Save();
    }

    public void ChangeRoleStatus(E_SpriteNameRoleStatus ToChange)
    {
        Hot.DataNowCellGameArchive.ListCellRole[Index].e_SpriteNameRoleStatus = ToChange;
        ImgRoleStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + ToChange.ToString());
    }

    public void UpdateSanityInfo()
    {
        for (int i = 0; i < ListImgCellSanity.Count; i++)
        {
            if
            (i < Hot.DataNowCellGameArchive.ListCellRole[Index].NowSanity / Hot.StepSanity)
            {
                ListImgCellSanity[i].GetComponent<Image>().sprite =
                    Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanityValueHave");
            }
            else
                ListImgCellSanity[i].GetComponent<Image>().sprite =
                    Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanityValueNone");
        }
    }    

    public void UpdateLevelInfo()
    {
        //等级的底图改变逻辑

        TxtRoleLevel.text = Hot.DataNowCellGameArchive.ListCellRole[Index].NowLevel.ToString();
    }

    public void UpdateExperience()
    {
        ImgProgress.GetComponent<RectTransform>().sizeDelta = 
            new Vector2(ImgProgress.GetComponent<RectTransform>().sizeDelta.x, 
                        49.3f * ((float)Hot.DataNowCellGameArchive.ListCellRole[Index].NowExperience /
                        Hot.ListNeedExperienceToUpLevel[Hot.DataNowCellGameArchive.ListCellRole[Index].NowLevel])); 
    }    
}
