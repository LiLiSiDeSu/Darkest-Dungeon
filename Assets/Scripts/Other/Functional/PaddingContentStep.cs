using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaddingContentStep : MonoBehaviour,
             IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);        
        gameObject.SetActive(false);        
    }
}
