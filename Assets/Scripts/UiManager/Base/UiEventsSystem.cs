using System;
using System.Collections.Generic;
public static class UiEventsSystem
{
    private static class Container<TEnum> 
        where TEnum : System.Enum
    {
        public static readonly Dictionary<StateView, System.Action<ViewEvent<TEnum>>> dictionaryEvent = new();
    }

    public static void Subscribe<TEnum>(StateView key, System.Action<ViewEvent<TEnum>> actino)
        where TEnum : System.Enum
    {
        if (Container<TEnum>.dictionaryEvent.TryGetValue(key, out var thisEvent))
        {
            thisEvent += actino;
        }
        else
        {
            thisEvent += actino;
            Container<TEnum>.dictionaryEvent.Add(key,thisEvent);
        }
    }

    public static void Unsubscribe<TEnum>(StateView key, System.Action<ViewEvent<TEnum>> actino)
        where TEnum : System.Enum
    {
        if (Container<TEnum>.dictionaryEvent.TryGetValue(key, out var thisEvent))
        {
            thisEvent -= actino;
        }
    }


    public static void Invoke<TEnum>(ViewEvent<TEnum> listener)
        where TEnum : System.Enum
    {
        var key = listener.stateView;
        if (Container<TEnum>.dictionaryEvent.TryGetValue(key, out var thisEvent))
        {
            thisEvent.Invoke(listener);
        }
    }
}
