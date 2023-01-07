using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stat<T>
{
    private UnityEvent _event = new UnityEvent();

    private T _value;

    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            _event.Invoke();
        }
    }

    public Stat(T InitValue)
    {
        Value = InitValue;
    }

    public void AddView(UnityAction Method)
    {
        _event.RemoveListener(Method);
        _event.AddListener(Method);
        _event.Invoke();
    }

    public void RemoveView(UnityAction Method)
    {
        _event.RemoveListener(Method);
    }

    public void SaveData(T Stat)
    {
        _event.RemoveAllListeners();
        Stat = Value;
    }
}
