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

        TxtNowStatue.text = Hot.DataNowCellGameArchive.DataStoreAncestralProperty.NowStatue.ToString();
        TxtNowDeed.text = Hot.DataNowCellGameArchive.DataStoreAncestralProperty.NowDeed.ToString();
        TxtNowBadge.text = Hot.DataNowCellGameArchive.DataStoreAncestralProperty.NowBadge.ToString();
        TxtNowPicture.text = Hot.DataNowCellGameArchive.DataStoreAncestralProperty.NowPicture.ToString();
        TxtNowCrystal.text = Hot.DataNowCellGameArchive.DataStoreAncestralProperty.NowCrystal.ToString();

        TxtMaxStatue.text = Hot.DataNowCellGameArchive.DataStoreAncestralProperty.MaxStatue.ToString();
        TxtMaxDeed.text = Hot.DataNowCellGameArchive.DataStoreAncestralProperty.MaxDeed.ToString();
        TxtMaxBadge.text = Hot.DataNowCellGameArchive.DataStoreAncestralProperty.MaxBadge.ToString();
        TxtMaxPicture.text = Hot.DataNowCellGameArchive.DataStoreAncestralProperty.MaxPicture.ToString();
        TxtMaxCrystal.text = Hot.DataNowCellGameArchive.DataStoreAncestralProperty.MaxCrystal.ToString();
    }

    public void Rounding()
    {
        if (Hot.DataNowCellGameArchive.DataStoreAncestralProperty.NowStatue > 
            Hot.DataNowCellGameArchive.DataStoreAncestralProperty.MaxStatue)
        {
            Hot.DataNowCellGameArchive.DataStoreAncestralProperty.NowStatue =
                Hot.DataNowCellGameArchive.DataStoreAncestralProperty.MaxStatue;
        }

        if (Hot.DataNowCellGameArchive.DataStoreAncestralProperty.NowDeed >
            Hot.DataNowCellGameArchive.DataStoreAncestralProperty.MaxDeed)
        {
            Hot.DataNowCellGameArchive.DataStoreAncestralProperty.NowDeed =
                Hot.DataNowCellGameArchive.DataStoreAncestralProperty.MaxDeed;
        }

        if (Hot.DataNowCellGameArchive.DataStoreAncestralProperty.NowBadge >
            Hot.DataNowCellGameArchive.DataStoreAncestralProperty.MaxBadge)
        {
            Hot.DataNowCellGameArchive.DataStoreAncestralProperty.NowBadge =
                Hot.DataNowCellGameArchive.DataStoreAncestralProperty.MaxBadge;
        }

        if (Hot.DataNowCellGameArchive.DataStoreAncestralProperty.NowPicture >
            Hot.DataNowCellGameArchive.DataStoreAncestralProperty.MaxPicture)
        {
            Hot.DataNowCellGameArchive.DataStoreAncestralProperty.NowPicture =
                Hot.DataNowCellGameArchive.DataStoreAncestralProperty.MaxPicture;
        }

        if (Hot.DataNowCellGameArchive.DataStoreAncestralProperty.NowCrystal >
            Hot.DataNowCellGameArchive.DataStoreAncestralProperty.MaxCrystal)
        {
            Hot.DataNowCellGameArchive.DataStoreAncestralProperty.NowCrystal =
                Hot.DataNowCellGameArchive.DataStoreAncestralProperty.MaxCrystal;
        }

        Data.GetInstance().Save();
    }
}
