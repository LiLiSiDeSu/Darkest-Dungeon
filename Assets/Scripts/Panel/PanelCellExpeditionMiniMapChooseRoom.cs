using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellExpeditionMiniMapChooseRoom : PanelBase
{
    public E_CellExpeditionMiniMapRoom e_CellExpeditionMiniMapRoom = E_CellExpeditionMiniMapRoom.None;
    public Image ImgCellExpeditionMiniMapChooseRoom;

    protected override void Awake()
    {
        base.Awake();

        ImgCellExpeditionMiniMapChooseRoom = transform.FindSonSonSon("ImgCellExpeditionMiniMapChooseRoom").GetComponent<Image>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellExpeditionMiniMapChooseRoom":
                Hot.PanelOtherMapEditor_.ImgCurrentChooseRoom.sprite =
                    Hot.MgrRes_.Load<Sprite>("Art/CellMap" + e_CellExpeditionMiniMapRoom.ToString());
                break;
        }
    }

    public void Init(E_CellExpeditionMiniMapRoom e_CellExpeditionMiniMapRoom)
    {        
        this.e_CellExpeditionMiniMapRoom = e_CellExpeditionMiniMapRoom;
        ImgCellExpeditionMiniMapChooseRoom.sprite = Hot.MgrRes_.Load<Sprite>("Art/CellMap" + e_CellExpeditionMiniMapRoom.ToString());
    }
}
