using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Test2
{
    public int cao;
    public string caocao;

    public Test2() { }

    public Test2(int cao, string caocao)
    {
        this.cao = cao;
        this.caocao = caocao;
    }
} 

public class Test1 : MonoBehaviour
{    
    private void Start()
    {
        Test2 test= new Test2(3, "123");

        Test2 caocc = new Test2();

        caocc = test;

        test.cao = 222;
        test.caocao = "caocaocaocao";
    }
}
