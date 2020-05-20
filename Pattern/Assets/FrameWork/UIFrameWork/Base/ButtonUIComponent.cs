using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Button UI 控件
/// </summary>
public class ButtonUIComponent : UIComponent
{
    private Button button;

    public ButtonUIComponent(Transform transform) : base(transform)
    {
      
    }

    public override void BindUIComponent()
    {
        button = GetComponentByPath("btn", typeof(Button)) as Button;
    }


}
