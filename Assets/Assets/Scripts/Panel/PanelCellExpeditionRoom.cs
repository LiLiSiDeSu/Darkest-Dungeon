using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellExpeditionRoom : PanelBase,
             IPointerEnterHandler, IPointerExitHandler
{
    public Image ImgCellRoomEditor;
    public Image ImgStatus;

    public PanelGridExpeditionRoom RootGrid = new();

    public E_MapObject e_Obj = E_MapObject.None;

    protected override void Awake()
    {
        base.Awake();

        ImgCellRoomEditor = transform.FindSonSonSon("ImgCellRoomEditor").GetComponent<Image>();
        ImgStatus = transform.FindSonSonSon("ImgStatus").GetComponent<Image>();
    }

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

    public void Init(E_MapObject p_e_Obj, PanelGridExpeditionRoom p_rootGrid)
    {
        e_Obj = p_e_Obj;
        RootGrid = p_rootGrid;
        transform.SetParent(p_rootGrid.transform, false);

        ImgCellRoomEditor.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + p_e_Obj);

        ImgCellRoomEditor.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicMapObject[p_e_Obj].X * Hot.BodySizeGridExpeditionMap.X, Hot.BodyDicMapObject[p_e_Obj].Y * Hot.BodySizeGridExpeditionMap.Y);
        ImgStatus.GetComponent<RectTransform>().sizeDelta =
            new(Hot.BodyDicMapObject[p_e_Obj].X * Hot.BodySizeGridExpeditionMap.X, Hot.BodyDicMapObject[p_e_Obj].Y * Hot.BodySizeGridExpeditionMap.Y);
    }
}
