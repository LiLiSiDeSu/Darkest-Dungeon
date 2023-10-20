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
}
