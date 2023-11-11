using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelExpeditionPrePare : PanelBase
{    
    public Transform BloodCourtyardContent;
    public Transform LairContent;
    public Transform FarmContent;
    public Transform WildsContent;
    public Transform RuinsContent;
    public Transform SeaContent;
    public Transform DarkestContent;    

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener("Esc" + "PanelExpeditionPrePare",
        () =>
        {
            Hot.e_NowPlayerLocation = E_PlayerLocation.Town;
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
        for (int i = 0; i < Hot.DataNowCellGameArchive.Expedition.Lair.Count; i++)
        {
            int tempi = i;

            Hot.MgrUI_.CreatePanel<PanelCellExpeditionEvent>(false, "/PanelCellExpeditionEvent",
            (panel) =>
            {
                panel.Init(tempi, E_ExpeditionLocation.Lair);
                panel.transform.SetParent(LairContent, false);
            });
        }
        for (int i = 0; i < Hot.DataNowCellGameArchive.Expedition.Wilds.Count; i++)
        {
            int tempi = i;

            Hot.MgrUI_.CreatePanel<PanelCellExpeditionEvent>(false, "/PanelCellExpeditionEvent",
            (panel) =>
            {
                panel.Init(tempi, E_ExpeditionLocation.Wilds);
                panel.transform.SetParent(WildsContent, false);
            });
        }
        for (int i = 0; i < Hot.DataNowCellGameArchive.Expedition.Darkest.Count; i++)
        {
            int tempi = i;

            Hot.MgrUI_.CreatePanel<PanelCellExpeditionEvent>(false, "/PanelCellExpeditionEvent",
            (panel) =>
            {
                panel.Init(tempi, E_ExpeditionLocation.Darkest);
                panel.transform.SetParent(DarkestContent, false);
            });
        }
        for (int i = 0; i < Hot.DataNowCellGameArchive.Expedition.Ruins.Count; i++)
        {
            int tempi = i;

            Hot.MgrUI_.CreatePanel<PanelCellExpeditionEvent>(false, "/PanelCellExpeditionEvent",
            (panel) =>
            {
                panel.Init(tempi, E_ExpeditionLocation.Ruins);
                panel.transform.SetParent(RuinsContent, false);
            });
        }
        for (int i = 0; i < Hot.DataNowCellGameArchive.Expedition.Sea.Count; i++)
        {
            int tempi = i;

            Hot.MgrUI_.CreatePanel<PanelCellExpeditionEvent>(false, "/PanelCellExpeditionEvent",
            (panel) =>
            {
                panel.Init(tempi, E_ExpeditionLocation.Sed);
                panel.transform.SetParent(SeaContent, false);
            });
        }
        for (int i = 0; i < Hot.DataNowCellGameArchive.Expedition.Farm.Count; i++)
        {
            int tempi = i;

            Hot.MgrUI_.CreatePanel<PanelCellExpeditionEvent>(false, "/PanelCellExpeditionEvent",
            (panel) =>
            {
                panel.Init(tempi, E_ExpeditionLocation.Farm);
                panel.transform.SetParent(FarmContent, false);
            });
        }
        for (int i = 0; i < Hot.DataNowCellGameArchive.Expedition.BloodCourtyard.Count; i++)
        {
            int tempi = i;

            Hot.MgrUI_.CreatePanel<PanelCellExpeditionEvent>(false, "/PanelCellExpeditionEvent",
            (panel) =>
            {
                panel.Init(tempi, E_ExpeditionLocation.BloodCourtyard);
                panel.transform.SetParent(BloodCourtyardContent, false);
            });
        }
    }
}
