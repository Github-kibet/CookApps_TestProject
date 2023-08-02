using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public abstract class BaseFSM<T> : MonoBehaviour where T : Enum
{
    [SerializeField]
    public BaseState<T> currentState;
    public BaseState<T> CurrentState { get { return currentState; } }
    [SerializeField]
    public BaseState<T> previousState;
    public BaseState<T> PreviousState { get { return previousState; } }

    [SerializeField]
    protected SerializableDictionary<T, BaseState<T>> stateTable = new SerializableDictionary<T, BaseState<T>>();
    public SerializableDictionary<T, BaseState<T>> StateTable { get { return stateTable; } }

    public UnityAction<T> changeStateAction;
    
    public BaseState<T> GetState(T stateType)
    {
        if (stateTable.ContainsKey(stateType))
        {
            return stateTable[stateType];
        }
        
        return null;
    }

    public virtual void AddState(T stateType, BaseState<T> state)
    {
        if (stateTable.ContainsKey(stateType))
            return;

        stateTable.Add(stateType, state);
    }

    public virtual void SubState(T stateType)
    {
        if (!stateTable.ContainsKey(stateType))
            return;

        stateTable.Remove(stateType);
    }

    public virtual void ChangeState(T updateStateType)
    {
        //FSM�� �ش� ���°� �ִ��� Ȯ��
        if (stateTable.ContainsKey(updateStateType))
        {
            var updateState = stateTable[updateStateType];
            
            //�ߺ� �����̸� UnNotifyEnter ����
            if (updateState == currentState)
            {
                changeStateAction?.Invoke(updateStateType);
                stateTable[updateStateType].UnNotifyEnter();
                return;
            }
            
            //���°� ����Ǹ� Exit ȣ��
            currentState?.Exit();
            
            currentState = updateState;

            //����� ���� Enter ȣ��
            changeStateAction?.Invoke(updateStateType);
            updateState.Enter();
        }
    }

    public void ApplyState()
    {
        var states = GetComponents<BaseState<T>>();
        StateTable.Clear();

        foreach (var state in states)
        {
            AddState(state.StateType, state);
        }
    }
    protected abstract void UpdateExcute();
    
    
    public static int EnumToInt<TValue>(TValue value) where TValue : Enum => (int)(object)value;

}
