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
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnDismiss":
                Hot.PanelRoleList_.RemoveRole(IndexListRole);
                Hot.MgrUI_.HidePanel(false, gameObject, "PanelRoleDetails");
                break;
        }
    }

    public void UpdateContent(DataContainer_CellRole Role)
    {
        (AllContent as RectTransform).sizeDelta =
            new(Hot.DicRoleConfig[Role.e_RoleName].StoreSize.x * Hot.BodySizeCellItem.X,
                Hot.DicRoleConfig[Role.e_RoleName].StoreSize.y * Hot.BodySizeCellItem.Y);

        transform.FindSonSonSon("ImgBkContent").GetComponent<GridLayoutGroup>().constraintCount = Hot.BodyDicStore[PanelCellTownStore_.e_PanelCellTownStore].X;
        transform.FindSonSonSon("ImgStatusContent").GetComponent<GridLayoutGroup>().constraintCount = Hot.BodyDicStore[PanelCellTownStore_.e_PanelCellTownStore].X;

        for (int i1 = 0; i1 < Hot.BodyDicStore[PanelCellTownStore_.e_PanelCellTownStore].Y; i1++)
        {
            int tempi1 = i1;

            Grids.Add(new());
            ItemRoot.Add(new());

            GameObject obj1 = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep");
            obj1.transform.SetParent(ItemContent, false);
            GridLayoutGroup glg = obj1.AddComponent<GridLayoutGroup>();
            glg.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            glg.constraintCount = 1;
            glg.childAlignment = TextAnchor.MiddleCenter;

            for (int i2 = 0; i2 < Hot.BodyDicStore[PanelCellTownStore_.e_PanelCellTownStore].X; i2++)
            {
                int tempi2 = i2;

                Grids[tempi1].Add(new());

                GameObject obj2 = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep");
                obj2.transform.SetParent(obj1.transform, false);

                ItemRoot[tempi1].Add(obj2.transform);

                Hot.MgrUI_.CreatePanel<PanelGridTownItem>(false, "/PanelGridTownItem",
                (PanelCellTownItemGrid_) =>
                {
                    Grids[tempi1][tempi2] = PanelCellTownItemGrid_;

                    PanelCellTownItemGrid_.transform.SetParent(ComponentRoot, false);
                    PanelCellTownItemGrid_.ImgBk.transform.SetParent(ImgBkContent, false);
                    PanelCellTownItemGrid_.ImgStatus.transform.SetParent(ImgStatusContent, false);

                    PanelCellTownItemGrid_.X = tempi2;
                    PanelCellTownItemGrid_.Y = tempi1;
                });
            }
        }

        LoadData();

        ChangeCellSize();
    }

    public void LoadData()
    {
        for (int i1 = 0; i1 < Hot.BodyDicStore[PanelCellTownStore_.e_PanelCellTownStore].Y; i1++)
        {
            int tempi1 = i1;

            for (int i2 = 0; i2 < Hot.BodyDicStore[PanelCellTownStore_.e_PanelCellTownStore].X; i2++)
            {
                int tempi2 = i2;

                if (Hot.DataNowCellGameArchive.ListCellStore[PanelCellTownStore_.Index].ListItem[tempi1][tempi2].e_SpriteNamePanelCellItem != E_SpriteNamePanelCellItem.None)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellItem>(false, "/PanelCellItem",
                    (PanelCellItem_) =>
                    {
                        PanelCellItem_.transform.SetParent(ItemRoot[tempi1][tempi2], false);
                        PanelCellItem_.transform.localPosition = Vector3.zero;

                        PanelCellItem_.RootGrid = Grids[tempi1][tempi2];
                        PanelCellItem_.MemberOf = this;
                        PanelCellItem_.e_Location = E_ItemLocation.TownItem;
                        PanelCellItem_.e_SpriteNamePanelCellItem =
                            Hot.DataNowCellGameArchive.ListCellStore[PanelCellTownStore_.Index].ListItem[tempi1][tempi2].e_SpriteNamePanelCellItem;

                        PanelCellItem_.ImgItem.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + PanelCellItem_.e_SpriteNamePanelCellItem);

                        PanelCellItem_.ChangeCellSize();

                        for (int i1 = 0; i1 < Hot.BodyDicItem[PanelCellItem_.e_SpriteNamePanelCellItem].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicItem[PanelCellItem_.e_SpriteNamePanelCellItem].X; i2++)
                            {
                                Grids[tempi1 + i1][tempi2 + i2].Item = PanelCellItem_;
                            }
                        }
                    });
                }
            }
        }
    }

    public void UpdateInfo(DataContainer_CellRole Role)
    {        
        ImgRoleShow.sprite = Hot.MgrRes_.Load<Sprite>("Art/Role" + Role.e_RoleName + "Await");

        TxtRoleName.text = Role.Name;
        TxtRoleLevel.text = Role.NowLevel.ToString();
        TxtSanityDetails.text = Role.NowSanity + " / " + Role.MaxSanity;

        UpdateSanityExplosionLimit(Role);
        UpdateLevelInfo(Role);
        UpdateSanityInfo(Role);
        UpdateExperience(Role);
        UpdateContent(Role);
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
