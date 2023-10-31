using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTownShopCost : PanelBase
{
    public Text TxtCostCopper;
    public Text TxtCostSilver;
    public Text TxtCostGold;
    public Text TxtCostPlatinum;

    public Text TxtCostStatue;
    public Text TxtCostDeed;
    public Text TxtCostBadge;
    public Text TxtCostPicture;
    public Text TxtCostCrystal;

    public bool CanBuy = false;

    protected override void Awake()
    {
        base.Awake();

        TxtCostCopper = transform.FindSonSonSon("TxtCostCopper").GetComponent<Text>();
        TxtCostSilver = transform.FindSonSonSon("TxtCostSilver").GetComponent<Text>();
        TxtCostGold = transform.FindSonSonSon("TxtCostGold").GetComponent<Text>();
        TxtCostPlatinum = transform.FindSonSonSon("TxtCostPlatinum").GetComponent<Text>();

        TxtCostStatue = transform.FindSonSonSon("TxtCostStatue").GetComponent<Text>();
        TxtCostDeed = transform.FindSonSonSon("TxtCostDeed").GetComponent<Text>();
        TxtCostBadge = transform.FindSonSonSon("TxtCostBadge").GetComponent<Text>();
        TxtCostPicture = transform.FindSonSonSon("TxtCostPicture").GetComponent<Text>();
        TxtCostCrystal = transform.FindSonSonSon("TxtCostCrystal").GetComponent<Text>();        
    }    

    public void UpdateInfo(InfoContainer_Cost cost)
    {
        //这里可以加上存储在数据里的OffSet值

        CanBuy = true;

        ChangeTextColorAndJudgeCanBug();

        TxtCostCopper.text = cost.Copper.ToString();
        TxtCostSilver.text = cost.Silver.ToString();
        TxtCostGold.text = cost.Gold.ToString();
        TxtCostPlatinum.text = cost.Platinum.ToString();

        TxtCostStatue.text = cost.Statue.ToString();
        TxtCostDeed.text = cost.Deed.ToString();
        TxtCostBadge.text = cost.Badge.ToString();
        TxtCostPicture.text = cost.Picture.ToString();
        TxtCostCrystal.text = cost.Crystal.ToString();
    }

    public void ChangeTextColorAndJudgeCanBug()
    {
        if (Hot.NowItem.Cost.Copper > Hot.DataPanelResTable.NowCopper)
        {
            TxtCostCopper.color = Color.red;
            CanBuy = false;
        }
        if (Hot.NowItem.Cost.Silver > Hot.DataPanelResTable.NowSilver)
        {
            TxtCostSilver.color = Color.red;
            CanBuy = false;
        }
        if (Hot.NowItem.Cost.Gold > Hot.DataPanelResTable.NowGold)
        {
            TxtCostGold.color = Color.red;
            CanBuy = false;
        }
        if (Hot.NowItem.Cost.Platinum > Hot.DataPanelResTable.NowPlatinum)
        {
            TxtCostPlatinum.color = Color.red;
            CanBuy = false;
        }

        if (Hot.NowItem.Cost.Statue > Hot.DataPanelResTable.NowStatue)
        {
            TxtCostStatue.color = Color.red;
            CanBuy = false;
        }
        if (Hot.NowItem.Cost.Deed > Hot.DataPanelResTable.NowDeed)
        {
            TxtCostDeed.color = Color.red;
            CanBuy = false;
        }
        if (Hot.NowItem.Cost.Badge > Hot.DataPanelResTable.NowBadge)
        {
            TxtCostBadge.color = Color.red;
            CanBuy = false;
        }
        if (Hot.NowItem.Cost.Picture > Hot.DataPanelResTable.NowPicture)
        {
            TxtCostPicture.color = Color.red;
            CanBuy = false;
        }
        if (Hot.NowItem.Cost.Crystal > Hot.DataPanelResTable.NowCrystal)
        {
            TxtCostCrystal.color = Color.red;
            CanBuy = false;
        }
    }

    public void InitTextColor()
    {
        TxtCostCopper.color = Color.white;
        TxtCostSilver.color = Color.white;
        TxtCostGold.color = Color.white;
        TxtCostPlatinum.color = Color.white;
        TxtCostStatue.color = Color.white;
        TxtCostDeed.color = Color.white;
        TxtCostBadge.color = Color.white;
        TxtCostPicture.color = Color.white;
        TxtCostCrystal.color = Color.white;
    }

    public void InitText()
    {
        TxtCostCopper.text = "0";
        TxtCostSilver.text = "0";
        TxtCostGold.text = "0";
        TxtCostPlatinum.text = "0";

        TxtCostStatue.text = "0";
        TxtCostDeed.text = "0";
        TxtCostBadge.text = "0";
        TxtCostPicture.text = "0";
        TxtCostCrystal.text = "0";
    }

    public void Clear()
    {
        InitTextColor();
        InitText();
    }
}
