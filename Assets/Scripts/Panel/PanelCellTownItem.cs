using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellTownItem : PanelBase, 
             IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{    
    public int Index;

    public int Weight;
    public int Capacity;

    public E_Location e_Location;
    public E_SpriteNamePanelCellItem e_SpriteNamePanelCellItem;

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

        if (Hot.e_NowPointerLocation == e_Location)
        {
            switch (e_Location)
            {
                case E_Location.PanelTownItem:
                    transform.SetParent(Hot.NowPanelTownItem.Content, false);
                    break;
                case E_Location.PanelTownShopItem:
                    transform.SetParent(Hot.PanelTownShopItem_.Content, false);
                    break;
            }
        }
        else
        {
            switch (Hot.e_NowPointerLocation)
            {
                case E_Location.None:
                    switch (e_Location)
                    {
                        case E_Location.PanelTownItem:
                            transform.SetParent(Hot.NowPanelTownItem.Content, false);
                            break;
                        case E_Location.PanelTownShopItem:
                            transform.SetParent(Hot.PanelTownShopItem_.Content, false);
                            break;
                    }
                    break;
                case E_Location.PanelTownItem:
                    Hot.AddItem(E_Location.PanelTownItem);
                    break;
                case E_Location.PanelTownShopItem:
                    Hot.AddItem(E_Location.PanelTownShopItem);
                    break;
            }

            Hot.Data_.Save();
        }        

        Hot.NowPanelTownItem.SortContent();
        Hot.PanelTownShopItem_.SortContent();
        Hot.NowItem = null;
    }

    #endregion

    public void InitDataInfo()
    {
        switch (e_SpriteNamePanelCellItem)
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

        ImgItem.sprite = MgrRes.GetInstance().Load<Sprite>("Art/" + e_SpriteNamePanelCellItem.ToString());
    } 
}
