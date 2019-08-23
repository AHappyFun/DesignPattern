using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class UpCommand:Command
{
    GameObject gameObj;
    Vector3 movePos;
    public UpCommand(GameObject go, Vector3 pos)
    {
        gameObj = go;
        movePos = pos;
    }
    public override void Execute()
    {
        Turn(gameObj,movePos);
    }
    public override void Undo()
    {
        Turn(gameObj,-movePos);
    }
    void Turn(GameObject go, Vector3 movePos)
    {
        go.transform.position += movePos;
    }
}
