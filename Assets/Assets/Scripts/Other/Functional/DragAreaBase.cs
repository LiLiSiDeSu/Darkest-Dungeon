using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAreaBase : PanelBaseDrag
{
    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.selectedObject.name == gameObject.name)
        {
            base.OnBeginDrag(eventData);
        }
    }

    public override void OnDrag(PointerEventData eventData)
    {
        if (eventData.selectedObject.name == gameObject.name)
        {
            base.OnDrag(eventData);
        }
    }
}
