using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelResCoin : PanelBase
{
    public Text TextCopper;
    public Text TextSilver;
    public Text TextGold;
    public Text TextPlatinum;

    protected override void Start()
    {
        base.Start();

        TextCopper = transform.FindSonSonSon("TxtCopper").GetComponent<Text>();
        TextSilver = transform.FindSonSonSon("TxtSilver").GetComponent<Text>();
        TextGold = transform.FindSonSonSon("TxtGold").GetComponent<Text>();
        TextPlatinum = transform.FindSonSonSon("TxtPlatinum").GetComponent<Text>();

        InitDataInfo();
    }

    public void InitDataInfo()
    {
        TextCopper.text = GlobalHot.NowCellGameArchive.DataResCoin.NumCopper.ToString();
        TextSilver.text = GlobalHot.NowCellGameArchive.DataResCoin.NumSilver.ToString();
        TextGold.text = GlobalHot.NowCellGameArchive.DataResCoin.NumGold.ToString();
        TextPlatinum.text = GlobalHot.NowCellGameArchive.DataResCoin.NumPlatinum.ToString();
    }
}
