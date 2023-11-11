using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCellExpeditionEvent : PanelBaseCell
{
    public E_ExpeditionLocation e_ExpeditionLocation;
    public Image ImgBorderExpeditionEvent;
    public Image ImgExpeditionEvent;

    protected override void Awake()
    {
        base.Awake();

        ImgBorderExpeditionEvent = transform.FindSonSonSon("ImgBorderExpeditionEvent").GetComponent<Image>();
        ImgExpeditionEvent = transform.FindSonSonSon("ImgExpeditionEvent").GetComponent<Image>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnExpeditionEvent":
                Debug.Log(Hot.DataNowCellGameArchive.Expedition[e_ExpeditionLocation][Index].e_dungeonSize + " - " +
                          Hot.DataNowCellGameArchive.Expedition[e_ExpeditionLocation][Index].e_dungeonLevel + " - " +
                          Hot.DataNowCellGameArchive.Expedition[e_ExpeditionLocation][Index].e_ExpeditionEvent);                
                break;
        }
    }

    public void Init(int index, E_ExpeditionLocation e_expeditionLocation)
    {
        Index = index;
        e_ExpeditionLocation = e_expeditionLocation;

        ImgBorderExpeditionEvent.sprite =
                    Hot.MgrRes_.Load<Sprite>
                    ("Art/" + "BorderExpedition" + Hot.DataNowCellGameArchive.Expedition[e_ExpeditionLocation][Index].e_dungeonSize +
                    "Level" + Hot.DataNowCellGameArchive.Expedition[e_ExpeditionLocation][Index].e_dungeonLevel);

        ImgExpeditionEvent.sprite =
                    Hot.MgrRes_.Load<Sprite>
                    ("Art/ExpeditionEvent" + Hot.DataNowCellGameArchive.Expedition[e_ExpeditionLocation][Index].e_ExpeditionEvent);
    }
}
