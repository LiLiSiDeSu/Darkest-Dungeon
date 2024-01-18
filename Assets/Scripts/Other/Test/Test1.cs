using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Test1 : MonoBehaviour
{
    public async void TaskTest()
    {
        await Task.Run(() =>
        {
            Thread.Sleep(2000);
            Debug.Log("cao1");
        });

        Debug.Log("cao2");
    }

    private void Awake()
    {
        TaskTest();

        Debug.Log("cao3");
    }
}
