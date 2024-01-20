using UnityEngine;
using UnityEngine.UI;

public class PanelCellRoleConfigRole : PanelBase
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
                Hot.PanelOtherEditorRoleConfig_.ImgCurrentRole.sprite = ImgChooseRole.sprite;
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
