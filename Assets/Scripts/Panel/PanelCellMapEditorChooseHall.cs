using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellMapEditorChooseHall : PanelBase             
{
    public E_CellExpeditionMiniMapHall e_CellExpeditionMiniMapHall = E_CellExpeditionMiniMapHall.None;
    public Image ImgCellMapEditorChooseHall;

    protected override void Awake()
    {
        base.Awake();

        ImgCellMapEditorChooseHall = transform.FindSonSonSon("ImgCellMapEditorChooseHall").GetComponent<Image>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellMapEditorChooseHall":
                Hot.PanelOtherMapEditor_.ImgCurrentChooseHall.sprite = 
                    Hot.MgrRes_.Load<Sprite>("Art/CellMap" + e_CellExpeditionMiniMapHall.ToString());
                Hot.e_NowChooseHall = e_CellExpeditionMiniMapHall;               
                break;
        }
    }

    public void Init(E_CellExpeditionMiniMapHall e_CellExpeditionMiniMapHall)
    {
        this.e_CellExpeditionMiniMapHall = e_CellExpeditionMiniMapHall;
        ImgCellMapEditorChooseHall.sprite = Hot.MgrRes_.Load<Sprite>("Art/CellMap" + e_CellExpeditionMiniMapHall.ToString());
    }    
}
