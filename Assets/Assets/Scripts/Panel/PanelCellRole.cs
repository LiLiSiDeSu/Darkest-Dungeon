using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellRole : PanelBaseCellDynamicScrollView,
             IPointerEnterHandler, IPointerExitHandler
{
    public E_RoleLocation e_RoleLocation;

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

    public PanelCellRolePortraitCanDrag RolePortraitCanDrag;

    public List<GameObject> ListImgCellSanity = new();

    protected override void Awake()
    {
        base.Awake();

        PrefabsDynamicContentStepSuffix = "PanelCellRole";

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
    }

    #region EventSystem接口实现

    public void OnPointerEnter(PointerEventData eventData)
    {
        Root.localPosition = new Vector3(0, 0, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Root.localPosition = new Vector3(30, 0, 0);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        Root.localPosition = new Vector3(30, 0, 0);
        ImgPanelBk.raycastTarget = false;

        Hot.PaddingContentStep_.transform.SetParent(Hot.PanelBarRoleList_.Content, false);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        ImgPanelBk.raycastTarget = true;
    }

    public override void EndDrag()
    {
        transform.SetParent(Hot.PaddingContentStep_.DependentObjRoot, false);
        transform.localPosition = Vector3.zero;
        DestroyImmediate(Hot.PanelBarRoleList_.ListDynamicContentStep[Index].gameObject);
        Hot.PanelBarRoleList_.SortContent();
        Hot.PaddingContentStep_ = null;
    }

    #endregion

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnRolePortrait":
                Hot.PanelRoleDetails_.Show(Index, e_RoleLocation);
                break;
        }
    }

    public void CreatePanelCellRoleCanDrag()
    {
        if (Hot.DataNowCellGameArchive.ListRole[Index].IndexExpeditionRoot == -1)
        {
            Hot.MgrUI_.CreatePanel<PanelCellRolePortraitCanDrag>(false, "/PanelCellRolePortraitCanDrag",
            (panel) =>
            {
                RolePortraitCanDrag = panel;
                panel.Init(this, RootPortrait, new(80, 80));
            });
        }
    }

    public void InitInfo(DataContainer_CellRole p_Role, E_RoleLocation p_e_RoleLocation)
    {
        ImgRolePortrait.sprite = Hot.MgrRes_.Load<Sprite>("Art/Portrait" + p_Role.e_RoleName);
        e_RoleLocation = p_e_RoleLocation;

        TxtRoleName.text = p_Role.Name;
        TxtRoleLevel.text = p_Role.NowLevel.ToString();

        TxtRoleName.text = p_Role.Name;
        ChangeSanityExplosionLimit();
        UpdateLevelInfo();
        UpdateSanityInfo();
        UpdateExperience();
        ChangeRoleStatus(p_Role.IndexExpeditionRoot);
    }

    /// <summary>
    /// 改变RootSanityValueBar下的ImgCellSanity的数量
    /// 记住一定要在UpdateSanityInfo前调用
    /// </summary>
    public void ChangeSanityExplosionLimit()
    {
        if (ListImgCellSanity.Count < Hot.DataNowCellGameArchive.ListRole[Index].LimitToSanityExplosion)
        {
            int v1 = Hot.DataNowCellGameArchive.ListRole[Index].LimitToSanityExplosion - ListImgCellSanity.Count;

            for
            (int i = 0; i < v1; i++)
            {
                ListImgCellSanity.Add(Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ImgCellSanity"));
                ListImgCellSanity[i].transform.SetParent(RootSanityValueBar, false);
                ListImgCellSanity[i].GetComponent<Image>().sprite =
                    Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanityValueNone");
            }
        }

        if (ListImgCellSanity.Count > Hot.DataNowCellGameArchive.ListRole[Index].LimitToSanityExplosion)
        {
            int v1 = ListImgCellSanity.Count - Hot.DataNowCellGameArchive.ListRole[Index].LimitToSanityExplosion;

            for
            (int i = 0; i < v1; i++)
            {
                ListImgCellSanity.RemoveAt(ListImgCellSanity.Count - 1);
            }
        }
    }

    public void ChangeName(string NameToChange)
    {
        Hot.DataNowCellGameArchive.ListRole[Index].Name = NameToChange;

        TxtRoleName.text = NameToChange;
    }

    public void ChangeSanity(int ValueToChange)
    {
        Hot.DataNowCellGameArchive.ListRole[Index].NowSanity += ValueToChange;

        UpdateSanityInfo();
    }

    public void ChangeExperience()
    {

    }

    public void ChangeLevel(int p_valueToChange)
    {
        Hot.DataNowCellGameArchive.ListRole[Index].NowLevel += p_valueToChange;
        if
        (Hot.DataNowCellGameArchive.ListRole[Index].NowLevel > Hot.DataNowCellGameArchive.ListRole[Index].MaxLevel)
            Hot.DataNowCellGameArchive.ListRole[Index].NowLevel = Hot.DataNowCellGameArchive.ListRole[Index].MaxLevel;

        UpdateLevelInfo();
    }

    public void ChangeRoleStatus(int p_index)
    {
        if (p_index == -1)
        {
            ImgRoleStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/RoleStatus" + "None");
        }
        else
        {
            ImgRoleStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/RoleStatus" + "Expedition");
        }
    }

    public void UpdateSanityInfo()
    {
        for (int i = 0; i < ListImgCellSanity.Count; i++)
        {
            if
            (i < Hot.DataNowCellGameArchive.ListRole[Index].NowSanity / Hot.StepSanity)
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

        TxtRoleLevel.text = Hot.DataNowCellGameArchive.ListRole[Index].NowLevel.ToString();
    }

    public void UpdateExperience()
    {
        ImgProgress.GetComponent<RectTransform>().sizeDelta =
            new Vector2(ImgProgress.GetComponent<RectTransform>().sizeDelta.x,
                        49.3f * ((float)Hot.DataNowCellGameArchive.ListRole[Index].NowExperience /
                        Hot.ListNeedExperienceToUpLevel[Hot.DataNowCellGameArchive.ListRole[Index].NowLevel]));
    }
}
