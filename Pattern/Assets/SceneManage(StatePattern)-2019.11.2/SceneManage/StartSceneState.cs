using UnityEngine;
using System.Collections;

public class StartSceneState : ISceneStateBase
{

    public StartSceneState(SceneManageControllor sceneM):base(sceneM)
    {
        this.StateName = "LoadScene";
    }

    public override void Enter()
    {
        //数据加载初始化
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Tick()
    {
        //第一帧update更新到 菜单场景
        m_SceneManage.SetState(new MainMenuSceneState(m_SceneManage), "MenuScene");
    }
}
