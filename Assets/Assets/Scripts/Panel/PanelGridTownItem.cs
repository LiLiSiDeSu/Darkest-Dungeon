using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelGridTownItem : PanelBaseGrid<PanelCellItem>
{
    protected override void Awake()
    {
        base.Awake();

        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.NowEnterCellGridItem = this;

            if (Hot.ChoseCellItem != null && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.BodyDicItem[Hot.ChoseCellItem.e_Item].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.BodyDicItem[Hot.ChoseCellItem.e_Item].X; i2++)
                    {
                        Hot.NowPanelCanStoreItem.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgCoverTransparenctRed);
                    }
                }
            }
            else
            {
                ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgCoverTransparenctGreen);
            }
        });
        Hot.MgrUI_.AddCustomEventListener(ImgBk.gameObject, EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.NowEnterCellGridItem = null;

            if (Hot.ChoseCellItem != null && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.BodyDicItem[Hot.ChoseCellItem.e_Item].Y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.BodyDicItem[Hot.ChoseCellItem.e_Item].X; i2++)
                    {
                        Hot.NowPanelCanStoreItem.Grids[Y + i1][X + i2].ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                    }
                }
            }
            else
            {
                ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
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
                    for (int i1 = 0; i1 < Hot.BodyDicItem[Hot.ChoseCellItem.e_Item].Y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.BodyDicItem[Hot.ChoseCellItem.e_Item].X; i2++)
                        {
                            Hot.ChoseCellItem.MemberOf.Grids[Hot.ChoseCellItem.RootGrid.Y + i1][Hot.ChoseCellItem.RootGrid.X + i2].Item = null;
                        }
                    }

                    for (int i1 = 0; i1 < Hot.BodyDicItem[Hot.ChoseCellItem.e_Item].Y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.BodyDicItem[Hot.ChoseCellItem.e_Item].X; i2++)
                        {
                            Hot.NowPanelCanStoreItem.Grids[Y + i1][X + i2].Item = Hot.ChoseCellItem;
                        }
                    }


                    Hot.ChoseCellItem.MemberOf.ItemRoot[Hot.ChoseCellItem.RootGrid.Y][Hot.ChoseCellItem.RootGrid.X].GetChild(0).
                        SetParent(Hot.NowPanelCanStoreItem.ItemRoot[Y][X], false);
                    Hot.ChoseCellItem.MemberOf.UpdateInfoByReduce(Hot.ChoseCellItem.e_Item);
                    Hot.NowPanelCanStoreItem.UpdateInfoByAdd(Hot.ChoseCellItem.e_Item);

                    switch (Hot.ChoseCellItem.e_Location)
                    {
                        //TownItem里的物品
                        case E_ItemLocation.PanelTownItem:
                            Hot.DataNowCellGameArchive.ListStore[(Hot.ChoseCellItem.MemberOf as PanelTownItem).PanelCellTownStore_.Index].
                                ListItem[Hot.ChoseCellItem.RootGrid.Y][Hot.ChoseCellItem.RootGrid.X].e_SpriteNamePanelCellItem = E_SpriteNamePanelCellItem.None;
                            switch (Hot.e_NowPointerLocation)
                            {
                                //在TownItem中移动
                                case E_NowPointerLocation.PanelTownItem:
                                    Hot.DataNowCellGameArchive.ListStore[(Hot.NowPanelCanStoreItem as PanelTownItem).PanelCellTownStore_.Index].
                                        ListItem[Y][X].e_SpriteNamePanelCellItem = Hot.ChoseCellItem.e_Item;
                                    break;
                                //卖到TownShop
                                case E_NowPointerLocation.PanelTownShopItem:
                                    Hot.DataNowCellGameArchive.TownShop.ListItem[Y][X].e_SpriteNamePanelCellItem = Hot.ChoseCellItem.e_Item;
                                    Hot.PanelOtherResTable_.Add(Hot.CostDicItem[Hot.ChoseCellItem.e_Item]);
                                    Hot.ChoseCellItem.e_Location = E_ItemLocation.TownShopItem;
                                    break;
                                //放到RoleStore
                                case E_NowPointerLocation.PanelRoleStore:
                                    Hot.DataNowCellGameArchive.ListRole[Hot.PanelRoleDetails_.IndexRole].
                                        ListItem[Y][X].e_SpriteNamePanelCellItem = Hot.ChoseCellItem.e_Item;
                                    Hot.ChoseCellItem.e_Location = E_ItemLocation.PanelRoleStore;
                                    break;
                            }
                            break;
                        //TownShop里的物品
                        case E_ItemLocation.TownShopItem:
                            Hot.DataNowCellGameArchive.TownShop.
                                ListItem[Hot.ChoseCellItem.RootGrid.Y][Hot.ChoseCellItem.RootGrid.X].e_SpriteNamePanelCellItem = E_SpriteNamePanelCellItem.None;
                            switch (Hot.e_NowPointerLocation)
                            {
                                //买到TownItem
                                case E_NowPointerLocation.PanelTownItem:
                                    Hot.DataNowCellGameArchive.ListStore[(Hot.NowPanelCanStoreItem as PanelTownItem).PanelCellTownStore_.Index].
                                        ListItem[Y][X].e_SpriteNamePanelCellItem = Hot.ChoseCellItem.e_Item;
                                    Hot.PanelOtherResTable_.Reduce(Hot.CostDicItem[Hot.ChoseCellItem.e_Item]);
                                    Hot.ChoseCellItem.e_Location = E_ItemLocation.PanelTownItem;
                                    break;
                                //在TownShop内移动的逻辑
                                case E_NowPointerLocation.PanelTownShopItem:
                                    //啊? 什么你居然要移动商店物品 给钱!!!
                                    //给钱逻辑 先不写把 感觉好肏
                                    Hot.DataNowCellGameArchive.TownShop.ListItem[Y][X].e_SpriteNamePanelCellItem = Hot.ChoseCellItem.e_Item;
                                    break;
                                //买到RoleStore
                                case E_NowPointerLocation.PanelRoleStore:
                                    Hot.DataNowCellGameArchive.ListRole[Hot.PanelRoleDetails_.IndexRole].ListItem[Y][X].e_SpriteNamePanelCellItem = Hot.ChoseCellItem.e_Item;
                                    Hot.PanelOtherResTable_.Reduce(Hot.CostDicItem[Hot.ChoseCellItem.e_Item]);
                                    Hot.ChoseCellItem.e_Location = E_ItemLocation.PanelRoleStore;
                                    break;
                            }
                            break;
                        //RoleStore里的物品
                        case E_ItemLocation.PanelRoleStore:
                            Hot.DataNowCellGameArchive.ListRole[Hot.PanelRoleDetails_.IndexRole].
                                ListItem[Hot.ChoseCellItem.RootGrid.Y][Hot.ChoseCellItem.RootGrid.X].e_SpriteNamePanelCellItem = E_SpriteNamePanelCellItem.None;
                            switch (Hot.e_NowPointerLocation)
                            {
                                //放到TownItem
                                case E_NowPointerLocation.PanelTownItem:
                                    Hot.DataNowCellGameArchive.ListStore[(Hot.NowPanelCanStoreItem as PanelTownItem).PanelCellTownStore_.Index].
                                        ListItem[Y][X].e_SpriteNamePanelCellItem = Hot.ChoseCellItem.e_Item;
                                    Hot.ChoseCellItem.e_Location = E_ItemLocation.PanelTownItem;
                                    break;
                                //卖到TownShop里
                                case E_NowPointerLocation.PanelTownShopItem:
                                    Hot.DataNowCellGameArchive.TownShop.ListItem[Y][X].e_SpriteNamePanelCellItem = Hot.ChoseCellItem.e_Item;
                                    Hot.PanelOtherResTable_.Add(Hot.CostDicItem[Hot.ChoseCellItem.e_Item]);
                                    Hot.ChoseCellItem.e_Location = E_ItemLocation.TownShopItem;
                                    break;
                                //在RoleStore里移动
                                case E_NowPointerLocation.PanelRoleStore:
                                    Hot.DataNowCellGameArchive.ListRole[Hot.PanelRoleDetails_.IndexRole].
                                        ListItem[Y][X].e_SpriteNamePanelCellItem = Hot.ChoseCellItem.e_Item;
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
            if (Y + Hot.BodyDicItem[Hot.ChoseCellItem.e_Item].Y >
                    Hot.BodyDicStore[(Hot.NowPanelCanStoreItem as PanelTownItem).PanelCellTownStore_.e_PanelCellTownStore].Y ||
                X + Hot.BodyDicItem[Hot.ChoseCellItem.e_Item].X >
                    Hot.BodyDicStore[(Hot.NowPanelCanStoreItem as PanelTownItem).PanelCellTownStore_.e_PanelCellTownStore].X)

            {
                return false;
            }
        }

        if (Hot.NowPanelCanStoreItem is PanelTownShopItem)
        {
            if (Y + Hot.BodyDicItem[Hot.ChoseCellItem.e_Item].Y >
                    Hot.DataNowCellGameArchive.TownShop.Y ||
                X + Hot.BodyDicItem[Hot.ChoseCellItem.e_Item].X >
                    Hot.DataNowCellGameArchive.TownShop.X)
            {
                return false;
            }
        }

        if (Hot.NowPanelCanStoreItem is PanelBaseRoleStore)
        {
            if (Y + Hot.BodyDicItem[Hot.ChoseCellItem.e_Item].Y >
                    (Hot.NowPanelCanStoreItem as PanelBaseRoleStore).NowRole.ListItem.Count ||
                X + Hot.BodyDicItem[Hot.ChoseCellItem.e_Item].X >
                    (Hot.NowPanelCanStoreItem as PanelBaseRoleStore).NowRole.ListItem[0].Count)
            {
                return false;
            }
        }

        for (int i1 = 0; i1 < Hot.BodyDicItem[Hot.ChoseCellItem.e_Item].Y; i1++)
        {
            for (int i2 = 0; i2 < Hot.BodyDicItem[Hot.ChoseCellItem.e_Item].X; i2++)
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


