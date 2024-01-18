using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelBaseCellRole : PanelBaseCellDynamicScrollView
{
    public E_RoleLocation e_RoleLocation;
    public Image ImgRolePortrait;

    public DataContainer_CellRole Data
    {
        get
        {
            switch (e_RoleLocation)
            {
                case E_RoleLocation.RoleList:
                    return Hot.DataNowCellGameArchive.ListRole[Index];
                case E_RoleLocation.GuildRecruit:
                    return Hot.DataNowCellGameArchive.ListRoleRecruit[Index].Role;
                default:
                    return null;
            }
        }
    }

    protected override void Awake()
    {
        base.Awake();

        ImgRolePortrait = transform.FindSonSonSon("ImgRolePortrait").GetComponent<Image>();
    }
}
