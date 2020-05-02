using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Event", menuName = "Event", order = 52)]
public class Event : ScriptableObject
{
    List<EventListener> EListeners;

    public void Register(EventListener li)
    {
        EListeners.Add(li);
    }

    public void Unregister(EventListener li)
    {
        EListeners.Remove(li);
    }

    public void OnOccured()
    {
        foreach(EventListener li in EListeners)
        {
            li.Response();
        }
    }
}
