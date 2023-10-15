using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Test1 : MonoBehaviour
{
    public List<UnityAction> cao = new List<UnityAction>();

    private void Start()
    {
        cao.Add(null);
        cao.Add(null);
        cao.Add(null);
        cao.Add(null);
        cao.Add(null);
        cao.Add(null);
        cao.Add(() => { });
        Debug.Log(cao.Count);
        cao[0]?.Invoke();
    }
}
