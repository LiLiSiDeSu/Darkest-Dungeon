using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : InstanceBaseAuto_Mono<StartUI>
{
    private void Start()
    {
        Hot.MgrUI_.CreatePanelAndShow<PanelOtherStart>
            (true, "/PanelOtherStart");

        Hot.MgrUI_.CreatePanelAndPush<PanelOtherDestroyArchiveHint>
            (true, "/PanelOtherDestroyArchiveHint", true, false, "PanelOtherDestroyArchiveHint");

        Hot.MgrUI_.CreatePanelAndPush<PanelOtherSetting>
            (true, "/PanelOtherSetting", true, false, "PanelOtherSetting");

        Hot.MgrUI_.CreatePanelAndPush<PanelGameArchiveChoose>
            (true, "/PanelGameArchiveChoose", true, true, "PanelGameArchiveChoose");

        Hot.MgrUI_.CreatePanelAndPush<PanelGameArchiveChooseLevel>
            (true, "/PanelGameArchiveChooseLevel", true, false, "PanelGameArchiveChooseLevel");

        Hot.MgrUI_.CreatePanelAndPush<PanelTown>
            (true, "/PanelTown", true, false, "PanelTown");

        Hot.MgrUI_.CreatePanelAndPush<PanelRooms>
            (true, "/PanelRooms", true, true, "PanelRooms");

        Hot.MgrUI_.CreatePanelAndPush<PanelTownStore>
            (true, "/PanelTownStore", true, true, "PanelTownStore");        

        Hot.MgrUI_.CreatePanelAndPush<PanelOhterResTable>
            (true, "/PanelOhterResTable", true, false, "PanelOhterResTable");

        Hot.MgrUI_.CreatePanelAndPush<PanelRoleList>
            (true, "/PanelRoleList", true, false, "PanelRoleList");

        Hot.MgrUI_.CreatePanelAndPush<PanelRoleDetails>
            (true, "/PanelRoleDetails", true, false, "PanelRoleDetails");

        Hot.MgrUI_.CreatePanelAndPush<PanelBarTown>
            (true, "/PanelBarTown", true, false, "PanelBarTown");

        Hot.MgrUI_.CreatePanelAndPush<PanelBarExpedition>
            (true, "/PanelBarExpedition", true, false, "PanelBarExpedition");

        Hot.MgrUI_.CreatePanelAndPush<PanelExpeditionPrepare>
            (true, "/PanelExpeditionPrepare", true, false, "PanelExpeditionPrepare");

        Hot.MgrUI_.CreatePanelAndPush<PanelExpeditionMapRoom>
            (true, "/PanelExpeditionMapRoom", true, false, "PanelExpeditionMapRoom");

        Hot.MgrUI_.CreatePanelAndPush<PanelExpeditionMapHall>
            (true, "/PanelExpeditionMapHall", true, false, "PanelExpeditionMapHall");

        Hot.MgrUI_.CreatePanelAndPush<PanelExpeditionMiniMap>
            (true, "/PanelExpeditionMiniMap", true, false, "PanelExpeditionMiniMap");

        Hot.MgrUI_.CreatePanelAndPush<PanelMapEditor>
            (true, "/PanelMapEditor", true, false, "PanelMapEditor");

        Destroy(gameObject);
    }
}
