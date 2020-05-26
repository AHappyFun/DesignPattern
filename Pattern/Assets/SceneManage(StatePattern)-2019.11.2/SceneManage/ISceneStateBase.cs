using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISceneStateBase 
{
    public string StateName;

    public SceneManageControllor m_SceneManage;
    public ISceneStateBase(SceneManageControllor sceneM)
    {
        m_SceneManage = sceneM;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void Tick()
    {

    }
}
