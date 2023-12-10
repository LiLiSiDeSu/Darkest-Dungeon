using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelRoleDetails : PanelBaseRoleStore
{
    public Image ImgRoleShow;
    public Image ImgBkRoleLevel;    
    public Image ImgProgress;
    public Image ImgRoleLevelBk;    

    public Text TxtRoleName;
    public Text TxtRoleLevel;
    public Text TxtSanityDetails;
    public Text TxtCapacity;

    public GameObject BtnDismiss;
    public Transform RootSanityValueBar;    

    public List<GameObject> ListImgCellSanity = new();

    public DataContainer_CellRole NowRole;

    /// <summary>
    /// 压力极限前的压力图标 在Awake里面会提前创建
    /// </summary>
    public int NumActiveObj;

    protected override void Awake()
    {
        base.Awake();

        BtnDismiss = transform.FindSonSonSon("BtnDismiss").gameObject;

        ImgRoleShow = transform.FindSonSonSon("ImgRoleShow").GetComponent<Image>();
        ImgBkRoleLevel = transform.FindSonSonSon("ImgBkRoleLevel").GetComponent<Image>();
        ImgProgress = transform.FindSonSonSon("ImgProgress").GetComponent<Image>();
        ImgRoleLevelBk = transform.FindSonSonSon("ImgRoleLevelBk").GetComponent<Image>();

        TxtRoleName = transform.FindSonSonSon("TxtRoleName").GetComponent<Text>();
        TxtRoleLevel = transform.FindSonSonSon("TxtRoleLevel").GetComponent<Text>();
        TxtSanityDetails = transform.FindSonSonSon("TxtSanityDetails").GetComponent<Text>();
        TxtCapacity = transform.FindSonSonSon("TxtCapacity").GetComponent<Text>();

        RootSanityValueBar = transform.FindSonSonSon("RootSanityValueBar");

        for (int i = 0; i < 15; i++)
        {
            ListImgCellSanity.Add(Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ImgCellSanity"));
            ListImgCellSanity[i].transform.SetParent(RootSanityValueBar, false);
            ListImgCellSanity[i].GetComponent<Image>().sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanityValueNone");
            ListImgCellSanity[i].SetActive(false);
        }

        Hot.CenterEvent_.AddEventListener("Esc" + "PanelRoleDetails",
        () =>
        {
            IndexRole = -1;
            e_RoleLocation = E_RoleLocation.None;
            NowRole = null;
            TxtCapacity.text = "";
            NowCapacity = 0;
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelRoleDetails"))
            {
                if (key == Hot.MgrInput_.Add)
                {
                    AllContent.localScale += new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime);
                }
                else if (key == Hot.MgrInput_.Reduce)
                {
                    AllContent.localScale -= new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
                }
            }
        });
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnDismiss":
                Hot.PanelRoleList_.RemoveRole(IndexRole);
                Hot.MgrUI_.HidePanel(false, gameObject, "PanelRoleDetails");
                break;
        }
    }

    public override void UpdateInfoByAdd(E_SpriteNamePanelCellItem p_e_Item)
    {
        base.UpdateInfoByAdd(p_e_Item);

        TxtCapacity.text = NowCapacity + " / " + NowRole.ListItem[0].Count * NowRole.ListItem.Count;
    }

    public override void UpdateInfoByReduce(E_SpriteNamePanelCellItem p_e_Item)
    {
        base.UpdateInfoByReduce(p_e_Item);

        TxtCapacity.text = NowCapacity + " / " + NowRole.ListItem[0].Count * NowRole.ListItem.Count;
    }

    public void UpdateContent(DataContainer_CellRole Role)
    {
        ClearList();
        
        InitGrid(Role.ListItem.Count, Role.ListItem[0].Count);

        LoadData(Role);        
    }

    public void InitTxtCapacity()
    {
        foreach (List<DataContainer_CellItem> listItem in Hot.DataNowCellGameArchive.ListCellRole[IndexRole].ListItem)
        {
            foreach (DataContainer_CellItem item in listItem)
            {
                if (item.e_SpriteNamePanelCellItem != E_SpriteNamePanelCellItem.None)
                {
                    NowCapacity += Hot.BodyDicItem[item.e_SpriteNamePanelCellItem].X * Hot.BodyDicItem[item.e_SpriteNamePanelCellItem].Y;
                }
            }
        }

        TxtCapacity.text =
           NowCapacity + " / " +
           Hot.DataNowCellGameArchive.ListCellRole[IndexRole].ListItem[0].Count * 
           Hot.DataNowCellGameArchive.ListCellRole[IndexRole].ListItem.Count;
    }

    public void LoadData(DataContainer_CellRole Role)
    {
        for (int i1 = 0; i1 < Role.ListItem.Count; i1++)
        {
            int tempi1 = i1;

            for (int i2 = 0; i2 < Role.ListItem[0].Count; i2++)
            {
                int tempi2 = i2;

                if (Role.ListItem[tempi1][tempi2].e_SpriteNamePanelCellItem != E_SpriteNamePanelCellItem.None)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellItem>(false, "/PanelCellItem",
                    (panel) =>
                    {
                        panel.transform.SetParent(ItemRoot[tempi1][tempi2], false);
                        panel.transform.localPosition = new(-20, 20);

                        panel.RootGrid = Grids[tempi1][tempi2];
                        panel.MemberOf = this;
                        panel.e_Location = E_ItemLocation.PanelRoleStore;
                        panel.e_Item = Role.ListItem[tempi1][tempi2].e_SpriteNamePanelCellItem;

                        panel.ImgItem.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + panel.e_Item);

                        panel.ChangeCellSize();

                        for (int i1 = 0; i1 < Hot.BodyDicItem[panel.e_Item].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicItem[panel.e_Item].X; i2++)
                            {
                                Grids[tempi1 + i1][tempi2 + i2].Item = panel;
                            }
                        }
                    });
                }
            }
        }

        InitTxtCapacity();
    }

    public void UpdateInfoByGuildRecruit(DataContainer_CellRole Role)
    {
        ImgRoleShow.sprite = Hot.MgrRes_.Load<Sprite>("Art/Role" + Role.e_RoleName + "Await");

        TxtRoleName.text = Role.Name;
        TxtRoleLevel.text = Role.NowLevel.ToString();
        TxtSanityDetails.text = Role.NowSanity + " / " + Role.MaxSanity;

        UpdateSanityExplosionLimit(Role);
        UpdateLevelInfo(Role);
        UpdateSanityInfo(Role);
        UpdateExperience(Role);
    }

    public void UpdateInfo(DataContainer_CellRole p_Role)
    {        
        NowRole = p_Role;

        ImgRoleShow.sprite = Hot.MgrRes_.Load<Sprite>("Art/Role" + p_Role.e_RoleName + "Await");

        TxtRoleName.text = p_Role.Name;
        TxtRoleLevel.text = p_Role.NowLevel.ToString();
        TxtSanityDetails.text = p_Role.NowSanity + " / " + p_Role.MaxSanity;

        UpdateSanityExplosionLimit(p_Role);
        UpdateLevelInfo(p_Role);
        UpdateSanityInfo(p_Role);
        UpdateExperience(p_Role);
        UpdateContent(p_Role);
    }

    public void UpdateSanityExplosionLimit(DataContainer_CellRole Role)
    {
        if (NumActiveObj > Role.LimitToSanityExplosion)
        {
            int v1 = NumActiveObj - Role.LimitToSanityExplosion;

            for (int i = 0; i < v1; i++)
            {
                ListImgCellSanity[Role.LimitToSanityExplosion + i].SetActive(false);
                NumActiveObj--;
            }
        }

        if (NumActiveObj < Role.LimitToSanityExplosion)
        {
            int tempNumActiveObj = NumActiveObj;
            int v1 = Role.LimitToSanityExplosion - NumActiveObj;

            for (int i = 0; i < v1; i++)
            {
                ListImgCellSanity[tempNumActiveObj + i].SetActive(true);
                NumActiveObj++;
            }
        }
    }

    public void UpdateName(DataContainer_CellRole Role, string NameToUpdate)
    {
        Role.Name = NameToUpdate;

        TxtRoleName.text = NameToUpdate;
    }

    public void UpdateSanity(DataContainer_CellRole Role, int ValueToUpdate)
    {
        Role.NowSanity += ValueToUpdate;

        UpdateSanityInfo(Role);
    }

    public void UpdateLevel(DataContainer_CellRole Role, int ValueToUpdate)
    {
        Role.NowLevel += ValueToUpdate;
        if (Role.NowLevel > Role.MaxLevel)
            Role.NowLevel = Role.MaxLevel;

        UpdateLevelInfo(Role);
    }

    public void UpdateSanityInfo(DataContainer_CellRole Role)
    {
        for (int i = 0; i < ListImgCellSanity.Count; i++)
        {
            if
            (i < Role.NowSanity / Hot.StepSanity)
            {
                ListImgCellSanity[i].GetComponent<Image>().sprite =
                    Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanityValueHave");
            }
            else
                ListImgCellSanity[i].GetComponent<Image>().sprite =
                    Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanityValueNone");
        }
    }

    public void UpdateLevelInfo(DataContainer_CellRole Role)
    {
        //等级的底图改变逻辑

        TxtRoleLevel.text = Role.NowLevel.ToString();
    }

    public void UpdateExperience(DataContainer_CellRole Role)
    {
        ImgProgress.GetComponent<RectTransform>().sizeDelta =
            new Vector2(ImgProgress.GetComponent<RectTransform>().sizeDelta.x,
                        49.3f * ((float)Role.NowExperience / Hot.ListNeedExperienceToUpLevel[Role.NowLevel]));
    }
}
