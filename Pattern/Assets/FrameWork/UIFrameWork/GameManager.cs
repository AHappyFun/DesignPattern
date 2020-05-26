using System.Collections.Generic;
using UnityEngine;
using System;


public class GameManager : SingletonBase<GameManager>
{

    private void Start()
    {
        Init();

        //UIManager.GetInstance.Open(new UITestDialog());
        ScriptUI.UIManager.GetInstance.Open("UITestDialog");
    }

    void Init()
    {
        ScriptUI.UIManager.GetInstance.Init();
    }


    private void Update()
    {
        float delta = Time.deltaTime;

        ScriptUI.UIManager.GetInstance.Tick(delta);
    }
}
