using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTown : PanelBase
{
    protected override void Start()
    {
        base.Start();

        transform.FindSonSonSon("BtnRecruit").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("BtnWineHouse").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("BtnGraveyard").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("BtnShop").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("BtnSmithy").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("BtnMercenaryaAssociation").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnRecruit":
                MgrUI.GetInstance().GetPanel<PanelRooms>("PanelRooms").StartByTown("PanelRoomRecruit");               
                break;

            case "BtnWineHouse":
                MgrUI.GetInstance().GetPanel<PanelRooms>("PanelRooms").StartByTown("PanelRoomWineHouse");              
                break;

            case "BtnGraveyard":
                MgrUI.GetInstance().GetPanel<PanelRooms>("PanelRooms").StartByTown("PanelRoomGraveyard");              
                break;

            case "BtnShop":
                MgrUI.GetInstance().GetPanel<PanelRooms>("PanelRooms").StartByTown("PanelRoomShop");
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
