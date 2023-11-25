using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellTownItemGrid : PanelBase             
{
    public int X;
    public int Y;   

    public Image ImgBk;
    public Image ImgStatus;

    public PanelCellItem Item;

    protected override void Awake()
    {
        base.Awake();

        ImgBk = transform.FindSonSonSon("ImgBk").GetComponent<Image>();
        ImgStatus = transform.FindSonSonSon("ImgStatus").GetComponent<Image>();

        ImgBk.alphaHitTestMinimumThreshold = 0.2f;

        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, EventTriggerType.PointerEnter, 
        (param) =>
        {
            Hot.NowItemGrid = this;

            if (Hot.NowCellItem != null && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].X; i2++)
                    {
                        Hot.NowPanelCanStoreItem.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctRed");
                    }
                }
            }
            else
            {
                ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctGreen");
            }
        });
        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.NowItemGrid = null;

            if (Hot.NowCellItem != null && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].X; i2++)
                    {
                        Hot.NowPanelCanStoreItem.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                    }
                }
            }
            else
            {
                ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
            }
        });
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "ImgBk":
                if (Hot.NowCellItem != null && 
                   (Hot.NowCellItem.e_Location != E_ItemLocation.TownShopItem || 
                    Hot.CanBuy || 
                   (Hot.NowCellItem.e_Location == E_ItemLocation.TownShopItem && Hot.e_NowPointerLocation == E_NowPointerLocation.PanelTownShopItem)) &&                     
                    JudgeCanPut())
                {                    
                    for (int i1 = 0; i1 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].Y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].X; i2++)
                        {
                            Hot.NowCellItem.MemberOf.Grids[Hot.NowCellItem.RootGrid.Y + i1][Hot.NowCellItem.RootGrid.X + i2].Item = null;
                        }
                    }

                    for (int i1 = 0; i1 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].Y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].X; i2++)
                        {                            
                            Hot.NowPanelCanStoreItem.Grids[Y + i1][X + i2].Item = Hot.NowCellItem;
                        }
                    }
                    

                    Hot.NowCellItem.MemberOf.ItemRoot[Hot.NowCellItem.RootGrid.Y][Hot.NowCellItem.RootGrid.X].GetChild(0).
                        SetParent(Hot.NowPanelCanStoreItem.ItemRoot[Y][X], false);
                    Hot.NowCellItem.MemberOf.UpdateInfoBySubtract(Hot.NowCellItem.e_SpriteNamePanelCellItem);
                    Hot.NowPanelCanStoreItem.UpdateInfoByAdd(Hot.NowCellItem.e_SpriteNamePanelCellItem);

                    switch (Hot.NowCellItem.e_Location)
                    {                        
                        case E_ItemLocation.TownItem:
                            Hot.DataNowCellGameArchive.ListCellStore[(Hot.NowCellItem.MemberOf as PanelTownItem).PanelCellTownStore_.Index].
                                ListItem[Hot.NowCellItem.RootGrid.Y][Hot.NowCellItem.RootGrid.X].e_SpriteNamePanelCellItem = E_SpriteNamePanelCellItem.None;                            

                            switch (Hot.e_NowPointerLocation)
                            {                                                      
                                //物品在物品栏中移动
                                case E_NowPointerLocation.PanelTownItem:                                    
                                    Hot.DataNowCellGameArchive.ListCellStore[(Hot.NowPanelCanStoreItem as PanelTownItem).PanelCellTownStore_.Index].
                                        ListItem[Y][X].e_SpriteNamePanelCellItem = Hot.NowCellItem.e_SpriteNamePanelCellItem;                                    
                                    break;
                                //卖东西
                                case E_NowPointerLocation.PanelTownShopItem:
                                    Hot.DataNowCellGameArchive.TownShop.ListItem[Y][X].e_SpriteNamePanelCellItem = Hot.NowCellItem.e_SpriteNamePanelCellItem;
                                    Hot.PanelOtherResTable_.Add(Hot.DicItemCost[Hot.NowCellItem.e_SpriteNamePanelCellItem]);                                    
                                    Hot.NowCellItem.e_Location = E_ItemLocation.TownShopItem;
                                    break;                                
                            }
                            break;
                        case E_ItemLocation.TownShopItem:
                            Hot.DataNowCellGameArchive.TownShop.ListItem[Hot.NowCellItem.RootGrid.Y][Hot.NowCellItem.RootGrid.X].e_SpriteNamePanelCellItem = 
                                E_SpriteNamePanelCellItem.None;

                            switch (Hot.e_NowPointerLocation)
                            {
                                //买东西
                                case E_NowPointerLocation.PanelTownItem:
                                    Hot.DataNowCellGameArchive.ListCellStore[(Hot.NowPanelCanStoreItem as PanelTownItem).PanelCellTownStore_.Index].
                                        ListItem[Y][X].e_SpriteNamePanelCellItem = Hot.NowCellItem.e_SpriteNamePanelCellItem;
                                    Hot.PanelOtherResTable_.Subtraction(Hot.DicItemCost[Hot.NowCellItem.e_SpriteNamePanelCellItem]);                                    
                                    Hot.NowCellItem.e_Location = E_ItemLocation.TownItem;
                                    break;
                                //这里按理说是商店内物品在商店内移动的逻辑
                                //但我觉得能动商店里的东西太肏了 所以现不写
                                case E_NowPointerLocation.PanelTownShopItem:
                                    //啊? 什么你居然要移动商店物品 给钱!!!
                                    //给钱逻辑 先不写把 感觉好肏
                                    Hot.DataNowCellGameArchive.TownShop.ListItem[Y][X].e_SpriteNamePanelCellItem = Hot.NowCellItem.e_SpriteNamePanelCellItem;
                                    break;
                            }
                            break;                        
                    }                    

                    Hot.Data_.Save();

                    Hot.NowCellItem.RootGrid = this;
                    Hot.NowCellItem.MemberOf = Hot.NowPanelCanStoreItem;
                }
                break;
        }
    }

    public bool JudgeCanPut()
    {        
        if (Hot.NowPanelCanStoreItem is PanelTownItem)
        {
            if (Y + Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].Y >
                    Hot.DicStoreBody[(Hot.NowPanelCanStoreItem as PanelTownItem).PanelCellTownStore_.e_PanelCellTownStore].Y ||
                X + Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].X >
                    Hot.DicStoreBody[(Hot.NowPanelCanStoreItem as PanelTownItem).PanelCellTownStore_.e_PanelCellTownStore].X)

            {
                return false;
            }            
        }

        if (Hot.NowPanelCanStoreItem is PanelTownShopItem)
        {
            if (Y + Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].Y >
                    Hot.DataNowCellGameArchive.TownShop.Y ||
                X + Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].X >
                    Hot.DataNowCellGameArchive.TownShop.X)
            {
                return false;
            }
        }

        for (int i1 = 0; i1 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].Y; i1++)
        {
            for (int i2 = 0; i2 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].X; i2++)
            {
                if (Hot.NowPanelCanStoreItem.Grids[Y + i1][X + i2].Item == null || Hot.NowPanelCanStoreItem.Grids[Y + i1][X + i2].Item == Hot.NowCellItem)
                {
                    ;
                }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }
}


