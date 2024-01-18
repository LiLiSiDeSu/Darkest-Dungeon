using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class PanelTownRooms : PanelBase
{
    private Transform ImgCurrentChoice;
    public Transform PanelRoomRoot;

    public Dictionary<string, Vector3> DicBtnPos = new();

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener("Esc" + "PanelTownRooms",
        () =>
        {
            if (Hot.ChoseCellItem != null && Hot.ChoseCellItem.e_Location == E_ItemLocation.TownShopItem)
            {
                Hot.PanelBarTownStore_.CancelNowChoosedItem();
            }

            Hot.MgrUI_.HidePanel(false, PanelRoomRoot.GetChild(0).gameObject, PanelRoomRoot.GetChild(0).gameObject.name);
        });

        ImgCurrentChoice = transform.FindSonSonSon("ImgCurrentChoice");
        PanelRoomRoot = transform.FindSonSonSon("PanelRoomRoot");

        Button[] btns = transform.FindSonSonSon("BtnRoomRoot").GetComponentsInChildren<Button>();
        foreach (Button btn in btns)
        {
            DicBtnPos.Add(btn.gameObject.name, btn.transform.localPosition);
        }
    }

    protected override void Button_OnClick(string Controlname)
    {
        base.Button_OnClick(Controlname);

        ChangeImgCurrentChoicePos(Controlname);

        Hot.MgrUI_.HidePanel(false, PanelRoomRoot.GetChild(0).gameObject, PanelRoomRoot.GetChild(0).gameObject.name);

        ShowRoom(Controlname);
    }

    public void ShowRoom(string controlname)
    {
        switch (controlname)
        {
            case "BtnRoomGuild":
                Hot.MgrUI_.ShowPanel<PanelRoomGuild>(false, "PanelRoomGuild",
                (panel) =>
                {
                    panel.transform.SetParent(Hot.PanelTownRooms_.PanelRoomRoot, false);
                });
                break;
            case "BtnRoomGraveyard":
                Hot.MgrUI_.ShowPanel<PanelRoomGraveyard>(false, "PanelRoomGraveyard",
                (panel) =>
                {
                    panel.transform.SetParent(Hot.PanelTownRooms_.PanelRoomRoot, false);
                });
                break;
            case "BtnRoomTownShop":
                Hot.MgrUI_.ShowPanel<PanelRoomTownShop>(false, "PanelRoomTownShop",
                (panel) =>
                {
                    panel.transform.SetParent(Hot.PanelTownRooms_.PanelRoomRoot, false);
                });
                break;
            case "BtnRoomSmithy":
                Hot.MgrUI_.ShowPanel<PanelRoomSmithy>(false, "PanelRoomSmithy",
                (panel) =>
                {
                    panel.transform.SetParent(Hot.PanelTownRooms_.PanelRoomRoot, false);
                });
                break;
            case "BtnRoomTavern":
                Hot.MgrUI_.ShowPanel<PanelRoomTavern>(false, "PanelRoomTavern",
                (panel) =>
                {
                    panel.transform.SetParent(Hot.PanelTownRooms_.PanelRoomRoot, false);
                });
                break;
            case "BtnRoomAbbey":
                Hot.MgrUI_.ShowPanel<PanelRoomAbbey>(false, "PanelRoomAbbey",
                (panel) =>
                {
                    panel.transform.SetParent(Hot.PanelTownRooms_.PanelRoomRoot, false);
                });
                break;
            case "BtnRoomSanitarium":
                Hot.MgrUI_.ShowPanel<PanelRoomSanitarium>(false, "PanelRoomSanitarium",
                (panel) =>
                {
                    panel.transform.SetParent(Hot.PanelTownRooms_.PanelRoomRoot, false);
                });
                break;
            case "BtnRoomSurvivorMaster":
                Hot.MgrUI_.ShowPanel<PanelRoomSurvivorMaster>(false, "PanelRoomSurvivorMaster",
                (panel) =>
                {
                    panel.transform.SetParent(Hot.PanelTownRooms_.PanelRoomRoot, false);
                });
                break;
        }
    }

    public void ChangeImgCurrentChoicePos(string btnName)
    {
        ImgCurrentChoice.transform.localPosition = new Vector3(DicBtnPos[btnName].x + 80, DicBtnPos[btnName].y, 0);
    }
}
