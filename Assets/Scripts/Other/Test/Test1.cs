using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Test1 : InstanceBaseAuto_Mono<Test1>
{
    public int caocaocaocaocao;

    protected override void Start()
    {
        base.Start();

        gameObject.SetActive(false);
    }

    public void Init()
    {
        caocaocaocaocao = 1111111111;
        Debug.Log(caocaocaocaocao);
    }
}
