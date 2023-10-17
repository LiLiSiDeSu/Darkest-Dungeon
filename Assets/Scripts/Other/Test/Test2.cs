using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    private void Start()
    {
        Test1.GetInstance().Init();

        int co = Test1.GetInstance().caocaocaocaocao + 2;

        Debug.Log(co);
    }
}
