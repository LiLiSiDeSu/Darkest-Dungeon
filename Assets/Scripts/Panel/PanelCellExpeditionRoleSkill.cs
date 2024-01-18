using UnityEngine;
using UnityEngine.UI;

public class PanelCellExpeditionRoleSkill : PanelBase
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
                Debug.Log(e_Skill);
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
