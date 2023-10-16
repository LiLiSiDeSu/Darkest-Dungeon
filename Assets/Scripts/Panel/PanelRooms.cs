using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelRooms : PanelBase
{
    public bool IsShow = false;

    private Transform ImgCurrentChoice;
    private float PosOffsetForImgCurrentChoice = 85f;
    private Dictionary<string, Transform> PosBtnRoom = new Dictionary<string, Transform>();

    public PanelBase CurrentPanel;
    public Dictionary<string, PanelBase> AllPanel = new Dictionary<string, PanelBase>();

    protected override void Start()
    {
        base.Start();

        ImgCurrentChoice = transform.FindSonSonSon("ImgCurrentChoice");

        Button[] temppos = transform.FindSonSonSon("BtnRoomRoot").GetComponentsInChildren<Button>();
        for (int i = 0; i < temppos.Length; i++)
        {
            PosBtnRoom.Add(temppos[i].gameObject.name, temppos[i].transform);
        }

        PanelBase[] temppanel = transform.FindSonSonSon("PanelRoomRoot").GetComponentsInChildren<PanelBase>();
        for (int i = 0; i < temppanel.Length; i++)
        {            
            AllPanel.Add(temppanel[i].gameObject.name, temppanel[i]);
            MgrUI.GetInstance().AddDicPanel(temppanel[i].gameObject.name, temppanel[i]);
        }

        HideAllRooms();

        gameObject.SetActive(false);
    }

    protected override void Button_OnClick(string Controlname)
    {
        base.Button_OnClick(Controlname);

        switch (Controlname)
        {
            case "BtnRoomRecruit":                
                HideBeforePanelAndShowNewPanel(AllPanel["PanelRoomRecruit"], "BtnRoomRecruit");                
                break;

            case "BtnRoomMercenaryaAssociation":                                
                HideBeforePanelAndShowNewPanel(AllPanel["PanelRoomMercenaryaAssociation"], "BtnRoomMercenaryaAssociation");                
                break;

            case "BtnRoomGraveyard":                                
                HideBeforePanelAndShowNewPanel(AllPanel["PanelRoomGraveyard"], "BtnRoomGraveyard");                
                break;

            case "BtnRoomShop":                               
                HideBeforePanelAndShowNewPanel(AllPanel["PanelRoomShop"], "BtnRoomShop");                
                break;

            case "BtnRoomSmithy":                                
                HideBeforePanelAndShowNewPanel(AllPanel["PanelRoomSmithy"], "BtnRoomSmithy");                
                break;

            case "BtnRoomWineHouse":                                
                HideBeforePanelAndShowNewPanel(AllPanel["PanelRoomWineHouse"], "BtnRoomWineHouse");                
                break;
        }
    }

    public void ChangeImgCurrentChoicePos(string Key)
    {        
        ImgCurrentChoice.gameObject.SetActive(true);
        ImgCurrentChoice.position = new Vector3
                         (PosBtnRoom[Key].position.x - PosOffsetForImgCurrentChoice, PosBtnRoom[Key].position.y, 0);
    }

    public void HideBeforePanelAndShowNewPanel(PanelBase NewPanel, string BtnNameToChangeImgCurrentChoicePos)
    {
        ChangeImgCurrentChoicePos(BtnNameToChangeImgCurrentChoicePos);

        if (CurrentPanel != null)
            CurrentPanel.gameObject.SetActive(false);
        
        CurrentPanel = NewPanel;
        CurrentPanel.gameObject.SetActive(true);
    }

    public void HideAllRooms()
    {
        foreach (PanelBase values in AllPanel.Values)
            values.gameObject.SetActive(false);
    }

    public void StartByTown(string RoomName)
    {        
        HideBeforePanelAndShowNewPanel(AllPanel[RoomName], RoomName.Replace("Panel", "Btn"));        
        MgrUI.GetInstance().ShowPanel<PanelRooms>(true, "PanelRooms");
    }
}
