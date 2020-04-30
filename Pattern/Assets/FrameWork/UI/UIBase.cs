using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// UI控件的transform容器
/// </summary>
public class UIBase : UnityEngine.Object
{
    public Transform root;
    public Dictionary<string, Transform> childNameMap;

    public UIBase()
    {
        childNameMap = new Dictionary<string, Transform>();
    }

    public void OnDestroy()
    {
        root = null;
        childNameMap = null;
    }

    public void GenChildPathMap(Transform root)
    {
        if (!root) { 
            Debug.LogError("UIBase --- Root is null");
            return;
        }
        this.root = root;
    }

    public Transform GetChildByPath(string path)
    {
        Transform child = GetTransformByPath(path);
        return child;
    }

    public Transform GetTransformByPath(string path)
    {
        if(!root || path == "")
        {
            return null;
        }
        if (childNameMap.ContainsKey(path))
        {
            return childNameMap[path];
        }
        if(path == root.name)
        {
            return root;
        }
        Transform child = root.Find(path);
        if (child)
        {
            childNameMap[path] = child;
        }

        return child;
    }

    public Component GetComponentByPath(string path, Type type )
    {
        Transform child = GetChildByPath(path);
        Component com = null;
        if (child)
        {
            com = child.GetComponent(type);
        }
        return com;
    }

    public GameObject GetGameObjectByPath(string path)
    {
        Transform child = GetChildByPath(path);
        GameObject go = null;
        if (child)
        {
            go = child.gameObject;
        }
        return go;
    }
}
