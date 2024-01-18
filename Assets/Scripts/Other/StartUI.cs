using System.Threading;
using UnityEngine;

public class StartUI : InstanceBaseAuto_Mono<StartUI>
{
    private void Start()
    {
        #region Other

        Hot.MgrUI_.CreatePanelAndShow<PanelOtherStart>
            (true, "/PanelOtherStart");

        Hot.MgrUI_.CreatePanelAndPush<PanelOtherDestroyArchiveHint>
            (true, "/PanelOtherDestroyArchiveHint", true, false, "PanelOtherDestroyArchiveHint");

        Hot.MgrUI_.CreatePanelAndPush<PanelOhterResTable>
            (true, "/PanelOhterResTable", true, false, "PanelOhterResTable");

        Hot.MgrUI_.CreatePanelAndPush<PanelOtherSetting>
            (true, "/PanelOtherSetting", true, false, "PanelOtherSetting");

        Hot.MgrUI_.CreatePanelAndPush<PanelOtherRoomEditor>
            (true, "/PanelOtherRoomEditor", true, false, "PanelOtherRoomEditor");

        #endregion

        #region GameArchive

        Hot.MgrUI_.CreatePanelAndPush<PanelGameArchiveChoose>
            (true, "/PanelGameArchiveChoose", true, true, "PanelGameArchiveChoose");

        Hot.MgrUI_.CreatePanelAndPush<PanelGameArchiveChooseLevel>
            (true, "/PanelGameArchiveChooseLevel", true, false, "PanelGameArchiveChooseLevel");

        #endregion

        #region Town

        Hot.MgrUI_.CreatePanelAndPush<PanelTown>
            (true, "/PanelTown", true, false, "PanelTown");

        #endregion

        #region Role

        Hot.MgrUI_.CreatePanelAndPush<PanelRoleDetails>
            (true, "/PanelRoleDetails", true, false, "PanelRoleDetails");

        #endregion

        #region Bar

        Hot.MgrUI_.CreatePanelAndPush<PanelBarTown>
            (true, "/PanelBarTown", true, false, "PanelBarTown");

        Hot.MgrUI_.CreatePanelAndPush<PanelBarExpedition>
            (true, "/PanelBarExpedition", true, false, "PanelBarExpedition");

        Hot.MgrUI_.CreatePanelAndPush<PanelBarRoleListExpedition>
            (true, "/PanelBarRoleListExpedition", true, false, "PanelBarRoleListExpedition");

        Hot.MgrUI_.CreatePanelAndPush<PanelBarExpeditionTimeLine>
            (true, "/PanelBarExpeditionTimeLine", true, false, "PanelBarExpeditionTimeLine");

        Hot.MgrUI_.CreatePanelAndPush<PanelBarTownStore>
            (true, "/PanelBarTownStore", true, true, "PanelBarTownStore");

        Hot.MgrUI_.CreatePanelAndPush<PanelBarRoleList>
            (true, "/PanelBarRoleList", true, false, "PanelBarRoleList");

        #endregion

        #region Expedition

        Hot.MgrUI_.CreatePanelAndPush<PanelExpeditionPrepare>
            (true, "/PanelExpeditionPrepare", true, false, "PanelExpeditionPrepare");

        Hot.MgrUI_.CreatePanelAndPush<PanelExpeditionMiniMap>
            (true, "/PanelExpeditionMiniMap", true, false, "PanelExpeditionMiniMap");

        Hot.MgrUI_.CreatePanelAndPush<PanelOtherMiniMapEditor>
            (true, "/PanelOtherMiniMapEditor", true, false, "PanelOtherMiniMapEditor");

        Hot.MgrUI_.CreatePanelAndPush<PanelExpeditionRoom>
            (true, "/PanelExpeditionRoom", true, false, "PanelExpeditionRoom");

        #endregion

        #region PanelTownRooms

        Hot.MgrUI_.CreatePanelAndPush<PanelTownRooms>
            (true, "/PanelTownRooms", true, true, "PanelTownRooms");

        Hot.MgrUI_.CreatePanelAndPush<PanelRoomGuild>
            (true, "/PanelRoomGuild", true, false, "PanelRoomGuild");
        Hot.MgrUI_.CreatePanelAndPush<PanelRoomGraveyard>
            (true, "/PanelRoomGraveyard", true, false, "PanelRoomGraveyard");
        Hot.MgrUI_.CreatePanelAndPush<PanelRoomTownShop>
            (true, "/PanelRoomTownShop", true, false, "PanelRoomTownShop");
        Hot.MgrUI_.CreatePanelAndPush<PanelRoomSmithy>
            (true, "/PanelRoomSmithy", true, false, "PanelRoomSmithy");
        Hot.MgrUI_.CreatePanelAndPush<PanelRoomTavern>
            (true, "/PanelRoomTavern", true, false, "PanelRoomTavern");
        Hot.MgrUI_.CreatePanelAndPush<PanelRoomSurvivorMaster>
            (true, "/PanelRoomSurvivorMaster", true, false, "PanelRoomSurvivorMaster");
        Hot.MgrUI_.CreatePanelAndPush<PanelRoomAbbey>
            (true, "/PanelRoomAbbey", true, false, "PanelRoomAbbey");
        Hot.MgrUI_.CreatePanelAndPush<PanelRoomSanitarium>
            (true, "/PanelRoomSanitarium", true, false, "PanelRoomSanitarium");

        #endregion

        #region DynamicContentStep的事件注册        

        Hot.CenterEvent_.AddEventListener<int, E_WSAD>
        ("DynamicContentStep",
        (index, arrow) =>
        {
            Hot.PaddingContentStep_.transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);
            Hot.PaddingContentStep_.transform.SetParent(Hot.NowPanelBaseDynamicScrollView_.Content, false);
            Hot.PaddingContentStep_.gameObject.SetActive(true);

            switch (arrow)
            {
                case E_WSAD.W:
                    for (int i = index; i < Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep.Count; i++)
                    {
                        Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep[i].transform.
                            SetParent(Hot.MgrUI_.UIBaseCanvas, false);
                        Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep[i].transform.
                            SetParent(Hot.NowPanelBaseDynamicScrollView_.Content, false);
                    }
                    break;
                case E_WSAD.S:
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

        #endregion       

        Destroy(gameObject);
    }
}
