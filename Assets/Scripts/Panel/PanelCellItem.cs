using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellItem : PanelBase,
             IPointerEnterHandler, IPointerExitHandler
{
    public PanelCellTownItemGrid RootGrid = new();
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
        Hot.PanelShopCost_.UpdateInfo(Hot.DicItemCost[e_SpriteNamePanelCellItem]);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.PanelShopCost_.Clear();
    }

    #endregion    

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

    public void Init()
    {
        ChangeSize();        
    }

    public void ChangeSize()
    {
        ImgItem.GetComponent<RectTransform>().sizeDelta =
            new(Hot.DicItemBody[e_SpriteNamePanelCellItem].x * Hot.SizeCellItemBody.x, Hot.DicItemBody[e_SpriteNamePanelCellItem].y * Hot.SizeCellItemBody.y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta =
            new(Hot.DicItemBody[e_SpriteNamePanelCellItem].x * Hot.SizeCellItemBody.x, Hot.DicItemBody[e_SpriteNamePanelCellItem].y * Hot.SizeCellItemBody.y);
    }    
}
