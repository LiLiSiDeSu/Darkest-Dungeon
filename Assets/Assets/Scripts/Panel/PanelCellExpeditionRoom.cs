using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellExpeditionRoom : PanelBaseCellVector2,
             IPointerEnterHandler, IPointerExitHandler
{
    public PanelBaseGrid<PanelCellExpeditionRoom> RootGrid = new();

    public E_MapObject e_Obj = E_MapObject.None;

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCellRoomEditor":
                break;
        }
    }

    #region EventSystem

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.NowEnterCellExpeditionRoom = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.NowEnterCellExpeditionRoom = null;
    }

    #endregion

    public void Init(E_MapObject p_e_Obj, PanelBaseGrid<PanelCellExpeditionRoom> p_rootGrid)
    {
        e_Obj = p_e_Obj;
        RootGrid = p_rootGrid;
        transform.SetParent(p_rootGrid.transform, false);

        ImgItem.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + e_Obj);

        ImgItem.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicMapObject[e_Obj].X * Hot.BodySizeGrid.X, Hot.BodyDicMapObject[e_Obj].Y * Hot.BodySizeGrid.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicMapObject[e_Obj].X * Hot.BodySizeGrid.X, Hot.BodyDicMapObject[e_Obj].Y * Hot.BodySizeGrid.Y);
    }
}
