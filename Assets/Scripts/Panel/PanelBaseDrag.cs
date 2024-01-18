using UnityEngine;
using UnityEngine.EventSystems;

public class PanelBaseDrag : PanelBase,
             IDragHandler, IBeginDragHandler, IEndDragHandler
{
    protected Vector2 DragOffSet;

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        DragOffSet = new Vector2(transform.position.x, transform.position.y) - eventData.position;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + DragOffSet;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {

    }
}
