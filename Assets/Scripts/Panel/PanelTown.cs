using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTown : PanelBase
{
    protected override void Start()
    {
        base.Start();

        transform.FindSonSonSon("ImgAbbey").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgSanitarium").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgSurvivorMaster").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgTavern").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgGraveyard").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgTownShop").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgSmithy").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgGuild").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;        
    }  

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnAbbey":
                Debug.Log("Abbey");
                break;
            case "BtnSanitarium":
                Debug.Log("Sanitarium");
                break;
            case "BtnSurvivorMaster":
                Debug.Log("SurvivorMaster");
                break;
            case "BtnTavern":
                MgrUI.GetInstance().GetPanel<PanelRooms>("PanelRooms").StartByTown("PanelRoomTavern");              
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
            case "BtnGuild":
                MgrUI.GetInstance().GetPanel<PanelRooms>("PanelRooms").StartByTown("PanelRoomGuild");           
                break;
        }
    }   
}
