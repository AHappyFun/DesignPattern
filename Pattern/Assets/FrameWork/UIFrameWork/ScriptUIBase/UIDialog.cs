﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptUI
{
    public class UIDialog: UIComponent
    {
        private UIDialog instance;
        private string d_Name;
        public string Name
        {
            get { return d_Name; }
            set { d_Name = value; }
        }

        protected override void OnPrepare()
        {
            Name = this.GetType().Name;
            instance = this;

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

            base.OnPrepare();
        }

        protected override void MoveLayer()
        {
            base.MoveLayer();
            transform.parent = Layer;
        }

        protected Button close_Btn;
        public override void BindUIComponent()
        {
            close_Btn = GetComponentByPath("Comm/btnClose", typeof(Button)) as Button;
        }

        //--------预绑定---------
        public override void AddListener()
        {
            base.AddListener();
            close_Btn.onClick.AddListener(Close_Click);
        }

        protected virtual void Close_Click()
        {
            Debug.Log("Close_Click" + Name);
        }
    }
}
