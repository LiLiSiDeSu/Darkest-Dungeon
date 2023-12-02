using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTranslateCoinCoin : PanelBase
{
    public Image ImgCopperSilver;
    public Image ImgSilverCopper;
    public Image ImgSilverGold;
    public Image ImgGoldSilver;
    public Image ImgGoldPlatinum;
    public Image ImgPlatinumGold;    

    protected override void Awake()
    {
        base.Awake();

        ImgCopperSilver = transform.FindSonSonSon("ImgCopperSilver").GetComponent<Image>();
        ImgSilverCopper = transform.FindSonSonSon("ImgSilverCopper").GetComponent<Image>();
        ImgSilverGold = transform.FindSonSonSon("ImgSilverGold").GetComponent<Image>();
        ImgGoldSilver = transform.FindSonSonSon("ImgGoldSilver").GetComponent<Image>();
        ImgGoldPlatinum = transform.FindSonSonSon("ImgGoldPlatinum").GetComponent<Image>();
        ImgPlatinumGold = transform.FindSonSonSon("ImgPlatinumGold").GetComponent<Image>();

        ImgCopperSilver.alphaHitTestMinimumThreshold = 0.2f;
        ImgSilverCopper.alphaHitTestMinimumThreshold = 0.2f;
        ImgSilverGold.alphaHitTestMinimumThreshold = 0.2f;
        ImgGoldSilver.alphaHitTestMinimumThreshold = 0.2f;
        ImgGoldPlatinum.alphaHitTestMinimumThreshold = 0.2f;
        ImgPlatinumGold.alphaHitTestMinimumThreshold = 0.2f;
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCopperSilver":
                if (Hot.DataPanelResTable.NowSilver >= Hot.NowTranslateRate)
                {
                    Hot.DataPanelResTable.NowSilver -= Hot.NowTranslateRate;
                    Hot.DataPanelResTable.NowCopper += Hot.DataPanelResTable.RateCopperToSilver * Hot.NowTranslateRate;
                }
                break;
            case "BtnSilverCopper":
                if (Hot.DataPanelResTable.NowCopper >= Hot.DataPanelResTable.RateCopperToSilver * Hot.NowTranslateRate)
                {
                    Hot.DataPanelResTable.NowSilver += Hot.NowTranslateRate;
                    Hot.DataPanelResTable.NowCopper -= Hot.DataPanelResTable.RateCopperToSilver * Hot.NowTranslateRate;
                }                
                break;
            case "BtnSilverGold":
                if (Hot.DataPanelResTable.NowGold >= Hot.NowTranslateRate)
                {
                    Hot.DataPanelResTable.NowGold -= Hot.NowTranslateRate;
                    Hot.DataPanelResTable.NowSilver += Hot.DataPanelResTable.RateSilverToGold * Hot.NowTranslateRate;
                }
                break;
            case "BtnGoldSilver":
                if (Hot.DataPanelResTable.NowSilver >= Hot.DataPanelResTable.RateSilverToGold * Hot.NowTranslateRate)
                {
                    Hot.DataPanelResTable.NowGold += Hot.NowTranslateRate;
                    Hot.DataPanelResTable.NowSilver -= Hot.DataPanelResTable.RateSilverToGold * Hot.NowTranslateRate;
                }
                break;
            case "BtnGoldPlatinum":
                if (Hot.DataPanelResTable.NowPlatinum >= Hot.NowTranslateRate)
                {
                    Hot.DataPanelResTable.NowPlatinum -= Hot.NowTranslateRate;
                    Hot.DataPanelResTable.NowGold += Hot.DataPanelResTable.RateGoldToPlatinum * Hot.NowTranslateRate;
                }
                break;
            case "BtnPlatinumGold":
                if (Hot.DataPanelResTable.NowGold >= Hot.DataPanelResTable.RateGoldToPlatinum * Hot.NowTranslateRate)
                {
                    Hot.DataPanelResTable.NowPlatinum += Hot.NowTranslateRate;
                    Hot.DataPanelResTable.NowGold -= Hot.DataPanelResTable.RateGoldToPlatinum * Hot.NowTranslateRate;
                }
                break;
        }

        Hot.PanelOtherResTable_.UpdateInfo();        
    }
}
