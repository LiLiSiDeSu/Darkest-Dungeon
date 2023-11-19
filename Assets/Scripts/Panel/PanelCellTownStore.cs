using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellTownStore : PanelBaseCellDynamicScrollView,
             IPointerEnterHandler, IPointerExitHandler
{
    public int Width;
    public int Height;

    public PanelTownItem PanelCellItem_ = new();    

    public InputField IptName;
    
    public Text TxtCapacity;    

    public Image ImgPanelBk;
    public Image ImgStore;

    public Transform Root;

    protected override void Awake()
    {
        base.Awake();

        PrefabsDynamicContentStepSuffix = "ForPanelCellTownStore";      

        IptName = transform.FindSonSonSon("IptName").GetComponent<InputField>();
        
        TxtCapacity = transform.FindSonSonSon("TxtCapacity").GetComponent<Text>();        

        ImgPanelBk = transform.FindSonSonSon("ImgPanelBk").GetComponent<Image>();
        ImgStore = transform.FindSonSonSon("ImgStore").GetComponent<Image>();

        Root = transform.FindSonSonSon("Root");

        ImgStore.alphaHitTestMinimumThreshold = 0.2f;

        Hot.MgrUI_.AddCustomEventListener(IptName.gameObject, EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.MgrInput_.OpenOrCloseCheck(false);
        });
        Hot.MgrUI_.AddCustomEventListener(IptName.gameObject, EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.MgrInput_.OpenOrCloseCheck(true);
        });
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
                switch (Hot.PoolNowPanel_.ContainPanel(PanelCellItem_.gameObject.name))
                {
                    case true:
                        Hot.MgrUI_.HidePanel(false, PanelCellItem_.gameObject, PanelCellItem_.gameObject.name);
                        break;
                    case false:
                        Hot.MgrUI_.ShowPanel<PanelTownItem>(true, PanelCellItem_.gameObject.name,
                        (panel) =>
                        {
                            panel.transform.SetParent(Hot.PanelTownStore_.RootPanelTownItem, false);
                        });
                        break;
                }
                break;
        }
    }    

    protected override void InputField_OnEndEdit(string controlname, string EventParam)
    {
        base.InputField_OnEndEdit(controlname, EventParam);
        
        switch (controlname)
        {
            case "IptName":
                Rename(EventParam); 
                break;
        }
    }   

    public void Rename(string name)
    {
        Hot.DataNowCellGameArchive.ListCellStore[Index].Name = name;
        Hot.Data_.Save();
    }

    public void Init()
    {
        IptName.text = Hot.DataNowCellGameArchive.ListCellStore[Index].Name;

        InitInfo();
    }

    public void InitInfo()
    {
        switch (Hot.DataNowCellGameArchive.ListCellStore[Index].e_SpriteNamePanelCellTownStore)
        {
            case E_PanelCellTownStore.StoreWood:
                Width = 10;
                Height = 5;
                break;

            case E_PanelCellTownStore.StoreIron:
                Width = 12;
                Height = 10;
                break;

            case E_PanelCellTownStore.StoreGold:
                Width = 15;
                Height = 13;
                break;
        }

        ImgStore.sprite = MgrRes.GetInstance().Load<Sprite>
        ("Art/" + Hot.DataNowCellGameArchive.ListCellStore[Index].e_SpriteNamePanelCellTownStore.ToString());
    }
}
