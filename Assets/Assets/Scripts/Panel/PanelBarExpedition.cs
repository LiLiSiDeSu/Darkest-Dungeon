using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

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
                if (Hot.NowExpeditionEvent != null)
                {
                    InitRolePos();
                    Hot.e_NowPlayerLocation = E_PlayerLocation.OnExpedition;
                    Hot.MgrUI_.HideAllPanel();
                    Hot.PanelExpeditionMiniMap_.Init();
                    Hot.MgrUI_.ShowPanel<PanelExpeditionRoom>(false, "PanelExpeditionRoom");
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

        for (int i = 0; i < Hot.DataNowCellGameArchive.ListCellRole.Count; i++)
        {
            int tempi = i;

            if (Hot.DataNowCellGameArchive.ListCellRole[tempi].IndexExpeditionRoot != -1)
            {
                Hot.MgrUI_.CreatePanel<PanelCellRolePortraitCanDrag>
                (false, "/PanelCellRolePortraitCanDrag",
                (panel) =>
                {
                    panel.ExpeditionRolePrepareRoot = ListCellExpeditionRolePrepareRoot[Hot.DataNowCellGameArchive.ListCellRole[tempi].IndexExpeditionRoot];

                    panel.Role = Hot.PanelRoleList_.ListDynamicContentStep[tempi].GetComponentInChildren<PanelCellRole>();
                    panel.Role.RolePortraitCanDrag = panel;
                    panel.Init(panel.Role, ListCellExpeditionRolePrepareRoot[Hot.DataNowCellGameArchive.ListCellRole[tempi].IndexExpeditionRoot].transform, new(100, 100));
                });
            }
        }
    }

    public void InitRolePos()
    {
        foreach (PanelCellExpeditionRolePrepareRoot item in ListCellExpeditionRolePrepareRoot)
        {
            if (item.transform.childCount > 0)
            {
                Hot.ListIndexPutRole.Add(item.GetComponentInChildren<PanelCellRolePortraitCanDrag>().Role.Index);
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
