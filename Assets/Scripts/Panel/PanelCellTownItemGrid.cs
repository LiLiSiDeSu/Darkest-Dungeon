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
            if (Hot.NowCellItem != null && JudgeCanPut())
            {
                for (int i1 = 0; i1 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].y; i1++)
                {
                    for (int i2 = 0; i2 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].x; i2++)
                    {
                        (Hot.NowPanelCanStoreItem as PanelTownItem).Grids[H + i1][W + i2].ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
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
                if (Hot.NowCellItem != null && JudgeCanPut() && Hot.NowPanelCanStoreItem is PanelTownItem)
                {
                    for (int i1 = 0; i1 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].x; i2++)
                        {
                            Hot.NowCellItem.PanelTownItem_.Grids[Hot.NowCellItem.RootGrid.H + i1][Hot.NowCellItem.RootGrid.W + i2].Item = null;
                        }
                    }

                    for (int i1 = 0; i1 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].y; i1++)
                    {
                        for (int i2 = 0; i2 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].x; i2++)
                        {                            
                            (Hot.NowPanelCanStoreItem as PanelTownItem).Grids[H + i1][W + i2].Item = Hot.NowCellItem;
                        }
                    }
                    
                    Hot.NowCellItem.PanelTownItem_.ItemRoot[Hot.NowCellItem.RootGrid.H][Hot.NowCellItem.RootGrid.W].GetChild(0).
                        SetParent(Hot.NowPanelCanStoreItem.ItemRoot[H][W], false);

                    Hot.DataNowCellGameArchive.ListCellStore[(Hot.NowCellItem.PanelTownItem_ as PanelTownItem).PanelCellTownStore_.Index].
                        ListItem[Hot.NowCellItem.RootGrid.H][Hot.NowCellItem.RootGrid.W].e_SpriteNamePanelCellItem = E_SpriteNamePanelCellItem.None;
                    Hot.DataNowCellGameArchive.ListCellStore[(Hot.NowPanelCanStoreItem as PanelTownItem).PanelCellTownStore_.Index].
                        ListItem[H][W].e_SpriteNamePanelCellItem = Hot.NowCellItem.e_SpriteNamePanelCellItem;
                    Hot.Data_.Save();

                    Hot.NowCellItem.RootGrid = this;
                    Hot.NowCellItem.PanelTownItem_ = Hot.NowPanelCanStoreItem;
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

            for (int i1 = 0; i1 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].y; i1++)
            {
                for (int i2 = 0; i2 < Hot.DicItemBody[Hot.NowCellItem.e_SpriteNamePanelCellItem].x; i2++)
                {
                    if (Hot.NowPanelCanStoreItem.Grids[H + i1][W + i2].Item == null || Hot.NowPanelCanStoreItem.Grids[H + i1][W + i2].Item == Hot.NowCellItem)
                    {
                        ;
                    }
                    else
                        return false;
                }
            }
        }

        return true;
    }
}


