using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

/// <summary>
/// AB打包工具
/// </summary>
public class AssetBundleBuildTool 
{
    //AB输出路径
    public static string WindowsOutPath = Application.streamingAssetsPath + "/Windows";

    public static string AndroidOutPath = Application.streamingAssetsPath + "/Android";


    [MenuItem("AssetBundle/2.打AB/Windows", false, 2)]
    public static void BuildAssetBundle_Win()
    {
        if (!Directory.Exists(WindowsOutPath))
        {
            Directory.CreateDirectory(WindowsOutPath);
        }
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone,BuildTarget.StandaloneWindows);

        BuildPipeline.BuildAssetBundles(WindowsOutPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

        //打完之后
        AssetDatabase.Refresh();

        Debug.Log("Build AB Windows64 Finish! ");

    }

    [MenuItem("AssetBundle/2.打AB/Android")]
    public static void BuildAssetBundle_Android()
    {

    }


}
