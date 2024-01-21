using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelRoomGuild : PanelBase
{
    public Transform RoomContent;

    protected override void Awake()
    {
        base.Awake();

        RoomContent = transform.FindSonSonSon("RoomContent");

        Hot.MgrUI_.CreatePanel<PanelRoleGuildRecruit>(true, E_PanelName.PanelRoleGuildRecruit,
        (panel) =>
        {
            panel.transform.SetParent(RoomContent, false);
        });

        Hot.MgrUI_.CreatePanel<PanelRoleGuildRecruitCost>(true, E_PanelName.PanelRoleGuildRecruitCost,
        (panel) =>
        {
            panel.transform.SetParent(RoomContent, false);
        });
    }
}
