using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public static GameEvent current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int> onEventTriggerEnter;
    public void EventTriggerEnter(int id)
    {
        if(onEventTriggerEnter != null)
        {
            onEventTriggerEnter(id);
        }
    }
    public event Action<int> onEventTriggerExit;
    public void EventTriggerExit(int id)
    {
        if (onEventTriggerExit != null)
        {
            onEventTriggerExit(id);
        }
    }
}
