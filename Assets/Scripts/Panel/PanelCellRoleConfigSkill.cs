using UnityEngine;
using UnityEngine.UI;

public class PanelCellRoleConfigSkill : PanelBase
{
    public E_Skill e_Skill;

    public Image ImgChooseSkill;

    protected override void Awake()
    {
        base.Awake();

        ImgChooseSkill = transform.FindSonSonSon("ImgChooseSkill").GetComponent<Image>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnChooseSkill":
                Hot.PanelOtherEditorRoleConfig_.ImgCurrentSkill.sprite = ImgChooseSkill.sprite;
                break;
        }
    }

    public void Init(E_Skill p_e_Skill, Transform p_father)
    {
        e_Skill = p_e_Skill;
        ImgChooseSkill.sprite = Hot.MgrRes_.LoadSprite(e_Skill.ToString());
        transform.SetParent(p_father, false);
    }
}
