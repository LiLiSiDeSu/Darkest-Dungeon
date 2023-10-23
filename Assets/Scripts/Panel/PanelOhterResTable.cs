using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOhterResTable : PanelBase
{
    private Dictionary<string, Text> AllText = new Dictionary<string, Text>();
    private Transform RootRes;
    private Transform RootTranslate;

    protected override void Awake()
    {
        base.Awake();

        RootRes = transform.FindSonSonSon("RootRes");
        RootTranslate = transform.FindSonSonSon("RootTranslate");

        Hot.MgrUI_.CreatePanelAndShow<PanelTranslateAncestralProperty>(true, "/PanelTranslateAncestralProperty", 
        callback : (panel) =>
        {
            panel.transform.SetParent(RootTranslate, false);                        
        });
        Hot.MgrUI_.CreatePanelAndShow<PanelTranslateCoinAncestralProperty>(true, "/PanelTranslateCoinAncestralProperty",
        callback: (panel) =>
        {
            panel.transform.SetParent(RootTranslate, false);
        });
        Hot.MgrUI_.CreatePanelAndShow<PanelTranslateCoinCoin>(true, "/PanelTranslateCoinCoin",
        callback: (panel) =>
        {
            panel.transform.SetParent(RootTranslate, false);
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("CertainKeyDown", (key) =>
        {
            if (key == Hot.MgrInput_.UpAdd)
            {
                Hot.TranslateNum += Hot.AddTranslateNum;                
            }
        });
        Hot.CenterEvent_.AddEventListener<KeyCode>("CertainKeyUp", (key) =>
        {
            if (key == Hot.MgrInput_.UpAdd)
            {
                Hot.TranslateNum = 1;                
            }
        });

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
        AllText["TxtStoreDebris"].text = Hot.DataPanelResTable.StoreDebris.ToString();

        AllText["TxtStatue"].text =
            Hot.DataPanelResTable.NowStatue + " / " +
            Hot.DataPanelResTable.NowLevelStatue * Hot.DataPanelResTable.LevelStepStatue + " - " +
            Hot.DataPanelResTable.NowLevelStatue;
        AllText["TxtDeed"].text =
            Hot.DataPanelResTable.NowDeed + " / " +
            Hot.DataPanelResTable.NowLevelDeed * Hot.DataPanelResTable.LevelStepDeed + " - " +
            Hot.DataPanelResTable.NowLevelDeed;
        AllText["TxtBadge"].text =
            Hot.DataPanelResTable.NowBadge + " / " +
            Hot.DataPanelResTable.NowLevelBadge * Hot.DataPanelResTable.LevelStepBadge + " - " +
            Hot.DataPanelResTable.NowLevelBadge;
        AllText["TxtPicture"].text =
            Hot.DataPanelResTable.NowPicture + " / " +
            Hot.DataPanelResTable.NowLevelPicture * Hot.DataPanelResTable.LevelStepPicture + " - " +
            Hot.DataPanelResTable.NowLevelPicture;
        AllText["TxtCrystal"].text =
            Hot.DataPanelResTable.NowCrystal + " / " +
            Hot.DataPanelResTable.NowLevelCrystal * Hot.DataPanelResTable.LevelStepCrystal + " - " +
            Hot.DataPanelResTable.NowLevelCrystal;

        AllText["TxtCopper"].text =
            Hot.DataPanelResTable.NowCopper + " / " +
            Hot.DataPanelResTable.NowLevelCopper * Hot.DataPanelResTable.LevelStepCopper + " - " +
            Hot.DataPanelResTable.NowLevelCopper;
        AllText["TxtSilver"].text =
            Hot.DataPanelResTable.NowSilver + " / " +
            Hot.DataPanelResTable.NowLevelSilver * Hot.DataPanelResTable.LevelStepSilver + " - " +
            Hot.DataPanelResTable.NowLevelSilver;
        AllText["TxtGold"].text =
            Hot.DataPanelResTable.NowGold + " / " +
            Hot.DataPanelResTable.NowLevelGold * Hot.DataPanelResTable.LevelStepGold + " - " +
            Hot.DataPanelResTable.NowLevelGold;
        AllText["TxtPlatinum"].text =
            Hot.DataPanelResTable.NowPlatinum + " / " +
            Hot.DataPanelResTable.NowLevelPlatinum * Hot.DataPanelResTable.LevelStepPlatinum + " - " +
            Hot.DataPanelResTable.NowLevelPlatinum;
    }

    public void Subtraction(InfoContainer_Cost cost)
    {        
        Hot.DataPanelResTable.NowCopper -= cost.Copper;
        Hot.DataPanelResTable.NowSilver -= cost.Silver;
        Hot.DataPanelResTable.NowGold -= cost.Gold;
        Hot.DataPanelResTable.NowPlatinum -= cost.Platinum;

        Hot.DataPanelResTable.NowStatue -= cost.Statue;
        Hot.DataPanelResTable.NowDeed -= cost.Deed;
        Hot.DataPanelResTable.NowPicture -= cost.Picture;
        Hot.DataPanelResTable.NowBadge -= cost.Badge;
        Hot.DataPanelResTable.NowCrystal -= cost.Crystal;

        UpdateInfo();
    }

    public void Add(InfoContainer_Cost cost)
    {
        Hot.DataPanelResTable.NowCopper += cost.Copper;
        Hot.DataPanelResTable.NowSilver += cost.Silver;
        Hot.DataPanelResTable.NowGold += cost.Gold;
        Hot.DataPanelResTable.NowPlatinum += cost.Platinum;

        Hot.DataPanelResTable.NowStatue += cost.Statue;
        Hot.DataPanelResTable.NowDeed += cost.Deed;
        Hot.DataPanelResTable.NowPicture += cost.Picture;
        Hot.DataPanelResTable.NowBadge += cost.Badge;
        Hot.DataPanelResTable.NowCrystal += cost.Crystal;

        UpdateInfo();
    }
}
