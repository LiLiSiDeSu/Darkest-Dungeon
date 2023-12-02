using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DetectionArea : MonoBehaviour,
             IPointerEnterHandler
{
    public int Index;
    public E_ArrowDirection e_ArrowDirection = E_ArrowDirection.Up;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.CenterEvent_.EventTrigger<int, E_ArrowDirection>("DynamicContentStep", Index, e_ArrowDirection);
    }
}
