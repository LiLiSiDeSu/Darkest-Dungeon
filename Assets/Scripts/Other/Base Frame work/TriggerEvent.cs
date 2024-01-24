using System.Collections.Generic;
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

public class TriggerEvent : InstanceBaseAuto_Mono<TriggerEvent>
{
    private Dictionary<string, IEventInfo> DicEvent = new Dictionary<string, IEventInfo>();

    #region AddEventListener

    public void AddEventListener(string name, UnityAction action)
    {

        if (DicEvent.ContainsKey(name))
            (DicEvent[name] as EventInfo).actions += action;
        else
            DicEvent.Add(name, new EventInfo(action));
    }

    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        if (DicEvent.ContainsKey(name))
            (DicEvent[name] as EventInfo<T>).actions += action;
        else
            DicEvent.Add(name, new EventInfo<T>(action));
    }

    public void AddEventListener<T0, T1>(string name, UnityAction<T0, T1> action)
    {
        if (DicEvent.ContainsKey(name))
            (DicEvent[name] as EventInfo<T0, T1>).actions += action;
        else
            DicEvent.Add(name, new EventInfo<T0, T1>(action));
    }

    public void AddEventListener<T0, T1, T2>(string name, UnityAction<T0, T1, T2> action)
    {
        if (DicEvent.ContainsKey(name))
            (DicEvent[name] as EventInfo<T0, T1, T2>).actions += action;
        else
            DicEvent.Add(name, new EventInfo<T0, T1, T2>(action));
    }

    #endregion

    #region RemoveEventListener

    public void RemoveEvent(string name)
    {
        DicEvent?.Remove(name);
    }
    public void RemoveEventListener(string name, UnityAction action)
    {
        if (DicEvent.ContainsKey(name))
            (DicEvent[name] as EventInfo).actions -= action;
    }

    public void RemoveEventListener<T>(string name, UnityAction<T> action)
    {
        if (DicEvent.ContainsKey(name))
            (DicEvent[name] as EventInfo<T>).actions -= action;
    }

    public void RemoveEventListener<T0, T1>(string name, UnityAction<T0, T1> action)
    {
        if (DicEvent.ContainsKey(name))
            (DicEvent[name] as EventInfo<T0, T1>).actions -= action;
    }

    public void RemoveEventListener<T0, T1, T2>(string name, UnityAction<T0, T1, T2> action)
    {
        if (DicEvent.ContainsKey(name))
            (DicEvent[name] as EventInfo<T0, T1, T2>).actions -= action;
    }

    #endregion

    #region EventTrigger

    public void EventTrigger(string name)
    {
        if (DicEvent.ContainsKey(name))
            (DicEvent[name] as EventInfo).actions?.Invoke();
        else
            Debug.Log("--- CenterEvent: " + name + " is null ---");
    }

    public void EventTrigger<T>(string name, T info)
    {
        if (DicEvent.ContainsKey(name))
            (DicEvent[name] as EventInfo<T>).actions?.Invoke(info);
        else
            Debug.Log("--- CenterEvent: " + name + " is null ---");
    }

    public void EventTrigger<T0, T1>(string name, T0 info0, T1 info1)
    {
        if (DicEvent.ContainsKey(name))
            (DicEvent[name] as EventInfo<T0, T1>).actions?.Invoke(info0, info1);
        else
            Debug.Log("--- CenterEvent: " + name + " is null ---");
    }

    public void EventTrigger<T0, T1, T2>(string name, T0 info0, T1 info1, T2 info2)
    {
        if (DicEvent.ContainsKey(name))
            (DicEvent[name] as EventInfo<T0, T1, T2>).actions?.Invoke(info0, info1, info2);
        else
            Debug.Log("--- CenterEvent: " + name + " is null ---");
    }

    #endregion

    public void Clear()
    {
        DicEvent.Clear();
    }
}
