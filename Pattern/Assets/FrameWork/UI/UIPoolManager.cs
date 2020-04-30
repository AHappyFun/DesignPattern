using System.Collections.Generic;
using UnityEngine;


public class UIPoolManager : Singleton<UIPoolManager>
{

    private List<UIComponent> tickList;

    public UIPoolManager()
    {
        tickList = new List<UIComponent>();
    }

    public void Tick(float delta)
    {
        if (tickList.Count <= 0)
            return;

        foreach (var item in tickList)
        {
            item.Tick(delta);
        }
    }

    public void AddTicker(UIComponent ui)
    {
        tickList.Add(ui);
    }


}
