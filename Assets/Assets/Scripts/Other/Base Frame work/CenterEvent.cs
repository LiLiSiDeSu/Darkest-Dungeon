using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public interface IEventInfo { }

#region EventInfo

public class EventInfo : IEventInfo
{
    public UnityAction actions;

    public EventInfo(UnityAction action)
    {
        actions += action;
    }
}

public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> actions;

    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}

public class EventInfo<T0, T1> : IEventInfo
{
    public UnityAction<T0, T1> actions;

    public EventInfo(UnityAction<T0, T1> action)
    {
        actions += action;
    }
}

public class EventInfo<T0, T1, T2> : IEventInfo
{
    public UnityAction<T0, T1, T2> actions;

    public EventInfo(UnityAction<T0, T1, T2> action)
    {
        actions += action;
    }
}


#endregion

public class CenterEvent : InstanceBaseAuto_Mono<CenterEvent>
{   
    private Dictionary<string, IEventInfo> EventDic = new Dictionary<string, IEventInfo>();

    #region AddEventListener

    public void AddEventListener(string name, UnityAction action)
    {

        if (EventDic.ContainsKey(name))
            (EventDic[name] as EventInfo).actions += action;
        else
            EventDic.Add(name, new EventInfo(action));
    }

    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        if (EventDic.ContainsKey(name))
            (EventDic[name] as EventInfo<T>).actions += action;
        else
            EventDic.Add(name, new EventInfo<T>(action));
    }

    public void AddEventListener<T0, T1>(string name, UnityAction<T0, T1> action)
    {
        if (EventDic.ContainsKey(name))
            (EventDic[name] as EventInfo<T0, T1>).actions += action;
        else
            EventDic.Add(name, new EventInfo<T0, T1>(action));
    }

    public void AddEventListener<T0, T1, T2>(string name, UnityAction<T0, T1, T2> action)
    {
        if (EventDic.ContainsKey(name))
            (EventDic[name] as EventInfo<T0, T1, T2>).actions += action;
        else
            EventDic.Add(name, new EventInfo<T0, T1, T2>(action));
    }

    #endregion

    #region RemoveEventListener

    public void RemoveEventListener(string name, UnityAction action)
    {
        if (EventDic.ContainsKey(name))
            (EventDic[name] as EventInfo).actions -= action;
    }

    public void RemoveEventListener<T>(string name, UnityAction<T> action)
    {
        if (EventDic.ContainsKey(name))
            (EventDic[name] as EventInfo<T>).actions -= action;
    }

    public void RemoveEventListener<T0, T1>(string name, UnityAction<T0, T1> action)
    {
        if (EventDic.ContainsKey(name))
            (EventDic[name] as EventInfo<T0, T1>).actions -= action;
    }

    public void RemoveEventListener<T0, T1, T2>(string name, UnityAction<T0, T1, T2> action)
    {
        if (EventDic.ContainsKey(name))
            (EventDic[name] as EventInfo<T0, T1, T2>).actions -= action;
    }

    #endregion

    #region EventTrigger

    public void EventTrigger(string name)
    {
        if (EventDic.ContainsKey(name))
            (EventDic[name] as EventInfo).actions?.Invoke();
        else
            Debug.Log("--- CenterEvent: " + name + " is null ---");
    }

    public void EventTrigger<T>(string name, T info)
    {
        if (EventDic.ContainsKey(name))
            (EventDic[name] as EventInfo<T>).actions?.Invoke(info);
        else
            Debug.Log("--- CenterEvent: " + name + " is null ---");
    }

    public void EventTrigger<T0, T1>(string name, T0 info0, T1 info1)
    {
        if (EventDic.ContainsKey(name))
            (EventDic[name] as EventInfo<T0, T1>).actions?.Invoke(info0, info1);
        else
            Debug.Log("--- CenterEvent: " + name + " is null ---");
    }

    public void EventTrigger<T0, T1, T2>(string name, T0 info0, T1 info1, T2 info2)
    {
        if (EventDic.ContainsKey(name))
            (EventDic[name] as EventInfo<T0, T1, T2>).actions?.Invoke(info0, info1, info2);
        else
            Debug.Log("--- CenterEvent: " + name + " is null ---");
    }

    #endregion

    public void Clear()
    {
        EventDic.Clear();
    }
}
