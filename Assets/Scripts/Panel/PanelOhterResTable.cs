using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOhterResTable : PanelBase
{
    private Dictionary<string, Text> AllText = new Dictionary<string, Text>();

    protected override void Awake()
    {
        base.Awake();

        CenterEvent.GetInstance().AddEventListener<KeyCode>("CertainKeyDown", (key) =>
        {
            if (key == MgrInput.GetInstance().PanelResTable)
            {
                if (Hot.NowIndexCellGameArchive != -1)
                {
                    if (Hot.NowIndexCellGameArchive != -1)
                    {
                        if (PoolNowPanel.GetInstance().ListNowPanel.Contains("PanelOhterResTable"))
                        {
                            Hot.MgrUI_.HidePanel
                                (false, Hot.MgrUI_.GetPanel<PanelOhterResTable>("PanelOhterResTable").gameObject, "PanelOhterResTable");                            
                        }
                        Hot.MgrUI_.ShowPanel<PanelOhterResTable>(true, "PanelOhterResTable");
                    }
                }
            }
        });

        Text[] texts = GetComponentsInChildren<Text>();
        for (int i = 0; i < texts.Length; i++)
        {
            AllText.Add(texts[i].gameObject.name, texts[i]);
        }
        Image[] images = GetComponentsInChildren<Image>();
        for (int i = 0; i < images.Length; i++)
        {
            images[i].alphaHitTestMinimumThreshold = 0.2f;
        }
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnStatue":
                break;
            case "BtnDeed":
                break;
            case "BtnCrystal":
                break;
            case "BtnBadge":
                break;
            case "BtnPicture":
                break;
            case "BtnCopper":
                break;
            case "BtnSilver":
                break;
            case "BtnGold":
                break;
            case "BtnPlatinum":
                break;
        }
    }
    
    public void UpdateInfo()
    {
        AllText["TxtStoreDebris"].text = Hot.DataPanelResTable_.StoreDebris.ToString();

        AllText["TxtStatue"].text =
            Hot.DataPanelResTable_.NowStatue + " / " +
            Hot.DataPanelResTable_.NowLevelStatue * Hot.DataPanelResTable_.LevelStepStatue + " - " +
            Hot.DataPanelResTable_.NowLevelStatue;
        AllText["TxtDeed"].text =
            Hot.DataPanelResTable_.NowDeed + " / " +
            Hot.DataPanelResTable_.NowLevelDeed * Hot.DataPanelResTable_.LevelStepDeed + " - " +
            Hot.DataPanelResTable_.NowLevelDeed;
        AllText["TxtBadge"].text =
            Hot.DataPanelResTable_.NowBadge + " / " +
            Hot.DataPanelResTable_.NowLevelBadge * Hot.DataPanelResTable_.LevelStepBadge + " - " +
            Hot.DataPanelResTable_.NowLevelBadge;
        AllText["TxtPicture"].text =
            Hot.DataPanelResTable_.NowPicture + " / " +
            Hot.DataPanelResTable_.NowLevelPicture * Hot.DataPanelResTable_.LevelStepPicture + " - " +
            Hot.DataPanelResTable_.NowLevelPicture;
        AllText["TxtCrystal"].text =
            Hot.DataPanelResTable_.NowCrystal + " / " +
            Hot.DataPanelResTable_.NowLevelCrystal * Hot.DataPanelResTable_.LevelStepCrystal + " - " +
            Hot.DataPanelResTable_.NowLevelCrystal;

        AllText["TxtCopper"].text =
            Hot.DataPanelResTable_.NowCopper + " / " +
            Hot.DataPanelResTable_.NowLevelCopper * Hot.DataPanelResTable_.LevelStepCopper + " - " +
            Hot.DataPanelResTable_.NowLevelCopper;
        AllText["TxtSilver"].text =
            Hot.DataPanelResTable_.NowSilver + " / " +
            Hot.DataPanelResTable_.NowLevelSilver * Hot.DataPanelResTable_.LevelStepSilver + " - " +
            Hot.DataPanelResTable_.NowLevelSilver;
        AllText["TxtGold"].text =
            Hot.DataPanelResTable_.NowGold + " / " +
            Hot.DataPanelResTable_.NowLevelGold * Hot.DataPanelResTable_.LevelStepGold + " - " +
            Hot.DataPanelResTable_.NowLevelGold;
        AllText["TxtPlatinum"].text =
            Hot.DataPanelResTable_.NowPlatinum + " / " +
            Hot.DataPanelResTable_.NowLevelPlatinum * Hot.DataPanelResTable_.LevelStepPlatinum + " - " +
            Hot.DataPanelResTable_.NowLevelPlatinum;
    }
}
