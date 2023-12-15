using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelExpeditionRoleDetails : PanelBaseRoleStore
{
    public Image ImgPortraitRole;
    public Text TxtRoleName;    

    public Transform SkillContent;
    public Transform RolePropertyContent;

    protected override void Awake()
    {
        base.Awake();

        ImgPortraitRole = transform.FindSonSonSon("ImgPortraitRole").GetComponent<Image>();
        TxtRoleName = transform.FindSonSonSon("TxtRoleName").GetComponent<Text>();

        SkillContent = transform.FindSonSonSon("SkillContent");
        RolePropertyContent = transform.FindSonSonSon("RolePropertyContent");

        LimitAdd = 3f;
        LimitReduce = 0.2f;
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnSkipTurn":
                Debug.Log("SkipTurn");
                break;
            case "BtnBackTown":
                Hot.PanelExpeditionRoom_.Clear();
                Hot.PanelBarRoleListExpedition_.ClearAndData();
                Hot.MgrUI_.HideAllPanel();
                Hot.MgrUI_.ShowPanel<PanelTown>(false, "PanelTown");
                Hot.e_NowPlayerLocation = E_PlayerLocation.Town;
                Hot.NowExpeditionEvent = null;
                Hot.NowEnterCellExpeditionMiniMap = null;
                Hot.DataNowCellGameArchive.ResetNowEvent();
                break;
        }
    }

    public void UpdateInfo(DataContainer_CellRole p_roleData)
    {
        ImgPortraitRole.sprite = Hot.MgrRes_.Load<Sprite>("Art/Portrait" + p_roleData.e_RoleName);
        TxtRoleName.text = p_roleData.Name;

        UpdateContent(p_roleData);
    }
}
