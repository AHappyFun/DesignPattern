using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAI : StateMachineManage
{
    public StateMachine stateMachine;
    private NPC npc;
    public NPCAI(NPC NPC)
    {
        npc = NPC;
    }
    public void InitStateMachine()
    {
        if (stateMachine)
            return;
        stateMachine = new StateMachine(this);
        stateMachine.States = new Dictionary<string, StateBase>();
        stateMachine.AddState(new NPCAttackState("Green"));
        stateMachine.AddState(new NPCWaitState("Red"));
        stateMachine.AddState(new NPCStrollState("Yellow"));
        stateMachine.Switch("Red");
    }

    public override NPC GetNPC()
    {
        if (npc)
            return npc;
        else
            return null;
    }
}
