using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceBase<T> where T : class, new()
{
    private static T instance = new();
    public static T Instance { get { return instance; } }
}
