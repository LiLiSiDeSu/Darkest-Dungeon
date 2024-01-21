using System;
using UnityEngine;
using UnityEngine.UI;

public class PanelOtherEditorRoleConfig : PanelBase
{
    public Image ImgCurrentRole;
    public Image ImgCurrentSkill;

    public Transform RoleContent;
    public Transform SkillContent;

    protected override void Awake()
    {
        base.Awake();

        ImgCurrentRole = transform.FindSonSonSon("ImgCurrentRole").GetComponent<Image>();
        ImgCurrentSkill = transform.FindSonSonSon("ImgCurrentSkill").GetComponent<Image>();

        RoleContent = transform.FindSonSonSon("RoleContent");
        SkillContent = transform.FindSonSonSon("SkillContent");

        Init();
    }

    public void Init()
    {
        foreach (E_RoleName item in Enum.GetValues(typeof(E_RoleName)))
        {
            if (item == E_RoleName.None)
                continue;

            Hot.MgrUI_.CreatePanel<PanelCellRoleConfigRole>(false, E_PanelName.PanelCellRoleConfigRole,
            (panel) =>
            {
                panel.Init(item, RoleContent);
            });
        }

        foreach (E_Skill item in Enum.GetValues(typeof(E_Skill)))
        {
            Hot.MgrUI_.CreatePanel<PanelCellRoleConfigSkill>(false, E_PanelName.PanelCellRoleConfigSkill,
            (panel) =>
            {
                panel.Init(item, SkillContent);
            });
        }
    }
}
