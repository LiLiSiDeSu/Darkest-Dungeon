using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

        Hot.MgrUI_.CreatePanelAndPush<PanelTownStore>
            (true, "/PanelTownStore", true, true, "PanelTownStore");

        #endregion

        #region Role

        Hot.MgrUI_.CreatePanelAndPush<PanelRoleList>
            (true, "/PanelRoleList", true, false, "PanelRoleList");

        Hot.MgrUI_.CreatePanelAndPush<PanelRoleDetails>
            (true, "/PanelRoleDetails", true, false, "PanelRoleDetails");

        #endregion

        #region Bar

        Hot.MgrUI_.CreatePanelAndPush<PanelBarTown>
            (true, "/PanelBarTown", true, false, "PanelBarTown");

        Hot.MgrUI_.CreatePanelAndPush<PanelBarExpedition>
            (true, "/PanelBarExpedition", true, false, "PanelBarExpedition");

        #endregion

        #region Expedition

        Hot.MgrUI_.CreatePanelAndPush<PanelExpeditionPrepare>
            (true, "/PanelExpeditionPrepare", true, false, "PanelExpeditionPrepare");

        Hot.MgrUI_.CreatePanelAndPush<PanelExpeditionMiniMap>
            (true, "/PanelExpeditionMiniMap", true, false, "PanelExpeditionMiniMap");

        Hot.MgrUI_.CreatePanelAndPush<PanelOtherMiniMapEditor>
            (true, "/PanelOtherMiniMapEditor", true, false, "PanelOtherMiniMapEditor");

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
                    for (int i = index; i < Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep.Count; i++)
                    {
                        Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep[i].transform.
                            SetParent(Hot.MgrUI_.UIBaseCanvas, false);
                        Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep[i].transform.
                            SetParent(Hot.NowPanelBaseDynamicScrollView_.Content, false);
                    }
                    break;
                case E_ArrowDirection.Down:                                
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

        if (!File.Exists(Application.persistentDataPath + "/Data/JsonData" + "/MapTemplet" + "/Default"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Data/JsonData" + "/MapTemplet" + "/Default");
        }

        Destroy(gameObject);
    }
}
