using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Test1 : MonoBehaviour
{
    private void Update()
    {
        Debug.Log(PoolBuffer.GetInstance().DicPool["PanelOhterResTable"][0].name);
    }
}
