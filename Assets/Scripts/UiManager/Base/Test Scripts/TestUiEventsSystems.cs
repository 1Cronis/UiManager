using System.Collections.Generic;
using System.Collections.Specialized;

public static class TestUiEventsSystem
{
    public static void Subscribe<T1>(StateView key, System.Action<T1,object> listener)
    {
        if (TestDictionary<T1>.eventTwoParam.TryGetValue(key, out var thisEvent))
        {
            thisEvent += listener;
        }
        else
        {
            thisEvent += listener;
            TestDictionary<T1>.eventTwoParam.Add(key, thisEvent);
        }
    }

    public static void Subscribe<T1>(StateView key, System.Action<T1> listener)
    {

        if (TestDictionary<T1>.eventOneParam.TryGetValue(key, out var thisEvent))
        {
            thisEvent += listener;
        }
        else
        {
            thisEvent = listener;
            TestDictionary<T1>.eventOneParam.Add(key, thisEvent);
        }
    }

    public static void Subscribe(StateView key, System.Action listener)
    {

        if (TestDictionary<object>.eventNoParam.TryGetValue(key, out var thisEvent))
        {
            thisEvent += listener;
        }
        else
        {
            thisEvent += listener;
            TestDictionary<object>.eventNoParam.Add(key, thisEvent);
        }
    }

    public static void Unsubscribe<T1>(StateView key, System.Action<T1,object> listener)
    {
        if (TestDictionary<T1>.eventTwoParam.TryGetValue(key, out var thisEvent))
        {
            thisEvent -= listener;
        }
    }

    public static void Unsubscribe<T1>(StateView key, System.Action<T1> listener)
    {
        if (TestDictionary<T1>.eventOneParam.TryGetValue(key, out var thisEvent))
        {
            thisEvent -= listener;
        }
    }

    public static void Unsubscribe(StateView key, System.Action listener)
    {
        if (TestDictionary<object>.eventNoParam.TryGetValue(key, out var thisEvent))
        {
            thisEvent -= listener;
        }
    }

    public static void TriggerEvent<T1>(StateView key, T1 param1, object param2)
    {
        if (TestDictionary<T1>.eventTwoParam.TryGetValue(key, out var thisEvent))
        {
            thisEvent?.Invoke(param1, param2);
        }
    }

    public static void TriggerEvent<T1>(StateView key, T1 param1)
    {
        if (TestDictionary<T1>.eventOneParam.TryGetValue(key, out var thisEvent))
        {
            thisEvent?.Invoke(param1);
        }
    }

    public static void TriggerEvent(StateView key)
    {
        if (TestDictionary<object>.eventNoParam.TryGetValue(key, out var thisEvent))
        {
            thisEvent?.Invoke();
        }
    }
}
