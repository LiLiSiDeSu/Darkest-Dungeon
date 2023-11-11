using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellExpeditionMap : PanelBase,
             IPointerEnterHandler, IPointerExitHandler
{
    public int h;
    public int w;

    public Image ImgClick;
    public Image ImgMask;    

    public Transform RootObj;     

    protected override void Awake()
    {
        base.Awake();

        ImgClick = transform.FindSonSonSon("ImgClick").GetComponent<Image>();        
        ImgMask = transform.FindSonSonSon("ImgMask").GetComponent<Image>();

        RootObj = transform.FindSonSonSon("RootObj");
    }

    #region EventSystem接口实现

    public void OnPointerEnter(PointerEventData eventData)
    {
        ImgClick.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgGreen");        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ImgClick.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + "ImgEmpty");
    }

    #endregion

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnClick":
                Debug.Log(h + " - " + w);
                break;
        }
    }
}
