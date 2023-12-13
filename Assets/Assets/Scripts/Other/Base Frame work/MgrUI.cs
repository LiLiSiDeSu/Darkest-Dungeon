using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MgrUI : InstanceBaseAuto_Mono<MgrUI>
{        
    public Dictionary<string, PanelBase> DicPanel = new();

    public RectTransform UIBaseCanvas;
    public EventSystem UIBaseEventSystem;

    private void Awake()
    {
        GameObject UI = new("UI");
        UI.transform.SetParent(MgrInstance.Instance.Gaming.transform, false);

        MgrRes.GetInstance().LoadAsync<GameObject>("Prefabs" + "/UIBaseCanvas", 
        (obj) =>
        {            
            UIBaseCanvas = obj.transform as RectTransform;
            UIBaseCanvas.gameObject.name = "UIBaseCanvas";
            obj.transform.SetParent(UI.transform);
        });

        UIBaseEventSystem = MgrRes.GetInstance().Load<GameObject>("Prefabs" + "/UIBaseEventSystem").GetComponent<EventSystem>();
        UIBaseEventSystem.gameObject.name = "UIBaseEventSystem";
        UIBaseEventSystem.transform.parent = UI.transform;
    }

    public bool ContainPanel(string panelName)
    {
        return DicPanel.ContainsKey(panelName);
    }

    /// <summary>
    /// 给DicPanel添加panel
    /// </summary>
    /// <param name="panelname">面板名</param>
    /// <param name="panel">面板对象</param>
    public void AddDicPanel(string panelname, PanelBase panel)
    {
        if (!DicPanel.ContainsKey(panelname))
            DicPanel.Add(panelname, panel);
    }

    /// <summary>
    /// 就是简单的创建一个面板 不会加入到PoolNowPanel和PoolEsc
    /// </summary>
    /// <param name="isAddDicPanel">是否要添加到PanelDic里面进行管理</param>   
    /// <typeparam name="T">面板类型</typeparam>
    /// <param name="panelname">面板预设体的名字(名字前要加"/"哦) 
    ///  - 面板要做成Prefabs还要挂载对应的脚本哦</param>    
    /// <param name="callback">回调委托</param>
    public void CreatePanel<T>
    (bool isAddDicPanel, string panelname, UnityAction<T> callback = null)
    where T : PanelBase
    {
        MgrRes.GetInstance().LoadAsync<GameObject>("Prefabs" + panelname, (obj) =>
        {
            //调试用 一般这边报错了就是Prefabs名字和类名不一样
            if (obj == null)
                Debug.Log("Path: Prefabs" + panelname + " is null ---注意\"/\"");

            obj.name = obj.name.Replace("(Clone)", "");

            obj.transform.SetParent(UIBaseCanvas);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;

            T panel = obj.GetComponent<T>();
            
            callback?.Invoke(panel);

            if (isAddDicPanel) DicPanel.Add(obj.name, panel);
        });
    }

    /// <summary>
    /// 创建面板并显示面板 主要用于需要创建并直接显示的面板加入PoolNowPanel
    /// </summary>
    /// <typeparam name="T">面板类型</typeparam>   
    /// <param name="isAddDicPanel">是否要添加到PanelDic里面进行管理</param>   
    /// <param name="panelname">面板预设体的名字(名字前要加"/"哦) 
    ///  - 面板要做成Prefabs还要挂载对应的脚本哦</param>        
    /// <param name="isAddpoolEsc">是否添加到poolEsc来从上到下逐个关闭</param>
    /// <param name="callback">回调委托</param>
    public void CreatePanelAndShow<T>
    (bool isAddDicPanel, string panelname, UnityAction<T> callback = null) 
    where T : PanelBase
    {                  
        MgrRes.GetInstance().LoadAsync<GameObject>("Prefabs" + panelname, (obj) =>
        {
            //调试用 一般这边报错了就是Prefabs名字和类名不一样
            if (obj == null)
                Debug.Log("Path: Prefabs" + panelname + " is null ---注意\"/\"");

            obj.name = obj.name.Replace("(Clone)", "");            

            obj.transform.SetParent(UIBaseCanvas);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;

            T panel = obj.GetComponent<T>();

            callback?.Invoke(panel);            

            if (isAddDicPanel) DicPanel.Add(obj.name, panel);            

            PoolNowPanel.GetInstance().ListNowPanel.Add(obj.name);
        });        
    }

    /// <summary>
    /// 创建面板并添加到缓存池 主要用于需要创建但不需要马上显示的面板    
    /// </summary>
    /// <typeparam name="T">面板的类型</typeparam>
    /// <param name="isAddDicPanel">是否要添加到PanelDic里面进行管理</param>
    /// <param name="panelname">面板预设体的名字(名字前要加"/"哦
    ///  - 面板要做成Prefabs还要挂载对应的脚本哦）</param>        
    /// <param name="isPush">是否要添加到对象池</param>
    /// <param name="Active">添加到缓存池后的状态</param>
    /// <param name="PushObjName">给添加到缓存池的对象取个可爱的名字</param>
    /// <param name="callback">回调委托</param>
    public void CreatePanelAndPush<T>
    (bool isAddDicPanel, string panelname, 
     bool isPush = false, bool Active = false, string PushObjName = "", UnityAction<T> callback = null)
    where T : PanelBase
    {        
        MgrRes.GetInstance().LoadAsync<GameObject>("Prefabs" + panelname, (obj) =>
        {
            //调试用
            if (obj == null)
                Debug.Log("Path: Prefabs" + panelname + " is null ---注意\"/\"");
            obj.name = obj.name.Replace("(Clone)", "");

            T panel = obj.GetComponent<T>();

            callback?.Invoke(panel);

            if (isAddDicPanel) DicPanel.Add(obj.name, panel);

            if (isPush) PoolBuffer.GetInstance().Push(Active, obj, PushObjName);
        });
    }

    /// <summary>
    /// 显示面板
    /// </summary>
    /// <typeparam name="T">面板类型</typeparam>
    /// <param name="isAddpoolEsc">是否添加到poolEsc来从上到下逐个关闭</param>
    /// <param name="panelname">面板名</param>    
    /// <param name="callback">回调委托</param>
    /// <param name="CallBackForPoolEsc">PoolEsc的回调委托</param>
    public void ShowPanel<T>
    (bool isAddpoolEsc, string panelname, UnityAction<T> callback = null) 
    where T : PanelBase
    {
        PoolBuffer.GetInstance().TakeAndGet(panelname).transform.SetParent(UIBaseCanvas, false);
        GetPanel<T>(panelname).transform.localPosition = Vector3.zero;
        GetPanel<T>(panelname).transform.localScale = Vector3.one;

        if (isAddpoolEsc) PoolEsc.GetInstance().ListEsc.Add(panelname);

        PoolNowPanel.GetInstance().ListNowPanel.Add(panelname);

        callback?.Invoke(GetPanel<T>(panelname));
    }

    /// <summary>
    /// 隐藏面板
    /// </summary>
    /// <param name="Active">面板在缓存池的激活状态</param>
    /// <param name="panel">面板对象</param>
    /// <param name="panelname">面板在缓存池中的名字(一般直接gameObject.name)</param>
    public void HidePanel(bool Active, GameObject panel, string panelname)
    {
        PoolBuffer.GetInstance().Push(Active, panel, panelname);
        PoolNowPanel.GetInstance().ListNowPanel.Remove(panelname);    
        if (PoolEsc.GetInstance().ListEsc.Contains(panelname))
            PoolEsc.GetInstance().ListEsc.Remove(panelname);
    }

    /// <summary>
    /// 隐藏所有面板
    /// </summary>
    public void HideAllPanel()
    {
        PoolEsc.GetInstance().HideAllOnly();

        List<string> tempNameList = Hot.PoolNowPanel_.ListNowPanel.ToList<string>();

        foreach (string name in tempNameList)
        {
            Hot.MgrUI_.HidePanel(false, GetPanel<PanelBase>(name).gameObject, name);
        }
    }

    public void DestroyPanel(string panelname, UnityAction callback = null)
    {
        Destroy(DicPanel[panelname].gameObject);
        DicPanel.Remove(panelname);
        callback?.Invoke();
    }

    public T GetPanel<T>(string panelname) where T : PanelBase
    {
        if (DicPanel.ContainsKey(panelname))
            return DicPanel[panelname] as T;
        else
            Debug.Log("--- MgrUI: " + panelname + " is null ---");
        return null;
    }

    public PanelBase GetPanel(string panelname)
    {
        if (DicPanel.ContainsKey(panelname))
            return DicPanel[panelname];
        return null;
    }

    /// <summary>
    /// 给Control添加CustomEvent监听
    /// </summary>
    /// <param name="control">控件对象</param>
    /// <param name="type">事件类型</param>
    /// <param name="callback">回调委托</param>
    public void AddCustomEventListener(GameObject control, EventTriggerType type, UnityAction<BaseEventData> callback)
    {
        EventTrigger trigger = control.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new();
        entry.eventID = type;
        entry.callback.AddListener(callback);
        trigger.triggers.Add(entry);
    }
}
