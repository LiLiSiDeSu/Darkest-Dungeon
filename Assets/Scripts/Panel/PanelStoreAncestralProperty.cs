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

    protected override void Awake()
    {
        base.Awake();

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
    }

    public void UpdateDataInfo()
    {
        Rounding();

        TxtNowStatue.text = GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.NowStatue.ToString();
        TxtNowDeed.text = GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.NowDeed.ToString();
        TxtNowBadge.text = GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.NowBadge.ToString();
        TxtNowPicture.text = GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.NowPicture.ToString();
        TxtNowCrystal.text = GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.NowCrystal.ToString();

        TxtMaxStatue.text = GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.MaxStatue.ToString();
        TxtMaxDeed.text = GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.MaxDeed.ToString();
        TxtMaxBadge.text = GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.MaxBadge.ToString();
        TxtMaxPicture.text = GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.MaxPicture.ToString();
        TxtMaxCrystal.text = GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.MaxCrystal.ToString();
    }

    public void Rounding()
    {
        if (GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.NowStatue > 
            GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.MaxStatue)
        {
            GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.NowStatue =
                GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.MaxStatue;
        }

        if (GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.NowDeed >
            GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.MaxDeed)
        {
            GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.NowDeed =
                GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.MaxDeed;
        }

        if (GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.NowBadge >
            GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.MaxBadge)
        {
            GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.NowBadge =
                GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.MaxBadge;
        }

        if (GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.NowPicture >
            GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.MaxPicture)
        {
            GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.NowPicture =
                GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.MaxPicture;
        }

        if (GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.NowCrystal >
            GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.MaxCrystal)
        {
            GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.NowCrystal =
                GlobalHot.NowCellGameArchive.DataStoreAncestralProperty.MaxCrystal;
        }

        Data.GetInstance().Save();
    }
}
