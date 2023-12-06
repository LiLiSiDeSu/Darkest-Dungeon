using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAreaBase : MonoBehaviour,
             IBeginDragHandler, IDragHandler, IEndDragHandler
{
    protected Vector2 DragOffSet;

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.selectedObject.name == gameObject.name)
            DragOffSet = new Vector2(transform.position.x, transform.position.y) - eventData.position;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        if (eventData.selectedObject.name == gameObject.name)
            transform.position = eventData.position + DragOffSet;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {

    }
}
