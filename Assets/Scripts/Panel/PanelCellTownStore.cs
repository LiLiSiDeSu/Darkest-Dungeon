using Palmmedia.ReportGenerator.Core.Reporting.Builders.Rendering;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.AI;
using UnityEngine.UI;
using static UnityEditor.FilePathAttribute;

public class PanelCellTownStore : PanelBase,
             IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int Index;

    public int MaxWeight;
    public int MaxCapacity;

    public Transform Push;

    public Vector2 DragOffSet;

    public Text TxtMaxWeight;    
    public Text TxtMaxCapacity;
    public Text TxtNowWeight;
    public Text TxtNowCapacity;
    public Image ImgStore;
    
    public PanelTownItem PanelCellItem_ = new PanelTownItem();

    protected override void Start()
    {
        base.Start();                

        TxtMaxWeight = transform.FindSonSonSon("TxtMaxWeight").GetComponent<Text>();        
        TxtMaxCapacity = transform.FindSonSonSon("TxtMaxCapacity").GetComponent<Text>();
        TxtNowWeight = transform.FindSonSonSon("TxtNowWeight").GetComponent<Text>();
        TxtNowCapacity = transform.FindSonSonSon("TxtNowCapacity").GetComponent<Text>();
        ImgStore = transform.FindSonSonSon("ImgStore").GetComponent<Image>();

        Push = transform.FindSonSonSon("Push");

        InitDataInfo();

        ImgStore.alphaHitTestMinimumThreshold = 0.2f;

        TxtMaxWeight.text = MaxWeight.ToString();        
        TxtMaxCapacity.text = MaxCapacity.ToString();
        TxtNowWeight.text = Hot.DataNowCellGameArchive.DataListCellStore[Index].NowWeight.ToString();
        TxtNowCapacity.text = Hot.DataNowCellGameArchive.DataListCellStore[Index].NowCapacity.ToString();
    }

    #region EventSystem接口实现

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = Hot.PanelTownStore_.transform;
        DragOffSet = new Vector2(transform.position.x, transform.position.y) - eventData.position;
        Hot.DragingTownStore = this;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + DragOffSet;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(Hot.PanelTownStore_.Content, false);

        Hot.PanelTownStore_.SortContent();

        Hot.DragingTownStore = null;
    }

    #endregion

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellTownStore":                
                PanelCellItem_.Show(this);                
                break;
        }
    }

    public void InitDataInfo()
    {
        switch (Hot.DataNowCellGameArchive.DataListCellStore[Index].e_SpriteNamePanelCellTownStore)
        {
            case E_SpriteNamePanelCellTownStore.StoreWood:
                MaxWeight = 50;
                MaxCapacity = 100;
                break;

            case E_SpriteNamePanelCellTownStore.StoreIron:
                MaxWeight = 200;
                MaxCapacity = 250;                
                break;

            case E_SpriteNamePanelCellTownStore.StoreGold:
                MaxWeight = 70;
                MaxCapacity = 400;                
                break;        
        }

        ImgStore.sprite = MgrRes.GetInstance().Load<Sprite>
        ("Art/" + Hot.DataNowCellGameArchive.DataListCellStore[Index].e_SpriteNamePanelCellTownStore.ToString());
    }
}
