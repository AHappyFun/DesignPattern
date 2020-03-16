using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWaitState : StateBase
{
    public NPCWaitState(string name) : base(name)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Machine.Manage.GetNPC().SetColor(Color.red);
    }
}
