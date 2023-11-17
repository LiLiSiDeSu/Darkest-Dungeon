using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class PanelCellTownStore : PanelBaseCellDynamicScrollView,
             IPointerEnterHandler, IPointerExitHandler
{
    public int MaxWeight;
    public int MaxCapacity;

    public PanelTownItem PanelCellItem_ = new();    

    public Text TxtWeight;
    public Text TxtCapacity;
    public Text TxtName;

    public Image ImgPanelBk;
    public Image ImgStore;

    public Transform Root;

    protected override void Awake()
    {
        base.Awake();

        PrefabsDynamicContentStepSuffix = "ForPanelCellTownStore";

        TxtWeight = transform.FindSonSonSon("TxtWeight").GetComponent<Text>();
        TxtCapacity = transform.FindSonSonSon("TxtCapacity").GetComponent<Text>();
        TxtName = transform.FindSonSonSon("TxtName").GetComponent<Text>();

        ImgPanelBk = transform.FindSonSonSon("ImgPanelBk").GetComponent<Image>();
        ImgStore = transform.FindSonSonSon("ImgStore").GetComponent<Image>();

        Root = transform.FindSonSonSon("Root");

        ImgStore.alphaHitTestMinimumThreshold = 0.2f;
    }

    #region EventSystem接口实现

    public void OnPointerEnter(PointerEventData eventData)
    {
        Root.transform.localPosition = new Vector3(50, 0 , 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Root.transform.localPosition = new Vector3(0, 0, 0);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        ImgPanelBk.raycastTarget = false;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        ImgPanelBk.raycastTarget = true;
    }

    #endregion

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellTownStore":
                break;
        }
    }

    public void Init()
    {
        switch (Hot.DataNowCellGameArchive.ListCellStore[Index].e_SpriteNamePanelCellTownStore)
        {
            case E_PanelCellTownStore.StoreWood:
                MaxWeight = 50;
                MaxCapacity = 100;
                break;

            case E_PanelCellTownStore.StoreIron:
                MaxWeight = 200;
                MaxCapacity = 250;
                break;

            case E_PanelCellTownStore.StoreGold:
                MaxWeight = 70;
                MaxCapacity = 400;
                break;
        }

        ImgStore.sprite = MgrRes.GetInstance().Load<Sprite>
        ("Art/" + Hot.DataNowCellGameArchive.ListCellStore[Index].e_SpriteNamePanelCellTownStore.ToString());

        TxtWeight.text = Hot.DataNowCellGameArchive.ListCellStore[Index].NowWeight + " / " + MaxWeight;
        TxtCapacity.text = Hot.DataNowCellGameArchive.ListCellStore[Index].NowCapacity + " / " + MaxCapacity;
        TxtName.text = Hot.DataNowCellGameArchive.ListCellStore[Index].Name;
    }
}
