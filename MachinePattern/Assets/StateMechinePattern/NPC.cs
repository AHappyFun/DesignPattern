using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private NPCAI npcAI;
    private Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        npcAI = new NPCAI(this);
        npcAI.InitStateMachine();
    }

    //------------------

    private void Update()
    {
        InputCheck();
    }

    void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            npcAI.stateMachine.Switch("Green");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            npcAI.stateMachine.Switch("Red");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            npcAI.stateMachine.Switch("Yellow");
        }
    }

    public void SetColor(Color col)
    {
        mat.SetColor("_Color", col);
    }
}
