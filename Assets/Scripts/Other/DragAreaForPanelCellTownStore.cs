using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAreaForPanelCellTownStore : MonoBehaviour,
             IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 DragOffSet;        

    public void OnBeginDrag(PointerEventData eventData)
    {
        Hot.PanelTownStore_.Bubbling(transform.parent.GetComponent<PanelTownItem>().FatherPanelCellTownStore.Index);

        if (eventData.selectedObject.name == "BtnDragArea")
            DragOffSet = new Vector2(transform.position.x, transform.position.y) - eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.selectedObject.name == "BtnDragArea")
            transform.position = eventData.position + DragOffSet;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }
}
