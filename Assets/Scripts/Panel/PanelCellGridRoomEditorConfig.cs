using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCellGridRoomEditorConfig
{
    public int X;
    public int Y;

    public PanelCellRoomEditor CellRoomEditor;

    public void Init(int x, int y)
    {
        X = x;
        Y = y;
    }
}
