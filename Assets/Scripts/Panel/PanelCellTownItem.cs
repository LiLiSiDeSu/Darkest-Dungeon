using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellTownItem : PanelBaseCell, 
             IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{        
    public int Weight;
    public int Capacity;

    public E_Location e_Location;
    public E_SpriteNamePanelCellItem e_SpriteNamePanelCellItem;
    public Image ImgItem;
    public InfoContainer_Cost Cost;    
    private Vector2 DragOffSet;
    
    public PanelBaseItem MemberOf;

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
        if (Hot.DragingItem == null)
        {
            Hot.NowItem = this;
            Hot.PanelShopCost_.UpdateInfo(Cost);
        }        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Hot.DragingItem == null)
        {
            Hot.NowItem = null;
            Hot.PanelShopCost_.Clear();
        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Hot.DragingItem = this;

        if (Hot.PanelShopCost_.CanBuy || Hot.DragingItem.e_Location == E_Location.TownItem)
        {            
            ImgItem.raycastTarget = false;

            switch (e_Location)
            {
                case E_Location.TownItem:
                    transform.parent = Hot.NowPanelItem.transform;
                    break;
                case E_Location.TownShopItem:
                    transform.parent = Hot.PanelTownShopItem_.transform;
                    break;
            }

            DragOffSet = new Vector2(transform.position.x, transform.position.y) - eventData.position;            
        }        
        else
            Hot.DragingItem = null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Hot.DragingItem != null)
        {
            transform.position = eventData.position + DragOffSet;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {        
        if (Hot.DragingItem != null)
        {            
            ImgItem.raycastTarget = true;

            switch (Hot.e_NowPointerLocation)
            {
                case E_NowPointerLocation.None:
                    transform.SetParent(MemberOf.Content, false);
                    break;
                case E_NowPointerLocation.PanelTownItem:
                    switch (e_Location)
                    {
                        case E_Location.TownItem:
                            MemberOf.NowIndex--;
                            Hot.AddItem(E_Location.TownItem);
                            break;
                        //买物品
                        case E_Location.TownShopItem:
                            MemberOf.NowIndex--;
                            Hot.PanelOtherResTable_.Subtraction(Cost);
                            Hot.AddItem(E_Location.TownItem);
                            break;
                    }
                    break;
                case E_NowPointerLocation.PanelTownShopItem:
                    switch (e_Location)
                    {
                        //卖物品
                        case E_Location.TownItem:
                            MemberOf.NowIndex--;
                            Hot.PanelOtherResTable_.Add(Cost);
                            Hot.AddItem(E_Location.TownShopItem);
                            break;
                        case E_Location.TownShopItem:
                            transform.SetParent(Hot.PanelTownShopItem_.Content, false);
                            break;
                    }                    
                    break;
            }

            MemberOf.SortContent();

            if (Hot.NowPanelItem != null)
                MemberOf = Hot.NowPanelItem;
            
            Hot.DragingItem = null;
            Hot.NowItem = null;
            Hot.PanelShopCost_.Clear();

            Hot.Data_.Save();
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
                    (Random.Range(0, 3), Random.Range(0, 3), Random.Range(0, 3), Random.Range(0, 3),
                     Random.Range(0, 3), Random.Range(0, 3), Random.Range(0, 3), Random.Range(0, 3), Random.Range(0, 3));

        ImgItem.sprite = MgrRes.GetInstance().Load<Sprite>("Art/" + e_SpriteNamePanelCellItem.ToString());
    } 
}
