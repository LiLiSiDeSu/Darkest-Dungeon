using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceBaseAuto_Mono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T GetInstance()
    {
        if (instance == null)
        {
            GameObject obj = new GameObject();            
            obj.name = typeof(T).ToString() + "_Instance";
            instance = obj.AddComponent<T>();
        }

        return instance;
    }
}