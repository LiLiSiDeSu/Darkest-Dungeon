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

        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(), (key) =>
        {
            if (key == Hot.MgrInput_.CapsLock && Hot.NowIndexCellGameArchive != -1)
            {
                if (Hot.NowIndexCellGameArchive != -1)
                {
                    if (Hot.PoolNowPanel_.ListNowPanel.Contains("PanelOhterResTable"))
                        Hot.MgrUI_.HidePanel(false, Hot.PanelOtherResTable_.gameObject, "PanelOhterResTable");
                    else
                        Hot.MgrUI_.ShowPanel<PanelOhterResTable>(true, "PanelOhterResTable");
                }
            }
        });

        RootRes = transform.FindSonSonSon("RootRes");
        RootTranslate = transform.FindSonSonSon("RootTranslate");

        Hot.MgrUI_.CreatePanel<PanelTranslateAncestralProperty>
        (false, "/PanelTranslateAncestralProperty",
        (panel) =>
        {
            panel.transform.SetParent(RootTranslate, false);
        });
        Hot.MgrUI_.CreatePanel<PanelTranslateCoinAncestralProperty>
        (false, "/PanelTranslateCoinAncestralProperty",
        (panel) =>
        {
            panel.transform.SetParent(RootTranslate, false);
        });
        Hot.MgrUI_.CreatePanel<PanelTranslateCoinCoin>
        (false, "/PanelTranslateCoinCoin",
        (panel) =>
        {
            panel.transform.SetParent(RootTranslate, false);
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyDown.ToString(), (key) =>
        {
            if (key == Hot.MgrInput_.Add)
            {
                Hot.NowTranslateRate += Hot.AddTranslateRate;
            }
        });
        Hot.CenterEvent_.AddEventListener<KeyCode>(E_InputKeyEvent.KeyUp.ToString(), (key) =>
        {
            if (key == Hot.MgrInput_.Add)
            {
                Hot.NowTranslateRate = 1;
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
                if (Hot.DataPanelResTable.NowStoreDebris >= Hot.DataPanelResTable.LevelUpNeedStatue &&
                    Hot.DataPanelResTable.NowLevelStatue < Hot.DataPanelResTable.LevelMaxStatue)
                {
                    Hot.DataPanelResTable.NowStoreDebris -= Hot.DataPanelResTable.LevelUpNeedStatue;
                    Hot.DataPanelResTable.NowLevelStatue += 1;
                }
                break;
            case "BtnDeed":
                if (Hot.DataPanelResTable.NowStoreDebris >= Hot.DataPanelResTable.LevelUpNeedDeed &&
                    Hot.DataPanelResTable.NowLevelDeed < Hot.DataPanelResTable.LevelMaxDeed)
                {
                    Hot.DataPanelResTable.NowStoreDebris -= Hot.DataPanelResTable.LevelUpNeedDeed;
                    Hot.DataPanelResTable.NowLevelDeed += 1;
                }
                break;
            case "BtnCrystal":
                if (Hot.DataPanelResTable.NowStoreDebris >= Hot.DataPanelResTable.LevelUpNeedCrystal &&
                    Hot.DataPanelResTable.NowLevelCrystal < Hot.DataPanelResTable.LevelMaxCrystal)
                {
                    Hot.DataPanelResTable.NowStoreDebris -= Hot.DataPanelResTable.LevelUpNeedCrystal;
                    Hot.DataPanelResTable.NowLevelCrystal += 1;
                }
                break;
            case "BtnBadge":
                if (Hot.DataPanelResTable.NowStoreDebris >= Hot.DataPanelResTable.LevelUpNeedBadge &&
                    Hot.DataPanelResTable.NowLevelBadge < Hot.DataPanelResTable.LevelMaxBadge)
                {
                    Hot.DataPanelResTable.NowStoreDebris -= Hot.DataPanelResTable.LevelUpNeedBadge;
                    Hot.DataPanelResTable.NowLevelBadge += 1;
                }
                break;
            case "BtnPicture":
                if (Hot.DataPanelResTable.NowStoreDebris >= Hot.DataPanelResTable.LevelUpNeedPicture &&
                    Hot.DataPanelResTable.NowLevelPicture < Hot.DataPanelResTable.LevelMaxPicture)
                {
                    Hot.DataPanelResTable.NowStoreDebris -= Hot.DataPanelResTable.LevelUpNeedPicture;
                    Hot.DataPanelResTable.NowLevelPicture += 1;
                }
                break;
            case "BtnCopper":
                if (Hot.DataPanelResTable.NowStoreDebris >= Hot.DataPanelResTable.LevelUpNeedCopper &&
                    Hot.DataPanelResTable.NowLevelCopper < Hot.DataPanelResTable.LevelMaxCopper)
                {
                    Hot.DataPanelResTable.NowStoreDebris -= Hot.DataPanelResTable.LevelUpNeedCopper;
                    Hot.DataPanelResTable.NowLevelCopper += 1;
                }
                break;
            case "BtnSilver":
                if (Hot.DataPanelResTable.NowStoreDebris >= Hot.DataPanelResTable.LevelUpNeedSilver &&
                    Hot.DataPanelResTable.NowLevelSilver < Hot.DataPanelResTable.LevelMaxSilver)
                {
                    Hot.DataPanelResTable.NowStoreDebris -= Hot.DataPanelResTable.LevelUpNeedSilver;
                    Hot.DataPanelResTable.NowLevelSilver += 1;
                }
                break;
            case "BtnGold":
                if (Hot.DataPanelResTable.NowStoreDebris >= Hot.DataPanelResTable.LevelUpNeedGold &&
                    Hot.DataPanelResTable.NowLevelGold < Hot.DataPanelResTable.LevelMaxGold)
                {
                    Hot.DataPanelResTable.NowStoreDebris -= Hot.DataPanelResTable.LevelUpNeedGold;
                    Hot.DataPanelResTable.NowLevelGold += 1;
                }
                break;
            case "BtnPlatinum":
                if (Hot.DataPanelResTable.NowStoreDebris >= Hot.DataPanelResTable.LevelUpNeedPlatinum &&
                    Hot.DataPanelResTable.NowLevelPlatinum < Hot.DataPanelResTable.LevelMaxPlatinum)
                {
                    Hot.DataPanelResTable.NowStoreDebris -= Hot.DataPanelResTable.LevelUpNeedPlatinum;
                    Hot.DataPanelResTable.NowLevelPlatinum += 1;
                }
                break;
        }

        UpdateInfo();
    }

    public void UpdateInfo()
    {
        ClampData();

        AllText["TxtStoreDebris"].text = Hot.DataPanelResTable.NowStoreDebris.ToString();

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

    public void ClampData()
    {
        if (Hot.DataPanelResTable.NowCopper > Hot.DataPanelResTable.LevelStepCopper * Hot.DataPanelResTable.NowLevelCopper)
            Hot.DataPanelResTable.NowCopper = Hot.DataPanelResTable.LevelStepCopper * Hot.DataPanelResTable.NowLevelCopper;

        if (Hot.DataPanelResTable.NowSilver > Hot.DataPanelResTable.LevelStepSilver * Hot.DataPanelResTable.NowLevelSilver)
            Hot.DataPanelResTable.NowSilver = Hot.DataPanelResTable.LevelStepSilver * Hot.DataPanelResTable.NowLevelSilver;

        if (Hot.DataPanelResTable.NowGold > Hot.DataPanelResTable.LevelStepGold * Hot.DataPanelResTable.NowLevelGold)
            Hot.DataPanelResTable.NowGold = Hot.DataPanelResTable.LevelStepGold * Hot.DataPanelResTable.NowLevelGold;

        if (Hot.DataPanelResTable.NowPlatinum > Hot.DataPanelResTable.LevelStepPlatinum * Hot.DataPanelResTable.NowLevelPlatinum)
            Hot.DataPanelResTable.NowPlatinum = Hot.DataPanelResTable.LevelStepPlatinum * Hot.DataPanelResTable.NowLevelPlatinum;

        if (Hot.DataPanelResTable.NowStatue > Hot.DataPanelResTable.LevelStepStatue * Hot.DataPanelResTable.NowLevelStatue)
            Hot.DataPanelResTable.NowStatue = Hot.DataPanelResTable.LevelStepStatue * Hot.DataPanelResTable.NowLevelStatue;

        if (Hot.DataPanelResTable.NowDeed > Hot.DataPanelResTable.LevelStepDeed * Hot.DataPanelResTable.NowLevelDeed)
            Hot.DataPanelResTable.NowDeed = Hot.DataPanelResTable.LevelStepDeed * Hot.DataPanelResTable.NowLevelDeed;

        if (Hot.DataPanelResTable.NowPicture > Hot.DataPanelResTable.LevelStepPicture * Hot.DataPanelResTable.NowLevelPicture)
            Hot.DataPanelResTable.NowPicture = Hot.DataPanelResTable.LevelStepPicture * Hot.DataPanelResTable.NowLevelPicture;

        if (Hot.DataPanelResTable.NowBadge > Hot.DataPanelResTable.LevelStepBadge * Hot.DataPanelResTable.NowLevelBadge)
            Hot.DataPanelResTable.NowBadge = Hot.DataPanelResTable.LevelStepBadge * Hot.DataPanelResTable.NowLevelBadge;

        if (Hot.DataPanelResTable.NowCrystal > Hot.DataPanelResTable.LevelStepCrystal * Hot.DataPanelResTable.NowLevelCrystal)
            Hot.DataPanelResTable.NowCrystal = Hot.DataPanelResTable.LevelStepCrystal * Hot.DataPanelResTable.NowLevelCrystal;
    }

    public void Reduce(InfoContainer_Cost cost)
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
