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

        TextCopper.text = Hot.NowCellGameArchive.DataStoreCoin.NowCopper.ToString();
        TextSilver.text = Hot.NowCellGameArchive.DataStoreCoin.NowSilver.ToString();
        TextGold.text = Hot.NowCellGameArchive.DataStoreCoin.NowGold.ToString();
        TextPlatinum.text = Hot.NowCellGameArchive.DataStoreCoin.NowPlatinum.ToString();

        switch (Hot.NowCellGameArchive.DataStoreCoin.e_StoreCoinLevel)
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

        TxtStoreCoinLevel.text = Hot.NowCellGameArchive.DataStoreCoin.StoreCoinLevel.ToString();
    }

    public void Rounding()
    {
        switch (Hot.NowCellGameArchive.DataStoreCoin.e_StoreCoinLevel)
        {
            case E_StoreCoinLevel.Silver:
                CopperToSilver();
                Hot.NowCellGameArchive.DataStoreCoin.NowGold = 0;
                Hot.NowCellGameArchive.DataStoreCoin.NowPlatinum = 0;
                if (Hot.NowCellGameArchive.DataStoreCoin.NowSilver >= Hot.NowCellGameArchive.DataStoreCoin.StoreCoinLevel)
                {
                    Hot.NowCellGameArchive.DataStoreCoin.NowCopper = 0;                    
                    Hot.NowCellGameArchive.DataStoreCoin.NowSilver = Hot.NowCellGameArchive.DataStoreCoin.StoreCoinLevel;
                }
                break;

            case E_StoreCoinLevel.Gold:
                SilverToGold();
                Hot.NowCellGameArchive.DataStoreCoin.NowPlatinum = 0;
                if (Hot.NowCellGameArchive.DataStoreCoin.NowGold >= Hot.NowCellGameArchive.DataStoreCoin.StoreCoinLevel)
                {
                    Hot.NowCellGameArchive.DataStoreCoin.NowCopper = 0;
                    Hot.NowCellGameArchive.DataStoreCoin.NowSilver = 0;                    
                    Hot.NowCellGameArchive.DataStoreCoin.NowGold = Hot.NowCellGameArchive.DataStoreCoin.StoreCoinLevel;
                }
                break;

            case E_StoreCoinLevel.Platinum:
                GoldToPlatinum();
                if (Hot.NowCellGameArchive.DataStoreCoin.NowPlatinum >= Hot.NowCellGameArchive.DataStoreCoin.StoreCoinLevel)
                {
                    Hot.NowCellGameArchive.DataStoreCoin.NowCopper = 0;
                    Hot.NowCellGameArchive.DataStoreCoin.NowSilver = 0;
                    Hot.NowCellGameArchive.DataStoreCoin.NowGold = 0;
                    Hot.NowCellGameArchive.DataStoreCoin.NowPlatinum = Hot.NowCellGameArchive.DataStoreCoin.StoreCoinLevel;
                }
                break;            
        }

        Data.GetInstance().Save();
    }

    private void CopperToSilver()
    {
        if (Hot.NowCellGameArchive.DataStoreCoin.NowCopper >= Hot.NowCellGameArchive.DataStoreCoin.RateCopperToSilver)
        {
            Hot.NowCellGameArchive.DataStoreCoin.NowSilver +=
                Hot.NowCellGameArchive.DataStoreCoin.NowCopper / Hot.NowCellGameArchive.DataStoreCoin.RateCopperToSilver;
            Hot.NowCellGameArchive.DataStoreCoin.NowCopper %= Hot.NowCellGameArchive.DataStoreCoin.RateCopperToSilver;
        }
    }

    private void SilverToGold()
    {
        CopperToSilver();

        if (Hot.NowCellGameArchive.DataStoreCoin.NowSilver >= Hot.NowCellGameArchive.DataStoreCoin.RateSilverToGold)
        {
            Hot.NowCellGameArchive.DataStoreCoin.NowGold +=
                Hot.NowCellGameArchive.DataStoreCoin.NowSilver / Hot.NowCellGameArchive.DataStoreCoin.RateSilverToGold;
            Hot.NowCellGameArchive.DataStoreCoin.NowSilver %= Hot.NowCellGameArchive.DataStoreCoin.RateSilverToGold;
        }
    }

    private void GoldToPlatinum()
    {
        SilverToGold();

        if (Hot.NowCellGameArchive.DataStoreCoin.NowGold >= Hot.NowCellGameArchive.DataStoreCoin.RateGoldToPlatinum)
        {
            Hot.NowCellGameArchive.DataStoreCoin.NowPlatinum +=
                Hot.NowCellGameArchive.DataStoreCoin.NowGold / Hot.NowCellGameArchive.DataStoreCoin.RateGoldToPlatinum;
            Hot.NowCellGameArchive.DataStoreCoin.NowGold %= Hot.NowCellGameArchive.DataStoreCoin.RateGoldToPlatinum;
        }
    }
}
