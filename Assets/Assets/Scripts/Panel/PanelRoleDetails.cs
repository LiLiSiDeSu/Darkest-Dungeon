using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PanelRoleDetails : PanelBaseRoleStore
{
    public Image ImgRoleShow;
    public Image ImgBkRoleLevel;    
    public Image ImgProgress;
    public Image ImgRoleLevelBk;    

    public Text TxtRoleName;
    public Text TxtRoleLevel;
    public Text TxtSanityDetails;

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
            ListImgCellSanity[i].GetComponent<Image>().sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanityValueNone");
            ListImgCellSanity[i].SetActive(false);
        }

        LimitAdd = 4f;
        LimitReduce = 0.7f;
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnDismiss":
                Hot.PanelBarRoleList_.RemoveRole(IndexRole);
                Hot.MgrUI_.HidePanel(false, gameObject, "PanelRoleDetails");
                break;
        }
    }

    public void Show(int p_index, E_RoleLocation p_e_RoleLocation)
    {
        if (Hot.UpdateOver)
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelRoleDetails"))
            {
                Hot.MgrUI_.HidePanel(false, gameObject, "PanelRoleDetails");
                Show(p_index, p_e_RoleLocation);
            }
            else
            {
                Hot.MgrUI_.ShowPanel<PanelRoleDetails>(true, "PanelRoleDetails",
                (panel) =>
                {
                    panel.IndexRole = p_index;
                    panel.BtnDismiss.SetActive(p_e_RoleLocation == E_RoleLocation.RoleList);

                    switch (p_e_RoleLocation)
                    {
                        case E_RoleLocation.RoleList:
                            panel.UpdateInfoByRoleList();
                            Hot.PanelBarRoleList_.Show();
                            break;
                        case E_RoleLocation.GuildRecruit:
                            panel.UpdateInfoByGuildRecruit();
                            break;
                    }
                });
            }
        }
    }

    public void UpdateInfoByGuildRecruit()
    {
        DataContainer_CellRole RoleData = Hot.DataNowCellGameArchive.ListRoleRecruit[IndexRole].Role;

        ImgRoleShow.sprite = Hot.MgrRes_.Load<Sprite>("Art/Role" + RoleData.e_RoleName + "Await");

        TxtRoleName.text = RoleData.Name;
        TxtRoleLevel.text = RoleData.NowLevel.ToString();
        TxtSanityDetails.text = RoleData.NowSanity + " / " + RoleData.MaxSanity;

        InitTxtCapacity(RoleData);

        UpdateSanityExplosionLimit(RoleData);
        UpdateLevelInfo(RoleData);
        UpdateSanityInfo(RoleData);
        UpdateExperience(RoleData);
    }

    public void UpdateInfoByRoleList()
    {
        NowCapacity = 0;

        DataContainer_CellRole RoleData = Hot.DataNowCellGameArchive.ListRole[IndexRole];

        ImgRoleShow.sprite = Hot.MgrRes_.Load<Sprite>("Art/Role" + RoleData.e_RoleName + "Await");

        TxtRoleName.text = RoleData.Name;
        TxtRoleLevel.text = RoleData.NowLevel.ToString();
        TxtSanityDetails.text = RoleData.NowSanity + " / " + RoleData.MaxSanity;

        InitTxtCapacity(RoleData);

        UpdateSanityExplosionLimit(RoleData);
        UpdateLevelInfo(RoleData);
        UpdateSanityInfo(RoleData);
        UpdateExperience(RoleData);

        UpdateContent(RoleData);
    }

    public void UpdateSanityExplosionLimit(DataContainer_CellRole Role)
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

    public void UpdateName(DataContainer_CellRole Role, string NameToUpdate)
    {
        Role.Name = NameToUpdate;

        TxtRoleName.text = NameToUpdate;
    }

    public void UpdateSanity(DataContainer_CellRole Role, int ValueToUpdate)
    {
        Role.NowSanity += ValueToUpdate;

        UpdateSanityInfo(Role);
    }

    public void UpdateLevel(DataContainer_CellRole Role, int ValueToUpdate)
    {
        Role.NowLevel += ValueToUpdate;
        if (Role.NowLevel > Role.MaxLevel)
            Role.NowLevel = Role.MaxLevel;

        UpdateLevelInfo(Role);
    }

    public void UpdateSanityInfo(DataContainer_CellRole Role)
    {
        for (int i = 0; i < ListImgCellSanity.Count; i++)
        {
            if (i < Role.NowSanity / Hot.StepSanity)
            {
                ListImgCellSanity[i].GetComponent<Image>().sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanityValueHave");
            }
            else
            {
                ListImgCellSanity[i].GetComponent<Image>().sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanityValueNone");
            }
        }
    }

    public void UpdateLevelInfo(DataContainer_CellRole Role)
    {
        //等级的底图改变逻辑

        TxtRoleLevel.text = Role.NowLevel.ToString();
    }

    public void UpdateExperience(DataContainer_CellRole Role)
    {
        E_RoleName e_RoleName = Hot.DataNowCellGameArchive.ListRole[IndexRole].e_RoleName;

        ImgProgress.GetComponent<RectTransform>().sizeDelta =
            new(ImgProgress.GetComponent<RectTransform>().sizeDelta.x,
            49.3f * ((float)Role.NowExperience / Hot.DicRoleConfig[e_RoleName].ListLevelUpNeedExperience[Role.NowLevel]));
    }
}
