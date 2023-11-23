using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelBaseCellDynamicScrollView : PanelBaseCell,
             IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Vector2 DragOffSet;
    public string PrefabsDynamicContentStepSuffix = "";

    public PanelBaseDynamicScrollView Father;    

    protected override void Start()
    {
        base.Start();

        Father = GetComponentInParent<PanelBaseDynamicScrollView>();
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        Father.EnableDetection();

        DragOffSet = new Vector2(transform.position.x, transform.position.y) - eventData.position;
        transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);

        Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep[Index].gameObject.SetActive(false);
        Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep[Index].transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);

        Hot.PaddingContentStep_ =
            Hot.MgrRes_.Load<GameObject>("Prefabs/" + "DynamicContentStepFor" + PrefabsDynamicContentStepSuffix).GetComponent<DynamicContentStep>();
        Hot.PaddingContentStep_.Init(-1);        
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + DragOffSet;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        Father.DisableDetection();

        EndDrag();
    }    

    public virtual void EndDrag()
    {
        
    }    
}
