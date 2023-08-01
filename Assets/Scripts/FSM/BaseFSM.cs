using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public abstract class BaseFSM<T1> : MonoBehaviour where T1 : Enum
{
    [SerializeField]
    public BaseState<T1> currentState;
    public BaseState<T1> CurrentState { get { return currentState; } }
    [SerializeField]
    public BaseState<T1> previousState;
    public BaseState<T1> PreviousState { get { return previousState; } }

    [SerializeField]
    protected SerializableDictionary<T1, BaseState<T1>> stateTable = new SerializableDictionary<T1, BaseState<T1>>();
    public SerializableDictionary<T1, BaseState<T1>> StateTable { get { return stateTable; } }

    public UnityAction<T1> changeStateAction;
    
    public BaseState<T1> GetState(T1 stateType)
    {
        if (stateTable.ContainsKey(stateType))
        {
            return stateTable[stateType];
        }
        
        return null;
    }

    public virtual void AddState(T1 stateType, BaseState<T1> state)
    {
        if (stateTable.ContainsKey(stateType))
            return;

        stateTable.Add(stateType, state);
    }

    public virtual void SubState(T1 stateType)
    {
        if (!stateTable.ContainsKey(stateType))
            return;

        stateTable.Remove(stateType);
    }

    public virtual void ChangeState(T1 updateStateType)
    {
        //FSM에 해당 상태가 있는지 확인
        if (stateTable.ContainsKey(updateStateType))
        {
            var updateState = stateTable[updateStateType];
            
            //중복 상태이면 UnNotifyEnter 실행
            if (updateState == currentState)
            {
                changeStateAction?.Invoke(updateStateType);
                stateTable[updateStateType].UnNotifyEnter();
                return;
            }
            
            //상태가 변경되면 Exit 호출
            currentState?.Exit();
            
            currentState = updateState;

            //변경된 상태 Enter 호출
            changeStateAction?.Invoke(updateStateType);
            updateState.Enter();
        }
    }

    public void ApplyState()
    {
        var states = GetComponents<BaseState<T1>>();
        StateTable.Clear();

        foreach (var state in states)
        {
            AddState(state.StateType, state);
        }
    }
    protected abstract void UpdateExcute();
    
    
    public static int EnumToInt<TValue>(TValue value) where TValue : Enum => (int)(object)value;

}
