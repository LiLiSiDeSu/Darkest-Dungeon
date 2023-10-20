using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveFalseOnAwake : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
