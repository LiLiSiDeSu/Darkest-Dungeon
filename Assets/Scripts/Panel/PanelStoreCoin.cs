using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelStoreCoin : PanelBase
{
    public Text TextCopper;
    public Text TextSilver;
    public Text TextGold;
    public Text TextPlatinum;

    public Image ImgStoreCoinLevel;
    public Text TxtStoreCoinLevel;

    protected override void Awake()
    {
        base.Awake();

        TextCopper = transform.FindSonSonSon("TxtCopper").GetComponent<Text>();
        TextSilver = transform.FindSonSonSon("TxtSilver").GetComponent<Text>();
        TextGold = transform.FindSonSonSon("TxtGold").GetComponent<Text>();
        TextPlatinum = transform.FindSonSonSon("TxtPlatinum").GetComponent<Text>();

        ImgStoreCoinLevel = transform.FindSonSonSon("ImgStoreCoinLevel").GetComponent<Image>();
        TxtStoreCoinLevel = transform.FindSonSonSon("TxtStoreCoinLevel").GetComponent<Text>();        
    }

    public void UpdateDataInfo()
    {
        Rounding();

        TextCopper.text = GlobalHot.NowCellGameArchive.DataStoreCoin.NowCopper.ToString();
        TextSilver.text = GlobalHot.NowCellGameArchive.DataStoreCoin.NowSilver.ToString();
        TextGold.text = GlobalHot.NowCellGameArchive.DataStoreCoin.NowGold.ToString();
        TextPlatinum.text = GlobalHot.NowCellGameArchive.DataStoreCoin.NowPlatinum.ToString();

        switch (GlobalHot.NowCellGameArchive.DataStoreCoin.e_StoreCoinLevel)
        {                
            case E_StoreCoinLevel.Silver:
                ImgStoreCoinLevel.sprite = MgrRes.GetInstance().Load<Sprite>("Art/" + "StoreCoinSilver");
                break;
            case E_StoreCoinLevel.Gold:
                ImgStoreCoinLevel.sprite = MgrRes.GetInstance().Load<Sprite>("Art/" + "StoreCoinGold");
                break;
            case E_StoreCoinLevel.Platinum:
                ImgStoreCoinLevel.sprite = MgrRes.GetInstance().Load<Sprite>("Art/" + "StoreCoinPlatinum");
                break;      
        }

        TxtStoreCoinLevel.text = GlobalHot.NowCellGameArchive.DataStoreCoin.StoreCoinLevel.ToString();
    }

    public void Rounding()
    {
        switch (GlobalHot.NowCellGameArchive.DataStoreCoin.e_StoreCoinLevel)
        {
            case E_StoreCoinLevel.Silver:
                CopperToSilver();
                GlobalHot.NowCellGameArchive.DataStoreCoin.NowGold = 0;
                GlobalHot.NowCellGameArchive.DataStoreCoin.NowPlatinum = 0;
                if (GlobalHot.NowCellGameArchive.DataStoreCoin.NowSilver >= GlobalHot.NowCellGameArchive.DataStoreCoin.StoreCoinLevel)
                {
                    GlobalHot.NowCellGameArchive.DataStoreCoin.NowCopper = 0;                    
                    GlobalHot.NowCellGameArchive.DataStoreCoin.NowSilver = GlobalHot.NowCellGameArchive.DataStoreCoin.StoreCoinLevel;
                }
                break;

            case E_StoreCoinLevel.Gold:
                SilverToGold();
                GlobalHot.NowCellGameArchive.DataStoreCoin.NowPlatinum = 0;
                if (GlobalHot.NowCellGameArchive.DataStoreCoin.NowGold >= GlobalHot.NowCellGameArchive.DataStoreCoin.StoreCoinLevel)
                {
                    GlobalHot.NowCellGameArchive.DataStoreCoin.NowCopper = 0;
                    GlobalHot.NowCellGameArchive.DataStoreCoin.NowSilver = 0;                    
                    GlobalHot.NowCellGameArchive.DataStoreCoin.NowGold = GlobalHot.NowCellGameArchive.DataStoreCoin.StoreCoinLevel;
                }
                break;

            case E_StoreCoinLevel.Platinum:
                GoldToPlatinum();
                if (GlobalHot.NowCellGameArchive.DataStoreCoin.NowPlatinum >= GlobalHot.NowCellGameArchive.DataStoreCoin.StoreCoinLevel)
                {
                    GlobalHot.NowCellGameArchive.DataStoreCoin.NowCopper = 0;
                    GlobalHot.NowCellGameArchive.DataStoreCoin.NowSilver = 0;
                    GlobalHot.NowCellGameArchive.DataStoreCoin.NowGold = 0;
                    GlobalHot.NowCellGameArchive.DataStoreCoin.NowPlatinum = GlobalHot.NowCellGameArchive.DataStoreCoin.StoreCoinLevel;
                }
                break;            
        }

        Data.GetInstance().Save();
    }

    private void CopperToSilver()
    {
        if (GlobalHot.NowCellGameArchive.DataStoreCoin.NowCopper >= GlobalHot.NowCellGameArchive.DataStoreCoin.RateCopperToSilver)
        {
            GlobalHot.NowCellGameArchive.DataStoreCoin.NowSilver +=
                GlobalHot.NowCellGameArchive.DataStoreCoin.NowCopper / GlobalHot.NowCellGameArchive.DataStoreCoin.RateCopperToSilver;
            GlobalHot.NowCellGameArchive.DataStoreCoin.NowCopper %= GlobalHot.NowCellGameArchive.DataStoreCoin.RateCopperToSilver;
        }
    }

    private void SilverToGold()
    {
        CopperToSilver();

        if (GlobalHot.NowCellGameArchive.DataStoreCoin.NowSilver >= GlobalHot.NowCellGameArchive.DataStoreCoin.RateSilverToGold)
        {
            GlobalHot.NowCellGameArchive.DataStoreCoin.NowGold +=
                GlobalHot.NowCellGameArchive.DataStoreCoin.NowSilver / GlobalHot.NowCellGameArchive.DataStoreCoin.RateSilverToGold;
            GlobalHot.NowCellGameArchive.DataStoreCoin.NowSilver %= GlobalHot.NowCellGameArchive.DataStoreCoin.RateSilverToGold;
        }
    }

    private void GoldToPlatinum()
    {
        SilverToGold();

        if (GlobalHot.NowCellGameArchive.DataStoreCoin.NowGold >= GlobalHot.NowCellGameArchive.DataStoreCoin.RateGoldToPlatinum)
        {
            GlobalHot.NowCellGameArchive.DataStoreCoin.NowPlatinum +=
                GlobalHot.NowCellGameArchive.DataStoreCoin.NowGold / GlobalHot.NowCellGameArchive.DataStoreCoin.RateGoldToPlatinum;
            GlobalHot.NowCellGameArchive.DataStoreCoin.NowGold %= GlobalHot.NowCellGameArchive.DataStoreCoin.RateGoldToPlatinum;
        }
    }
}
