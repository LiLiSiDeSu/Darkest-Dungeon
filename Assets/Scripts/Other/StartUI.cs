public class StartUI : InstanceBaseAuto_Mono<StartUI>
{
    private void Start()
    {
        #region Other

        Hot.MgrUI_.CreatePanelAndShow<PanelOtherStart>
            (true, E_PanelName.PanelOtherStart, false);

        Hot.MgrUI_.CreatePanelAndPush<PanelOtherDestroyArchiveHint>
            (true, E_PanelName.PanelOtherDestroyArchiveHint, true, false);

        Hot.MgrUI_.CreatePanelAndPush<PanelOhterResTable>
            (true, E_PanelName.PanelOhterResTable, true, false);

        Hot.MgrUI_.CreatePanelAndPush<PanelOtherSetting>
            (true, E_PanelName.PanelOtherSetting, true, false);

        #endregion

        #region GameArchive

        Hot.MgrUI_.CreatePanelAndPush<PanelGameArchiveChoose>
            (true, E_PanelName.PanelGameArchiveChoose, true, true);

        Hot.MgrUI_.CreatePanelAndPush<PanelGameArchiveChooseLevel>
            (true, E_PanelName.PanelGameArchiveChooseLevel, true, false);

        #endregion

        #region Town

        Hot.MgrUI_.CreatePanelAndPush<PanelTown>
            (true, E_PanelName.PanelTown, true, false);

        #endregion

        #region Role

        Hot.MgrUI_.CreatePanelAndPush<PanelRoleDetails>
            (true, E_PanelName.PanelRoleDetails, true, false);

        #endregion

        #region Bar

        Hot.MgrUI_.CreatePanelAndPush<PanelBarTown>
            (true, E_PanelName.PanelBarTown, true, false);

        Hot.MgrUI_.CreatePanelAndPush<PanelBarExpedition>
            (true, E_PanelName.PanelBarExpedition, true, false);

        Hot.MgrUI_.CreatePanelAndPush<PanelBarRoleListExpedition>
            (true, E_PanelName.PanelBarRoleListExpedition, true, false);

        Hot.MgrUI_.CreatePanelAndPush<PanelBarExpeditionTimeLine>
            (true, E_PanelName.PanelBarExpeditionTimeLine, true, false);

        Hot.MgrUI_.CreatePanelAndPush<PanelBarTownStore>
            (true, E_PanelName.PanelBarTownStore, true, true);

        Hot.MgrUI_.CreatePanelAndPush<PanelBarRoleList>
            (true, E_PanelName.PanelBarRoleList, true, false);

        #endregion

        #region Editor

        Hot.MgrUI_.CreatePanelAndPush<PanelOtherEditorMiniMap>
            (true, E_PanelName.PanelOtherEditorMiniMap, true, false);

        Hot.MgrUI_.CreatePanelAndPush<PanelOtherEditorRoom>
            (true, E_PanelName.PanelOtherEditorRoom, true, false);

        Hot.MgrUI_.CreatePanelAndPush<PanelOtherEditorRoleConfig>
            (true, E_PanelName.PanelOtherEditorRoleConfig, true, false);

        #endregion

        #region Expedition

        Hot.MgrUI_.CreatePanelAndPush<PanelExpeditionPrepare>
            (true, E_PanelName.PanelExpeditionPrepare, true, false);

        Hot.MgrUI_.CreatePanelAndPush<PanelExpeditionMiniMap>
            (true, E_PanelName.PanelExpeditionMiniMap, true, false);

        Hot.MgrUI_.CreatePanelAndPush<PanelExpeditionRoom>
            (true, E_PanelName.PanelExpeditionRoom, true, false);

        #endregion

        #region PanelTownRooms

        Hot.MgrUI_.CreatePanelAndPush<PanelTownRooms>
            (true, E_PanelName.PanelTownRooms, true, true);

        Hot.MgrUI_.CreatePanelAndPush<PanelRoomGuild>
            (true, E_PanelName.PanelRoomGuild, true, false);
        Hot.MgrUI_.CreatePanelAndPush<PanelRoomGraveyard>
            (true, E_PanelName.PanelRoomGraveyard, true, false);
        Hot.MgrUI_.CreatePanelAndPush<PanelRoomTownShop>
            (true, E_PanelName.PanelRoomTownShop, true, false);
        Hot.MgrUI_.CreatePanelAndPush<PanelRoomSmithy>
            (true, E_PanelName.PanelRoomSmithy, true, false);
        Hot.MgrUI_.CreatePanelAndPush<PanelRoomTavern>
            (true, E_PanelName.PanelRoomTavern, true, false);
        Hot.MgrUI_.CreatePanelAndPush<PanelRoomSurvivorMaster>
            (true, E_PanelName.PanelRoomSurvivorMaster, true, false);
        Hot.MgrUI_.CreatePanelAndPush<PanelRoomAbbey>
            (true, E_PanelName.PanelRoomAbbey, true, false);
        Hot.MgrUI_.CreatePanelAndPush<PanelRoomSanitarium>
            (true, E_PanelName.PanelRoomSanitarium, true, false);

        #endregion

        #region DynamicContentStep的事件注册        

        Hot.TriggerEvent_.AddEventListener<int, E_WSAD>
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
