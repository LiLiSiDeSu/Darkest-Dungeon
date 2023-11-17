using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelBaseCellDynamicScrollView : PanelBaseCell,
             IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Vector2 DragOffSet;
    public string PrefabsDynamicContentStepSuffix = "";

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        DragOffSet = new Vector2(transform.position.x, transform.position.y) - eventData.position;
        transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);

        Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep[Index].gameObject.SetActive(false);

        Hot.PaddingContentStep_ =
            Hot.MgrRes_.Load<GameObject>("Prefabs/" + "DynamicContentStep" + PrefabsDynamicContentStepSuffix).
            GetComponent<DynamicContentStep>();
        Hot.PaddingContentStep_.Init(-1);
        Hot.NowPanelBaseDynamicScrollView_.EnableDetection();
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + DragOffSet;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        Hot.NowPanelBaseDynamicScrollView_.DisableDetection();

        if (Hot.NowPanelBaseDynamicScrollView_ != null)
        {
            Hot.PaddingContentStep_.transform.SetParent(Hot.NowPanelBaseDynamicScrollView_.Content, false);
            transform.SetParent(Hot.PaddingContentStep_.DependentObjRoot, false);
            transform.localPosition = Vector3.zero;
            DestroyImmediate(Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep[Index].gameObject);
            Hot.NowPanelBaseDynamicScrollView_.SortContent();
        }
        else
        {
            Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep[Index].gameObject.SetActive(true);
            transform.SetParent(Hot.NowPanelBaseDynamicScrollView_.ListDynamicContentStep[Index].DependentObjRoot, false);
            transform.localPosition = Vector3.zero;

            DestroyImmediate(Hot.PaddingContentStep_.gameObject);
            Hot.PaddingContentStep_ = null;
        }        
    }
}
