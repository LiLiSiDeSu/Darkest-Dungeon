using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelCellExpeditionMiniMapGrid : PanelBase,
             IPointerEnterHandler, IPointerExitHandler
{
    public int W;
    public int H;

    public bool IsHave;

    public E_CellExpeditionMiniMapHall e_CellExpeditionMiniMapHall = E_CellExpeditionMiniMapHall.None;
    public E_CellExpeditionMiniMapRoom e_CellExpeditionMiniMapRoom = E_CellExpeditionMiniMapRoom.None;

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void Init(int w, int h)
    {
        W = w;
        H = h;
    }
}
