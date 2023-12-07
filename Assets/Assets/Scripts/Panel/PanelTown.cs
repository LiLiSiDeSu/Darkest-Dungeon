using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTown : PanelBase
{
    protected override void Awake()
    {
        base.Awake();

        transform.FindSonSonSon("ImgRoomAbbey").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgRoomSanitarium").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgRoomSurvivorMaster").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgRoomTavern").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgRoomGraveyard").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgRoomTownShop").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgRoomSmithy").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgRoomGuild").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        Hot.MgrUI_.ShowPanel<PanelTownRooms>(true, "PanelTownRooms");
        Hot.PanelTownRooms_.ChangeImgCurrentChoicePos(controlname);
        Hot.PanelTownRooms_.ShowRoom(controlname);
    }   
}
