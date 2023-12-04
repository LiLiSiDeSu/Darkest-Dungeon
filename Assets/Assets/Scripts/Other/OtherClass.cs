using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public sealed class OtherClass { }

[Serializable]
public class my_Vector2
{
    public int X;
    public int Y;

    public static my_Vector2 m_One
    {
        get { return new(-1, -1); }
    }

    public my_Vector2() 
    {
        X = -1;
        Y = -1;
    }
    public my_Vector2(int X, int Y)
    {
        this.X = X; 
        this.Y = Y;
    }
}
