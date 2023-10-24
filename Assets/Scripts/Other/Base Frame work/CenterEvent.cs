using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public interface IEventInfo { }

public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> actions;

    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}

public class EventInfo : IEventInfo
{
    public UnityAction actions;

    public EventInfo(UnityAction action)
    {
        actions += action;
    }
}

public class CenterEvent : InstanceBaseAuto_Mono<CenterEvent>
{   
    private Dictionary<string, IEventInfo> EventDic = new Dictionary<string, IEventInfo>();
    
    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        if (EventDic.ContainsKey(name))
            (EventDic[name] as EventInfo<T>).actions += action;
        else
            EventDic.Add(name, new EventInfo<T>(action));
    }
    
    public void AddEventListener(string name, UnityAction action)
    {       

        if (EventDic.ContainsKey(name))
            (EventDic[name] as EventInfo).actions += action;
        else
            EventDic.Add(name, new EventInfo(action));
    }
    
    public void RemoveEventListener<T>(string name, UnityAction<T> action)
    {
        if (EventDic.ContainsKey(name))
            (EventDic[name] as EventInfo<T>).actions -= action;
    }
    
    public void RemoveEventListener(string name, UnityAction action)
    {
        if (EventDic.ContainsKey(name))
            (EventDic[name] as EventInfo).actions -= action;
    }

    public void EventTrigger<T>(string name, T info)
    {       
        if (EventDic.ContainsKey(name))
            (EventDic[name] as EventInfo<T>).actions?.Invoke(info);
    }
    
    public void EventTrigger(string name)
    {      
        if (EventDic.ContainsKey(name))
            (EventDic[name] as EventInfo).actions?.Invoke();
    }
  
    public void Clear()
    {
        EventDic.Clear();
    }
}
