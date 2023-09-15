using System;
using System.Collections.Generic;
using UnityEngine.Events;

public static class UiEventsSystem
{
    private static readonly Dictionary<KeyValuePair<Enum, Enum>, UnityEvent> eventDictionary = new Dictionary<KeyValuePair<Enum, Enum>, UnityEvent>();

    // ����� ��� �������� �� �������
    public static void Subscribe(Enum key1, Enum key2, UnityAction listener)
    {
        var key = new KeyValuePair<Enum, Enum>(key1, key2);

        UnityEvent thisEvent = null;
        if (eventDictionary.TryGetValue(key, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            eventDictionary.Add(key, thisEvent);
        }
    }

    // ����� ��� ������� �� �������
    public static void Unsubscribe(Enum key1, Enum key2, UnityAction listener)
    {
        var key = new KeyValuePair<Enum, Enum>(key1, key2);

        UnityEvent thisEvent = null;
        if (eventDictionary.TryGetValue(key, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    // ����� ��� ������ �������
    public static void TriggerEvent(Enum key1, Enum key2)
    {
        var key = new KeyValuePair<Enum, Enum>(key1, key2);

        UnityEvent thisEvent = null;
        if (eventDictionary.TryGetValue(key, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}

