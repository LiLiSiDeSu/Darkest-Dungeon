using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellTownStore : PanelBaseCellDynamicScrollView,
             IPointerEnterHandler, IPointerExitHandler
{    
    public E_PanelCellTownStore e_PanelCellTownStore;

    public PanelTownItem PanelCellItem_ = new();    

    public InputField IptName;
    
    public Text TxtCapacity;

    public Image ImgPanelBk;
    public Image ImgStore;

    public Transform Root;

    protected override void Awake()
    {
        base.Awake();

        PrefabsDynamicContentStepSuffix = "PanelCellTownStore";

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
        Root.transform.localPosition = new Vector3(30, 0 , 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {        
        Root.transform.localPosition = new Vector3(0, 0, 0);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {        
        base.OnBeginDrag(eventData);

        Root.transform.localPosition = new Vector3(0, 0, 0);

        ImgPanelBk.raycastTarget = false;
        ImgStore.raycastTarget = false;

        Hot.PaddingContentStep_.transform.SetParent(Hot.PanelBarTownStore_.Content, false);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        ImgPanelBk.raycastTarget = true;
        ImgStore.raycastTarget = true;
    }

    public override void EndDrag()
    {
        transform.SetParent(Hot.PaddingContentStep_.DependentObjRoot, false);
        transform.localPosition = Vector3.zero;
        DestroyImmediate(Hot.PanelBarTownStore_.ListDynamicContentStep[Index].gameObject);
        Hot.PanelBarTownStore_.SortContent();
        Hot.PaddingContentStep_ = null;
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
                            panel.transform.SetParent(Hot.PanelBarTownStore_.RootPanelTownItem, false);
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
        Hot.DataNowCellGameArchive.ListStore[Index].Name = name;
        IptName.text = name;
        PanelCellItem_.IptName.text = name;
    }

    public void Init()
    {
        IptName.text = Hot.DataNowCellGameArchive.ListStore[Index].Name;
        e_PanelCellTownStore = Hot.DataNowCellGameArchive.ListStore[Index].e_PanelCellTownStore;
        
        InitInfo();
    }

    public void InitInfo()
    {
        ImgStore.sprite = MgrRes.GetInstance().Load<Sprite>
        ("Art/" + e_PanelCellTownStore.ToString());
    }
}
