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
                if (Hot.DataPanelResTable.NowSilver >= Hot.TranslateNum)
                {
                    Hot.DataPanelResTable.NowSilver -= Hot.TranslateNum;
                    Hot.DataPanelResTable.NowCopper += Hot.DataPanelResTable.RateCopperToSilver * Hot.TranslateNum;
                }
                break;
            case "BtnSilverCopper":
                if (Hot.DataPanelResTable.NowCopper >= Hot.DataPanelResTable.RateCopperToSilver * Hot.TranslateNum)
                {
                    Hot.DataPanelResTable.NowSilver += Hot.TranslateNum;
                    Hot.DataPanelResTable.NowCopper -= Hot.DataPanelResTable.RateCopperToSilver * Hot.TranslateNum;
                }                
                break;
            case "BtnSilverGold":
                if (Hot.DataPanelResTable.NowGold >= Hot.TranslateNum)
                {
                    Hot.DataPanelResTable.NowGold -= Hot.TranslateNum;
                    Hot.DataPanelResTable.NowSilver += Hot.DataPanelResTable.RateSilverToGold * Hot.TranslateNum;
                }
                break;
            case "BtnGoldSilver":
                if (Hot.DataPanelResTable.NowSilver >= Hot.DataPanelResTable.RateSilverToGold * Hot.TranslateNum)
                {
                    Hot.DataPanelResTable.NowGold += Hot.TranslateNum;
                    Hot.DataPanelResTable.NowSilver -= Hot.DataPanelResTable.RateSilverToGold * Hot.TranslateNum;
                }
                break;
            case "BtnGoldPlatinum":
                if (Hot.DataPanelResTable.NowPlatinum >= Hot.TranslateNum)
                {
                    Hot.DataPanelResTable.NowPlatinum -= Hot.TranslateNum;
                    Hot.DataPanelResTable.NowGold += Hot.DataPanelResTable.RateGoldToPlatinum * Hot.TranslateNum;
                }
                break;
            case "BtnPlatinumGold":
                if (Hot.DataPanelResTable.NowGold >= Hot.DataPanelResTable.RateGoldToPlatinum * Hot.TranslateNum)
                {
                    Hot.DataPanelResTable.NowPlatinum += Hot.TranslateNum;
                    Hot.DataPanelResTable.NowGold -= Hot.DataPanelResTable.RateGoldToPlatinum * Hot.TranslateNum;
                }
                break;
        }

        Hot.PanelOtherResTable_.UpdateInfo();
        Hot.Data_.Save();
    }
}
