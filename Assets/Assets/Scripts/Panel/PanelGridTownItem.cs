using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelGridTownItem : PanelBaseGrid
{
    public PanelCellItem Item;

    protected override void Awake()
    {
        base.Awake();

        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.NowEnterCellGridItem = this;

            if (Hot.ChoseCellItem != null && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.BodyDicItem[Hot.ChoseCellItem.e_SpriteNamePanelCellItem].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.BodyDicItem[Hot.ChoseCellItem.e_SpriteNamePanelCellItem].X; i2++)
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
            Hot.NowEnterCellGridItem = null;

            if (Hot.ChoseCellItem != null && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.BodyDicItem[Hot.ChoseCellItem.e_SpriteNamePanelCellItem].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.BodyDicItem[Hot.ChoseCellItem.e_SpriteNamePanelCellItem].X; i2++)
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
                if (Hot.ChoseCellItem != null &&
                   (Hot.ChoseCellItem.e_Location != E_ItemLocation.TownShopItem ||
                    Hot.CanBuy ||
                   (Hot.ChoseCellItem.e_Location == E_ItemLocation.TownShopItem && Hot.e_NowPointerLocation == E_NowPointerLocation.PanelTownShopItem)) &&
                    JudgeCanPut())
                {
                    for (int i1 = 0; i1 < Hot.BodyDicItem[Hot.ChoseCellItem.e_SpriteNamePanelCellItem].Y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.BodyDicItem[Hot.ChoseCellItem.e_SpriteNamePanelCellItem].X; i2++)
                        {
                            Hot.ChoseCellItem.MemberOf.Grids[Hot.ChoseCellItem.RootGrid.Y + i1][Hot.ChoseCellItem.RootGrid.X + i2].Item = null;
                        }
                    }

                    for (int i1 = 0; i1 < Hot.BodyDicItem[Hot.ChoseCellItem.e_SpriteNamePanelCellItem].Y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.BodyDicItem[Hot.ChoseCellItem.e_SpriteNamePanelCellItem].X; i2++)
                        {
                            Hot.NowPanelCanStoreItem.Grids[Y + i1][X + i2].Item = Hot.ChoseCellItem;
                        }
                    }


                    Hot.ChoseCellItem.MemberOf.ItemRoot[Hot.ChoseCellItem.RootGrid.Y][Hot.ChoseCellItem.RootGrid.X].GetChild(0).
                        SetParent(Hot.NowPanelCanStoreItem.ItemRoot[Y][X], false);
                    Hot.ChoseCellItem.MemberOf.UpdateInfoBySubtract(Hot.ChoseCellItem.e_SpriteNamePanelCellItem);
                    Hot.NowPanelCanStoreItem.UpdateInfoByAdd(Hot.ChoseCellItem.e_SpriteNamePanelCellItem);

                    switch (Hot.ChoseCellItem.e_Location)
                    {
                        case E_ItemLocation.TownItem:
                            Hot.DataNowCellGameArchive.ListCellStore[(Hot.ChoseCellItem.MemberOf as PanelTownItem).PanelCellTownStore_.Index].
                                ListItem[Hot.ChoseCellItem.RootGrid.Y][Hot.ChoseCellItem.RootGrid.X].e_SpriteNamePanelCellItem = E_SpriteNamePanelCellItem.None;

                            switch (Hot.e_NowPointerLocation)
                            {
                                //物品在物品栏中移动
                                case E_NowPointerLocation.PanelTownItem:
                                    Hot.DataNowCellGameArchive.ListCellStore[(Hot.NowPanelCanStoreItem as PanelTownItem).PanelCellTownStore_.Index].
                                        ListItem[Y][X].e_SpriteNamePanelCellItem = Hot.ChoseCellItem.e_SpriteNamePanelCellItem;
                                    break;
                                //卖东西
                                case E_NowPointerLocation.PanelTownShopItem:
                                    Hot.DataNowCellGameArchive.TownShop.ListItem[Y][X].e_SpriteNamePanelCellItem = Hot.ChoseCellItem.e_SpriteNamePanelCellItem;
                                    Hot.PanelOtherResTable_.Add(Hot.CostDicItem[Hot.ChoseCellItem.e_SpriteNamePanelCellItem]);
                                    Hot.ChoseCellItem.e_Location = E_ItemLocation.TownShopItem;
                                    break;
                            }
                            break;
                        case E_ItemLocation.TownShopItem:
                            Hot.DataNowCellGameArchive.TownShop.ListItem[Hot.ChoseCellItem.RootGrid.Y][Hot.ChoseCellItem.RootGrid.X].e_SpriteNamePanelCellItem =
                                E_SpriteNamePanelCellItem.None;

                            switch (Hot.e_NowPointerLocation)
                            {
                                //买东西
                                case E_NowPointerLocation.PanelTownItem:
                                    Hot.DataNowCellGameArchive.ListCellStore[(Hot.NowPanelCanStoreItem as PanelTownItem).PanelCellTownStore_.Index].
                                        ListItem[Y][X].e_SpriteNamePanelCellItem = Hot.ChoseCellItem.e_SpriteNamePanelCellItem;
                                    Hot.PanelOtherResTable_.Subtraction(Hot.CostDicItem[Hot.ChoseCellItem.e_SpriteNamePanelCellItem]);
                                    Hot.ChoseCellItem.e_Location = E_ItemLocation.TownItem;
                                    break;
                                //这里按理说是商店内物品在商店内移动的逻辑
                                //但我觉得能动商店里的东西太肏了 所以现不写
                                case E_NowPointerLocation.PanelTownShopItem:
                                    //啊? 什么你居然要移动商店物品 给钱!!!
                                    //给钱逻辑 先不写把 感觉好肏
                                    Hot.DataNowCellGameArchive.TownShop.ListItem[Y][X].e_SpriteNamePanelCellItem = Hot.ChoseCellItem.e_SpriteNamePanelCellItem;
                                    break;
                            }
                            break;
                    }

                    Hot.ChoseCellItem.RootGrid = this;
                    Hot.ChoseCellItem.MemberOf = Hot.NowPanelCanStoreItem;
                }
                break;
        }
    }

    public bool JudgeCanPut()
    {
        if (Hot.NowPanelCanStoreItem is PanelTownItem)
        {
            if (Y + Hot.BodyDicItem[Hot.ChoseCellItem.e_SpriteNamePanelCellItem].Y >
                    Hot.BodyDicStore[(Hot.NowPanelCanStoreItem as PanelTownItem).PanelCellTownStore_.e_PanelCellTownStore].Y ||
                X + Hot.BodyDicItem[Hot.ChoseCellItem.e_SpriteNamePanelCellItem].X >
                    Hot.BodyDicStore[(Hot.NowPanelCanStoreItem as PanelTownItem).PanelCellTownStore_.e_PanelCellTownStore].X)

            {
                return false;
            }
        }

        if (Hot.NowPanelCanStoreItem is PanelTownShopItem)
        {
            if (Y + Hot.BodyDicItem[Hot.ChoseCellItem.e_SpriteNamePanelCellItem].Y >
                    Hot.DataNowCellGameArchive.TownShop.Y ||
                X + Hot.BodyDicItem[Hot.ChoseCellItem.e_SpriteNamePanelCellItem].X >
                    Hot.DataNowCellGameArchive.TownShop.X)
            {
                return false;
            }
        }

        for (int i1 = 0; i1 < Hot.BodyDicItem[Hot.ChoseCellItem.e_SpriteNamePanelCellItem].Y; i1++)
        {
            for (int i2 = 0; i2 < Hot.BodyDicItem[Hot.ChoseCellItem.e_SpriteNamePanelCellItem].X; i2++)
            {
                if (Hot.NowPanelCanStoreItem.Grids[Y + i1][X + i2].Item == null || Hot.NowPanelCanStoreItem.Grids[Y + i1][X + i2].Item == Hot.ChoseCellItem)
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


