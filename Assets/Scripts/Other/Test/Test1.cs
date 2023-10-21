using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Test1 : MonoBehaviour
{
    private void Update()
    {
        Graphic[] all = GetComponentsInChildren<Graphic>();
        for (int i = 0; i < all.Length; i++)
        {
            Debug.Log(all[i].gameObject.name);
        }
    }
}
