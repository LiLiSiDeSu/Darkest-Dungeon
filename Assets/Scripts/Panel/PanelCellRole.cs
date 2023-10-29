using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellRole : PanelBaseCell,
             IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image ImgPortrait;
    public Image ImgProgress;
    public Image ImgRoleLevelBk;
    public Image ImgRoleStatus;
    public Text TxtRoleName;
    public Text TxtRoleLevel;

    private Vector2 DragOffSet;

    public Transform RootSanityValueBar;

    public List<GameObject> ListImgCellSanity = new List<GameObject>();

    protected override void Awake()
    {
        base.Awake();

        ImgPortrait = transform.FindSonSonSon("ImgPortrait").GetComponent<Image>();
        ImgProgress = transform.FindSonSonSon("ImgProgress").GetComponent<Image>();
        ImgRoleLevelBk = transform.FindSonSonSon("ImgRoleLevelBk").GetComponent<Image>();
        ImgRoleStatus = transform.FindSonSonSon("ImgRoleStatus").GetComponent<Image>();

        TxtRoleName = transform.FindSonSonSon("TxtRoleName").GetComponent<Text>();
        TxtRoleLevel = transform.FindSonSonSon("TxtRoleLevel").GetComponent<Text>();

        RootSanityValueBar = transform.FindSonSonSon("RootSanityValueBar");

        ImgPortrait.alphaHitTestMinimumThreshold = 0.2f;
    }

    #region EventSystem�ӿ�ʵ��

    public void OnBeginDrag(PointerEventData eventData)
    {        
        DragOffSet =
            new Vector2(ImgPortrait.transform.position.x, ImgPortrait.transform.position.y) - eventData.position;
        Hot.DragingRolePortrait = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "PanelCellRoleCanDrag");
        Hot.DragingRolePortrait.transform.FindSonSonSon("ImgRolePortrait").
            GetComponent<Image>().sprite = ImgPortrait.sprite;
        Hot.DragingRolePortrait.transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);
        Hot.DragingRolePortrait.transform.FindSonSonSon("ImgRolePortrait").
            GetComponent<Image>().raycastTarget = false;

        Hot.DragingRolePortrait.GetComponent<PanelCellRoleCanDrag>().PanelCellRole_ = this;
    }

    public void OnDrag(PointerEventData eventData)
    {        
        Hot.DragingRolePortrait.transform.position = eventData.position + DragOffSet;
    }    

    public void OnEndDrag(PointerEventData eventData)
    {
        Hot.DragingRolePortrait.transform.FindSonSonSon("ImgRolePortrait").
            GetComponent<Image>().raycastTarget = true;
        Destroy(Hot.DragingRolePortrait);
        Hot.DragingRolePortrait = null;
    }

    #endregion

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnPortrait":
                Hot.MgrUI_.ShowPanel<PanelRoleDetails>(true, "PanelRoleDetails");
                Hot.PanelRoleDetails_.Index = Index;                
                Hot.PanelRoleDetails_.UpdateInfo();
                break;
        }
    }

    public void InitInfo()
    {
        ImgPortrait.sprite =
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
    /// �ı�RootSanityValueBar�µ�ImgCellSanity������
    /// ��סһ��Ҫ��UpdateSanityInfoǰ����
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
        //�ȼ��ĵ�ͼ�ı��߼�

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