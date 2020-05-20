using UnityEngine;
using System.Collections;

/// <summary>
/// 负责UI的资源加载
/// </summary>
public class UIComponentBase : UIBase
{
    //public Transform Layer;
    public bool isLoaded = false;
    public bool isLoadType = false; //是否是加载类组件

    public GameObject pfb;
    public string loadPath;

    public UIComponentBase() : base()
    {
    }

    public virtual void LoadResource(string path)
    {
        isLoadType = true;
        AssetLoader.Instance.Load(path, LoadResourceOK);
    }

    public virtual void LoadResourceOK(GameObject asset)
    {
        if (asset)
        {
            isLoaded = true;
            pfb = asset;
        }
    }
}
