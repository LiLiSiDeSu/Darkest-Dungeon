using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCellStore : PanelBase
{
    public int IndexCellCellStore;

    public DataContainer_CellStore DataCellStore = new DataContainer_CellStore();

    public Text TxtWeight;
    public Text TxtCapacity;

    protected override void Start()
    {
        base.Start();

        TxtWeight = transform.FindSonSonSon("TxtWeight").GetComponent<Text>();
        TxtCapacity = transform.FindSonSonSon("TxtCapacity").GetComponent<Text>();

        TxtWeight.text = DataCellStore.Weight.ToString();
        TxtCapacity.text = DataCellStore.Capacity.ToString();
    }
}
