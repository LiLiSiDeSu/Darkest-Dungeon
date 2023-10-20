using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellTownItem : PanelBase, 
             IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{    
    public E_SpriteNamePanelCellItem Hot_ESpriteName
    {
        get
        {
            if (e_Location == E_Location.PanelTownShopItem)
            {
                return Hot.NowCellGameArchive.DataListCellShopItem[Index].e_SpriteNamePanelCellItem;
            }

            return Hot.NowCellGameArchive.DataListCellStore
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
    private Vector2 DragOffSet;

    protected override void Start()
    {
        base.Start();

        ImgItem = transform.FindSonSonSon("ImgItem").GetComponent<Image>();

        InitDataInfo();

        ImgItem.alphaHitTestMinimumThreshold = 0.2f;    
    }

    #region EventSystem接口实现

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.PanelRoomTownShop_.PanelShopCost_.UpdateInfo(Cost);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.PanelRoomTownShop_.PanelShopCost_.Clear();        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ImgItem.raycastTarget = false;

        switch (e_Location)
        {
            case E_Location.PanelTownItem:
                transform.parent = Hot.NowPanelCellTownStore.PanelCellItem_.transform;
                break;
            case E_Location.PanelTownShopItem:
                transform.parent = Hot.PanelRoomTownShop_.PanelTownShopItem_.transform;
                break;            
        }
        DragOffSet = new Vector2(transform.position.x, transform.position.y) - eventData.position;
        Hot.NowItem = this;
    }

    public void OnDrag(PointerEventData eventData)
    {                
        transform.position = eventData.position + DragOffSet;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ImgItem.raycastTarget = true;

        switch (Hot.e_NowPointerLocation)
        {
            case E_Location.None:
                switch (e_Location)
                {                   
                    case E_Location.PanelTownItem:
                        transform.SetParent(Hot.NowPanelTownItem.Content, false);
                        Hot.NowPanelTownItem.SortContent();
                        break;
                    case E_Location.PanelTownShopItem:
                        transform.SetParent(Hot.PanelRoomTownShop_.PanelTownShopItem_.Content, false);
                        Hot.PanelTownShopItem_.SortContent();
                        break;                    
                }
                break;
            case E_Location.PanelTownItem:
                transform.SetParent(Hot.NowPanelTownItem.Content, false);
                Hot.NowPanelTownItem.SortContent();
                break;
            case E_Location.PanelTownShopItem:
                transform.SetParent(Hot.PanelRoomTownShop_.PanelTownShopItem_.Content, false);
                Hot.PanelTownShopItem_.SortContent();
                break;
        }

        Hot.NowItem = null;
    }

    #endregion

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
