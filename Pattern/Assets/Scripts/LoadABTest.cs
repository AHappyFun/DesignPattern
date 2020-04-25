using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
/// <summary>
/// 加载AB资源测试
/// </summary>
public class LoadABTest : MonoBehaviour
{
    private string _URL;
    private string _AssetName;

    private void Awake()
    {
        //_URL = "file://" + Application.streamingAssetsPath + "/Windows" + "/platformtitle.u3d";
        //_AssetName = "Android@2x";

        _URL = "file://" + Application.streamingAssetsPath + "/Windows" + "/prefab.u3d";
        _AssetName = "Cube001";
    }

    private void Start()
    {
        //GameObject go = GameObject.Find("Cube");
        //StartCoroutine(LoadNonObjectFromAB(_URL, go, _AssetName));

        StartCoroutine(LoadPrefabFromAB(_URL, _AssetName, Vector3.zero));
    }


    IEnumerator LoadNonObjectFromAB(string abURL, GameObject go, string assetName)
    {
        if (string.IsNullOrEmpty(abURL) || go == null)
        {
            Debug.LogError(GetType() + "LoadNonObjectFromAB--加载AB信息错误");
        }

        using (WWW www = new WWW(abURL))
        {
            yield return www;
            AssetBundle ab = www.assetBundle;
            if(ab != null)
            {
                if(assetName == "")
                {
                    go.GetComponent<Renderer>().material.mainTexture = ab.mainAsset as Texture;
                }
                else
                {
                    go.GetComponent<Renderer>().material.mainTexture = ab.LoadAsset(assetName) as Texture;
                }
                //卸载AB
                ab.Unload(false);
            }
            else
            {
                Debug.LogError(GetType() + "AB下载错误");
            }
        }
    }

    IEnumerator LoadPrefabFromAB(string abURL, string assetName, Vector3 pos)
    {
        if (string.IsNullOrEmpty(abURL))
        {
            Debug.LogError(GetType() + "LoadPrefabFromAB()--加载AB信息错误");
        }

        using (WWW www = new WWW(abURL))
        {
            yield return www;
            AssetBundle ab = www.assetBundle;
            if (ab != null)
            {
                if (assetName == "")
                {
                    if(pos != null)
                    {
                        Instantiate(ab.mainAsset as GameObject, pos, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(ab.mainAsset as GameObject);
                    }
                }
                else
                {
                    if (pos != null)
                    {
                        Instantiate(ab.LoadAsset(assetName) as GameObject, pos, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(ab.LoadAsset(assetName) as GameObject);
                    }
                }
                //卸载AB
                ab.Unload(false);
            }
            else
            {
                Debug.LogError(GetType() + "AB下载错误");
            }
        }
    }

    //加载到内存镜像
    IEnumerator LoadFromAB(string abURL)
    {
        if (string.IsNullOrEmpty(abURL))
        {
            Debug.LogError(GetType() + "LoadPrefabFromAB()--加载AB信息错误");
        }

        using (WWW www = new WWW(abURL))
        {
            yield return www;
            AssetBundle ab = www.assetBundle;
            if (ab == null)
            {
                Debug.LogError(GetType() + "AB下载错误");
            }
        }
    }
}
