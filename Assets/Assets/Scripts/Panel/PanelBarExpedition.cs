using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PanelBarExpedition : PanelBase,
             IPointerEnterHandler, IPointerExitHandler
{
    public List<PanelCellExpeditionRolePrepareRoot> ListCellExpeditionRolePrepareRoot = new();

    public Transform ExpeditionRoleRootBk;

    protected override void Awake()
    {
        base.Awake();

        ExpeditionRoleRootBk = transform.FindSonSonSon("ExpeditionRoleRootBk");
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnExpedition":
                InitRolePos();
                if (Hot.NowExpeditionEvent != null && Hot.DataNowCellGameArchive.ListExpeditionRoleIndex.Count > 0)
                {
                    Hot.e_NowPlayerLocation = E_PlayerLocation.OnExpedition;
                    Hot.MgrUI_.HideAllPanel();
                    Hot.DataNowCellGameArchive.e_NowExpeditionLocation = Hot.NowExpeditionEvent.e_ExpeditionLocation;
                    Hot.DataNowCellGameArchive.NowEventIndex = Hot.NowExpeditionEvent.Index;
                    Hot.PanelExpeditionMiniMap_.Init(false);
                    Hot.MgrUI_.ShowPanel<PanelExpeditionRoom>(false, "PanelExpeditionRoom");
                    Hot.MgrUI_.ShowPanel<PanelBarRoleListExpedition>(true, "PanelBarRoleListExpedition",
                    (panel) =>
                    {
                        panel.Init();
                    });

                    Hot.Data_.Save();
                    Debug.Log(Hot.DataNowCellGameArchive.ListExpeditionRoleIndex.Count);
                }
                break;
        }
    }

    #region EventSystem

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.e_NowPointerLocation = E_NowPointerLocation.PanelBarExpedition;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.e_NowPointerLocation = E_NowPointerLocation.None;
    }

    #endregion

    public void Init()
    {
        for (int i = 0; i < 4; i++)
        {
            int tempi = i;

            Hot.MgrUI_.CreatePanel<PanelCellExpeditionRolePrepareRoot>(false, "/PanelCellExpeditionRolePrepareRoot",
            (panel) =>
            {
                panel.Init(tempi, ExpeditionRoleRootBk);
                ListCellExpeditionRolePrepareRoot.Add(panel);
            });
        }

        for (int i = 0; i < Hot.DataNowCellGameArchive.ListRole.Count; i++)
        {
            int tempi = i;

            if (Hot.DataNowCellGameArchive.ListRole[tempi].IndexExpeditionRoot != -1)
            {
                Hot.MgrUI_.CreatePanel<PanelCellRolePortraitCanDrag>
                (false, "/PanelCellRolePortraitCanDrag",
                (panel) =>
                {
                    panel.ExpeditionRolePrepareRoot = ListCellExpeditionRolePrepareRoot[Hot.DataNowCellGameArchive.ListRole[tempi].IndexExpeditionRoot];

                    panel.Role = Hot.PanelBarRoleList_.ListDynamicContentStep[tempi].GetComponentInChildren<PanelCellRole>();
                    panel.Role.RolePortraitCanDrag = panel;
                    panel.Init(panel.Role, ListCellExpeditionRolePrepareRoot[Hot.DataNowCellGameArchive.ListRole[tempi].IndexExpeditionRoot].transform, new(100, 100));
                });
            }
        }
    }

    public void InitRolePos()
    {
        Hot.DataNowCellGameArchive.ListExpeditionRoleIndex.Clear();

        foreach (PanelCellExpeditionRolePrepareRoot item in ListCellExpeditionRolePrepareRoot)
        {
            if (item.transform.childCount > 0)
            {
                Hot.DataNowCellGameArchive.ListExpeditionRoleIndex.Add(item.GetComponentInChildren<PanelCellRolePortraitCanDrag>().Role.Index);
            }
        }
    }

    public void Clear()
    {
        foreach (var item in ListCellExpeditionRolePrepareRoot)
        {
            DestroyImmediate(item.gameObject);
        }

        ListCellExpeditionRolePrepareRoot.Clear();
    }
}
