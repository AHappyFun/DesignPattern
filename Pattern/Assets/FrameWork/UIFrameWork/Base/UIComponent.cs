using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// UI控件基类
/// 控制显隐、周期方法、父子级管理
/// </summary>
public class UIComponent : UIComponentBase
{
    public Transform Layer;
    public Transform parentTransform;   //组件父物体
    public UIComponent parent;          //逻辑父物体
    public Transform selfTransform;     //组件自己
    public UIComponentScript uiscript;  //组件Script

    private bool isInited = false;
    public bool isVisible = false;
    public bool isGray = false;

    public UIComponent(Transform trans = null) : base()
    {
        Init(trans);
    }

    public virtual string GetUIPrefabPath()
    {
        return "";
    }

    public virtual void BindUIComponent() { }

    public virtual void Init(Transform selfTrans)
    {
        if (isInited) return;
        isInited = true;

        if (selfTrans)
        {
            root = selfTrans;
            OnPrepare(root);
        }
        else
        {
            LoadResource(GetUIPrefabPath());
        }
    }

    public override void LoadResourceOK(GameObject asset)
    {
        base.LoadResourceOK(asset);
        if (pfb == null)
        {
            Debug.LogError("UIComponent Load prefab is null");
            return;
        }
        // Debug.Log("layer name "+Layer.name);
        Layer = UILayer.GetInstance.UIPanelLayer;
        pfb = Instantiate(pfb, Layer);

        OnPrepare(pfb.transform);
        isLoaded = true;

        //有load回调就执行回调
    }

    public virtual void Hide()
    {
        root.gameObject.SetActive(false);
    }

    public virtual void Show()
    {
        //parse args 

        //设置可见
        SetVisible(true);

        //手动刷新(有些面板不需要tick刷新)
        InitRefresh();
    }

    public virtual void Tick(float delta)
    {
        if (!isLoaded)
            return;
    }


    //控制显隐的入口
    public virtual void SetVisible(bool show)
    {
        if (isVisible == show) return;

        isVisible = show;
        RefreshVisible();
    }

    private void RefreshVisible()
    {
        if (root == null) return;
        root.gameObject.SetActive(isVisible);

        if (isVisible)
        {
            TryOnShow();
        }
        else
        {
            TryOnHide();
        }
    }

    //非加载组件的可见刷新
    private void RefreshSelfVisible()
    {
        if(isVisible)
        {
            TryOnShow();
        }
        else
        {
            TryOnHide();
        }
    }

    //-------子类需要复写的周期方法---------
    public virtual void OnCreate()
    {
        Debug.Log("OnCreate");
    }

    public virtual void AddListener()
    {
        Debug.Log("AddListener");
    }

    public virtual void OnShow()
    {
        Debug.Log("OnShow");
    }

    public virtual void OnHide()
    {
        Debug.Log("OnHide");
    }

    public virtual void OnRefresh()
    {
        Debug.Log("OnRefresh");
    }

    public virtual void OnClose()
    {
        Debug.Log("OnColse");
    }

    //------周期方法--------
    private void TryCreate()
    {
        try
        {
            OnCreate();
        }
        catch (System.Exception)
        {       
            throw;
        }
    }

    private void TryAddListener()
    {
        try
        {
            AddListener();
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    private void TryOnShow()
    {
        try
        {
            OnShow();
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    private void TryOnHide()
    {
        try
        {
            OnHide();
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    private void TryRefresh()
    {
        try
        {
            OnRefresh();
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    protected void TryOnClose()
    {
        try
        {
            OnClose();
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    private void InitRefresh()
    {
        //refresh other

        //
        TryRefresh();
    }


    //----获取tranform之后----
    protected virtual void OnPrepare(Transform transform)
    {
        selfTransform = transform;

        AddCSComponentScript();

        if (isLoadType)
        {
            //parent = GetParent();
            //SetParentTransform(GetParent().GetTransform());
        }
        else
        {
            //parentTransform = transform.parent;
            //parent = GetParent();
        }

        //skin
        GenChildPathMap(transform);
        BindUIComponent();
        //组件周期 create lienster 
        TryCreate();
        TryAddListener();

        //区分加载和非加载的UIComponent，做不同处理
        if (isLoadType)
        {
            SetVisible(true);  //on show
        }
        else
        {
            isVisible = root.gameObject.activeSelf;
            RefreshSelfVisible();
        }

        InitRefresh();  //on refresh
    }

    private void AddCSComponentScript()
    {
        uiscript = selfTransform.GetComponent<UIComponentScript>();
        if (!uiscript)
        {
            uiscript = selfTransform.gameObject.AddComponent<UIComponentScript>();
        }
        uiscript.uicomponent = this;
    }

    //-------父子级管理----------

    UIComponent GetParent()
    {
        if (parent == null)
        {
            SetParent(GetDefaultParent());
        }

        return parent;
    }

    void SetParent(UIComponent parent)
    {
        if (parent == null)
        {
            Debug.LogError("SetParent  parent is nil");
        }
        this.parent = parent;

    }

    void SetParentTransform(Transform transform)
    {
        if (!selfTransform) return;

        parentTransform = transform;
        if(transform && selfTransform.parent != transform)
        {
            selfTransform.SetParent(transform, false);
        }
        else if(transform == null)
        {

        }
    }

    UIComponent GetDefaultParent()
    {
        UIComponent com = null;
        if (selfTransform != null)
        {
            Debug.Log(selfTransform.transform.name);
            com = FindParent(selfTransform.parent);
        }
        if(com == null)
        {
            //com = UILayer.GetInstance.UIRoot;
            //遍历完了都没找到父级，父级就是最上层的Root
            Debug.Log("com is nil");
        }
        return com;
    }

    UIComponent FindParent(Transform transform)
    {
        if (!transform)
        {
            Debug.LogError("transform is nil.");
            return null;
        }
        UIComponent uIComponent;
        UIComponentScript com = transform.GetComponent<UIComponentScript>();
        if (com)
        {
            uIComponent = com.uicomponent;
        }
        else
        {
            uIComponent = FindParent(transform.parent);
        }
        return uIComponent;
    }

    public virtual Transform GetTransform()
    {
        return selfTransform;
    }

    //---------组件置灰---------
    public void Gray(bool isGray)
    {
        if(this.isGray == isGray)
        {
            return;
        }
        this.isGray = isGray;

        Graphic[] graphs = GetGraphicComponents();
        Material gray;
        if (isGray)
            gray = UIManager.GetInstance.GetGrayMaterial();
        else
            gray = null;

        for (int i = 0; i < graphs.Length; i++)
        {
            graphs[i].material = gray;
        }

    }

    private Graphic[] GetGraphicComponents()
    {
        Graphic[] images;
        images = GetTransform().GetComponentsInChildren<Graphic>();
        return images;
    }

}
