using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelTownShopItem : PanelBaseVector2Store,
             IPointerEnterHandler, IPointerExitHandler
{        
    protected override void Awake()
    {
        base.Awake();

        AllContent = transform.FindSonSonSon("AllContent");
        ImgBkContent = transform.FindSonSonSon("ImgBkContent");
        ImgItemContent = transform.FindSonSonSon("ImgItemContent");
        ImgStatusContent = transform.FindSonSonSon("ImgStatusContent");        
        ComponentRoot = transform.FindSonSonSon("ComponentRoot");        
    }

    #region EventSystem接口实现

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.NowPanelCanStoreItem = this;
        Hot.e_NowPointerLocation = E_NowPointerLocation.PanelTownShopItem;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.NowPanelCanStoreItem = null;
        Hot.e_NowPointerLocation = E_NowPointerLocation.None;
    }

    #endregion    

    public void InitContent()
    {
        (AllContent as RectTransform).sizeDelta = new Vector2(Hot.DataNowCellGameArchive.TownShop.X * Hot.SizeCellItemBody.x, 
                                                              Hot.DataNowCellGameArchive.TownShop.Y * Hot.SizeCellItemBody.y);

        transform.FindSonSonSon("ImgBkContent").GetComponent<GridLayoutGroup>().constraintCount = Hot.DataNowCellGameArchive.TownShop.X;        
        transform.FindSonSonSon("ImgStatusContent").GetComponent<GridLayoutGroup>().constraintCount = Hot.DataNowCellGameArchive.TownShop.X;

        for (int i1 = 0; i1 < Hot.DataNowCellGameArchive.TownShop.Y; i1++)
        {
            int tempi1 = i1;

            Grids.Add(new());
            ItemRoot.Add(new());

            GameObject obj1 = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep");
            obj1.transform.SetParent(ImgItemContent, false);
            GridLayoutGroup glg = obj1.AddComponent<GridLayoutGroup>();
            glg.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            glg.constraintCount = 1;
            glg.childAlignment = TextAnchor.MiddleCenter;
            glg.cellSize = new Vector2(20, 20);

            for (int i2 = 0; i2 < Hot.DataNowCellGameArchive.TownShop.X; i2++)
            {
                int tempi2 = i2;

                Grids[tempi1].Add(new());

                GameObject obj2 = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep");
                obj2.transform.SetParent(obj1.transform, false);

                ItemRoot[tempi1].Add(obj2.transform);

                Hot.MgrUI_.CreatePanel<PanelCellTownItemGrid>(false, "/PanelCellTownItemGrid",
                (PanelCellTownItemGrid_) =>
                {
                    Grids[tempi1][tempi2] = PanelCellTownItemGrid_;

                    PanelCellTownItemGrid_.transform.SetParent(ComponentRoot, false);
                    PanelCellTownItemGrid_.ImgBk.transform.SetParent(ImgBkContent, false);
                    PanelCellTownItemGrid_.ImgStatus.transform.SetParent(ImgStatusContent, false);

                    PanelCellTownItemGrid_.W = tempi2;
                    PanelCellTownItemGrid_.H = tempi1;
                });
            }
        }

        LoadData();

        ChangeSize();
    }

    public void LoadData()
    {
        for (int i1 = 0; i1 < Hot.DataNowCellGameArchive.TownShop.Y; i1++)
        {
            int tempi1 = i1;

            for (int i2 = 0; i2 < Hot.DataNowCellGameArchive.TownShop.X; i2++)
            {
                int tempi2 = i2;

                if (Hot.DataNowCellGameArchive.TownShop.ListItem[tempi1][tempi2].e_SpriteNamePanelCellItem != E_SpriteNamePanelCellItem.None)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellItem>(false, "/PanelCellItem",
                    (PanelCellItem_) =>
                    {
                        PanelCellItem_.transform.SetParent(ItemRoot[tempi1][tempi2], false);
                        PanelCellItem_.transform.localPosition = Vector3.zero;

                        PanelCellItem_.RootGrid = Grids[tempi1][tempi2];
                        PanelCellItem_.MemberOf = this;
                        PanelCellItem_.e_Location = E_ItemLocation.TownShopItem;
                        PanelCellItem_.e_SpriteNamePanelCellItem =
                            Hot.DataNowCellGameArchive.TownShop.ListItem[tempi1][tempi2].e_SpriteNamePanelCellItem;

                        PanelCellItem_.ImgItem.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + PanelCellItem_.e_SpriteNamePanelCellItem);                        
                        PanelCellItem_.ChangeSize();

                        for (int i1 = 0; i1 < Hot.DicItemBody[PanelCellItem_.e_SpriteNamePanelCellItem].y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.DicItemBody[PanelCellItem_.e_SpriteNamePanelCellItem].x; i2++)
                            {
                                Grids[tempi1 + i1][tempi2 + i2].Item = PanelCellItem_;
                            }
                        }
                    });
                }
            }
        }
    }    

    public void Clear()
    {

    }
}
