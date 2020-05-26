using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptUI
{
    public class UIManager : Singleton<UIManager>
    {
        public UIManager()
        {

        }

        public void Init() { }

        public void Tick(float delta) { }

        //传入UI类的字符串
        public void Open(string dialog)
        {
            //先检测对象池里有没有，有就显示池子里的，没有就加载一个

            //load asset
            string path = UITestDialog;
            AssetLoader.Instance.Load(path, LoadUIAssetOK);
        }
        private void LoadUIAssetOK(GameObject asset)
        {
            if (!asset)
                return;

            Transform layer = UILayer.GetInstance.UIPanelLayer;
            GameObject ui = GameObject.Instantiate(asset, layer);
        }
        //-------------------------------
        private Image im;
        public void SetUIImage(string image, Image trans)
        {
            im = trans;
            AssetLoader.Instance.LoadSprite(image, LoadImageCallBack);
        }

        private void LoadImageCallBack(Sprite sp)
        {
            if (im == null || sp == null) { Debug.Log("Loaded Sprite is null."); return; }

            im.sprite = sp;
        }

        public Material GetGrayMaterial()
        {
            Material mat;
            string path = "Prefabs/Materials/UI_Gray";
            mat = Resources.Load<Material>(path);
            return mat;
        }

        //-------------------------------
        public static string UITestDialog = "Prefabs/UI/TestPanel";

    }

   
}
