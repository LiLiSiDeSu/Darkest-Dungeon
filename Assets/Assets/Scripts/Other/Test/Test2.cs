using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test2<T> : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log(typeof(T).Name);
    }
}
