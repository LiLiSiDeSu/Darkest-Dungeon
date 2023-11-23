using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelTownItem : PanelBaseVector2Store,
             IPointerEnterHandler, IPointerExitHandler
{    
    public InputField IptName;        

    public PanelCellTownStore PanelCellTownStore_;

    protected override void Awake()
    {
        base.Awake();

        AllContent = transform.FindSonSonSon("AllContent");
        ImgBkContent = transform.FindSonSonSon("ImgBkContent");
        ItemContent = transform.FindSonSonSon("ItemContent");
        ImgStatusContent = transform.FindSonSonSon("ImgStatusContent");        
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
        Hot.NowPanelCanStoreItem = this;
        Hot.e_NowPointerLocation = E_NowPointerLocation.PanelTownItem;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.NowPanelCanStoreItem = null;
        Hot.e_NowPointerLocation = E_NowPointerLocation.None;
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

    public override void InitInfo()
    {
        foreach (List<DataContainer_CellItem> listItem2 in Hot.DataNowCellGameArchive.ListCellStore[PanelCellTownStore_.Index].ListItem)
        {
            foreach (DataContainer_CellItem item in listItem2)
            {
                if (item.e_SpriteNamePanelCellItem != E_SpriteNamePanelCellItem.None)
                {
                    NowCapacity += (int)Hot.DicItemBody[item.e_SpriteNamePanelCellItem].x * (int)Hot.DicItemBody[item.e_SpriteNamePanelCellItem].y;                    
                }
            }
        }

        PanelCellTownStore_.TxtCapacity.text = 
            PanelCellTownStore_.PanelCellItem_.NowCapacity + " / " + 
           (int)Hot.DicStoreBody[PanelCellTownStore_.e_PanelCellTownStore].x * 
           (int)Hot.DicStoreBody[PanelCellTownStore_.e_PanelCellTownStore].y;
    }

    public override void UpdateInfoByAdd(E_SpriteNamePanelCellItem e_SpriteNamePanelCellItem)
    {
        NowCapacity += (int)Hot.DicItemBody[e_SpriteNamePanelCellItem].x * (int)Hot.DicItemBody[e_SpriteNamePanelCellItem].y;
        PanelCellTownStore_.TxtCapacity.text = 
            NowCapacity + " / " + (int)Hot.DicStoreBody[PanelCellTownStore_.e_PanelCellTownStore].x * (int)Hot.DicStoreBody[PanelCellTownStore_.e_PanelCellTownStore].y;
    }

    public override void UpdateInfoBySubtract(E_SpriteNamePanelCellItem e_SpriteNamePanelCellItem)
    {
        NowCapacity -= (int)Hot.DicItemBody[e_SpriteNamePanelCellItem].x * (int)Hot.DicItemBody[e_SpriteNamePanelCellItem].y;        
        PanelCellTownStore_.TxtCapacity.text = 
            NowCapacity + " / " + (int)Hot.DicStoreBody[PanelCellTownStore_.e_PanelCellTownStore].x * (int)Hot.DicStoreBody[PanelCellTownStore_.e_PanelCellTownStore].y;
    }

    public void InitContent()
    {
        IptName.text = Hot.DataNowCellGameArchive.ListCellStore[PanelCellTownStore_.Index].Name;

        (AllContent as RectTransform).sizeDelta = 
            new Vector2(Hot.DicStoreBody[PanelCellTownStore_.e_PanelCellTownStore].x * Hot.SizeCellItemBody.x, 
                        Hot.DicStoreBody[PanelCellTownStore_.e_PanelCellTownStore].y * Hot.SizeCellItemBody.y); 

        transform.FindSonSonSon("ImgBkContent").GetComponent<GridLayoutGroup>().constraintCount = (int)Hot.DicStoreBody[PanelCellTownStore_.e_PanelCellTownStore].x;        
        transform.FindSonSonSon("ImgStatusContent").GetComponent<GridLayoutGroup>().constraintCount = (int)Hot.DicStoreBody[PanelCellTownStore_.e_PanelCellTownStore].x;

        for (int i1 = 0; i1 < Hot.DicStoreBody[PanelCellTownStore_.e_PanelCellTownStore].y; i1++)
        {
            int tempi1 = i1;

            Grids.Add(new());
            ItemRoot.Add(new());

            GameObject obj1 = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep");
            obj1.transform.SetParent(ItemContent, false);
            GridLayoutGroup glg = obj1.AddComponent<GridLayoutGroup>();
            glg.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            glg.constraintCount = 1;
            glg.childAlignment = TextAnchor.MiddleCenter;            

            for (int i2 = 0; i2 < Hot.DicStoreBody[PanelCellTownStore_.e_PanelCellTownStore].x; i2++)
            {
                int tempi2 = i2;

                Grids[tempi1].Add(new());                

                GameObject obj2 = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ContentStep");
                obj2.transform.SetParent(obj1.transform, false);

                ItemRoot[tempi1].Add(obj2.transform);

                Hot.MgrUI_.CreatePanel<PanelCellTownItemGrid>(false, "/PanelCellTownItemGrid",
                (PanelCellTownItemGrid_) =>
                {
                    Grids[tempi1][tempi2] = PanelCellTownItemGrid_;

                    PanelCellTownItemGrid_.transform.SetParent(ComponentRoot, false);
                    PanelCellTownItemGrid_.ImgBk.transform.SetParent(ImgBkContent, false);
                    PanelCellTownItemGrid_.ImgStatus.transform.SetParent(ImgStatusContent, false);

                    PanelCellTownItemGrid_.X = tempi2;
                    PanelCellTownItemGrid_.Y = tempi1;
                });
            }
        }

        LoadData();

        ChangeSize();
    }    

    public void LoadData()
    {        
        for (int i1 = 0; i1 < Hot.DicStoreBody[PanelCellTownStore_.e_PanelCellTownStore].y; i1++)
        {
            int tempi1 = i1;

            for (int i2 = 0; i2 < Hot.DicStoreBody[PanelCellTownStore_.e_PanelCellTownStore].x; i2++)
            {
                int tempi2 = i2;

                if (Hot.DataNowCellGameArchive.ListCellStore[PanelCellTownStore_.Index].ListItem[tempi1][tempi2].e_SpriteNamePanelCellItem != E_SpriteNamePanelCellItem.None)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellItem>(false, "/PanelCellItem",
                    (PanelCellItem_) =>
                    {                        
                        PanelCellItem_.transform.SetParent(ItemRoot[tempi1][tempi2], false);
                        PanelCellItem_.transform.localPosition = Vector3.zero;

                        PanelCellItem_.RootGrid = Grids[tempi1][tempi2];
                        PanelCellItem_.MemberOf = this;
                        PanelCellItem_.e_Location = E_ItemLocation.TownItem;
                        PanelCellItem_.e_SpriteNamePanelCellItem =
                            Hot.DataNowCellGameArchive.ListCellStore[PanelCellTownStore_.Index].ListItem[tempi1][tempi2].e_SpriteNamePanelCellItem;

                        PanelCellItem_.ImgItem.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + PanelCellItem_.e_SpriteNamePanelCellItem);

                        PanelCellItem_.ChangeSize();

                        for (int i1 = 0; i1 < Hot.DicItemBody[PanelCellItem_.e_SpriteNamePanelCellItem].y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.DicItemBody[PanelCellItem_.e_SpriteNamePanelCellItem].x; i2++)
                            {                                
                                Grids[tempi1 + i1][tempi2 + i2].Item = PanelCellItem_;
                            }
                        }
                    });
                }
            }
        }        
    }        
}
