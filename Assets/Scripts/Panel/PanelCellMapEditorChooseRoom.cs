using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellMapEditorChooseRoom : PanelBase
{
    public E_CellExpeditionMiniMapRoom e_CellExpeditionMiniMapRoom = E_CellExpeditionMiniMapRoom.None;
    public Image ImgCellMapEditorChooseRoom;

    protected override void Awake()
    {
        base.Awake();

        ImgCellMapEditorChooseRoom = transform.FindSonSonSon("ImgCellMapEditorChooseRoom").GetComponent<Image>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellMapEditorChooseRoom":
                Hot.PanelOtherMapEditor_.ImgCurrentChooseRoom.sprite =
                    Hot.MgrRes_.Load<Sprite>("Art/CellMap" + e_CellExpeditionMiniMapRoom.ToString());
                Hot.e_NowChooseRoom = e_CellExpeditionMiniMapRoom;
                break;
        }
    }

    public void Init(E_CellExpeditionMiniMapRoom e_CellExpeditionMiniMapRoom)
    {        
        this.e_CellExpeditionMiniMapRoom = e_CellExpeditionMiniMapRoom;
        ImgCellMapEditorChooseRoom.sprite = Hot.MgrRes_.Load<Sprite>("Art/CellMap" + e_CellExpeditionMiniMapRoom.ToString());
    }
}
