using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : InstanceBaseAuto_Mono<StartUI>
{
    protected override void Start()
    {
        base.Start();

        MgrUI.GetInstance().CreatePanelAndShow<PanelOtherStart>
                         (true, "/PanelOtherStart");

        MgrUI.GetInstance().CreatePanelAndPush<PanelOtherHint>
                         (true, "/PanelOtherHint", true, false, "PanelOtherHint");

        MgrUI.GetInstance().CreatePanelAndPush<PanelOtherSetting>
                         (true, "/PanelOtherSetting", true, false, "PanelOtherSetting");

        MgrUI.GetInstance().CreatePanelAndPush<PanelGameArchiveChoose>
                         (true, "/PanelGameArchiveChoose", true, true, "PanelGameArchiveChoose");

        MgrUI.GetInstance().CreatePanelAndPush<PanelGameArchiveChooseLevel>
                         (true, "/PanelGameArchiveChooseLevel", true, false, "PanelGameArchiveChooseLevel");

        MgrUI.GetInstance().CreatePanelAndPush<PanelTown>
                         (true, "/PanelTown", true, false, "PanelTown");

        MgrUI.GetInstance().CreatePanelAndPush<PanelRooms>
                         (true, "/PanelRooms", true, true, "PanelRooms");

        MgrUI.GetInstance().CreatePanelAndPush<PanelTownStore>
                         (true, "/PanelTownStore", true, true, "PanelTownStore");

        MgrUI.GetInstance().CreatePanelAndPush<PanelStoreAncestralProperty>
                         (true, "/PanelStoreAncestralProperty", true, false, "PanelStoreAncestralProperty");

        MgrUI.GetInstance().CreatePanelAndPush<PanelStoreCoin>
                         (true, "/PanelStoreCoin", true, false, "PanelStoreCoin");

        MgrUI.GetInstance().CreatePanelAndPush<PanelAction>
                         (true, "/PanelAction", true, false, "PanelAction");

        Destroy(gameObject);
    }
}
