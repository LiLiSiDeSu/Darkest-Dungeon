using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCellExpeditionEvent : PanelBaseCell
{
    public E_ExpeditionLocation e_ExpeditionLocation;

    public Image ImgBorderExpeditionEvent;
    public Image ImgExpeditionEvent;
    public Image ImgCurrentChoose;    

    protected override void Awake()
    {
        base.Awake();

        ImgBorderExpeditionEvent = transform.FindSonSonSon("ImgBorderExpeditionEvent").GetComponent<Image>();
        ImgExpeditionEvent = transform.FindSonSonSon("ImgExpeditionEvent").GetComponent<Image>();
        ImgCurrentChoose = transform.FindSonSonSon("ImgCurrentChoose").GetComponent<Image>();

        ImgCurrentChoose.gameObject.SetActive(false);
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnExpeditionEvent":               
                if (Hot.ChoseExpeditionEvent == this)
                {
                    ImgCurrentChoose.gameObject.SetActive(false);
                    Hot.ChoseExpeditionEvent = null;
                    Hot.PanelExpeditionDetails_.Clear();
                    return;
                }
                
                if (Hot.ChoseExpeditionEvent == null)
                {
                    Hot.ChoseExpeditionEvent = this;
                }
                if (Hot.ChoseExpeditionEvent != this)
                {
                    Hot.ChoseExpeditionEvent.ImgCurrentChoose.gameObject.SetActive(false);
                    Hot.ChoseExpeditionEvent = this;
                }                
                ImgCurrentChoose.gameObject.SetActive(true);

                Hot.PanelExpeditionDetails_.UpdateInfo(Hot.DataNowCellGameArchive.ExpeditionPrepare[e_ExpeditionLocation][Index]);

                Debug.Log(Hot.DataNowCellGameArchive.ExpeditionPrepare[e_ExpeditionLocation][Index].e_dungeonSize + " - " +
                          Hot.DataNowCellGameArchive.ExpeditionPrepare[e_ExpeditionLocation][Index].e_dungeonLevel + " - " +
                          Hot.DataNowCellGameArchive.ExpeditionPrepare[e_ExpeditionLocation][Index].e_ExpeditionEvent);                
                break;
        }
    }

    public void Init(int index, E_ExpeditionLocation e_expeditionLocation)
    {
        Index = index;
        e_ExpeditionLocation = e_expeditionLocation;

        ImgBorderExpeditionEvent.sprite =
                    Hot.MgrRes_.Load<Sprite>
                    ("Art/" + "BorderExpedition" + Hot.DataNowCellGameArchive.ExpeditionPrepare[e_ExpeditionLocation][Index].e_dungeonSize +
                    "Level" + Hot.DataNowCellGameArchive.ExpeditionPrepare[e_ExpeditionLocation][Index].e_dungeonLevel);

        ImgExpeditionEvent.sprite =
                    Hot.MgrRes_.Load<Sprite>
                    ("Art/ExpeditionEvent" + Hot.DataNowCellGameArchive.ExpeditionPrepare[e_ExpeditionLocation][Index].e_ExpeditionEvent);
    }
}
