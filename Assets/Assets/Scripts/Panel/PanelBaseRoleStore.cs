using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelBaseRoleStore : PanelBaseVector2Store,
             IPointerEnterHandler, IPointerExitHandler
{
    public int IndexRole = -1;

    public Text TxtCapacity;

    protected override void Awake()
    {
        base.Awake();

        TxtCapacity = transform.FindSonSonSon("TxtCapacity").GetComponent<Text>();
        TxtCapacity.text = "0 / 0";

        Hot.CenterEvent_.AddEventListener("Esc" + "PanelRoleDetails",
        () =>
        {
            IndexRole = -1;
            TxtCapacity.text = "0 / 0";
            NowCapacity = 0;
        });
    }

    #region EventSystem

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.e_NowPointerLocation = E_NowPointerLocation.PanelRoleStore;
        Hot.NowPanelCanStoreItem = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.e_NowPointerLocation = E_NowPointerLocation.None;
        Hot.NowPanelCanStoreItem = null;
    }

    #endregion

    public override void UpdateInfoByAdd(E_Item p_e_Item)
    {
        base.UpdateInfoByAdd(p_e_Item);

        TxtCapacity.text = NowCapacity + " / " + Hot.DataNowCellGameArchive.ListRole[IndexRole].ListItem[0].Count * Hot.DataNowCellGameArchive.ListRole[IndexRole].ListItem.Count;
    }

    public override void UpdateInfoByReduce(E_Item p_e_Item)
    {
        base.UpdateInfoByReduce(p_e_Item);

        TxtCapacity.text = NowCapacity + " / " + Hot.DataNowCellGameArchive.ListRole[IndexRole].ListItem[0].Count * Hot.DataNowCellGameArchive.ListRole[IndexRole].ListItem.Count;
    }

    public void InitTxtCapacity(DataContainer_CellRole Role)
    {
        foreach (List<DataContainer_CellItem> listItem in Role.ListItem)
        {
            foreach (DataContainer_CellItem item in listItem)
            {
                if (item.e_Item != E_Item.None)
                {
                    NowCapacity += Hot.BodyDicItem[item.e_Item].X * Hot.BodyDicItem[item.e_Item].Y;
                }
            }
        }

        TxtCapacity.text = NowCapacity + " / " + Role.ListItem[0].Count * Role.ListItem.Count;
    }

    public void UpdateContent(DataContainer_CellRole Role)
    {
        ClearAll();

        Hot.UpdateOver = false;

        InitGrids(Role.ListItem.Count, Role.ListItem[0].Count);

        LoadData(Role);
    }

    public override void End()
    {
        base.End();

        Hot.UpdateOver = true;
    }

    public void LoadData(DataContainer_CellRole Role)
    {
        for (int i1 = 0; i1 < Role.ListItem.Count; i1++)
        {
            int tempi1 = i1;

            for (int i2 = 0; i2 < Role.ListItem[0].Count; i2++)
            {
                int tempi2 = i2;

                if (Role.ListItem[tempi1][tempi2].e_Item != E_Item.None)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellItem>(false, "/PanelCellItem",
                    (panel) =>
                    {
                        panel.transform.SetParent(ItemRoot[tempi1][tempi2], false);
                        panel.transform.localPosition = new(-20, 20);

                        panel.RootGrid = Grids[tempi1][tempi2];
                        panel.MemberOf = this;
                        panel.e_Location = E_ItemLocation.PanelRoleStore;
                        panel.e_Item = Role.ListItem[tempi1][tempi2].e_Item;

                        panel.ImgItem.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + panel.e_Item);

                        panel.ChangeCellSize();

                        for (int i1 = 0; i1 < Hot.BodyDicItem[panel.e_Item].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicItem[panel.e_Item].X; i2++)
                            {
                                Grids[tempi1 + i1][tempi2 + i2].Item = panel;
                            }
                        }
                    });
                }
            }
        }        
    }
}
