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
}
