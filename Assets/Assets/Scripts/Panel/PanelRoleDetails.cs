using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                            panel.UpdateInfo(Hot.DataNowCellGameArchive.ListRole[p_index]);
                            Hot.PanelBarRoleList_.Show();
                            break;
                        case E_RoleLocation.GuildRecruit:
                            panel.UpdateInfoByGuildRecruit(Hot.DataNowCellGameArchive.ListRoleRecruit[p_index].Role);
                            break;
                    }
                });
            }
        }
    }

    public override void UpdateInfoByAdd(E_SpriteNamePanelCellItem p_e_Item)
    {
        base.UpdateInfoByAdd(p_e_Item);

        TxtCapacity.text = NowCapacity + " / " + NowRole.ListItem[0].Count * NowRole.ListItem.Count;
    }

    public override void UpdateInfoByReduce(E_SpriteNamePanelCellItem p_e_Item)
    {
        base.UpdateInfoByReduce(p_e_Item);

        TxtCapacity.text = NowCapacity + " / " + NowRole.ListItem[0].Count * NowRole.ListItem.Count;
    }

    public void UpdateInfoByGuildRecruit(DataContainer_CellRole Role)
    {
        ImgRoleShow.sprite = Hot.MgrRes_.Load<Sprite>("Art/Role" + Role.e_RoleName + "Await");

        TxtRoleName.text = Role.Name;
        TxtRoleLevel.text = Role.NowLevel.ToString();
        TxtSanityDetails.text = Role.NowSanity + " / " + Role.MaxSanity;

        UpdateSanityExplosionLimit(Role);
        UpdateLevelInfo(Role);
        UpdateSanityInfo(Role);
        UpdateExperience(Role);
    }

    public void UpdateInfo(DataContainer_CellRole p_Role)
    {        
        NowRole = p_Role;

        ImgRoleShow.sprite = Hot.MgrRes_.Load<Sprite>("Art/Role" + p_Role.e_RoleName + "Await");

        TxtRoleName.text = p_Role.Name;
        TxtRoleLevel.text = p_Role.NowLevel.ToString();
        TxtSanityDetails.text = p_Role.NowSanity + " / " + p_Role.MaxSanity;

        UpdateSanityExplosionLimit(p_Role);
        UpdateLevelInfo(p_Role);
        UpdateSanityInfo(p_Role);
        UpdateExperience(p_Role);
        UpdateContent(p_Role);
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
