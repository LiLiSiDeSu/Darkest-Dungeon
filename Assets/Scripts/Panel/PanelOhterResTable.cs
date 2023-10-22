using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOhterResTable : PanelBase
{
    private Dictionary<string, Text> AllText = new Dictionary<string, Text>();
    private Transform RootRes;

    protected override void Awake()
    {
        base.Awake();

        RootRes = transform.FindSonSonSon("RootRes");

        Hot.CenterEvent_.AddEventListener<KeyCode>("CertainKeyDown", (key) =>
        {
            if (key == Hot.MgrInput_.PanelResTable)
            {
                if (Hot.NowIndexCellGameArchive != -1)
                {
                    if (Hot.NowIndexCellGameArchive != -1)
                    {
                        if (Hot.PoolNowPanel_.ListNowPanel.Contains("PanelOhterResTable"))
                        {
                            Hot.MgrUI_.HidePanel
                                (false, Hot.PanelOtherResTable_.gameObject, "PanelOhterResTable");                            
                        }
                        Hot.MgrUI_.ShowPanel<PanelOhterResTable>(true, "PanelOhterResTable");
                    }
                }
            }
        });

        Text[] texts = RootRes.GetComponentsInChildren<Text>();
        for (int i = 0; i < texts.Length; i++)
        {
            AllText.Add(texts[i].gameObject.name, texts[i]);
        }
        Image[] images = RootRes.GetComponentsInChildren<Image>();
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

    public void Subtraction(InfoContainer_Cost cost)
    {        
        Hot.DataPanelResTable_.NowCopper -= cost.Copper;
        Hot.DataPanelResTable_.NowSilver -= cost.Silver;
        Hot.DataPanelResTable_.NowGold -= cost.Gold;
        Hot.DataPanelResTable_.NowPlatinum -= cost.Platinum;

        Hot.DataPanelResTable_.NowStatue -= cost.Statue;
        Hot.DataPanelResTable_.NowDeed -= cost.Deed;
        Hot.DataPanelResTable_.NowPicture -= cost.Picture;
        Hot.DataPanelResTable_.NowBadge -= cost.Badge;
        Hot.DataPanelResTable_.NowCrystal -= cost.Crystal;

        UpdateInfo();
    }

    public void Add(InfoContainer_Cost cost)
    {
        Hot.DataPanelResTable_.NowCopper += cost.Copper;
        Hot.DataPanelResTable_.NowSilver += cost.Silver;
        Hot.DataPanelResTable_.NowGold += cost.Gold;
        Hot.DataPanelResTable_.NowPlatinum += cost.Platinum;

        Hot.DataPanelResTable_.NowStatue += cost.Statue;
        Hot.DataPanelResTable_.NowDeed += cost.Deed;
        Hot.DataPanelResTable_.NowPicture += cost.Picture;
        Hot.DataPanelResTable_.NowBadge += cost.Badge;
        Hot.DataPanelResTable_.NowCrystal += cost.Crystal;

        UpdateInfo();
    }
}
