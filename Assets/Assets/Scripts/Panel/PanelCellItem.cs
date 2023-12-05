using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellItem : PanelBase,
             IPointerEnterHandler, IPointerExitHandler
{
    public PanelGridTownItem RootGrid = new();
    public PanelBaseVector2Store MemberOf = new();

    public Image ImgItem;
    public Image ImgStatus;

    public E_ItemLocation e_Location = E_ItemLocation.None;

    public E_SpriteNamePanelCellItem e_SpriteNamePanelCellItem = E_SpriteNamePanelCellItem.None;

    protected override void Awake()
    {
        base.Awake();        

        ImgItem = transform.FindSonSonSon("ImgItem").GetComponent<Image>();
        ImgStatus = transform.FindSonSonSon("ImgStatus").GetComponent<Image>();
    }

    #region EventSystem接口实现

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.PanelTownShopCost_.UpdateInfo(Hot.CostDicItem[e_SpriteNamePanelCellItem]);
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
                    ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctGreen");
                    Hot.ChoseCellItem = this;
                }
                else if (Hot.ChoseCellItem != this)
                {
                    Hot.ChoseCellItem.ImgItem.raycastTarget = true;
                    Hot.ChoseCellItem.ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                    ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgCoverTransparenctGreen");
                    Hot.ChoseCellItem = this;
                }

                Hot.ChoseCellItem.ImgItem.raycastTarget = false;
                break;
        }
    }        

    public void ChangeSize()
    {
        ImgItem.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicItem[e_SpriteNamePanelCellItem].X * Hot.BodySizeCellItem.X, Hot.BodyDicItem[e_SpriteNamePanelCellItem].Y * Hot.BodySizeCellItem.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicItem[e_SpriteNamePanelCellItem].X * Hot.BodySizeCellItem.X, Hot.BodyDicItem[e_SpriteNamePanelCellItem].Y * Hot.BodySizeCellItem.Y);
    }
}
