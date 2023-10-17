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

    protected override void Start()
    {
        base.Start();

        TextCopper = transform.FindSonSonSon("TxtCopper").GetComponent<Text>();
        TextSilver = transform.FindSonSonSon("TxtSilver").GetComponent<Text>();
        TextGold = transform.FindSonSonSon("TxtGold").GetComponent<Text>();
        TextPlatinum = transform.FindSonSonSon("TxtPlatinum").GetComponent<Text>();

        ImgStoreCoinLevel = transform.FindSonSonSon("ImgStoreCoinLevel").GetComponent<Image>();
        TxtStoreCoinLevel = transform.FindSonSonSon("TxtStoreCoinLevel").GetComponent<Text>();

        UpdateDataInfo();
    }

    public void UpdateDataInfo()
    {
        Rounding();

        TextCopper.text = GlobalHot.NowCellGameArchive.DataResCoin.NowCopper.ToString();
        TextSilver.text = GlobalHot.NowCellGameArchive.DataResCoin.NowSilver.ToString();
        TextGold.text = GlobalHot.NowCellGameArchive.DataResCoin.NowGold.ToString();
        TextPlatinum.text = GlobalHot.NowCellGameArchive.DataResCoin.NowPlatinum.ToString();

        switch (GlobalHot.NowCellGameArchive.DataResCoin.e_StoreCoinLevel)
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

        TxtStoreCoinLevel.text = GlobalHot.NowCellGameArchive.DataResCoin.StoreCoinLevel.ToString();
    }

    public void Rounding()
    {
        switch (GlobalHot.NowCellGameArchive.DataResCoin.e_StoreCoinLevel)
        {
            case E_StoreCoinLevel.Silver:
                CopperToSilver();
                GlobalHot.NowCellGameArchive.DataResCoin.NowGold = 0;
                GlobalHot.NowCellGameArchive.DataResCoin.NowPlatinum = 0;
                if (GlobalHot.NowCellGameArchive.DataResCoin.NowSilver >= GlobalHot.NowCellGameArchive.DataResCoin.StoreCoinLevel)
                {
                    GlobalHot.NowCellGameArchive.DataResCoin.NowCopper = 0;                    
                    GlobalHot.NowCellGameArchive.DataResCoin.NowSilver = GlobalHot.NowCellGameArchive.DataResCoin.StoreCoinLevel;
                }
                break;

            case E_StoreCoinLevel.Gold:
                SilverToGold();
                GlobalHot.NowCellGameArchive.DataResCoin.NowPlatinum = 0;
                if (GlobalHot.NowCellGameArchive.DataResCoin.NowGold >= GlobalHot.NowCellGameArchive.DataResCoin.StoreCoinLevel)
                {
                    GlobalHot.NowCellGameArchive.DataResCoin.NowCopper = 0;
                    GlobalHot.NowCellGameArchive.DataResCoin.NowSilver = 0;                    
                    GlobalHot.NowCellGameArchive.DataResCoin.NowGold = GlobalHot.NowCellGameArchive.DataResCoin.StoreCoinLevel;
                }
                break;

            case E_StoreCoinLevel.Platinum:
                GoldToPlatinum();
                if (GlobalHot.NowCellGameArchive.DataResCoin.NowPlatinum >= GlobalHot.NowCellGameArchive.DataResCoin.StoreCoinLevel)
                {
                    GlobalHot.NowCellGameArchive.DataResCoin.NowCopper = 0;
                    GlobalHot.NowCellGameArchive.DataResCoin.NowSilver = 0;
                    GlobalHot.NowCellGameArchive.DataResCoin.NowGold = 0;
                    GlobalHot.NowCellGameArchive.DataResCoin.NowPlatinum = GlobalHot.NowCellGameArchive.DataResCoin.StoreCoinLevel;
                }
                break;            
        }

        Data.GetInstance().Save(GlobalHot.IndexNowCellGameArchive);
    }

    private void CopperToSilver()
    {
        if (GlobalHot.NowCellGameArchive.DataResCoin.NowCopper >= GlobalHot.NowCellGameArchive.DataResCoin.RateCopperToSilver)
        {
            GlobalHot.NowCellGameArchive.DataResCoin.NowSilver +=
                GlobalHot.NowCellGameArchive.DataResCoin.NowCopper / GlobalHot.NowCellGameArchive.DataResCoin.RateCopperToSilver;
            GlobalHot.NowCellGameArchive.DataResCoin.NowCopper %= GlobalHot.NowCellGameArchive.DataResCoin.RateCopperToSilver;
        }
    }

    private void SilverToGold()
    {
        CopperToSilver();

        if (GlobalHot.NowCellGameArchive.DataResCoin.NowSilver >= GlobalHot.NowCellGameArchive.DataResCoin.RateSilverToGold)
        {
            GlobalHot.NowCellGameArchive.DataResCoin.NowGold +=
                GlobalHot.NowCellGameArchive.DataResCoin.NowSilver / GlobalHot.NowCellGameArchive.DataResCoin.RateSilverToGold;
            GlobalHot.NowCellGameArchive.DataResCoin.NowSilver %= GlobalHot.NowCellGameArchive.DataResCoin.RateSilverToGold;
        }
    }

    private void GoldToPlatinum()
    {
        SilverToGold();

        if (GlobalHot.NowCellGameArchive.DataResCoin.NowGold >= GlobalHot.NowCellGameArchive.DataResCoin.RateGoldToPlatinum)
        {
            GlobalHot.NowCellGameArchive.DataResCoin.NowPlatinum +=
                GlobalHot.NowCellGameArchive.DataResCoin.NowGold / GlobalHot.NowCellGameArchive.DataResCoin.RateGoldToPlatinum;
            GlobalHot.NowCellGameArchive.DataResCoin.NowGold %= GlobalHot.NowCellGameArchive.DataResCoin.RateGoldToPlatinum;
        }
    }
}
