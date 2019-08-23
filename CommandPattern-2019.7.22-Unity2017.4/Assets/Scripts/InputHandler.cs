using System;
using System.Collections.Generic;
using UnityEngine;
public class InputHandler:MonoBehaviour
{
    public GameObject go;
    public Stack<Command> cmds = new Stack<Command>();
    //通过Command间接控制
    //void HandleInput()
    //{
    //    if (Input.GetKeyDown(KeyCode.UpArrow))
    //    {
    //        new UpCommand().Execute(go);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.DownArrow))
    //    {
    //        new DownCommand().Execute(go);
    //    }
    //}
    //private void Update()
    //{
    //    HandleInput();
    //}

    //------将Command当做对象传递----------
    //Command HandleInput()
    //{
    //    if (Input.GetKeyDown(KeyCode.UpArrow))
    //    {
    //        return new UpCommand();
    //    }
    //    else if (Input.GetKeyDown(KeyCode.DownArrow))
    //    {
    //        return new DownCommand();
    //    }
    //    return null;
    //}
    //private void Update()
    //{
    //    Command cmd = HandleInput();
    //    if (cmd!=null)
    //    {
    //        cmd.Execute(go);
    //    }
    //}

    //------实现撤销- 指令存在栈集合里---------
    Command HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return new UpCommand(go, new Vector3(0,5,0));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return new DownCommand(go, new Vector3(0, -5, 0));
        }
        return null;
    }
    private void Update()
    {
        Command cmd = HandleInput();
        if (cmd!=null)
        {
            cmd.Execute();
            cmds.Push(cmd);
        }
        HandleUndo();    
    }
    void HandleUndo()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (cmds.Count == 0)
                return;
            cmds.Pop().Undo();
        }
    }

}
