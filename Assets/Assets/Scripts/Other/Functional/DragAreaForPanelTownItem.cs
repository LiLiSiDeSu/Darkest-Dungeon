using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAreaForPanelTownItem : DragAreaBase,
             IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(
        () =>
        {
            transform.parent.GetComponent<PanelTownItem>().Hide();
            transform.parent.GetComponent<PanelTownItem>().Show();
        });
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent.GetComponent<PanelTownItem>().Hide();
        transform.parent.GetComponent<PanelTownItem>().Show();

        base.OnBeginDrag(eventData);
    }
}
