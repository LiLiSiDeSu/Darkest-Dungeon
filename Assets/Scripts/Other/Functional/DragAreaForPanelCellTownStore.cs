using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAreaForPanelCellTownStore : MonoBehaviour,
             IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 DragOffSet;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(
        () =>
        {
            transform.parent.GetComponent<PanelTownItem>().Hide();
            transform.parent.GetComponent<PanelTownItem>().Show();
        });
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent.GetComponent<PanelTownItem>().Hide();
        transform.parent.GetComponent<PanelTownItem>().Show();

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
