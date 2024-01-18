using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellItem : PanelBaseCellVector2,
             IPointerEnterHandler, IPointerExitHandler
{
    public PanelBaseGrid<PanelCellItem> RootGrid = new();
    public PanelBaseVector2Store MemberOf = new();

    public E_ItemLocation e_Location = E_ItemLocation.None;

    public E_Item e_Item = E_Item.None;

    #region EventSystem

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.PanelTownShopCost_.UpdateInfo(Hot.CostDicItem[e_Item]);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.PanelTownShopCost_.Clear();
    }

    #endregion    

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnItem":
                if (Hot.ChoseCellItem == null)
                {
                    ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgCoverTransparenctGreen);
                    Hot.ChoseCellItem = this;
                }
                else if (Hot.ChoseCellItem != this)
                {
                    Hot.ChoseCellItem.ImgItem.raycastTarget = true;
                    Hot.ChoseCellItem.ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgEmpty);
                    ImgStatus.sprite = Hot.LoadSprite(E_Res.ImgCoverTransparenctGreen);
                    Hot.ChoseCellItem = this;
                }

                Hot.ChoseCellItem.ImgItem.raycastTarget = false;
                break;
        }
    }

    public override void ChangeCellSize()
    {
        base.ChangeCellSize();

        ImgItem.GetComponent<RectTransform>().sizeDelta = new(Hot.BodyDicItem[e_Item].X * Hot.BodyGrid.X, Hot.BodyDicItem[e_Item].Y * Hot.BodyGrid.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta = new(Hot.BodyDicItem[e_Item].X * Hot.BodyGrid.X, Hot.BodyDicItem[e_Item].Y * Hot.BodyGrid.Y);
    }
}
