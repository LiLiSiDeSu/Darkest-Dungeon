using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellTownItemGrid : PanelBase             
{
    public int W;
    public int H;   

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
                for (int i1 = 0; i1 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].x; i2++)
                    {
                        Hot.NowPanelCanStoreItem.Grids[H + i1][W + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctRed");
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
                for (int i1 = 0; i1 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].x; i2++)
                    {
                        Hot.NowPanelCanStoreItem.Grids[H + i1][W + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
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
                    for (int i1 = 0; i1 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].x; i2++)
                        {
                            Hot.NowCellItem.MemberOf.Grids[Hot.NowCellItem.RootGrid.H + i1][Hot.NowCellItem.RootGrid.W + i2].Item = null;
                        }
                    }

                    for (int i1 = 0; i1 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].x; i2++)
                        {                            
                            Hot.NowPanelCanStoreItem.Grids[H + i1][W + i2].Item = Hot.NowCellItem;
                        }
                    }
                    

                    Hot.NowCellItem.MemberOf.ItemRoot[Hot.NowCellItem.RootGrid.H][Hot.NowCellItem.RootGrid.W].GetChild(0).
                        SetParent(Hot.NowPanelCanStoreItem.ItemRoot[H][W], false);

                    switch (Hot.NowCellItem.e_Location)
                    {                        
                        case E_ItemLocation.TownItem:
                            Hot.DataNowCellGameArchive.ListCellStore[(Hot.NowCellItem.MemberOf as PanelTownItem).PanelCellTownStore_.Index].
                                ListItem[Hot.NowCellItem.RootGrid.H][Hot.NowCellItem.RootGrid.W].e_SpriteNamePanelCellItem = E_SpriteNamePanelCellItem.None;
                            switch (Hot.e_NowPointerLocation)
                            {                                                      
                                //物品在物品栏中移动
                                case E_NowPointerLocation.PanelTownItem:                                    
                                    Hot.DataNowCellGameArchive.ListCellStore[(Hot.NowPanelCanStoreItem as PanelTownItem).PanelCellTownStore_.Index].
                                        ListItem[H][W].e_SpriteNamePanelCellItem = Hot.NowCellItem.e_SpriteNamePanelCellItem;
                                    break;
                                //卖东西
                                case E_NowPointerLocation.PanelTownShopItem:
                                    Hot.DataNowCellGameArchive.TownShop.ListItem[H][W].e_SpriteNamePanelCellItem = Hot.NowCellItem.e_SpriteNamePanelCellItem;
                                    Hot.PanelOtherResTable_.Add(Hot.DicItemCost[Hot.NowCellItem.e_SpriteNamePanelCellItem]);
                                    Hot.NowCellItem.e_Location = E_ItemLocation.TownShopItem;
                                    break;                                
                            }
                            break;
                        case E_ItemLocation.TownShopItem:
                            Hot.DataNowCellGameArchive.TownShop.ListItem[Hot.NowCellItem.RootGrid.H][Hot.NowCellItem.RootGrid.W].e_SpriteNamePanelCellItem = 
                                E_SpriteNamePanelCellItem.None;
                            switch (Hot.e_NowPointerLocation)
                            {
                                //买东西
                                case E_NowPointerLocation.PanelTownItem:
                                    Hot.DataNowCellGameArchive.ListCellStore[(Hot.NowPanelCanStoreItem as PanelTownItem).PanelCellTownStore_.Index].
                                        ListItem[H][W].e_SpriteNamePanelCellItem = Hot.NowCellItem.e_SpriteNamePanelCellItem;
                                    Hot.PanelOtherResTable_.Subtraction(Hot.DicItemCost[Hot.NowCellItem.e_SpriteNamePanelCellItem]);
                                    Hot.NowCellItem.e_Location = E_ItemLocation.TownItem;
                                    break;
                                //这里按理说是商店内物品在商店内移动的逻辑
                                //但我觉得能动商店里的东西太肏了 所以现不写
                                case E_NowPointerLocation.PanelTownShopItem:
                                    //啊? 什么你居然要移动商店物品 给钱!!!
                                    //给钱逻辑 先不写把 感觉好肏
                                    Hot.DataNowCellGameArchive.TownShop.ListItem[H][W].e_SpriteNamePanelCellItem = Hot.NowCellItem.e_SpriteNamePanelCellItem;
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
            if (H + Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].y >
                    Hot.DicStoreBody[(Hot.NowPanelCanStoreItem as PanelTownItem).PanelCellTownStore_.e_PanelCellTownStore].y ||
                W + Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].x >
                    Hot.DicStoreBody[(Hot.NowPanelCanStoreItem as PanelTownItem).PanelCellTownStore_.e_PanelCellTownStore].x)

            {
                return false;
            }            
        }

        if (Hot.NowPanelCanStoreItem is PanelTownShopItem)
        {
            if (H + Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].y >
                    Hot.DataNowCellGameArchive.TownShop.Y ||
                W + Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].x >
                    Hot.DataNowCellGameArchive.TownShop.X)
            {
                return false;
            }
        }

        for (int i1 = 0; i1 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].y; i1++)
        {
            for (int i2 = 0; i2 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].x; i2++)
            {
                if (Hot.NowPanelCanStoreItem.Grids[H + i1][W + i2].Item == null || Hot.NowPanelCanStoreItem.Grids[H + i1][W + i2].Item == Hot.NowCellItem)
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


