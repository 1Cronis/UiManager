using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class UiEventsSystem
{
    private static readonly Dictionary<StateView, UnityEvent> eventNoParam = new Dictionary<StateView, UnityEvent>();
    private static readonly Dictionary<StateView, UnityEvent<object>> eventOneParam = new Dictionary<StateView, UnityEvent<object>>();
    private static readonly Dictionary<StateView, UnityEvent<object, object>> eventTwoParam = new Dictionary<StateView, UnityEvent<object, object>>();
    
    public static void Subscribe<T1,T2>(StateView key, UnityAction<T1, T2> listener)
    {
        UnityEvent<object, object> thisEvent = null;
        if (eventTwoParam.TryGetValue(key, out thisEvent))
        {
            thisEvent.AddListener((param1, param2) => listener((T1)param1, (T2)param2));
        }
        else
        {
            thisEvent = new UnityEvent<object, object>();
            thisEvent.AddListener((param1, param2) => listener((T1)param1, (T2)param2));
            eventTwoParam.Add(key, thisEvent);
        }
    }

    public static void Subscribe<T>(StateView key, UnityAction<T> listener)
    {
        UnityEvent<object> thisEvent = null;
        if (eventOneParam.TryGetValue(key, out thisEvent))
        {
            thisEvent.AddListener(data => listener((T)data));
        }
        else
        {
            thisEvent = new UnityEvent<object>();
            thisEvent.AddListener(data => listener((T)data));
            eventOneParam.Add(key, thisEvent);
        }
    }
    public static void Subscribe(StateView key, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (eventNoParam.TryGetValue(key, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            eventNoParam.Add(key, thisEvent);
        }
    }

    public static void Unsubscribe<T1, T2>(StateView key, UnityAction<T1, T2> listener)
    {
        UnityEvent<object,object> thisEvent = null;
        if (eventTwoParam.TryGetValue(key, out thisEvent))
        {
            thisEvent.RemoveListener((param1, param2) => listener((T1)param1, (T2)param2));
        }
    }

    public static void Unsubscribe<T>(StateView key, UnityAction<T> listener)
    {
        UnityEvent<object> thisEvent = null;
        if (eventOneParam.TryGetValue(key, out thisEvent))
        { 
            thisEvent.RemoveListener(data => listener((T)data));
        }
    }

    public static void Unsubscribe(StateView key, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (eventNoParam.TryGetValue(key, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent<T1, T2>(StateView key, T1 param1, T2 param2 = default(T2))
    {
        UnityEvent<object, object> thisEvent = null;
        if (eventTwoParam.TryGetValue(key, out thisEvent))
        {
            thisEvent.Invoke(param1, param2);
        }
    }
    public static void TriggerEvent<T>(StateView key, T data)
    {
        UnityEvent<object> thisEvent = null;
        if (eventOneParam.TryGetValue(key, out thisEvent))
        {
            thisEvent.Invoke(data);
        }
    }

    public static void TriggerEvent(StateView key)
    {
        UnityEvent thisEvent = null;
        if (eventNoParam.TryGetValue(key, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}

