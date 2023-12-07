using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelRoleDetails : PanelBase
{
    public PanelCellRole NowRole;

    public Image ImgRoleShow;
    public Image ImgBkRoleLevel;    
    public Image ImgProgress;
    public Image ImgRoleLevelBk;    

    public Text TxtRoleName;
    public Text TxtRoleLevel;
    public Text TxtSanityDetails;

    /// <summary>
    /// 解雇角色
    /// </summary>
    public GameObject BtnDismiss;
    public Transform RootSanityValueBar;    

    public List<GameObject> ListImgCellSanity = new();

    /// <summary>
    /// 压力极限前的压力图标 在Awake里面会提前创建
    /// </summary>
    public int NumActiveObj;

    protected override void Awake()
    {
        base.Awake();

        BtnDismiss = transform.FindSonSonSon("BtnDismiss").gameObject;

        ImgRoleShow = transform.FindSonSonSon("ImgRoleShow").GetComponent<Image>();
        ImgBkRoleLevel = transform.FindSonSonSon("ImgBkRoleLevel").GetComponent<Image>();
        ImgProgress = transform.FindSonSonSon("ImgProgress").GetComponent<Image>();
        ImgRoleLevelBk = transform.FindSonSonSon("ImgRoleLevelBk").GetComponent<Image>();

        TxtRoleName = transform.FindSonSonSon("TxtRoleName").GetComponent<Text>();
        TxtRoleLevel = transform.FindSonSonSon("TxtRoleLevel").GetComponent<Text>();
        TxtSanityDetails = transform.FindSonSonSon("TxtSanityDetails").GetComponent<Text>();

        RootSanityValueBar = transform.FindSonSonSon("RootSanityValueBar");

        for (int i = 0; i < 15; i++)
        {
            ListImgCellSanity.Add(Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ImgCellSanity"));
            ListImgCellSanity[i].transform.SetParent(RootSanityValueBar, false);
            ListImgCellSanity[i].GetComponent<Image>().sprite =
                Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanityValueNone");
            ListImgCellSanity[i].SetActive(false);
        }
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnDismiss":
                Hot.PanelRoleList_.RemoveRole(NowRole);
                Hot.MgrUI_.HidePanel(false, gameObject, "PanelRoleDetails");
                break;
        }
    }

    public void UpdateInfo(DataContainer_CellRole Role)
    {        
        ImgRoleShow.sprite =
            Hot.MgrRes_.Load<Sprite>("Art/Role" + Role.e_RoleName + "Await");

        TxtRoleName.text = Role.Name;
        TxtRoleLevel.text = Role.NowLevel.ToString();
        TxtSanityDetails.text = Role.NowSanity + " / " + Role.MaxSanity;

        ChangeSanityExplosionLimit(Role);
        UpdateLevelInfo(Role);
        UpdateSanityInfo(Role);
        UpdateExperience(Role);
    }

    public void ChangeSanityExplosionLimit(DataContainer_CellRole Role)
    {
        if (NumActiveObj > Role.LimitToSanityExplosion)
        {
            int v1 = NumActiveObj - Role.LimitToSanityExplosion;

            for (int i = 0; i < v1; i++)
            {
                ListImgCellSanity[Role.LimitToSanityExplosion + i].SetActive(false);
                NumActiveObj--;
            }
        }

        if (NumActiveObj < Role.LimitToSanityExplosion)
        {
            int tempNumActiveObj = NumActiveObj;
            int v1 = Role.LimitToSanityExplosion - NumActiveObj;

            for (int i = 0; i < v1; i++)
            {
                ListImgCellSanity[tempNumActiveObj + i].SetActive(true);
                NumActiveObj++;
            }
        }
    }

    public void ChangeName(DataContainer_CellRole Role, string NameToChange)
    {
        Role.Name = NameToChange;

        TxtRoleName.text = NameToChange;
    }

    public void ChangeSanity(DataContainer_CellRole Role, int ValueToChange)
    {
        Role.NowSanity += ValueToChange;

        UpdateSanityInfo(Role);
    }

    public void ChangeExperience(DataContainer_CellRole Role)
    {

    }

    public void ChangeLevel(DataContainer_CellRole Role, int ValueToChange)
    {
        Role.NowLevel += ValueToChange;
        if (Role.NowLevel > Role.MaxLevel)
            Role.NowLevel = Role.MaxLevel;

        UpdateLevelInfo(Role);
    }

    public void UpdateSanityInfo(DataContainer_CellRole Role)
    {
        for (int i = 0; i < ListImgCellSanity.Count; i++)
        {
            if
            (i < Role.NowSanity / Hot.StepSanity)
            {
                ListImgCellSanity[i].GetComponent<Image>().sprite =
                    Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanityValueHave");
            }
            else
                ListImgCellSanity[i].GetComponent<Image>().sprite =
                    Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanityValueNone");
        }
    }

    public void UpdateLevelInfo(DataContainer_CellRole Role)
    {
        //等级的底图改变逻辑

        TxtRoleLevel.text = Role.NowLevel.ToString();
    }

    public void UpdateExperience(DataContainer_CellRole Role)
    {
        ImgProgress.GetComponent<RectTransform>().sizeDelta =
            new Vector2(ImgProgress.GetComponent<RectTransform>().sizeDelta.x,
                        49.3f * ((float)Role.NowExperience / Hot.ListNeedExperienceToUpLevel[Role.NowLevel]));
    }
}
