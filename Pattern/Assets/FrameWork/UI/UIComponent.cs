using UnityEngine;
using System.Collections;

/// <summary>
/// UI控件基类
/// </summary>
public class UIComponent : UIComponentBase
{
    public Transform Layer;

    public UIComponent(Transform trans = null):base()
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

    public virtual void Hide()
    {
        root.gameObject.SetActive(false);
    }

    public virtual void Show()
    {
        //parse args 

        //设置可见
        root.gameObject.SetActive(true);

        //手动刷新(有些面板不需要tick刷新)
    } 

    public virtual void Tick(float delta)
    {
        if (!isLoaded)
            return;
    }

    public override void LoadResourceOK(GameObject asset)
    {
        base.LoadResourceOK(asset);
        if (pfb == null)
        {
            Debug.LogError("UIComponent Load prefab is null");
            return;
        }
        pfb = Instantiate(pfb, Layer);

        OnPrepare(pfb.transform);
        isLoaded = true;

        //有load回调就执行回调
    }

    //--------------

    //获取tranform之后
    protected virtual void OnPrepare(Transform transform)
    {
        //skin
        GenChildPathMap(transform);
        BindUIComponent();

        //组件周期
        Show();
        //create show refresh ...
    }
}
