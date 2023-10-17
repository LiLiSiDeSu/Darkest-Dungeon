using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelStoreAncestralProperty : PanelBase
{
    public Text TxtNowStatue;
    public Text TxtNowDeed;
    public Text TxtNowBadge;
    public Text TxtNowPicture;
    public Text TxtNowCrystal;

    public Text TxtMaxStatue;
    public Text TxtMaxDeed;
    public Text TxtMaxBadge;
    public Text TxtMaxPicture;
    public Text TxtMaxCrystal;

    protected override void Start()
    {
        base.Start();

        TxtNowStatue = transform.FindSonSonSon("TxtNowStatue").GetComponent<Text>();
        TxtNowDeed = transform.FindSonSonSon("TxtNowDeed").GetComponent<Text>();
        TxtNowBadge = transform.FindSonSonSon("TxtNowBadge").GetComponent<Text>();
        TxtNowPicture = transform.FindSonSonSon("TxtNowPicture").GetComponent<Text>();
        TxtNowCrystal = transform.FindSonSonSon("TxtNowCrystal").GetComponent<Text>();

        TxtMaxStatue = transform.FindSonSonSon("TxtMaxStatue").GetComponent<Text>();
        TxtMaxDeed = transform.FindSonSonSon("TxtMaxDeed").GetComponent<Text>();
        TxtMaxBadge = transform.FindSonSonSon("TxtMaxBadge").GetComponent<Text>();
        TxtMaxPicture = transform.FindSonSonSon("TxtMaxPicture").GetComponent<Text>();
        TxtMaxCrystal = transform.FindSonSonSon("TxtMaxCrystal").GetComponent<Text>();

        UpdateDataInfo();        
    }

    public void UpdateDataInfo()
    {
        Rounding();

        TxtNowStatue.text = GlobalHot.NowCellGameArchive.DataResAncestralProperty.NowStatue.ToString();
        TxtNowDeed.text = GlobalHot.NowCellGameArchive.DataResAncestralProperty.NowDeed.ToString();
        TxtNowBadge.text = GlobalHot.NowCellGameArchive.DataResAncestralProperty.NowBadge.ToString();
        TxtNowPicture.text = GlobalHot.NowCellGameArchive.DataResAncestralProperty.NowPicture.ToString();
        TxtNowCrystal.text = GlobalHot.NowCellGameArchive.DataResAncestralProperty.NowCrystal.ToString();

        TxtMaxStatue.text = GlobalHot.NowCellGameArchive.DataResAncestralProperty.MaxStatue.ToString();
        TxtMaxDeed.text = GlobalHot.NowCellGameArchive.DataResAncestralProperty.MaxDeed.ToString();
        TxtMaxBadge.text = GlobalHot.NowCellGameArchive.DataResAncestralProperty.MaxBadge.ToString();
        TxtMaxPicture.text = GlobalHot.NowCellGameArchive.DataResAncestralProperty.MaxPicture.ToString();
        TxtMaxCrystal.text = GlobalHot.NowCellGameArchive.DataResAncestralProperty.MaxCrystal.ToString();
    }

    public void Rounding()
    {
        if (GlobalHot.NowCellGameArchive.DataResAncestralProperty.NowStatue > 
            GlobalHot.NowCellGameArchive.DataResAncestralProperty.MaxStatue)
        {
            GlobalHot.NowCellGameArchive.DataResAncestralProperty.NowStatue =
                GlobalHot.NowCellGameArchive.DataResAncestralProperty.MaxStatue;
        }

        if (GlobalHot.NowCellGameArchive.DataResAncestralProperty.NowDeed >
            GlobalHot.NowCellGameArchive.DataResAncestralProperty.MaxDeed)
        {
            GlobalHot.NowCellGameArchive.DataResAncestralProperty.NowDeed =
                GlobalHot.NowCellGameArchive.DataResAncestralProperty.MaxDeed;
        }

        if (GlobalHot.NowCellGameArchive.DataResAncestralProperty.NowBadge >
            GlobalHot.NowCellGameArchive.DataResAncestralProperty.MaxBadge)
        {
            GlobalHot.NowCellGameArchive.DataResAncestralProperty.NowBadge =
                GlobalHot.NowCellGameArchive.DataResAncestralProperty.MaxBadge;
        }

        if (GlobalHot.NowCellGameArchive.DataResAncestralProperty.NowPicture >
            GlobalHot.NowCellGameArchive.DataResAncestralProperty.MaxPicture)
        {
            GlobalHot.NowCellGameArchive.DataResAncestralProperty.NowPicture =
                GlobalHot.NowCellGameArchive.DataResAncestralProperty.MaxPicture;
        }

        if (GlobalHot.NowCellGameArchive.DataResAncestralProperty.NowCrystal >
            GlobalHot.NowCellGameArchive.DataResAncestralProperty.MaxCrystal)
        {
            GlobalHot.NowCellGameArchive.DataResAncestralProperty.NowCrystal =
                GlobalHot.NowCellGameArchive.DataResAncestralProperty.MaxCrystal;
        }

        Data.GetInstance().Save(GlobalHot.IndexNowCellGameArchive);
    }
}
