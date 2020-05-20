using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

/// <summary>
/// UI Dialog
/// </summary>
public class UIDialog : UIComponent
{
    private UIDialog instance;
    private string d_Name;

    public string Name
    {
        get { return d_Name; }
        set { d_Name = value; }
    }

    public UIDialog() : base()
    {
        Name = this.GetType().Name;
    }

    public UIDialog Open()
    {
        if (GetInstance() != null)
        {
            GetInstance().Show();
        }
        else
        {
            instance = this;
        }

        return instance;
    }

    //--------开放的---------
    public UIDialog GetInstance()
    {
        return instance;
    }

    //--------复写的---------
    public override void Show()
    {
        base.Show();
    }

    protected override void OnPrepare(Transform transform)
    {
        //add canvas相关组件
        CanvasRenderer cr = transform.GetComponent<CanvasRenderer>();
        if (!cr)
        {
            transform.gameObject.AddComponent<CanvasRenderer>();
        }

        Canvas cv = transform.GetComponent<Canvas>();
        if (!cv)
        {
            transform.gameObject.AddComponent<Canvas>();
        }

        GraphicRaycaster gr = transform.GetComponent<GraphicRaycaster>();
        if (!gr)
        {
            transform.gameObject.AddComponent<GraphicRaycaster>();
        }

        base.OnPrepare(transform);

        //---准备完成后放入池中--
        UIPoolManager.GetInstance.PushPool(this);

    }

    protected Button close_Btn;
    public override void BindUIComponent()
    {
        close_Btn = GetComponentByPath("Comm/btnClose", typeof(Button)) as Button;
    }

    public override void OnClose()
    {
        base.OnClose();
        Debug.Log("Close close");
    }
    //--------预绑定---------
    public override void AddListener()
    {
        base.AddListener();    
        close_Btn.onClick.AddListener(
            () =>
            {
                Close_Click(name);
            }
        );
    }

    private static void Close_Click(string name)
    {
        Debug.Log("Close_Click" + name);
        Type type = TypeUtils.TypeInMemory(name);
    }
}

public class UITestDialog: UIDialog
{
    public Text hpTxt;
    public Button button;
    public Image image;

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
        base.BindUIComponent();
        hpTxt = GetComponentByPath("hp", typeof(Text)) as Text;
        button = GetComponentByPath("btn", typeof(Button)) as Button;
        image = GetComponentByPath("Image", typeof(Image)) as Image;
    }

    void Init()
    {

    }

    public override void Tick(float delta)
    {
        base.Tick(delta);

        hpTxt.text = delta.ToString();
    }

    //-----------周期----------
    public override void OnShow()
    {
        base.OnShow();
        // Gray(true);
        UIManager.GetInstance.SetUIImage("UISprite/sprite_001", image);
    }

    public override void OnHide()
    {
        base.OnHide();
    }

    public override void AddListener()
    {
        base.AddListener();
        button.onClick.AddListener(ButtonClick);
        //close_Btn.onClick.AddListener(Close_Click);
    }

    public override void OnClose()
    {
        base.OnClose();
    }

    //------绑定方法------

    private static void ButtonClick()
    {
        Debug.Log("OKOKOKOKOK");
    }


}