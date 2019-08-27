using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ShareFlyWeight : IFlyWeight
{
    private string internalState;
    private Color externalState;

    public ShareFlyWeight(string interstate)
    {
        internalState = interstate;
    }
    
    public void SetExternalState(Color exterstate)
    {
        externalState = exterstate;
    }

    public void ShowState()
    {
        Debug.Log("internal: " + internalState + getMemory(internalState));
        Debug.Log("external: " + externalState);
    }

    public static string getMemory(object o) // 获取引用类型的内存地址方法
    {
        GCHandle h = GCHandle.Alloc(o, GCHandleType.Pinned);
        IntPtr addr = h.AddrOfPinnedObject();
        return "0x" + addr.ToString("X");
    }

}
