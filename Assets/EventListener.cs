using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    [SerializeField] Event gEvent;
    [SerializeField] UnityEvent response;

    private void OnEnable() 
    {
        gEvent.Register(this);
    }

    private void OnDisable() 
    {
        gEvent.Unregister(this);
    }

    public void Response()
    {
        response.Invoke();
    }
}
