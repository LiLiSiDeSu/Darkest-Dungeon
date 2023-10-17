using Palmmedia.ReportGenerator.Core.Reporting.Builders.Rendering;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UI;

public class PanelCellTownStore : PanelBase
{
    public int Index;

    public int MaxWeight;
    public int MaxCapacity;

    public Text TxtMaxWeight;    
    public Text TxtMaxCapacity;
    public Text TxtNowWeight;
    public Text TxtNowCapacity;
    public Image ImgStore;
    
    public PanelTownItem NowPanelTownStoreItem = new PanelTownItem();

    protected override void Start()
    {
        base.Start();                

        TxtMaxWeight = transform.FindSonSonSon("TxtMaxWeight").GetComponent<Text>();        
        TxtMaxCapacity = transform.FindSonSonSon("TxtMaxCapacity").GetComponent<Text>();
        TxtNowWeight = transform.FindSonSonSon("TxtNowWeight").GetComponent<Text>();
        TxtNowCapacity = transform.FindSonSonSon("TxtNowCapacity").GetComponent<Text>();
        ImgStore = transform.FindSonSonSon("ImgStore").GetComponent<Image>();        

        InitDataInfo();

        ImgStore.alphaHitTestMinimumThreshold = 0.2f;

        TxtMaxWeight.text = MaxWeight.ToString();        
        TxtMaxCapacity.text = MaxCapacity.ToString();
        TxtNowWeight.text = GlobalHot.NowCellGameArchive.DataListCellStore[Index].NowWeight.ToString();
        TxtNowCapacity.text = GlobalHot.NowCellGameArchive.DataListCellStore[Index].NowCapacity.ToString();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellTownStore":                
                NowPanelTownStoreItem.Show(this);                
                break;
        }
    }

    public void InitDataInfo()
    {
        switch (GlobalHot.NowCellGameArchive.DataListCellStore[Index].e_SpriteNamePanelCellTownStore)
        {
            case E_SpriteNamePanelCellTownStore.StoreWood:
                MaxWeight = 50;
                MaxCapacity = 100;
                break;

            case E_SpriteNamePanelCellTownStore.StoreIron:
                MaxWeight = 200;
                MaxCapacity = 250;                
                break;

            case E_SpriteNamePanelCellTownStore.StoreGold:
                MaxWeight = 70;
                MaxCapacity = 400;                
                break;        
        }

        ImgStore.sprite = MgrRes.GetInstance().Load<Sprite>
        ("Art/" + GlobalHot.NowCellGameArchive.DataListCellStore[Index].e_SpriteNamePanelCellTownStore.ToString());
    }
}
