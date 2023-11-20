using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBaseVector2Store : PanelBase
{
    public Transform AllContent;
    public Transform ImgBkContent;
    public Transform ImgStatusContent;
    public Transform ImgItemContent;
    public Transform ComponentRoot;

    public List<List<PanelCellTownItemGrid>> Grids = new();
    public List<List<Transform>> ItemRoot = new();
}
