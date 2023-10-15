using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PanelCellTownItem : PanelBase
{    
    public int IndexPanelCellItem;

    public int Weight;
    public int Capacity;

    public Image ImgItem;

    public DataContainer_PanelCellItem DataPanelCellTownItem;

    protected override void Start()
    {
        base.Start();

        ImgItem = transform.FindSonSonSon("ImgItem").GetComponent<Image>();

        InitDataInfo();

        ImgItem.alphaHitTestMinimumThreshold = 0.2f;
    }

    public void InitDataInfo()
    {
        switch (DataPanelCellTownItem.e_SpriteNamePanelCellItem)
        {
            case E_SpriteNamePanelCellItem.ItemFoodCookie:                
                break;
            case E_SpriteNamePanelCellItem.ItemFoodApple:
                break;
            case E_SpriteNamePanelCellItem.ItemFoodBread:
                break;
            case E_SpriteNamePanelCellItem.ItemFoodRawBeef:
                break;
            case E_SpriteNamePanelCellItem.ItemFoodRawChicken:
                break;
            case E_SpriteNamePanelCellItem.ItemFoodRawMutton:
                break;
            case E_SpriteNamePanelCellItem.ItemFoodRawPotato:
                break;
            case E_SpriteNamePanelCellItem.ItemFoodCookedBeef:
                break;
            case E_SpriteNamePanelCellItem.ItemFoodCoodedChicken:
                break;
            case E_SpriteNamePanelCellItem.ItemFoodCoodedMutton:
                break;
            case E_SpriteNamePanelCellItem.ItemFoodCookedPotato:
                break;
        }

        ImgItem.sprite = MgrRes.GetInstance().Load<Sprite>("Art/" + DataPanelCellTownItem.e_SpriteNamePanelCellItem.ToString());
    }
}
