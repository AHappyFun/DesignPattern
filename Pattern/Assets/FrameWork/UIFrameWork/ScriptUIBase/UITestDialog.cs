using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptUI
{
    public class UITestDialog: UIDialog
    {
        //------UI  Component--------
        public Text hpTxt;
        public Button button;
        public Image image;    

        public override void BindUIComponent()
        {
            base.BindUIComponent();
            Layer = UILayer.GetInstance.UITipsLayer;

            hpTxt = GetComponentByPath("hp", typeof(Text)) as Text;
            button = GetComponentByPath("btn", typeof(Button)) as Button;
            image = GetComponentByPath("Image", typeof(Image)) as Image;
        }

        public override void Tick(float delta)
        {
            base.Tick(delta);

            hpTxt.text = delta.ToString();
        }

        //--------周期-----------
        public override void OnShow()
        {
            base.OnShow();
            Gray(true);
            ScriptUI.UIManager.GetInstance.SetUIImage("UISprite/sprite_001", image);
        }

        public override void OnHide()
        {
            base.OnHide();
        }

        public override void AddListener()
        {
            base.AddListener();
            button.onClick.AddListener(ButtonClick);
        }

        public override void OnClose()
        {
            base.OnClose();
        }

        //------Cllback------
        private static void ButtonClick()
        {
            Debug.Log("OK!!!!");
        }
    }
}
