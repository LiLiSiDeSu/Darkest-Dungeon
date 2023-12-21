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
                Hot.DataNowCellGameArchive.ClearNowEvent();
                Hot.PanelExpeditionRoom_.ClearImgStatus();

                if (Hot.NowExpeditionEvent != null)
                {
                    Hot.NowExpeditionEvent.ImgCurrentChoose.gameObject.SetActive(false);
                }
                Hot.NowExpeditionEvent = null;
                Hot.NowInCellExpeditionMiniMap = null;

                Hot.MgrUI_.HideAllPanel();
                Hot.MgrUI_.ShowPanel<PanelTown>(false, "PanelTown");

                Hot.e_NowPlayerLocation = E_PlayerLocation.Town;

                Hot.Data_.Save();
                break;
        }
    }

    public void UpdateInfo()
    {
        NowCapacity = 0;

        DataContainer_CellRole roleData = Hot.DataNowCellGameArchive.ListRole[IndexRole];

        ImgPortraitRole.sprite = Hot.MgrRes_.Load<Sprite>("Art/Portrait" + roleData.e_RoleName);
        TxtRoleName.text = roleData.Name;

        UpdateContent(roleData);
    }

    public void Clear()
    {
        NowCapacity = 0;
        ImgPortraitRole.sprite = Hot.MgrRes_.Load<Sprite>("Art/Portrait" + E_RoleName.None);
        TxtRoleName.text = "";

        ClearAll();
    }
}
