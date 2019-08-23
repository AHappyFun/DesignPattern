using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAttackState : StateBase
{
    public NPCAttackState(string name) : base(name)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Machine.Manage.GetNPC().SetColor(Color.green);
    }
}
