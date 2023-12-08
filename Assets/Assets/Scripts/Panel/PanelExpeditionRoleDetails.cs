using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelExpeditionRoleDetails : PanelBaseRoleStore
{
    public Image ImgPortraitRole;
    public Text TxtRoleName;
    public Text TxtCapacity;

    public Transform SkillContent;

    protected override void Awake()
    {
        base.Awake();

        ImgPortraitRole = transform.FindSonSonSon("ImgPortraitRole").GetComponent<Image>();
        TxtRoleName = transform.FindSonSonSon("TxtRoleName").GetComponent<Text>();
        TxtCapacity = transform.FindSonSonSon("TxtCapacity").GetComponent<Text>();

        SkillContent = transform.FindSonSonSon("SkillContent");
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnSkipTurn":
                Debug.Log("SkipTurn");
                break;
        }
    }

    public void UpdateInfo(DataContainer_CellRole p_roleData)
    {
        ImgPortraitRole.sprite = Hot.MgrRes_.Load<Sprite>("Art/Portrait" + p_roleData.e_RoleName);
        TxtRoleName.text = p_roleData.Name;
    }
}
