using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCellTownStore : PanelBase
{
    public int IndexCellCellStore;

    public DataContainer_CellStore DataCellStore = new DataContainer_CellStore();

    public Text TxtWeight;
    public Text TxtCapacity;

    protected override void Start()
    {
        base.Start();
       
        transform.FindSonSonSon("ImgStoreItem").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;

        TxtWeight = transform.FindSonSonSon("TxtWeight").GetComponent<Text>();
        TxtCapacity = transform.FindSonSonSon("TxtCapacity").GetComponent<Text>();

        TxtWeight.text = DataCellStore.Weight.ToString();
        TxtCapacity.text = DataCellStore.Capacity.ToString();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellTownStore":
                MgrUI.GetInstance().ShowPanel<PanelTownStoreItem>(true, "PanelTownStoreItem");
                break;
        }
    }
}
