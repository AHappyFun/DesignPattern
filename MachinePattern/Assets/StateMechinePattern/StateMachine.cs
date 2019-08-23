using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private StateBase m_CurrentState;
    private Dictionary<string,StateBase> states;

    public StateBase CurrentState
    {
        get  {   return m_CurrentState;  }
        set  {     m_CurrentState = value;    }
    }

    public Dictionary<string, StateBase> States
    {
        get
        {
            return states;
        }

        set
        {
            states = value;
        }
    }

    public StateMachineManage Manage;

    public StateMachine(StateMachineManage man)
    {
        Manage = man;
    }

    private void Update()
    {
        if (m_CurrentState)
        {
            m_CurrentState.Update();
        }
    }

    public void Switch(string name)
    {
        if (States.ContainsKey(name))
            m_CurrentState = States[name];
        m_CurrentState.Enter();
    }

    public void Trigger()
    {

    }

    public void AddState(StateBase state)
    {
        string name = state.StateName;
        if (States.ContainsKey(name))
            return;
        States.Add(name, state);
        state.Machine = this;
    }

    public void RemoveState(StateBase state)
    {
        string name = state.StateName;
        if (States.ContainsKey(name))
            States.Remove(name);
    }
    
}
