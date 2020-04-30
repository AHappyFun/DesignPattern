using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// UI Dialog
/// </summary>
public class UIDialog : UIComponent
{
    private UIDialog instance;

    public UIDialog() : base()
    {
    }

    public UIDialog Open()
    {
        if (GetInstance() != null)
        {
            GetInstance().Show();
        }
        else
        {
            instance = new UIDialog();
        }

        return instance;
    }

    public override void Show()
    {
        base.Show();
    }

    protected override void OnPrepare(Transform transform)
    {
        base.OnPrepare(transform);
    }

    //--------开放的---------
    public UIDialog GetInstance()
    {
        return instance;
    }
}

public class UITestDialog: UIDialog
{
    public Text hpTxt;

    public UITestDialog() : base()
    {
        //UIManager.GetInstance.tickList.Add(this);

        Layer = UILayer.GetInstance.UIPanelLayer;

    }

    public override string GetUIPrefabPath()
    {
        return "Prefabs/UI/TestPanel";
    }

    public override void BindUIComponent()
    {
        hpTxt = GetComponentByPath("hp", typeof(Text)) as Text;
    }

    void Init()
    {

    }

    public override void Tick(float delta)
    {
        base.Tick(delta);

        hpTxt.text = delta.ToString();
    }
}