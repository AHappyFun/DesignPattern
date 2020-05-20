using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;


public class UIManager :Singleton<UIManager>
{

    public UIManager()
    {
        
    }

    public void Open(UIDialog dialog)
    {
        UIPoolManager.GetInstance.AddTicker(dialog);

        dialog.Open();

    }

    public void Open<T>()
    {
        Type type = typeof(T);
        ConstructorInfo[] ci = type.GetConstructors();

    }

    //传入UI类的字符串
    public void Open(string dialog)
    {
        Type type = TypeUtils.TypeInMemory(dialog);

        ConstructorInfo ct = type.GetConstructor(System.Type.EmptyTypes);

        //拿到类型了，但是怎么知道类型是个啥，又去实例化它呢？？？
        //最多只是知道它是Object类型的

        System.Object dia =  ct.Invoke(null);
               
        Debug.Log("反射拿到类型："+type.Name);
    }

    public void Close(string dialog)
    {
        UIDialog dia = UIPoolManager.GetInstance.GetDialogInPool(dialog);
        if(dia == null)
        {
            Debug.Log("池子里没有这个Dialog: "+ dia);
            return;
        }

        
    }

    private Image im;
    public void SetUIImage(string image, Image trans)
    {
        im = trans;
        //im.sprite = 
        AssetLoader.Instance.LoadSprite(image, LoadImageCallBack);
    }

    private void LoadImageCallBack(Sprite sp)
    {
        if(im == null || sp == null) { Debug.Log("Loaded Sprite is null."); return; }

        im.sprite = sp;
    }

    //------------------

    public void Tick(float delta)
    {
        if(UIPoolManager.GetInstance != null)
        {
            UIPoolManager.GetInstance.Tick(delta);
        }
    }

    public void Init()
    {

    }

    //----------------
    public Material GetGrayMaterial()
    {
        Material mat;
        string path = "Prefabs/Materials/UI_Gray";
        mat =  Resources.Load<Material>(path);
        return mat;
    }
}