using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Events;

public static class Test2UiEventsSystem
{
    private static readonly Dictionary<StateView, System.Action<TestEventView<TypeView>>> dictionaryEvent = new ();

    public static void Subscribe(StateView key, System.Action<TestEventView<TypeView>> actino)
    {
        if (dictionaryEvent.TryGetValue(key, out var thisEvent))
        {
            thisEvent += actino;
        }
        else
        {
            thisEvent += actino;
            dictionaryEvent.Add(key,thisEvent);
        }
    }

    public static void Unsubscribe(StateView key, System.Action<TestEventView<TypeView>> actino)
    {
        if (dictionaryEvent.TryGetValue(key, out var thisEvent))
        {
            thisEvent -= actino;
        }
    }

    public static void Invoke(TestEventView<TypeView> listener)
    {
        var key = listener.stateView;
        if (dictionaryEvent.TryGetValue(key, out var thisEvent))
        {
            thisEvent.Invoke(listener);
        }
    }
}
