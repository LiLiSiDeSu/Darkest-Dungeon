using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceBase_Mono<T> : MonoBehaviour where T : MonoBehaviour
{    
    private static T instance;
    public static T Instance { get { return instance; } }    

    #region Life Function

    protected virtual void Awake()
    {        
        instance = this as T;
        gameObject.name = typeof(T).ToString() + "_Instance";        
    }     

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        
    }

    #endregion    
}
