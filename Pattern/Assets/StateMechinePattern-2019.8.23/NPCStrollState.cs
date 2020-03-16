using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStrollState : StateBase
{
    public NPCStrollState(string name) : base(name)
    {
        //this.StateName = 
    }
    public override void Enter()
    {
        base.Enter();
        Machine.Manage.GetNPC().SetColor(Color.yellow);
    }
}
