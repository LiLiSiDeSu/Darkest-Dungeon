using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellExpeditionMiniMapChooseHall : PanelBase             
{
    public E_CellExpeditionMiniMapHall e_CellExpeditionMiniMapHall = E_CellExpeditionMiniMapHall.None;
    public Image ImgCellExpeditionMiniMapChooseHall;

    protected override void Awake()
    {
        base.Awake();

        ImgCellExpeditionMiniMapChooseHall = transform.FindSonSonSon("ImgCellExpeditionMiniMapChooseHall").GetComponent<Image>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellExpeditionMiniMapChooseHall":
                Hot.PanelOtherMapEditor_.ImgCurrentChooseHall.sprite = 
                    Hot.MgrRes_.Load<Sprite>("Art/CellMap" + e_CellExpeditionMiniMapHall.ToString());
                break;
        }
    }

    public void Init(E_CellExpeditionMiniMapHall e_CellExpeditionMiniMapHall)
    {
        this.e_CellExpeditionMiniMapHall = e_CellExpeditionMiniMapHall;
        ImgCellExpeditionMiniMapChooseHall.sprite = Hot.MgrRes_.Load<Sprite>("Art/CellMap" + e_CellExpeditionMiniMapHall.ToString());
    }    
}
