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

    public DataContainer_CellStore DataCellStore;
    public PanelTownStoreItem PanelItem;

    protected override void Start()
    {
        base.Start();        

        transform.FindSonSonSon("ImgStoreItem").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;

        TxtMaxWeight = transform.FindSonSonSon("TxtMaxWeight").GetComponent<Text>();
        TxtNowWeight = transform.FindSonSonSon("TxtNowWeight").GetComponent<Text>();
        TxtMaxCapacity = transform.FindSonSonSon("TxtMaxCapacity").GetComponent<Text>();
        TxtNowCapacity = transform.FindSonSonSon("TxtNowCapacity").GetComponent<Text>();

        InitDataInfo();

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
            case E_PanelCellStorePrefabName.PanelCellStoreWood:
                DataCellStore.MaxWeight = 50;
                DataCellStore.MaxCapacity = 100;
                break;

            case E_PanelCellStorePrefabName.PanelCellStoreIron:
                DataCellStore.MaxWeight = 200;
                DataCellStore.MaxCapacity = 250;
                break;

            case E_PanelCellStorePrefabName.PanelCellStoreGold:
                DataCellStore.MaxWeight = 70;
                DataCellStore.MaxCapacity = 400;
                break;        
        }
    }
}
