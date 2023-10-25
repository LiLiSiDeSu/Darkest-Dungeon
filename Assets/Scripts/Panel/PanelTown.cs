using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTown : PanelBase
{
    protected override void Start()
    {
        base.Start();
        
        transform.FindSonSonSon("ImgWineHouse").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgGraveyard").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgTownShop").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgSmithy").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgMercenaryaAssociation").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;        
    }  

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnWineHouse":
                MgrUI.GetInstance().GetPanel<PanelRooms>("PanelRooms").StartByTown("PanelRoomWineHouse");              
                break;
            case "BtnGraveyard":
                MgrUI.GetInstance().GetPanel<PanelRooms>("PanelRooms").StartByTown("PanelRoomGraveyard");              
                break;
            case "BtnTownShop":
                MgrUI.GetInstance().GetPanel<PanelRooms>("PanelRooms").StartByTown("PanelRoomTownShop");
                break;
            case "BtnSmithy":
                MgrUI.GetInstance().GetPanel<PanelRooms>("PanelRooms").StartByTown("PanelRoomSmithy");              
                break;
            case "BtnMercenaryaAssociation":
                MgrUI.GetInstance().GetPanel<PanelRooms>("PanelRooms").StartByTown("PanelRoomMercenaryaAssociation");           
                break;
        }
    }   
}
