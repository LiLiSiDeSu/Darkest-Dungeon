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

        TxtNowStatue.text = Hot.NowCellGameArchive.DataStoreAncestralProperty.NowStatue.ToString();
        TxtNowDeed.text = Hot.NowCellGameArchive.DataStoreAncestralProperty.NowDeed.ToString();
        TxtNowBadge.text = Hot.NowCellGameArchive.DataStoreAncestralProperty.NowBadge.ToString();
        TxtNowPicture.text = Hot.NowCellGameArchive.DataStoreAncestralProperty.NowPicture.ToString();
        TxtNowCrystal.text = Hot.NowCellGameArchive.DataStoreAncestralProperty.NowCrystal.ToString();

        TxtMaxStatue.text = Hot.NowCellGameArchive.DataStoreAncestralProperty.MaxStatue.ToString();
        TxtMaxDeed.text = Hot.NowCellGameArchive.DataStoreAncestralProperty.MaxDeed.ToString();
        TxtMaxBadge.text = Hot.NowCellGameArchive.DataStoreAncestralProperty.MaxBadge.ToString();
        TxtMaxPicture.text = Hot.NowCellGameArchive.DataStoreAncestralProperty.MaxPicture.ToString();
        TxtMaxCrystal.text = Hot.NowCellGameArchive.DataStoreAncestralProperty.MaxCrystal.ToString();
    }

    public void Rounding()
    {
        if (Hot.NowCellGameArchive.DataStoreAncestralProperty.NowStatue > 
            Hot.NowCellGameArchive.DataStoreAncestralProperty.MaxStatue)
        {
            Hot.NowCellGameArchive.DataStoreAncestralProperty.NowStatue =
                Hot.NowCellGameArchive.DataStoreAncestralProperty.MaxStatue;
        }

        if (Hot.NowCellGameArchive.DataStoreAncestralProperty.NowDeed >
            Hot.NowCellGameArchive.DataStoreAncestralProperty.MaxDeed)
        {
            Hot.NowCellGameArchive.DataStoreAncestralProperty.NowDeed =
                Hot.NowCellGameArchive.DataStoreAncestralProperty.MaxDeed;
        }

        if (Hot.NowCellGameArchive.DataStoreAncestralProperty.NowBadge >
            Hot.NowCellGameArchive.DataStoreAncestralProperty.MaxBadge)
        {
            Hot.NowCellGameArchive.DataStoreAncestralProperty.NowBadge =
                Hot.NowCellGameArchive.DataStoreAncestralProperty.MaxBadge;
        }

        if (Hot.NowCellGameArchive.DataStoreAncestralProperty.NowPicture >
            Hot.NowCellGameArchive.DataStoreAncestralProperty.MaxPicture)
        {
            Hot.NowCellGameArchive.DataStoreAncestralProperty.NowPicture =
                Hot.NowCellGameArchive.DataStoreAncestralProperty.MaxPicture;
        }

        if (Hot.NowCellGameArchive.DataStoreAncestralProperty.NowCrystal >
            Hot.NowCellGameArchive.DataStoreAncestralProperty.MaxCrystal)
        {
            Hot.NowCellGameArchive.DataStoreAncestralProperty.NowCrystal =
                Hot.NowCellGameArchive.DataStoreAncestralProperty.MaxCrystal;
        }

        Data.GetInstance().Save();
    }
}
