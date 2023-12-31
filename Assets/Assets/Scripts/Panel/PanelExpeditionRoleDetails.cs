using UnityEngine;
using UnityEngine.UI;

public class PanelExpeditionRoleDetails : PanelBaseRoleStore
{
    public Image ImgPortraitRole;

    public Text TxtRoleName;
    public Text TxtHp;
    public Text TxtSanity;
    public Text TxtLevel;
    public Text TxtExperience;
    public Text TxtAction;
    public Text TxtSpeed;

    public Transform SkillContent;
    public Transform RolePropertyContent;

    protected override void Awake()
    {
        base.Awake();

        ImgPortraitRole = transform.FindSonSonSon("ImgPortraitRole").GetComponent<Image>();

        TxtRoleName = transform.FindSonSonSon("TxtRoleName").GetComponent<Text>();
        TxtHp = transform.FindSonSonSon("TxtHp").GetComponent<Text>();
        TxtSanity = transform.FindSonSonSon("TxtSanity").GetComponent<Text>();
        TxtLevel = transform.FindSonSonSon("TxtLevel").GetComponent<Text>();
        TxtExperience = transform.FindSonSonSon("TxtExperience").GetComponent<Text>();
        TxtAction = transform.FindSonSonSon("TxtAction").GetComponent<Text>();
        TxtSpeed = transform.FindSonSonSon("TxtSpeed").GetComponent<Text>();

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
                Hot.PanelBarRoleListExpedition_.ClearAndData();
                Hot.PanelBarExpeditionTimeLine_.Clear();
                Hot.PanelExpeditionRoom_.Clear();
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

    public void UpdateInfo(int p_IndexRole)
    {
        NowCapacity = 0;
        IndexRole = p_IndexRole;

        DataContainer_CellRole roleData = Hot.DataNowCellGameArchive.ListRole[IndexRole];

        ImgPortraitRole.sprite = Hot.MgrRes_.Load<Sprite>("Art/Portrait" + roleData.e_RoleName);

        TxtRoleName.text = roleData.Name;
        TxtHp.text = roleData.NowHp + " / " + roleData.MaxHp;
        TxtSanity.text = roleData.NowSanity + " / " + roleData.MaxSanity;
        TxtLevel.text = roleData.NowLevel + " / " + roleData.MaxLevel;
        TxtExperience.text = roleData.NowExperience + " / " + Hot.DicRoleConfig[roleData.e_RoleName].ListLevelUpNeedExperience[roleData.NowLevel];
        TxtAction.text = roleData.NowAction + " / " + roleData.MaxAction;
        TxtSpeed.text = roleData.NowSpeed.ToString();
        InitTxtCapacity(roleData);

        UpdateContent(roleData);
    }

    public void Clear()
    {
        NowCapacity = 0;
        ImgPortraitRole.sprite = Hot.MgrRes_.Load<Sprite>("Art/Portrait" + E_RoleName.None);

        TxtRoleName.text = "";
        TxtHp.text = "0 / 0";
        TxtSanity.text = "0 / 0";
        TxtLevel.text = "0 / 0";
        TxtExperience.text = "0 / 0";
        TxtCapacity.text = "0 / 0";
        TxtAction.text = "0 / 0";
        TxtSpeed.text = "0";

        ClearAll();
    }
}
