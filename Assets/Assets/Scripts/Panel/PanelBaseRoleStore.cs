using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelBaseRoleStore : PanelBaseVector2Store,
             IPointerEnterHandler, IPointerExitHandler
{
    public int IndexRole = -1;
    public E_RoleLocation e_RoleLocation = E_RoleLocation.None;

    #region EventSystem

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.e_NowPointerLocation = E_NowPointerLocation.PanelRoleStore;
        Hot.NowPanelCanStoreItem = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.e_NowPointerLocation = E_NowPointerLocation.None;
        Hot.NowPanelCanStoreItem = null;
    }

    #endregion
}
