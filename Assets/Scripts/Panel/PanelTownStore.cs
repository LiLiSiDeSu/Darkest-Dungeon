using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelTownStore : PanelBase, 
             IPointerEnterHandler, IPointerExitHandler
{
    public int NowIndex = 0;        
    public Transform RootPanelTownItem;
    public Transform Content;

    public List<Transform> ListPanelTownItemSteps;

    public PanelCellTownStore NowPanelCellTownStore = new PanelCellTownStore();    

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>("CertainKeyDown", (key) =>
        {
            if (key == Hot.MgrInput_.PanelTownStore)
            {

                if (Hot.PoolNowPanel_.ListNowPanel.Contains("PanelTownStore"))
                {
                    Hot.MgrUI_.HidePanel
                        (false, Hot.PanelTownStore_.gameObject, "PanelTownStore");
                }
                Hot.MgrUI_.ShowPanel<PanelTownStore>(true, "PanelTownStore", CallBackForPoolEsc: () =>
                {
                    Hot.NowPanelCellTownStore = null;
                });
            }
        });

        Content = transform.FindSonSonSon("Content");
        RootPanelTownItem = transform.FindSonSonSon("RootPanelTownItem");        
    }

    #region EventSystem接口实现

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    #endregion

    public void UpdateContent()
    {
        NowIndex = 0;

        for (int i = 0;  i < Hot.DataNowCellGameArchive.ListCellStore.Count; i++)
        {
            int tempi = i;

            MgrUI.GetInstance().CreatePanelAndPush<PanelCellTownStore>
                             (false, "/PanelCellTownStore", false, false, "PanelCellTownStore",
            (PanelCellTownStore_) =>
            {
                PanelCellTownStore_.transform.SetParent(Content, false);

                MgrUI.GetInstance().CreatePanelAndPush<PanelTownItem>
                                 (false, "/PanelTownItem", false, false, "PanelTownItem",
                (PanelTownItem_) =>
                {
                    GameObject obj = new GameObject(tempi.ToString());
                    ListPanelTownItemSteps.Add(obj.transform);
                    obj.transform.SetParent(RootPanelTownItem, false);
                    PanelTownItem_.transform.SetParent(obj.transform, false);
                    PanelCellTownStore_.PanelCellItem_ = PanelTownItem_;
                    PanelTownItem_.FatherPanelCellTownStore = PanelCellTownStore_;
                    PanelTownItem_.gameObject.name += tempi;
                    PanelTownItem_.UpdateContent();
                });

                PanelCellTownStore_.Index = NowIndex;
                NowIndex++;
            });
        }
    }

    public void Bubbling(int IndexToBubble)
    {
        ListPanelTownItemSteps[IndexToBubble].FindSonSonSon("PanelTownItem" + IndexToBubble).GetComponent<PanelTownItem>().
            FatherPanelCellTownStore.Index = ListPanelTownItemSteps.Count - 1;
        ListPanelTownItemSteps[IndexToBubble].FindSonSonSon("PanelTownItem" + IndexToBubble).transform.SetParent
                (ListPanelTownItemSteps[ListPanelTownItemSteps.Count - 1], false);
        ListPanelTownItemSteps[ListPanelTownItemSteps.Count - 1].
            FindSonSonSon("PanelTownItem" + IndexToBubble).gameObject.name = "PanelTownItem" + (ListPanelTownItemSteps.Count - 1);

        for (int i = IndexToBubble; i < NowIndex - 1; i++)
        {
            ListPanelTownItemSteps[i + 1].FindSonSonSon("PanelTownItem" + (i + 1)).
                GetComponent<PanelTownItem>().FatherPanelCellTownStore.Index = i;
            ListPanelTownItemSteps[i + 1].FindSonSonSon("PanelTownItem" + (i + 1)).transform.SetParent
                (ListPanelTownItemSteps[i], false);
            ListPanelTownItemSteps[i].FindSonSonSon("PanelTownItem" + (i + 1)).gameObject.name = "PanelTownItem" + i;            
        }        
    }

    /// <summary>
    /// 删除Content下的物体 用于重新读档
    /// </summary>
    public void ClearContent()
    {        
        PanelCellTownStore[] all = Content.GetComponentsInChildren<PanelCellTownStore>();
        for (int i = 0; i < all.Length; i++)
        {
            DestroyImmediate(all[i].PanelCellItem_.gameObject);
            DestroyImmediate(all[i].gameObject);
        }
    }

    public void SortContent()
    {
        PanelCellTownStore[] all = transform.GetComponentsInChildren<PanelCellTownStore>();
        for (int i = 0; i < all.Length; i++)
        {
            all[i].Index = i;
        }
    }
}
