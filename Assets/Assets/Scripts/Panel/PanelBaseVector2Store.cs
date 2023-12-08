using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBaseVector2Store : PanelBaseVector2<PanelGridTownItem>
{
    public int NowCapacity = 0;

    public virtual void UpdateInfoByAdd(E_SpriteNamePanelCellItem e_SpriteNamePanelCellItem) { }    

    public virtual void UpdateInfoBySubtract(E_SpriteNamePanelCellItem e_SpriteNamePanelCellItem) { }
}
