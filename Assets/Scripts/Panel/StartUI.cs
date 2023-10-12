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

        MgrUI.GetInstance().CreatePanelAndPush<PanelGameArchiveChoose>
                         (true, "/PanelGameArchiveChoose", true, true, "PanelGameArchiveChoose");

        MgrUI.GetInstance().CreatePanelAndPush<PanelGameArchiveChooseLevel>
                         (true, "/PanelGameArchiveChooseLevel", true, false, "PanelGameArchiveChooseLevel");

        MgrUI.GetInstance().CreatePanelAndPush<PanelTown>
                         (true, "/PanelTown", true, false, "PanelTown");

        MgrUI.GetInstance().CreatePanelAndPush<PanelRooms>
                         (true, "/PanelRooms", true, true, "PanelRooms");

        Destroy(gameObject);
    }
}
