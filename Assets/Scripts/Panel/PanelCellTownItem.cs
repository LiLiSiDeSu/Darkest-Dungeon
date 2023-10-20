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
        if (Hot.NowItem == null)
        {
            Hot.NowItem = this;
            Hot.PanelShopCost_.UpdateInfo(Cost);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!Hot.PanelShopCost_.CanBuy || Hot.DragingItem == null)
        {
            Hot.NowItem = null;
            Hot.PanelShopCost_.Clear();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Hot.PanelShopCost_.CanBuy)
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
            Hot.DragingItem = this;
        }        
    }

    public void OnDrag(PointerEventData eventData)
    {                
        if (Hot.PanelShopCost_.CanBuy)
        {
            transform.position = eventData.position + DragOffSet;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Hot.PanelShopCost_.CanBuy)
        {
            ImgItem.raycastTarget = true;

            switch (Hot.e_NowPointerLocation)
            {
                case E_Location.None:
                    switch (e_Location)
                    {
                        case E_Location.PanelTownItem:
                            transform.SetParent(Hot.NowPanelCellTownStore.PanelCellItem_.Content, false);
                            break;
                        case E_Location.PanelTownShopItem:
                            transform.SetParent(Hot.PanelTownShopItem_.Content, false);
                            break;
                    }
                    break;
                case E_Location.PanelTownItem:
                    switch (e_Location)
                    {
                        case E_Location.PanelTownItem:
                            transform.SetParent(Hot.NowPanelCellTownStore.PanelCellItem_.Content, false);
                            break;
                        //买物品
                        case E_Location.PanelTownShopItem:
                            Hot.AddItem(E_Location.PanelTownItem);
                            break;
                    }
                    break;
                case E_Location.PanelTownShopItem:
                    switch (e_Location)
                    {
                        //卖物品
                        case E_Location.PanelTownItem:
                            break;
                        case E_Location.PanelTownShopItem:
                            transform.SetParent(Hot.PanelTownShopItem_.Content, false);
                            break;
                    }
                    Hot.AddItem(E_Location.PanelTownShopItem);
                    break;
            }

            Hot.NowItem = null;
            Hot.PanelShopCost_.Clear();

            Hot.Data_.Save();
            if (Hot.PanelTownStore_.NowPanelCellTownStore != null)
                Hot.NowPanelCellTownStore.PanelCellItem_.SortContent();
            Hot.PanelTownShopItem_.SortContent();
            Hot.DragingItem = null;
        }
    }

    #endregion

    public void InitDataInfo()
    {
        switch (e_SpriteNamePanelCellItem)
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

        Cost = new InfoContainer_Cost
                    (Random.Range(0, 3), Random.Range(0, 3), Random.Range(0, 0), Random.Range(0, 0),
                     Random.Range(0, 12), Random.Range(0, 12), Random.Range(0, 12), Random.Range(0, 12), Random.Range(0, 12));

        ImgItem.sprite = MgrRes.GetInstance().Load<Sprite>("Art/" + e_SpriteNamePanelCellItem.ToString());
    } 
}
