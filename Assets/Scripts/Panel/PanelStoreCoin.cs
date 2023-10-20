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
        //TextCopper.text = Hot.DataNowCellGameArchive.DataStoreCoin.NowCopper.ToString();
        //TextSilver.text = Hot.DataNowCellGameArchive.DataStoreCoin.NowSilver.ToString();
        //TextGold.text = Hot.DataNowCellGameArchive.DataStoreCoin.NowGold.ToString();
        //TextPlatinum.text = Hot.DataNowCellGameArchive.DataStoreCoin.NowPlatinum.ToString();        
    }

    //public void Rounding()
    //{
    //    switch (Hot.DataNowCellGameArchive.DataStoreCoin.e_StoreCoinLevel)
    //    {
    //        case E_StoreCoinLevel.Silver:
    //            CopperToSilver();
    //            Hot.DataNowCellGameArchive.DataStoreCoin.NowGold = 0;
    //            Hot.DataNowCellGameArchive.DataStoreCoin.NowPlatinum = 0;
    //            if (Hot.DataNowCellGameArchive.DataStoreCoin.NowSilver >= Hot.DataNowCellGameArchive.DataStoreCoin.StoreCoinLevel)
    //            {
    //                Hot.DataNowCellGameArchive.DataStoreCoin.NowCopper = 0;                    
    //                Hot.DataNowCellGameArchive.DataStoreCoin.NowSilver = Hot.DataNowCellGameArchive.DataStoreCoin.StoreCoinLevel;
    //            }
    //            break;

    //        case E_StoreCoinLevel.Gold:
    //            SilverToGold();
    //            Hot.DataNowCellGameArchive.DataStoreCoin.NowPlatinum = 0;
    //            if (Hot.DataNowCellGameArchive.DataStoreCoin.NowGold >= Hot.DataNowCellGameArchive.DataStoreCoin.StoreCoinLevel)
    //            {
    //                Hot.DataNowCellGameArchive.DataStoreCoin.NowCopper = 0;
    //                Hot.DataNowCellGameArchive.DataStoreCoin.NowSilver = 0;                    
    //                Hot.DataNowCellGameArchive.DataStoreCoin.NowGold = Hot.DataNowCellGameArchive.DataStoreCoin.StoreCoinLevel;
    //            }
    //            break;

    //        case E_StoreCoinLevel.Platinum:
    //            GoldToPlatinum();
    //            if (Hot.DataNowCellGameArchive.DataStoreCoin.NowPlatinum >= Hot.DataNowCellGameArchive.DataStoreCoin.StoreCoinLevel)
    //            {
    //                Hot.DataNowCellGameArchive.DataStoreCoin.NowCopper = 0;
    //                Hot.DataNowCellGameArchive.DataStoreCoin.NowSilver = 0;
    //                Hot.DataNowCellGameArchive.DataStoreCoin.NowGold = 0;
    //                Hot.DataNowCellGameArchive.DataStoreCoin.NowPlatinum = Hot.DataNowCellGameArchive.DataStoreCoin.StoreCoinLevel;
    //            }
    //            break;            
    //    }

    //    Data.GetInstance().Save();
    //}

    //private void CopperToSilver()
    //{
    //    if (Hot.DataNowCellGameArchive.DataStoreCoin.NowCopper >= Hot.DataNowCellGameArchive.DataStoreCoin.RateCopperToSilver)
    //    {
    //        Hot.DataNowCellGameArchive.DataStoreCoin.NowSilver +=
    //            Hot.DataNowCellGameArchive.DataStoreCoin.NowCopper / Hot.DataNowCellGameArchive.DataStoreCoin.RateCopperToSilver;
    //        Hot.DataNowCellGameArchive.DataStoreCoin.NowCopper %= Hot.DataNowCellGameArchive.DataStoreCoin.RateCopperToSilver;
    //    }
    //}

    //private void SilverToGold()
    //{
    //    CopperToSilver();

    //    if (Hot.DataNowCellGameArchive.DataStoreCoin.NowSilver >= Hot.DataNowCellGameArchive.DataStoreCoin.RateSilverToGold)
    //    {
    //        Hot.DataNowCellGameArchive.DataStoreCoin.NowGold +=
    //            Hot.DataNowCellGameArchive.DataStoreCoin.NowSilver / Hot.DataNowCellGameArchive.DataStoreCoin.RateSilverToGold;
    //        Hot.DataNowCellGameArchive.DataStoreCoin.NowSilver %= Hot.DataNowCellGameArchive.DataStoreCoin.RateSilverToGold;
    //    }
    //}

    //private void GoldToPlatinum()
    //{
    //    SilverToGold();

    //    if (Hot.DataNowCellGameArchive.DataStoreCoin.NowGold >= Hot.DataNowCellGameArchive.DataStoreCoin.RateGoldToPlatinum)
    //    {
    //        Hot.DataNowCellGameArchive.DataStoreCoin.NowPlatinum +=
    //            Hot.DataNowCellGameArchive.DataStoreCoin.NowGold / Hot.DataNowCellGameArchive.DataStoreCoin.RateGoldToPlatinum;
    //        Hot.DataNowCellGameArchive.DataStoreCoin.NowGold %= Hot.DataNowCellGameArchive.DataStoreCoin.RateGoldToPlatinum;
    //    }
    //}
}
