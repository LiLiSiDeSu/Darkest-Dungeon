using Palmmedia.ReportGenerator.Core.Reporting.Builders.Rendering;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UI;

public class PanelCellTownStore : PanelBase
{
    public int IndexCellCellStore;    

    public Text TxtMaxWeight;
    public Text TxtNowWeight;
    public Text TxtMaxCapacity;
    public Text TxtNowCapacity;
    public Image ImgStore;

    public DataContainer_PanelCellStore DataCellStore;
    public PanelTownStoreItem PanelItem;

    protected override void Start()
    {
        base.Start();                

        TxtMaxWeight = transform.FindSonSonSon("TxtMaxWeight").GetComponent<Text>();
        TxtNowWeight = transform.FindSonSonSon("TxtNowWeight").GetComponent<Text>();
        TxtMaxCapacity = transform.FindSonSonSon("TxtMaxCapacity").GetComponent<Text>();
        TxtNowCapacity = transform.FindSonSonSon("TxtNowCapacity").GetComponent<Text>();
        ImgStore = transform.FindSonSonSon("ImgStore").GetComponent<Image>();        

        InitDataInfo();

        ImgStore.alphaHitTestMinimumThreshold = 0.2f;

        TxtMaxWeight.text = "/" + DataCellStore.MaxWeight.ToString();
        TxtNowWeight.text = DataCellStore.NowWeight.ToString();
        TxtMaxCapacity.text = "/" + DataCellStore.MaxCapacity.ToString();
        TxtNowCapacity.text = DataCellStore.NowCapacity.ToString();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellTownStore":                
                PanelItem.Show(this);                
                break;
        }
    }

    public void InitDataInfo()
    {
        switch (DataCellStore.e_PanelCellStorePrefabName)
        {
            case E_SpriteNamePanelCellTownStore.StoreWood:
                DataCellStore.MaxWeight = 50;
                DataCellStore.MaxCapacity = 100;                
                ImgStore.sprite = MgrRes.GetInstance().Load<Sprite>("Art/" + E_SpriteNamePanelCellTownStore.StoreWood.ToString());
                break;

            case E_SpriteNamePanelCellTownStore.StoreIron:
                DataCellStore.MaxWeight = 200;
                DataCellStore.MaxCapacity = 250;
                ImgStore.sprite = MgrRes.GetInstance().Load<Sprite>("Art/" + E_SpriteNamePanelCellTownStore.StoreIron.ToString());
                break;

            case E_SpriteNamePanelCellTownStore.StoreGold:
                DataCellStore.MaxWeight = 70;
                DataCellStore.MaxCapacity = 400;
                ImgStore.sprite = MgrRes.GetInstance().Load<Sprite>("Art/" + E_SpriteNamePanelCellTownStore.StoreGold.ToString());
                break;        
        }
    }
}
