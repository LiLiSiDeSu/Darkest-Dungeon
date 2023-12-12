using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelTownStore : PanelBaseDynamicScrollView
{    
    public Transform RootPanelTownItem;

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyDown",
        (key) =>
        {
            if (Hot.ChoseCellItem != null && key == Hot.MgrInput_.Mouse1)
            {
                CancelNowChoosedItem();
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.NowPanelCanStoreItem != null)
            {
                if (key == Hot.MgrInput_.Add)
                {
                    Hot.NowPanelCanStoreItem.AllContent.localScale += new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
                }

                if (key == Hot.MgrInput_.Reduce)
                {
                    Hot.NowPanelCanStoreItem.AllContent.localScale -= new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
                }
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyDown", (key) =>
        {
            if (Hot.NowIndexCellGameArchive != -1 && Hot.e_NowPlayerLocation != E_PlayerLocation.OnExpedition && key == Hot.MgrInput_.Tab)
            {
                if (Hot.PoolNowPanel_.ListNowPanel.Contains("PanelTownStore"))
                    Hot.MgrUI_.HidePanel(false, Hot.PanelTownStore_.gameObject, "PanelTownStore");
                else
                    Hot.MgrUI_.ShowPanel<PanelTownStore>(true, "PanelTownStore");
            }
        });

        RootPanelTownItem = transform.FindSonSonSon("RootPanelTownItem");
        Content = transform.FindSonSonSon("TownStoreContent");
    }

    public override void InitContent()
    {
        for (int i1 = 0; i1 < Hot.DataNowCellGameArchive.ListCellStore.Count; i1++)
        {
            int tempi = i1;

            Hot.MgrUI_.CreatePanel<PanelCellTownStore>
            (false, "/PanelCellTownStore", 
            (PanelCellTownStore_) =>
            {
                PanelCellTownStore_.Index = tempi;
                GameObject obj = Hot.MgrRes_.Load<GameObject>("Prefabs/" + "DynamicContentStepFor" + PanelCellTownStore_.PrefabsDynamicContentStepSuffix);
                obj.name = tempi.ToString();
                obj.transform.SetParent(Content, false);
                obj.GetComponent<DynamicContentStep>().Init(tempi);
                PanelCellTownStore_.transform.SetParent(obj.GetComponent<DynamicContentStep>().DependentObjRoot, false);
                ListDynamicContentStep.Add(obj.GetComponent<DynamicContentStep>());
                PanelCellTownStore_.Init();

                Hot.MgrUI_.CreatePanelAndPush<PanelTownItem>
                (true, "/PanelTownItem", true, false, "PanelTownItem" + tempi,
                (PanelTownItem_) =>
                {
                    PanelTownItem_.gameObject.name = "PanelTownItem" + tempi;
                    PanelTownItem_.transform.SetParent(RootPanelTownItem, false);
                    PanelTownItem_.gameObject.SetActive(false);

                    PanelTownItem_.PanelCellTownStore_ = PanelCellTownStore_;
                    PanelCellTownStore_.PanelCellItem_ = PanelTownItem_;                    

                    PanelTownItem_.InitTxtCapacity();
                    PanelTownItem_.InitContent();

                    Hot.CenterEvent_.AddEventListener("Esc" + PanelTownItem_.gameObject.name,
                    () =>
                    {
                        if (Hot.ChoseCellItem != null && Hot.ChoseCellItem.e_Location == E_ItemLocation.PanelTownItem)
                        {
                            Hot.PanelTownStore_.CancelNowChoosedItem();
                        }
                    });
                });
            });
        }        
    }    

    public void CancelNowChoosedItem()
    {
        if (Hot.NowEnterCellGridItem != null)
        {
            for (int i1 = 0; i1 < Hot.BodyDicItem[Hot.ChoseCellItem.e_Item].Y; i1++)
            {
                for (int i2 = 0; i2 < Hot.BodyDicItem[Hot.ChoseCellItem.e_Item].X; i2++)
                {
                    Hot.NowPanelCanStoreItem.Grids[Hot.NowEnterCellGridItem.Y + i1][Hot.NowEnterCellGridItem.X + i2].ImgStatus.sprite =
                        Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
                }
            }
        }

        Hot.ChoseCellItem.ImgStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
        Hot.ChoseCellItem.ImgItem.raycastTarget = true;
        Hot.ChoseCellItem = null;
        Hot.CanBuy = false;        
    }

    public override void Clear()
    {
        foreach (DynamicContentStep item in Content.GetComponentsInChildren<DynamicContentStep>())
        {            
            Hot.MgrUI_.DicPanel.Remove(item.GetComponentInChildren<PanelCellTownStore>().PanelCellItem_.gameObject.name);
            Hot.PoolBuffer_.DicPool.Remove(item.GetComponentInChildren<PanelCellTownStore>().PanelCellItem_.gameObject.name);
            DestroyImmediate(item.GetComponentInChildren<PanelCellTownStore>().PanelCellItem_.gameObject);
            DestroyImmediate(item.gameObject);
        }                
    }
    
    public override void SortContent()
    {
        DynamicContentStep[] allDynamicContentStep = transform.GetComponentsInChildren<DynamicContentStep>();
        List<DynamicContentStep> tempList = new();
        for (int i = 0; i < allDynamicContentStep.Length; i++)
        {
            tempList.Add(allDynamicContentStep[i]);
            tempList[i].SetIndex(i);
            tempList[i].SetIndex(i);
            tempList[i].gameObject.name = i.ToString();
        }
        ListDynamicContentStep = tempList;

        PanelCellTownStore[] all = transform.GetComponentsInChildren<PanelCellTownStore>();
        List<DataContainer_CellTownStore> tempData = new();
        for (int i = 0; i < all.Length; i++)
        {
            tempData.Add(Hot.DataNowCellGameArchive.ListCellStore[all[i].Index]);
            all[i].Index = i;
        }
        Hot.DataNowCellGameArchive.ListCellStore = tempData;
    }
}
