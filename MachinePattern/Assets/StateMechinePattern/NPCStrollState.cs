using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStrollState : StateBase
{
    public NPCStrollState(string name) : base(name)
    {
    }
    public override void Enter()
    {
        base.Enter();
        Machine.Manage.GetNPC().SetColor(Color.yellow);
    }
}
