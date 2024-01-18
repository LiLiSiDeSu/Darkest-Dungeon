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
    public Transform SkillContent;

    public List<GameObject> ListImgCellSanity = new();

    public int NumActiveObj;

    public E_RoleLocation e_RoleLocation;
    public DataContainer_CellRole DataRole
    {
        get
        {
            switch (e_RoleLocation)
            {
                case E_RoleLocation.RoleList:
                    return Hot.DataNowCellGameArchive.ListRole[IndexRole];
                case E_RoleLocation.GuildRecruit:
                    return Hot.DataNowCellGameArchive.ListRoleRecruit[IndexRole].Role;
                default:
                    return null;
            }
        }
    }

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
        SkillContent = transform.FindSonSonSon("SkillContent");

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
                Clear();

                Hot.MgrUI_.ShowPanel<PanelRoleDetails>(true, "PanelRoleDetails",
                (panel) =>
                {
                    panel.IndexRole = p_index;
                    panel.e_RoleLocation = p_e_RoleLocation;

                    panel.BtnDismiss.SetActive(p_e_RoleLocation == E_RoleLocation.RoleList);

                    ImgRoleShow.sprite = Hot.MgrRes_.Load<Sprite>("Art/Role" + DataRole.e_RoleName + "Await");

                    TxtRoleName.text = DataRole.Name;
                    TxtRoleLevel.text = DataRole.NowLevel.ToString();
                    TxtSanityDetails.text = DataRole.NowSanity + " / " + DataRole.MaxSanity;
                    TxtRoleLevel.text = DataRole.NowLevel.ToString();

                    InitTxtCapacity(DataRole);
                    UpdateSanityExplosionLimit();
                    UpdateSanityInfo();
                    UpdateExperience();
                    UpdateSkillContent();

                    switch (p_e_RoleLocation)
                    {
                        case E_RoleLocation.RoleList:
                            Hot.PanelBarRoleList_.Show();
                            NowCapacity = 0;
                            UpdateContent(DataRole);
                            break;
                        case E_RoleLocation.GuildRecruit:
                            ;   
                            break;
                    }
                });
            }
        }
    }
    public void Clear()
    {
        int count = SkillContent.childCount;
        
        for (int i = 0; i < count; i++)
        {
            Destroy(SkillContent.GetChild(i).gameObject);
        }
    }

    public void UpdateSanityExplosionLimit()
    {
        if (NumActiveObj > DataRole.LimitToSanityExplosion)
        {
            int v1 = NumActiveObj - DataRole.LimitToSanityExplosion;

            for (int i = 0; i < v1; i++)
            {
                ListImgCellSanity[DataRole.LimitToSanityExplosion + i].SetActive(false);
                NumActiveObj--;
            }
        }

        if (NumActiveObj < DataRole.LimitToSanityExplosion)
        {
            int tempNumActiveObj = NumActiveObj;
            int v1 = DataRole.LimitToSanityExplosion - NumActiveObj;

            for (int i = 0; i < v1; i++)
            {
                ListImgCellSanity[tempNumActiveObj + i].SetActive(true);
                NumActiveObj++;
            }
        }
    }
    public void UpdateSanityInfo()
    {
        for (int i = 0; i < ListImgCellSanity.Count; i++)
        {
            if (i < DataRole.NowSanity / Hot.StepSanity)
            {
                ListImgCellSanity[i].GetComponent<Image>().sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanityValueHave");
            }
            else
            {
                ListImgCellSanity[i].GetComponent<Image>().sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanityValueNone");
            }
        }
    }
    public void UpdateExperience()
    {
        E_RoleName e_RoleName = DataRole.e_RoleName;

        ImgProgress.GetComponent<RectTransform>().sizeDelta =
            new(ImgProgress.GetComponent<RectTransform>().sizeDelta.x,
            49.3f * ((float)DataRole.NowExperience / Hot.DicRoleConfig[e_RoleName].ListLevelUpNeedExperience[DataRole.NowLevel]));
    }
    public void UpdateSkillContent()
    {
        foreach (E_Skill e_Skill in DataRole.DicSkill.Keys)
        {
            E_Skill tempe_Skill = e_Skill;

            Hot.MgrUI_.CreatePanel<PanelCellRoleSkill>(false, "/PanelCellRoleSkill",
            (panel) =>
            {
                panel.Init(tempe_Skill, SkillContent);
            });
        }
    }
}
