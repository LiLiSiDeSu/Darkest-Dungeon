using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Test1 : MonoBehaviour
{
    GraphicRaycaster raycaster;
    PointerEventData pointerEventData;
    EventSystem eventSystem;

    void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>(); // 获取Canvas上的GraphicRaycaster组件
        eventSystem = GetComponent<EventSystem>(); // 获取Canvas上的EventSystem组件
        pointerEventData = new PointerEventData(eventSystem); // 创建一个PointerEventData对象
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 当玩家点击鼠标左键时
        {
            pointerEventData.position = Input.mousePosition; // 设置射线检测的位置为鼠标位置

            List<RaycastResult> results = new List<RaycastResult>(); // 用于存储射线检测的结果
            raycaster.Raycast(pointerEventData, results); // 进行射线检测

            foreach (RaycastResult result in results)
            {
                // 在这里处理射线检测的结果，比如获取被点击的UI元素并进行相应的处理
                Debug.Log("UI元素被点击了：" + result.gameObject.name);
            }
        }
    }
}
