using UnityEngine;
using UnityEngine.UI;

public class PanelCellRoleConfigChooseSkill : PanelBase
{
    public E_Skill e_Skill;

    public bool IsRoleSkill;

    public Image ImgChooseSkill;
    public Image ImgIsRoleSkill;

    protected override void Awake()
    {
        base.Awake();

        ImgChooseSkill = transform.FindSonSonSon("ImgChooseSkill").GetComponent<Image>();
        ImgIsRoleSkill = transform.FindSonSonSon("ImgIsRoleSkill").GetComponent<Image>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnChooseSkill":
                if (Hot.PanelOtherEditorRoleConfig_.e_ChoseRoleName == E_RoleName.None)
                {
                    return;
                }

                if (Hot.PanelOtherEditorRoleConfig_.e_ChoseSkill == e_Skill)
                {
                    Hot.PanelOtherEditorRoleConfig_.UpdateImgCurrentSkill(E_Skill.None);
                }
                else
                {
                    Hot.PanelOtherEditorRoleConfig_.UpdateImgCurrentSkill(e_Skill);
                }
                break;
        }
    }

    public void Init(E_Skill p_e_Skill, Transform p_father)
    {
        e_Skill = p_e_Skill;
        ImgChooseSkill.sprite = Hot.MgrRes_.LoadSprite(e_Skill.ToString());
        transform.SetParent(p_father, false);
    }

    public void UpdateImgIsRoleSkill(bool p_IsRoleSkill)
    {
        IsRoleSkill = p_IsRoleSkill;

        if (p_IsRoleSkill)
        {
            ImgIsRoleSkill.sprite = Hot.LoadSprite(E_Res.ImgCoverTransparenctGreen);
        }
        else
        {
            ImgIsRoleSkill.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
        }
    }
}
