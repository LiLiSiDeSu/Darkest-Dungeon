using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelCellExpeditionRolePrepareRoot : PanelBaseCell,
             IPointerEnterHandler, IPointerExitHandler
{
    #region EventSystem

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.NowEnterExpeditionRolePrepareRoot = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.NowEnterExpeditionRolePrepareRoot = null;
    }

    #endregion

    public void Init(int p_index, Transform p_father)
    {
        transform.SetParent(p_father, false);
        Index = p_index;
    }
}
