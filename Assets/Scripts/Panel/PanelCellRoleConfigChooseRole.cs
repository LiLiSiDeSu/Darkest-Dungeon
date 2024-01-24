using UnityEngine;
using UnityEngine.UI;

public class PanelCellRoleConfigChooseRole : PanelBase
{
    public E_RoleName e_RoleName;

    public Image ImgChooseRole;

    protected override void Awake()
    {
        base.Awake();

        ImgChooseRole = transform.FindSonSonSon("ImgChooseRole").GetComponent<Image>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnChooseRole":
                if (Hot.PanelOtherEditorRoleConfig_.e_ChoseRoleName == e_RoleName)
                {
                    Hot.PanelOtherEditorRoleConfig_.Clear();
                }
                else
                {
                    Hot.PanelOtherEditorRoleConfig_.ClearRoleSkillContent();

                    Hot.PanelOtherEditorRoleConfig_.UpdateImgCurrentRole(e_RoleName);
                    Hot.PanelOtherEditorRoleConfig_.UpdateImgCurrentSkill(E_Skill.None);
                    Hot.PanelOtherEditorRoleConfig_.UpdateRoleSkillContent(e_RoleName);

                    Hot.PanelOtherEditorRoleConfig_.GenerateByData(e_RoleName);
                }
                break;
        }
    }

    public void Init(E_RoleName p_e_RoleName, Transform p_father)
    {
        e_RoleName = p_e_RoleName;
        ImgChooseRole.sprite = Hot.MgrRes_.LoadSprite("Portrait" + p_e_RoleName);
        transform.SetParent(p_father, false);
    }
}
