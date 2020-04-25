using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class AssetBundleBuildTool 
{
    //AB输出路径
    public static string WindowsOutPath = Application.streamingAssetsPath + "/Windows";


    [MenuItem("Tools/打AB/Windows")]
    public static void BuildAssetBundle()
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


}
