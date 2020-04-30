using System;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;


public class UIManager :Singleton<UIManager>
{

    public UIManager()
    {
        
    }

    public void Open(UIDialog dialog)
    {
        UIPoolManager.GetInstance.AddTicker(dialog);

        dialog.Open();

    }

    public void Open<T>()
    {
        Type type = typeof(T);
        ConstructorInfo[] ci = type.GetConstructors();

    }

    public void Open(string dialog)
    {
        Type type = TypeUtils.TypeInMemory(dialog);
        
        Debug.Log(type.Name);
        //type =    
    }

    public void Tick(float delta)
    {
        if(UIPoolManager.GetInstance != null)
        {
            UIPoolManager.GetInstance.Tick(delta);
        }
    }

    public void Init()
    {

    }
}