using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

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
    public bool ContainPanel(E_PanelName p_e_PanelName)
    {
        return DicPanel.ContainsKey(p_e_PanelName.ToString());
    }

    /// <summary>
    /// 给DicPanel添加panel
    /// </summary>
    /// <param name="panelname">面板名</param>
    /// <param name="panel">面板对象</param>
    public void AddDicPanel(string panelname, PanelBase panel)
    {
        if (!DicPanel.ContainsKey(panelname))
        {
            DicPanel.Add(panelname, panel);
        }
    }

    /// <summary>
    /// 就是简单的创建一个面板 不会加入到PoolNowPanel和PoolEsc
    /// </summary>
    /// <param name="isAddDicPanel">是否要添加到PanelDic里面进行管理</param>   
    /// <typeparam name="T">面板类型</typeparam>
    /// <param name="p_e_PanelName">面板预设体的枚举</param>    
    /// <param name="callback">回调委托</param>
    public void CreatePanel<T>
    (bool isAddDicPanel, E_PanelName p_e_PanelName, UnityAction<T> callback = null)
    where T : PanelBase
    {
        string panelName = "/" + p_e_PanelName.ToString();

        MgrRes.GetInstance().LoadAsync<GameObject>("Prefabs" + panelName, (obj) =>
        {
            //调试用 一般这边报错了就是Prefabs名字和类名不一样
            if (obj == null)
            {
                Debug.Log("Path: Prefabs" + panelName + " is null ---注意\"/\"");
            }

            obj.name = obj.name.Replace("(Clone)", "");

            obj.transform.SetParent(UIBaseCanvas);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;

            T panel = obj.GetComponent<T>();

            callback?.Invoke(panel);

            if (isAddDicPanel)
            {
                DicPanel.Add(obj.name, panel);
            }
        });
    }

    /// <summary>
    /// 创建面板并显示面板 主要用于需要创建并直接显示的面板加入PoolNowPanel
    /// </summary>
    /// <typeparam name="T">面板类型</typeparam>   
    /// <param name="isAddDicPanel">是否要添加到PanelDic里面进行管理</param>   
    /// <param name="p_e_PanelName">面板预设体的枚举</param>        
    /// <param name="isAddpoolEsc">是否添加到poolEsc来从上到下逐个关闭</param>
    /// <param name="callback">回调委托</param>
    public void CreatePanelAndShow<T>
    (bool isAddDicPanel, E_PanelName p_e_PanelName, bool isAddpoolEsc, UnityAction<T> callback = null)
    where T : PanelBase
    {
        string panelName = "/" + p_e_PanelName.ToString();

        MgrRes.GetInstance().LoadAsync<GameObject>("Prefabs" + panelName, (obj) =>
        {
            //调试用 一般这边报错了就是Prefabs名字和类名不一样
            if (obj == null)
            {
                Debug.Log("Path: Prefabs" + panelName + " is null ---注意\"/\"");
            }

            obj.name = obj.name.Replace("(Clone)", "");

            obj.transform.SetParent(UIBaseCanvas);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;

            T panel = obj.GetComponent<T>();

            callback?.Invoke(panel);

            if (isAddDicPanel)
            {
                DicPanel.Add(obj.name, panel);
            }
            if (isAddpoolEsc)
            {
                PoolEsc.GetInstance().ListEsc.Add(obj.name);
            }

            PoolNowPanel.GetInstance().ListNowPanel.Add(obj.name);
        });
    }

    /// <summary>
    /// 创建面板并添加到缓存池 主要用于需要创建但不需要马上显示的面板    
    /// </summary>
    /// <typeparam name="T">面板的类型</typeparam>
    /// <param name="p_isAddDicPanel">是否要添加到PanelDic里面进行管理</param>
    /// <param name="p_e_PanelName">面板预设体的枚举</param>        
    /// <param name="p_isPush">是否要添加到对象池</param>
    /// <param name="p_active">添加到缓存池后的状态</param>
    /// <param name="p_pushObjName">给添加到缓存池的对象取个可爱的名字</param>
    /// <param name="p_callback">回调委托</param>
    public void CreatePanelAndPush<T>
    (bool p_isAddDicPanel, E_PanelName p_e_PanelName,
     bool p_isPush = false, bool p_active = false, UnityAction<T> p_callback = null, string p_pushObjName = "")
    where T : PanelBase
    {
        if (p_pushObjName == "")
        {
            p_pushObjName = p_e_PanelName.ToString();
        }

        MgrRes.GetInstance().LoadAsync<GameObject>("Prefabs/" + p_e_PanelName, (obj) =>
        {
            //调试用
            if (obj == null)
            {
                Debug.Log("Path: Prefabs" + p_pushObjName + " is null ---注意\"/\"");
            }

            obj.name = p_pushObjName;

            T panel = obj.GetComponent<T>();

            p_callback?.Invoke(panel);

            if (p_isAddDicPanel)
            {
                DicPanel.Add(obj.name, panel);
            }
            if (p_isPush)
            {
                PoolBuffer.GetInstance().Push(p_active, obj, obj.name);
            }
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

        if (isAddpoolEsc)
        {
            PoolEsc.GetInstance().ListEsc.Add(panelname);
        }

        PoolNowPanel.GetInstance().ListNowPanel.Add(panelname);

        callback?.Invoke(GetPanel<T>(panelname));
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
    (bool isAddpoolEsc, E_PanelName p_e_PanelName, UnityAction<T> callback = null)
    where T : PanelBase
    {
        string panelName = p_e_PanelName.ToString();

        PoolBuffer.GetInstance().TakeAndGet(panelName).transform.SetParent(UIBaseCanvas, false);
        GetPanel<T>(panelName).transform.localPosition = Vector3.zero;
        GetPanel<T>(panelName).transform.localScale = Vector3.one;

        if (isAddpoolEsc)
        {
            PoolEsc.GetInstance().ListEsc.Add(panelName);
        }

        PoolNowPanel.GetInstance().ListNowPanel.Add(panelName);

        callback?.Invoke(GetPanel<T>(panelName));
    }

    /// <summary>
    /// 隐藏面板
    /// </summary>
    /// <param name="Active">面板在缓存池的激活状态</param>
    /// <param name="panel">面板的GameObject</param>
    /// <param name="panelname">面板在缓存池中的名字(一般直接gameObject.name)</param>
    public void HidePanel(bool Active, GameObject panel, string panelname)
    {
        PoolBuffer.GetInstance().Push(Active, panel, panelname);
        PoolNowPanel.GetInstance().ListNowPanel.Remove(panelname);

        if (PoolEsc.GetInstance().ListEsc.Contains(panelname))
        {
            PoolEsc.GetInstance().ListEsc.Remove(panelname);
        }
    }
    /// <summary>
    /// 隐藏面板
    /// </summary>
    /// <param name="Active">面板在缓存池的激活状态</param>
    /// <param name="panel">面板的GameObject</param>
    /// <param name="panelname">面板在缓存池中的名字(一般直接gameObject.name)</param>
    public void HidePanel(bool Active, GameObject panel, E_PanelName p_e_PanelName)
    {
        string panelName = p_e_PanelName.ToString();

        PoolBuffer.GetInstance().Push(Active, panel, panelName);
        PoolNowPanel.GetInstance().ListNowPanel.Remove(panelName);

        if (PoolEsc.GetInstance().ListEsc.Contains(panelName))
        {
            PoolEsc.GetInstance().ListEsc.Remove(panelName);
        }
    }

    public void HideAllPanel()
    {
        PoolEsc.GetInstance().HideAllOnly();

        List<string> tempNameList = new();
        tempNameList.DeepCopy(Hot.PoolNowPanel_.ListNowPanel);

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
        {
            return DicPanel[panelname] as T;
        }
        else
        {
            Debug.Log("--- MgrUI: " + panelname + " is null ---");
        }
        
        return null;
    }
    public T GetPanel<T>(E_PanelName p_e_PanelName) where T : PanelBase
    {
        string panelName = p_e_PanelName.ToString();

        if (DicPanel.ContainsKey(panelName))
        {
            return DicPanel[panelName] as T;
        }
        else
        {
            Debug.Log("--- MgrUI: " + panelName + " is null ---");
        }
        
        return null;
    }
    public PanelBase GetPanel(string panelname)
    {
        if (DicPanel.ContainsKey(panelname))
        {
            return DicPanel[panelname];
        }
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