using UnityEngine;
using UnityEngine.UI;

public class PanelCellRoleConfigRoleSkill : PanelBase
{
    public E_Skill e_Skill;

    public Image ImgRoleSkill;

    protected override void Awake()
    {
        base.Awake();

        ImgRoleSkill = transform.FindSonSonSon("ImgRoleSkill").GetComponent<Image>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnRoleSkill":
                if (Hot.PanelOtherEditorRoleConfig_.e_ChoseSkill != e_Skill)
                {
                    Hot.PanelOtherEditorRoleConfig_.ClearSkillArea();
                    Hot.PanelOtherEditorRoleConfig_.UpdateImgCurrentSkill(e_Skill);

                    Hot.PanelOtherEditorRoleConfig_.GenerateByData(e_Skill);
                }
                break;
        }
    }

    public void Init(E_Skill p_e_Skill, Transform p_father)
    {
        e_Skill = p_e_Skill;
        ImgRoleSkill.sprite = Hot.MgrRes_.LoadSprite(e_Skill.ToString());
        transform.SetParent(p_father, false);
    }
}
