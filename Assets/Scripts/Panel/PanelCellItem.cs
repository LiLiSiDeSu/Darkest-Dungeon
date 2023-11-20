using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCellItem : PanelBase
{
    public PanelCellTownItemGrid RootGrid = new();
    public PanelBaseVector2Store PanelTownItem_;

    public InfoContainer_Cost Cost;

    public Image ImgItem;
    public Image ImgStatus;          

    public E_Location e_Location = E_Location.None;

    public E_SpriteNamePanelCellItem e_SpriteNamePanelCellItem = E_SpriteNamePanelCellItem.None;

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyDown", 
        (key) =>
        {
            if (Hot.NowCellItem != null && key == Hot.MgrInput_.Cancel)
            {
                Hot.NowCellItem.ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                Hot.NowCellItem.ImgItem.raycastTarget = true;
                Hot.NowCellItem = null;                
            }
        });

        ImgItem = transform.FindSonSonSon("ImgItem").GetComponent<Image>();
        ImgStatus = transform.FindSonSonSon("ImgStatus").GetComponent<Image>();
    }    

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnItem":
                if (Hot.NowCellItem == null)
                {
                    ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctGreen");
                    Hot.NowCellItem = this;
                }
                else if (Hot.NowCellItem != this)
                {
                    Hot.NowCellItem.ImgItem.raycastTarget = true;
                    Hot.NowCellItem.ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                    ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctGreen");
                    Hot.NowCellItem = this;
                }

                Hot.NowCellItem.ImgItem.raycastTarget = false;
                break;
        }
    }

    public void ChangeItemBody()
    {
        ImgItem.GetComponent<RectTransform>().sizeDelta = 
            new (Hot.DicItemBody[e_SpriteNamePanelCellItem].x * Hot.SizeCellItemBody.x, Hot.DicItemBody[e_SpriteNamePanelCellItem].y * Hot.SizeCellItemBody.y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta =
            new(Hot.DicItemBody[e_SpriteNamePanelCellItem].x * Hot.SizeCellItemBody.x, Hot.DicItemBody[e_SpriteNamePanelCellItem].y * Hot.SizeCellItemBody.y);
    }

    public void ChangeSize()
    {        
        RootGrid.ImgBk.GetComponent<RectTransform>().sizeDelta = Hot.SizeCellItemBody;
        RootGrid.ImgStatus.GetComponent<RectTransform>().sizeDelta = Hot.SizeCellItemBody;

        (PanelTownItem_ as PanelTownItem).ImgBkContent.GetComponent<GridLayoutGroup>().cellSize = Hot.SizeCellItemBody;
        (PanelTownItem_ as PanelTownItem).ImgItemContent.GetComponent<GridLayoutGroup>().cellSize = Hot.SizeCellItemBody;        
        (PanelTownItem_ as PanelTownItem).ImgStatusContent.GetComponent<GridLayoutGroup>().cellSize = Hot.SizeCellItemBody;

        foreach (GridLayoutGroup item in (PanelTownItem_ as PanelTownItem).ImgItemContent.GetComponentsInChildren<GridLayoutGroup>())
        {
            item.cellSize = Hot.SizeCellItemBody;
        }
    }

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
    }
}
