using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBarRoleListExpedition : PanelBase
{
    public int NowPutIndex = 0;
    public List<int> ListNeedPutRole = new();

    public Transform RoleListExpeditionContent;

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (Hot.e_NowPlayerLocation == E_PlayerLocation.OnExpedition && key == Hot.MgrInput_.RoleList)
            {
                if (Hot.PoolNowPanel_.ContainPanel("PanelBarRoleListExpedition"))
                {
                    Hot.MgrUI_.HidePanel(false, gameObject, "PanelBarRoleListExpedition");
                }
                else
                {
                    Hot.MgrUI_.ShowPanel<PanelBarRoleListExpedition>(true, "PanelBarRoleListExpedition");
                }
            }
        });

        RoleListExpeditionContent = transform.FindSonSonSon("RoleListExpeditionContent");
    }

    public void InitByTown()
    {
        ListNeedPutRole = new();
        for (int i = 0; i < Hot.DataNowCellGameArchive.RoleIndexListExpedition.Count; i++)
        {
            ListNeedPutRole.Add(Hot.DataNowCellGameArchive.RoleIndexListExpedition[i]);
        }

        foreach (int index in ListNeedPutRole)
        {
            Hot.MgrUI_.CreatePanel<PanelCellRoleExpedition>(false, "/PanelCellRoleExpedition",
            (panel) =>
            {
                panel.Init(index, RoleListExpeditionContent);
            });
        }
    }

    public void InitByOnExpedition()
    {
        foreach (int index in Hot.DataNowCellGameArchive.RoleIndexListExpedition)
        {
            Hot.MgrUI_.CreatePanel<PanelCellRoleExpedition>(false, "/PanelCellRoleExpedition",
            (panel) =>
            {
                panel.Init(index, RoleListExpeditionContent);
            });
        }
    }

    public PanelCellRoleExpedition GetCellRoleExpedition(int p_Index)
    {
        return RoleListExpeditionContent.GetChild(p_Index).GetComponent<PanelCellRoleExpedition>();
    }

    public void Clear()
    {
        ListNeedPutRole.Clear();

        foreach (PanelCellRoleExpedition item in RoleListExpeditionContent.GetComponentsInChildren<PanelCellRoleExpedition>())
        {
            Destroy(item.gameObject);
        }
    }
}
