using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PanelCellTownItem : PanelBase
{    
    public E_SpriteNamePanelCellItem Hot_ESpriteName
    {
        get
        {
            if (e_Location == E_Location.TownShop)
            {
                return GlobalHot.NowCellGameArchive.DataListCellShopItem[Index].e_SpriteNamePanelCellItem;
            }

            return GlobalHot.NowCellGameArchive.DataListCellStore
                   [transform.parent.parent.parent.parent.GetComponent<PanelTownItem>().FatherPanelCellTownStore.Index].
                   DataListCellStoreItem[Index].e_SpriteNamePanelCellItem;
        }
    }

    public int Index;

    public int Weight;
    public int Capacity;

    public E_Location e_Location;

    public InfoContainer_Cost Cost = new InfoContainer_Cost();

    public Image ImgItem;    

    protected override void Start()
    {
        base.Start();

        ImgItem = transform.FindSonSonSon("ImgItem").GetComponent<Image>();

        InitDataInfo();

        ImgItem.alphaHitTestMinimumThreshold = 0.2f;

        MgrUI.GetInstance().AddCustomEventListener
        (gameObject, UnityEngine.EventSystems.EventTriggerType.PointerEnter,
        (panel) =>
        {
            GlobalHot.PanelRoomShop_.PanelShopCost_.UpdateInfo(Cost);
        });
        MgrUI.GetInstance().AddCustomEventListener
        (gameObject, UnityEngine.EventSystems.EventTriggerType.PointerExit,
        (panel) =>
        {
            GlobalHot.PanelRoomShop_.PanelShopCost_.Clear();
        });
    }

    public void InitDataInfo()
    {
        switch (Hot_ESpriteName)
        {
            case E_SpriteNamePanelCellItem.ItemFoodCookie:
                Cost = new InfoContainer_Cost
                    (Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), 
                     Random.Range(0, 1000), Random.Range(0, 1000) ,Random.Range(0, 1000) , Random.Range(0, 1000), Random.Range(0, 1000));
                break;
            case E_SpriteNamePanelCellItem.ItemFoodApple:
                Cost = new InfoContainer_Cost
                    (Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000),
                     Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
                break;
            case E_SpriteNamePanelCellItem.ItemFoodBread:
                Cost = new InfoContainer_Cost
                    (Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000),
                     Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
                break;
            case E_SpriteNamePanelCellItem.ItemFoodRawBeef:
                Cost = new InfoContainer_Cost
                    (Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000),
                     Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
                break;
            case E_SpriteNamePanelCellItem.ItemFoodRawChicken:
                Cost = new InfoContainer_Cost
                    (Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000),
                     Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
                break;
            case E_SpriteNamePanelCellItem.ItemFoodRawMutton:
                Cost = new InfoContainer_Cost
                    (Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000),
                     Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
                break;
            case E_SpriteNamePanelCellItem.ItemFoodRawPotato:
                Cost = new InfoContainer_Cost
                    (Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000),
                     Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
                break;
            case E_SpriteNamePanelCellItem.ItemFoodCookedBeef:
                Cost = new InfoContainer_Cost
                    (Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000),
                     Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
                break;
            case E_SpriteNamePanelCellItem.ItemFoodCoodedChicken:
                Cost = new InfoContainer_Cost
                    (Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000),
                     Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
                break;
            case E_SpriteNamePanelCellItem.ItemFoodCoodedMutton:
                Cost = new InfoContainer_Cost
                    (Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000),
                     Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
                break;
            case E_SpriteNamePanelCellItem.ItemFoodCookedPotato:
                Cost = new InfoContainer_Cost
                    (Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000),
                     Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
                break;
        }

        ImgItem.sprite = MgrRes.GetInstance().Load<Sprite>("Art/" + Hot_ESpriteName.ToString());
    }
}
