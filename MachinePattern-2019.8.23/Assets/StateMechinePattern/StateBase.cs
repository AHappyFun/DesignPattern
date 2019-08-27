using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase : MonoBehaviour
{
    public string StateName;
    private StateMachine machine;

    public StateMachine Machine
    {
        get
        {
            return machine;
        }

        set
        {
            machine = value;
        }
    }

    public StateBase(string name)
    {
        StateName = name;
    }
    public virtual void Enter()
    {
        Debug.Log(StateName+"进来了");
    }

    public virtual void Exit()
    {
        Debug.Log(StateName + "出去了");
    }

    public void Update()
    {
        
    }
}
