using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoController : MonoBehaviour
{
    private UnityAction UpdateEvent;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (UpdateEvent != null)
            UpdateEvent.Invoke();        
    }

    public void AddUpadateEventListener(UnityAction function)
    {
        UpdateEvent += function;
    }

    public void RemoveUpdateEventListener(UnityAction function)
    {
        UpdateEvent -= function;
    } 
}
