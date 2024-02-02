using UnityEngine;
using UnityEngine.UI;

public class PanelCellExpeditionRoleSkill : PanelBase
{
    public E_Skill e_Skill;

    public Image ImgRoleSkill;
    public Image ImgIsChose;

    protected override void Awake()
    {
        base.Awake();

        ImgRoleSkill = transform.FindSonSonSon("ImgRoleSkill").GetComponent<Image>();
        ImgIsChose = transform.FindSonSonSon("ImgIsChose").GetComponent<Image>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnRoleSkill":
                if (Hot.PanelExpeditionRoleDetails_.e_ChoseSkill == e_Skill)
                {
                    Hot.PanelExpeditionRoleDetails_.UpdateNowRoleSkill(E_Skill.None);
                    Hot.ChoseCellExpeditionRoom.GenerateMoveArea();
                    Hot.ChoseCellExpeditionRoom.ImgStatus.sprite = Hot.MgrRes_.LoadSprite(E_Res.ImgCoverTransparenctGreen);
                }
                else
                {
                    Hot.PanelExpeditionRoleDetails_.UpdateNowRoleSkill(e_Skill);
                }
                break;
        }
    }

    public void Init(E_Skill p_e_Skill, Transform p_father)
    {
        e_Skill = p_e_Skill;
        ImgRoleSkill.sprite = Hot.LoadSprite(p_e_Skill.ToString());
        transform.SetParent(p_father);
    }
}
