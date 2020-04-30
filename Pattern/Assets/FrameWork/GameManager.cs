using System.Collections.Generic;
using UnityEngine;
using System;


public class GameManager : SingletonBase<GameManager>
{

    private void Start()
    {
        Init();

        UIManager.GetInstance.Open(new UITestDialog());
    }

    void Init()
    {
        UIManager.GetInstance.Init();
    }


    private void Update()
    {
        float delta = Time.deltaTime;

        UIManager.GetInstance.Tick(delta);
    }
}
