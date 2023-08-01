using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseState<T> : MonoBehaviour
{
    [SerializeField]
    protected T stateType;
    
    public T StateType { get { return stateType; } }

    public UnityEvent enterStateEvent;
    public UnityEvent executeStateEvent;
    public UnityEvent exitStateEvent;

    public abstract void Enter();
    public abstract void UnNotifyEnter();
    public abstract void Exit();
    public abstract void UnNotifyExit();
}