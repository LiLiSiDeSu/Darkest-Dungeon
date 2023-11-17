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

        Hot.MgrUI_.CreatePanelAndPush<PanelOtherMapEditor>
            (true, "/PanelOtherMapEditor", true, false, "PanelOtherMapEditor");

        Hot.CenterEvent_.AddEventListener<int, E_ArrowDirection>
        ("DynamicContentStep",
        (index, arrow) =>
        {
            Hot.PaddingContentStep_.transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);
            Hot.PaddingContentStep_.transform.SetParent(Hot.NowPanelBaseDynamicScrollView_.Content, false);
            Hot.PaddingContentStep_.gameObject.SetActive(true);            

            switch (arrow)
            {
                case E_ArrowDirection.Up:
                    Debug.Log(index + " - " + arrow);
                    for (int i = index; i < Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep.Count; i++)
                    {
                        Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep[i].transform.
                            SetParent(Hot.MgrUI_.UIBaseCanvas, false);
                        Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep[i].transform.
                            SetParent(Hot.NowPanelBaseDynamicScrollView_.Content, false);
                    }
                    break;
                case E_ArrowDirection.Down:
                    Debug.Log(index + " - " + arrow);
                    for (int i = index + 1; i < Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep.Count; i++)
                    {
                        Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep[i].transform.
                            SetParent(Hot.MgrUI_.UIBaseCanvas, false);
                        Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep[i].transform.
                            SetParent(Hot.NowPanelBaseDynamicScrollView_.Content, false);
                    }
                    break;
            }
        });

        Destroy(gameObject);
    }
}
