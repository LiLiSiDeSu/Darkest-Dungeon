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
    private void Awake()
    {
        int[] c = new int[] { 1, 2, 3, 4};
        int[] b = c;
        c = null;
    }
}
