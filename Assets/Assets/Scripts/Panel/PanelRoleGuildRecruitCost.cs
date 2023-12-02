using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PanelRoleGuildRecruitCost : PanelBase
{
    public Text TxtCopper;
    public Text TxtSilver;
    public Text TxtGold;
    public Text TxtPlatinum;

    public bool CanBuy = false;

    protected override void Awake()
    {
        base.Awake();        

        TxtCopper = transform.FindSonSonSon("TxtCopper").GetComponent<Text>();
        TxtSilver = transform.FindSonSonSon("TxtSilver").GetComponent<Text>();
        TxtGold = transform.FindSonSonSon("TxtGold").GetComponent<Text>();
        TxtPlatinum = transform.FindSonSonSon("TxtPlatinum").GetComponent<Text>();
    }

    public void UpdateInfo(DataContainer_CoinCost CoinCost)
    {
        CanBuy = true;

        ChangeTextColorAndJudgeCanBug(CoinCost);

        TxtCopper.text = CoinCost.Copper.ToString();
        TxtSilver.text = CoinCost.Silver.ToString();
        TxtGold.text = CoinCost.Gold.ToString();
        TxtPlatinum.text = CoinCost.Platinum.ToString();
    }
    
    public void ChangeTextColorAndJudgeCanBug(DataContainer_CoinCost CoinCost)
    {
        if (CoinCost.Copper > Hot.DataNowCellGameArchive.ResTable.NowCopper)
        {
            TxtCopper.color = Color.red;
            CanBuy = false;
        }
        if (CoinCost.Silver > Hot.DataNowCellGameArchive.ResTable.NowSilver)
        {
            TxtSilver.color = Color.red;
            CanBuy = false;
        }
        if (CoinCost.Gold > Hot.DataNowCellGameArchive.ResTable.NowGold)
        {
            CanBuy = false;
            TxtGold.color = Color.red;
        }
        if (CoinCost.Platinum > Hot.DataNowCellGameArchive.ResTable.NowPlatinum)
        {
            TxtPlatinum.color = Color.red;
            CanBuy = false;
        }
    }

    public void InitText()
    {
        TxtCopper.text = "0";
        TxtSilver.text = "0";
        TxtGold.text = "0";
        TxtPlatinum.text = "0";        
    }

    public void InitTextColor()
    {
        TxtCopper.color = Color.white;
        TxtSilver.color = Color.white;
        TxtGold.color = Color.white;
        TxtPlatinum.color = Color.white;
    }

    public void Clear()
    {
        InitTextColor();
        InitText();
    }
}
