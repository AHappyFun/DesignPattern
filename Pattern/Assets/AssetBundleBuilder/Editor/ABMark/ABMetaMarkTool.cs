using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ABMetaMarkTool 
{
    [MenuItem("AB/标记AB(按类型)")]
    public static void MarkAB()
    {
        Debug.Log("Mark AB Start!...");
        //1.
        ABMark_MapJson.Mark();
    }
}
