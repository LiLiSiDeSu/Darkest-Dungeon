using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelTownItem : PanelBase,
             IPointerEnterHandler, IPointerExitHandler
{
    public Transform AllContent;
    public Transform ImgBkContent;
    public Transform ImgStatusContent;
    public Transform ImgItemContent;
    public Transform ComponentRoot;

    public InputField IptName;    

    public List<List<Transform>> DependentObj = new();

    public PanelCellTownStore PanelCellTownStore_;

    protected override void Awake()
    {
        base.Awake();

        AllContent = transform.FindSonSonSon("AllContent");
        ImgBkContent = transform.FindSonSonSon("ImgBkContent");
        ImgStatusContent = transform.FindSonSonSon("ImgStatusContent");
        ImgItemContent = transform.FindSonSonSon("ImgItemContent");
        ComponentRoot = transform.FindSonSonSon("ComponentRoot");

        IptName = transform.FindSonSonSon("IptName").GetComponent<InputField>();

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
        Hot.NowPanelTownItem = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.NowPanelTownItem = null;
    }

    #endregion

    protected override void InputField_OnEndEdit(string controlname, string EventParam)
    {
        base.InputField_OnEndEdit(controlname, EventParam);

        switch (controlname)
        {
            case "IptName":
                PanelCellTownStore_.Rename(EventParam);
                break;
        }
    }

    public void Hide()
    {
        Hot.MgrUI_.HidePanel(false, gameObject, gameObject.name);
    }

    public void Show()
    {
        Hot.MgrUI_.ShowPanel<PanelTownItem>(true, gameObject.name,
        (panel) =>
        {
            panel.transform.SetParent(Hot.PanelTownStore_.RootPanelTownItem, false);
        });
    }

    public void ShowForBtn()
    {
        if (PoolNowPanel.GetInstance().ListNowPanel.Contains(gameObject.name))
            Hide();
        else
            Show();
    }

    public void InitContent()
    {
        IptName.text = Hot.DataNowCellGameArchive.ListCellStore[PanelCellTownStore_.Index].Name;

        (AllContent as RectTransform).sizeDelta = new Vector2(PanelCellTownStore_.Width * 20f, PanelCellTownStore_.Height * 20f);

        transform.FindSonSonSon("ImgBkContent").GetComponent<GridLayoutGroup>().constraintCount = PanelCellTownStore_.Width;
        transform.FindSonSonSon("ImgStatusContent").GetComponent<GridLayoutGroup>().constraintCount = PanelCellTownStore_.Width;

        for (int i1 = 0; i1 < PanelCellTownStore_.Height; i1++)
        {
            int tempi1 = i1;

            GameObject obj1 = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep");
            obj1.transform.SetParent(ImgItemContent, false);
            GridLayoutGroup glg = obj1.AddComponent<GridLayoutGroup>();
            glg.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            glg.constraintCount = 1;
            glg.childAlignment = TextAnchor.MiddleCenter;
            glg.cellSize = new Vector2(20, 20);

            for (int i2 = 0; i2 < PanelCellTownStore_.Width; i2++)
            {
                int tempi2 = i2;

                GameObject obj2 = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep");
                obj2.transform.SetParent(obj1.transform, false);

                Hot.MgrUI_.CreatePanel<PanelCellTownItemGrid>(false, "/PanelCellTownItemGrid",
                (PanelCellTownItemGrid_) =>
                {
                    PanelCellTownItemGrid_.transform.SetParent(ComponentRoot, false);
                    PanelCellTownItemGrid_.ImgBk.transform.SetParent(ImgBkContent, false);
                    PanelCellTownItemGrid_.ImgStatus.transform.SetParent(ImgStatusContent, false);

                    PanelCellTownItemGrid_.W = tempi1;
                    PanelCellTownItemGrid_.H = tempi2;
                    
                    if (Hot.DataNowCellGameArchive.ListCellStore[PanelCellTownStore_.Index].ListItem[tempi1][tempi2].e_SpriteNamePanelCellItem != E_SpriteNamePanelCellItem.None)
                    {
                        Hot.MgrUI_.CreatePanel<PanelCellItem>(false, "/PanelCellItem",
                        (PanelCellItem_) =>
                        {                            
                            PanelCellItem_.transform.SetParent(obj2.transform, false);
                            PanelCellItem_.transform.localPosition = Vector3.zero;

                            PanelCellItem_.RootGrid = PanelCellTownItemGrid_;
                            PanelCellItem_.PanelTownItem_ = this;
                            PanelCellItem_.e_Location = E_Location.TownItem;
                            PanelCellItem_.e_SpriteNamePanelCellItem =
                                Hot.DataNowCellGameArchive.ListCellStore[PanelCellTownStore_.Index].ListItem[tempi1][tempi2].e_SpriteNamePanelCellItem;

                            PanelCellItem_.ImgItem.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + PanelCellItem_.e_SpriteNamePanelCellItem);
                            PanelCellItem_.ChangeItemBody();
                            PanelCellItem_.ChangeSize();
                        });
                    }
                });
            }
        }
    }    

    public void EnableDetection()
    {
        foreach (Image item in ImgBkContent.GetComponentsInChildren<Image>())
        {
            item.raycastTarget = true;
        }
    }

    public void DisableDetection()
    {
        foreach (Image item in ImgBkContent.GetComponentsInChildren<Image>())
        {
            item.raycastTarget = false;
        }
    }

    public void Add()
    {

    }

    public void Reomve()
    {

    }    
}
