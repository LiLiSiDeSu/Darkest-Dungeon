using System.Collections.Generic;
using UnityEngine;

public class PanelBarRoleListExpedition : PanelBase
{
    public int IndexChose = -1;
    public int IndexNowPut = -1;

    public List<int> ListNeedPutRoleIndex = new();
    public List<PanelCellExpeditionRole> ListCellExpeditionRole = new();

    public Transform RoleListExpeditionContent;

    protected override void Awake()
    {
        base.Awake();

        Hot.TriggerEvent_.AddEventListener<KeyCode>(E_KeyEvent.KeyDown.ToString(),
        (key) =>
        {
            if (Hot.e_NowPlayerLocation == E_PlayerLocation.OnExpedition && key == Hot.MgrInput_.RoleList)
            {
                if (Hot.PoolNowPanel_.ContainPanel(E_PanelName.PanelBarRoleListExpedition))
                {
                    Hot.MgrUI_.HidePanel(false, gameObject, E_PanelName.PanelBarRoleListExpedition);
                }
                else
                {
                    Hot.MgrUI_.ShowPanel<PanelBarRoleListExpedition>(true, E_PanelName.PanelBarRoleListExpedition);
                }
            }
        });

        RoleListExpeditionContent = transform.FindSonSonSon("RoleListExpeditionContent");
    }

    public void Init()
    {
        ListNeedPutRoleIndex = new();

        for (int i = 0; i < Hot.DataNowCellGameArchive.ListExpeditionRoleIndex.Count; i++)
        {
            ListNeedPutRoleIndex.Add(Hot.DataNowCellGameArchive.ListExpeditionRoleIndex[i]);
        }

        for (int i = 0; i < ListNeedPutRoleIndex.Count; i++)
        {
            int tempi = i;

            Hot.MgrUI_.CreatePanel<PanelCellExpeditionRole>(false, E_PanelName.PanelCellExpeditionRole,
            (panel) =>
            {
                panel.Init(tempi, ListNeedPutRoleIndex[tempi], RoleListExpeditionContent);
                ListCellExpeditionRole.Add(panel);

                if (tempi == ListNeedPutRoleIndex.Count - 1)
                {
                    DisableImgStatus();
                }
            });
        }
    }

    public void EnableImgStatus()
    {
        foreach (PanelCellExpeditionRole item in ListCellExpeditionRole)
        {
            item.ImgRolePortrait.raycastTarget = true;
        }
    }
    public void DisableImgStatus()
    {
        foreach (PanelCellExpeditionRole item in ListCellExpeditionRole)
        {
            item.ImgRolePortrait.raycastTarget = false;
        }
    }

    public PanelCellExpeditionRole GetCellRoleExpedition(int p_Index)
    {
        return RoleListExpeditionContent.GetChild(p_Index).GetComponent<PanelCellExpeditionRole>();
    }

    public void ClickMapExpeditionRole(int p_RoleIndex)
    {
        if (p_RoleIndex == -1 && IndexChose == -1)
        {
            return;
        }

        if (p_RoleIndex == -1)
        {
            ListCellExpeditionRole[IndexChose].ImgBanner.gameObject.SetActive(false);
            IndexChose = -1;
            Hot.PanelExpeditionRoleDetails_.IndexRole = -1;
            Hot.PanelExpeditionRoleDetails_.Clear();

            return;
        }

        for (int i = 0; i < ListCellExpeditionRole.Count; i++)
        {
            if (ListCellExpeditionRole[i].IndexRole == p_RoleIndex)
            {
                Hot.PanelExpeditionRoleDetails_.UpdateInfo(ListCellExpeditionRole[i].IndexRole);

                if (IndexChose != -1)
                {
                    ListCellExpeditionRole[IndexChose].ImgBanner.gameObject.SetActive(false);
                }

                IndexChose = i;
                ListCellExpeditionRole[IndexChose].ImgBanner.gameObject.SetActive(true);

                return;
            }
        }
    }

    public void ClearNoData()
    {
        foreach (PanelCellExpeditionRole item in ListCellExpeditionRole)
        {
            Destroy(item.gameObject);
        }

        IndexNowPut = -1;
        ListNeedPutRoleIndex.Clear();
        ListCellExpeditionRole.Clear();
    }

    public void ClearAndData()
    {
        foreach (PanelCellExpeditionRole item in ListCellExpeditionRole)
        {
            if (item.CellExpeditionRoom != null)
            {
                Hot.DataNowCellGameArchive.ListRole[item.CellExpeditionRoom.RootGrid.Data.IndexListRole].ReSetExpeditionData();
                item.CellExpeditionRoom.RootGrid.Data.IndexListRole = -1;
            }

            Destroy(item.gameObject);
        }

        IndexNowPut = -1;
        ListNeedPutRoleIndex.Clear();
        ListCellExpeditionRole.Clear();

        Hot.Data_.Save();
    }

    public void Sort()
    {
        List<int> ListIndex = new();
        for (int i = 0; i < Hot.DataNowCellGameArchive.ListExpeditionRoleIndex.Count; i++)
        {
            ListIndex.Add(Hot.DataNowCellGameArchive.ListExpeditionRoleIndex[i]);
        }
        int count = RoleListExpeditionContent.childCount;

        for (int i = 0; i < ListCellExpeditionRole.Count; i++)
        {
            ListCellExpeditionRole[i].transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);
        }

        for (int i = 0; count != RoleListExpeditionContent.childCount; i++)
        {
            if (i == count)
            {
                i = 0;
            }

            if (ListIndex[0] == ListCellExpeditionRole[i].IndexRole)
            {
                ListCellExpeditionRole[i].Index = RoleListExpeditionContent.childCount;
                ListCellExpeditionRole[i].transform.SetParent(RoleListExpeditionContent, false);
                ListCellExpeditionRole[i].transform.localPosition = Vector3.zero;
                ListIndex.RemoveAt(0);
            }
        }
    }
}
