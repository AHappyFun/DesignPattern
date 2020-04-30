using UnityEngine;
using System.Collections;
using System;

public class AssetLoader : MonoBehaviour
{

    public static AssetLoader Instance;

    private string loadPath;
    private Action<GameObject> loadCallBack;

    private void Awake()
    {
        Instance = this;
    }

    public void Load(string path, Action<GameObject> func)
    {
        StartCoroutine(LoadAsset(path, func));
    }

    IEnumerator LoadAsset(string path, Action<GameObject> func)
    {
        loadPath = path;
        loadCallBack = func;

        ResourceRequest request = Resources.LoadAsync<GameObject>(path);
        yield return request;

        //加载完回调
        OnAssetLoaded(request);

        //func(request);
    }

    private void OnAssetLoaded(ResourceRequest request)
    {
        GameObject asset = request.asset as GameObject;

        loadCallBack?.Invoke(asset);
    }

}
