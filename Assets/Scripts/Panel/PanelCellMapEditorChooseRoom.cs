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
                Hot.PanelOtherMapEditor_.ImgCurrentChoose.sprite =
                    Hot.MgrRes_.Load<Sprite>("Art/CellMapRoom" + e_CellExpeditionMiniMapRoom.ToString());
                Hot.PanelOtherMapEditor_.ImgCurrentChoose.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 60);

                Hot.e_NowChooseRoom = e_CellExpeditionMiniMapRoom;
                Hot.e_NowChooseHall = E_CellExpeditionMiniMapHall.None;
                break;
        }
    }

    public void Init(E_CellExpeditionMiniMapRoom e_CellExpeditionMiniMapRoom)
    {        
        this.e_CellExpeditionMiniMapRoom = e_CellExpeditionMiniMapRoom;
        ImgCellMapEditorChooseRoom.sprite = Hot.MgrRes_.Load<Sprite>("Art/CellMapRoom" + e_CellExpeditionMiniMapRoom.ToString());
    }
}
