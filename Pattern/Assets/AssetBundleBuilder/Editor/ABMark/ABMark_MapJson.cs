using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// 地图Json的AB标记
/// </summary>
public class ABMark_MapJson 
{
    public static void Mark()
    {
        MarkJsonCfg();
    }

    public static void MarkJsonCfg()
    {
        string path = Application.dataPath + "/Resources/Map";
        string extend = "*.json.meta";
        string[] directories = Directory.GetDirectories(path);

        //然后开始
    }
}
