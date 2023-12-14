using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGridRoomEditorConfig
{
    public int X;
    public int Y;

    public bool IsHave;

    public E_MapObject e_Obj = E_MapObject.None;

    public void Init(int x, int y)
    {
        X = x;
        Y = y;
    }
}
