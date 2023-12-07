using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class PanelBaseDynamicScrollView : PanelBase,
                      IPointerEnterHandler, IPointerExitHandler
{
    public int NowIndex;

    public List<DynamicContentStep> ListDynamicContentStep = new();

    public Transform Content;

    #region EventSystem接口实现

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        Hot.NowPanelBaseDynamicScrollView_ = this;
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        
    }

    #endregion

    public void EnableDetection()
    {
        for (int i = 0; i < ListDynamicContentStep.Count; i++)
        {
            ListDynamicContentStep[i].SetRootDetectionAreaActive(true);
        }
    }

    public void DisableDetection()
    {
        for (int i = 0; i < ListDynamicContentStep.Count; i++)
        {
            ListDynamicContentStep[i].SetRootDetectionAreaActive(false);
        }
    }

    public abstract void InitContent();
    public virtual void Clear() 
    {
        ListDynamicContentStep.Clear();
    }    
    public abstract void SortContent();    
}
