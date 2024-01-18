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
                if (Hot.NowExpeditionEvent == null)
                {
                    Hot.NowExpeditionEvent = this;
                    Hot.NowExpeditionEvent.ImgCurrentChoose.gameObject.SetActive(true);
                    Hot.PanelExpeditionDetails_.UpdateInfo(Hot.DataNowCellGameArchive.GetDataNowEvent(Hot.NowExpeditionEvent.e_ExpeditionLocation, Hot.NowExpeditionEvent.Index));
                    return;
                }
                if (Hot.NowExpeditionEvent == this)
                {
                    Hot.NowExpeditionEvent.ImgCurrentChoose.gameObject.SetActive(false);
                    Hot.NowExpeditionEvent = null;
                    Hot.PanelExpeditionDetails_.Clear();
                    return;
                }
                if (Hot.NowExpeditionEvent != this)
                {
                    Hot.NowExpeditionEvent.ImgCurrentChoose.gameObject.SetActive(false);
                    Hot.NowExpeditionEvent = this;
                    Hot.NowExpeditionEvent.ImgCurrentChoose.gameObject.SetActive(true);
                    Hot.PanelExpeditionDetails_.UpdateInfo(Hot.DataNowCellGameArchive.GetDataNowEvent(Hot.NowExpeditionEvent.e_ExpeditionLocation, Hot.NowExpeditionEvent.Index));
                    return;
                }
                break;
        }
    }

    public void Init(int index, E_ExpeditionLocation e_expeditionLocation)
    {
        Index = index;
        e_ExpeditionLocation = e_expeditionLocation;

        DataContainer_ExpeditionMiniMap data = Hot.DataNowCellGameArchive.ExpeditionPrepare[e_expeditionLocation][index];

        ImgBorderExpeditionEvent.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "BorderExpedition" + data.e_dungeonSize + "Level" + data.e_dungeonLevel);
        ImgExpeditionEvent.sprite = Hot.MgrRes_.Load<Sprite>("Art/ExpeditionEvent" + data.e_ExpeditionEvent);
    }
}
