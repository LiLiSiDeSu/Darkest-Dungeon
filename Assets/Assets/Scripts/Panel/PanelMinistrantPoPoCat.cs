using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelMinistrantPoPoCat : PanelBase, IPointerEnterHandler, IPointerExitHandler
{    
    private Animator AnimatorMinistrantForShop;
    private GameObject BtnOpen;
    private GameObject BtnClose;
    private E_PoPoCatStatus e_PoPoCatStatus;

    protected override void Awake()
    {
        base.Awake();
        
        AnimatorMinistrantForShop = transform.FindSonSonSon("AnimatorMinistrantForShop").GetComponent<Animator>();        
        BtnOpen = transform.FindSonSonSon("BtnOpen").gameObject;
        BtnClose = transform.FindSonSonSon("BtnClose").gameObject;
        transform.FindSonSonSon("ImgOpen").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgClose").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;        

        BtnOpen.SetActive(false);
        BtnClose.SetActive(false);

        e_PoPoCatStatus = E_PoPoCatStatus.Open;
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnOpen":
                e_PoPoCatStatus = E_PoPoCatStatus.Close;
                BtnOpen.SetActive(false);
                BtnClose.SetActive(true);
                break;

            case "BtnClose":
                e_PoPoCatStatus = E_PoPoCatStatus.Open;
                BtnOpen.SetActive(true);
                BtnClose.SetActive(false);
                break;
        }
    }

    #region EventSystem接口函数实现

    public void OnPointerEnter(PointerEventData eventData)
    {
        AnimatorMinistrantForShop.gameObject.SetActive(false);

        switch (e_PoPoCatStatus)
        {
            case E_PoPoCatStatus.Open:                
                BtnOpen.SetActive(true);
                break;
            case E_PoPoCatStatus.Close:                
                BtnClose.SetActive(true);
                break;
        }        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        AnimatorMinistrantForShop.gameObject.SetActive(true);
        BtnOpen.SetActive(false);
        BtnClose.SetActive(false);
    }

    #endregion
}
