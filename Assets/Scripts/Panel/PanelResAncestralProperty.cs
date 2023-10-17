using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelResAncestralProperty : PanelBase
{
    public Text TxtStatue;
    public Text TxtDeed;
    public Text TxtBadge;
    public Text TxtPicture;
    public Text TxtCrystal;

    protected override void Start()
    {
        base.Start();

        TxtStatue = transform.FindSonSonSon("TxtStatue").GetComponent<Text>();
        TxtDeed = transform.FindSonSonSon("TxtDeed").GetComponent<Text>();
        TxtBadge = transform.FindSonSonSon("TxtBadge").GetComponent<Text>();
        TxtPicture = transform.FindSonSonSon("TxtPicture").GetComponent<Text>();
        TxtCrystal = transform.FindSonSonSon("TxtCrystal").GetComponent<Text>();

        InitDataInfo();        
    }

    public void InitDataInfo()
    {
        TxtStatue.text = GlobalHot.NowCellGameArchive.DataResAncestralProperty.NumStatue.ToString();
        TxtDeed.text = GlobalHot.NowCellGameArchive.DataResAncestralProperty.NumDeed.ToString();
        TxtBadge.text = GlobalHot.NowCellGameArchive.DataResAncestralProperty.NumBadge.ToString();
        TxtPicture.text = GlobalHot.NowCellGameArchive.DataResAncestralProperty.NumPicture.ToString();
        TxtCrystal.text = GlobalHot.NowCellGameArchive.DataResAncestralProperty.NumCrystal.ToString();
    }
}
