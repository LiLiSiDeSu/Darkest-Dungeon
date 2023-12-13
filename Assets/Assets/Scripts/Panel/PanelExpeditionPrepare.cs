using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PanelExpeditionPrepare : PanelBase
{    
    public Transform BloodCourtyardContent;
    public Transform LairContent;
    public Transform FarmContent;
    public Transform WildsContent;
    public Transform RuinsContent;
    public Transform SeaContent;
    public Transform DarkestContent;

    public Transform this[E_ExpeditionLocation e_ExpeditionLocation]
    {
        get
        {
            switch (e_ExpeditionLocation)
            {                
                case E_ExpeditionLocation.BloodCourtyard:
                    return BloodCourtyardContent;                    
                case E_ExpeditionLocation.Lair:
                    return LairContent;
                case E_ExpeditionLocation.Farm:
                    return FarmContent;
                case E_ExpeditionLocation.Wilds:
                    return WildsContent;
                case E_ExpeditionLocation.Ruins:
                    return RuinsContent;
                case E_ExpeditionLocation.Darkest:
                    return DarkestContent;
                case E_ExpeditionLocation.Sea:
                    return SeaContent;
            }
            return null;
        }
    }

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener("Esc" + "PanelExpeditionPrepare",
        () =>
        {
            Hot.e_NowPlayerLocation = E_PlayerLocation.Town;
        });

        Hot.MgrUI_.CreatePanel<PanelExpeditionDetails>(true, "/PanelExpeditionDetails",
        (panel) =>
        {
            panel.transform.SetParent(transform, false);
        });

        BloodCourtyardContent = transform.FindSonSonSon("BloodCourtyardContent");
        LairContent = transform.FindSonSonSon("LairContent");
        FarmContent = transform.FindSonSonSon("FarmContent");
        WildsContent = transform.FindSonSonSon("WildsContent");
        RuinsContent = transform.FindSonSonSon("RuinsContent");
        SeaContent = transform.FindSonSonSon("SeaContent");
        DarkestContent = transform.FindSonSonSon("DarkestContent");
    }

    public void InitContent()
    {        
        Refresh();

        foreach (E_ExpeditionLocation e_ExpeditionLocation in Enum.GetValues(typeof(E_ExpeditionLocation)))
        {
            if (e_ExpeditionLocation != E_ExpeditionLocation.Town)
            {
                for (int i = 0; i < Hot.DataNowCellGameArchive.ExpeditionPrepare[e_ExpeditionLocation].Count; i++)
                {
                    int tempi = i;

                    Hot.MgrUI_.CreatePanel<PanelCellExpeditionEvent>(false, "/PanelCellExpeditionEvent",
                    (panel) =>
                    {
                        panel.transform.SetParent(this[e_ExpeditionLocation], false);
                        panel.Init(tempi, e_ExpeditionLocation);
                    });
                }
            }         
        }        
    }

    public void Clear()
    {
        foreach (PanelCellExpeditionEvent item in transform.GetComponentsInChildren<PanelCellExpeditionEvent>())
        {
            Destroy(item.gameObject);
        }
    }

    public void Refresh()
    {
        Hot.DataNowCellGameArchive.ExpeditionPrepare.Darkest.
            Add(Hot.MgrJson_.Load<DataContainer_ExpeditionMiniMap>(Hot.PanelOtherMiniMapEditor_.PathFolder + "/Default", "/Map0"));
        Hot.DataNowCellGameArchive.ExpeditionPrepare.Darkest.
            Add(Hot.MgrJson_.Load<DataContainer_ExpeditionMiniMap>(Hot.PanelOtherMiniMapEditor_.PathFolder + "/Default", "/Map1"));
    }
}
