using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

/// <summary>
/// 标记AB资源 
/// 按照Scene进行分类
/// </summary>
public class AssetBundleMarkTool 
{
    [MenuItem("AssetBundle/1.标记AB")]
    public static void SetABMark()
    {
        string needSetMarkRootDir = string.Empty;

        DirectoryInfo[] dirSceneDirArray;

        //清空无用AB标记
        AssetDatabase.RemoveUnusedAssetBundleNames();

        needSetMarkRootDir = Application.dataPath + "/" + "Resources";
        DirectoryInfo tempDirInfo = new DirectoryInfo(needSetMarkRootDir);
        dirSceneDirArray = tempDirInfo.GetDirectories();

        //2.遍历每个Scene文件夹
        foreach (DirectoryInfo dirInfo in dirSceneDirArray)
        {
            //遍历目录下的所有目录和文件
            string tmpSceneDir = needSetMarkRootDir + "/" + dirInfo.Name;
            DirectoryInfo tmpSceneDirInfo = new DirectoryInfo(tmpSceneDir);

            int tmpIndex = tmpSceneDir.LastIndexOf("/");
            string tmpSceneName = tmpSceneDir.Substring(tmpIndex + 1);

            //递归，找到文件就标记
            MarkFileOrDir(dirInfo, tmpSceneName);

        }


        //刷新
        AssetDatabase.Refresh();

        Debug.Log("AB 标记完成");
    }

    static void MarkFileOrDir(FileSystemInfo fileSysInfo, string sceneName)
    {
        if (!fileSysInfo.Exists)
        {
            Debug.LogError("File or Dir don't exist!");
            return;
        }
        //Debug.Log(fileSysInfo.Name);
        //得到当前目录下一级的文件信息
        DirectoryInfo dirInfo = fileSysInfo as DirectoryInfo;
        FileSystemInfo[] fileSysArray = dirInfo.GetFileSystemInfos();
        foreach (FileSystemInfo fileInfo in fileSysArray)
        {
            FileInfo fileInfoObj = fileInfo as FileInfo;
            //is file
            if (fileInfoObj != null)
            {
                MarkFile(fileInfoObj, sceneName);
            }
            //is dir
            else
            {
                MarkFileOrDir(fileInfo, sceneName);
            }
        }
    }

    static void MarkFile(FileInfo fileInfo, string sceneName)
    {
        //meta不处理
        if (fileInfo.Extension == ".meta") return;

        Debug.Log("fileinfo" + fileInfo.FullName);

        string filePath = string.Empty;
        string abName = string .Empty;

        int index = fileInfo.FullName.IndexOf("Assets");
        filePath = fileInfo.FullName.Substring(index);

        abName = GetABName(fileInfo, sceneName);

        AssetImporter importer = AssetImporter.GetAtPath(filePath);
        importer.assetBundleName = abName;

        //场景文件
        if(fileInfo.Extension == ".unity")
        {
            importer.assetBundleVariant = "u3d";
        }
        else
        {
            importer.assetBundleVariant = "ab";
        }
    }

    //组合AB包名
    static string GetABName(FileInfo file, string sceneName)
    {
        string abName;

        //windows 路径为反斜杠
        string windowsPath = file.FullName;
        //unity 路径为参数杠
        string unityPath = windowsPath.Replace("\\", "/");

        int tmpSceneNameIndex = unityPath.IndexOf(sceneName) + sceneName.Length;

        string abFIleNameArea = unityPath.Substring(tmpSceneNameIndex + 1);

        if (abFIleNameArea.Contains("/"))
        {
            string[] tmpStrs = abFIleNameArea.Split('/');
            abName = sceneName + "/" + tmpStrs[0];
        }
        else
        {
            abName = sceneName + "/" + sceneName;
        }

        return abName;
    }
  
}
