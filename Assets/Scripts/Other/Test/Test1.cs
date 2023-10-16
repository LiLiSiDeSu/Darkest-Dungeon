using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Test1 : MonoBehaviour
{    
    private void Start()
    {
        string[] cao = Directory.GetFiles(MgrXml.GetInstance().filePath);
        char[] caocao = new char[cao[0].Length];        
        for (int i = 0; i < cao[0].Length; i++)
        {
            caocao[i] = cao[0][i];

            if (caocao[i] == '\\')
            {
                caocao[i] = '/';
            }
        }
        
        string c = "";

        for (int i = 0; i < caocao.Length; i++)
        {
            c += caocao[i];
        }
    }
}
