using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;




public class AutomateBuildProcess
{
    private static string buildFolderPath = "C:/Users/sev_9/Desktop/Builds/";
    private static string date = System.DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
    private static string prefix = "Innovamat_";

    public static List<string> getEnabledScenesPathNames()
    {
        List<string> enabledScenePathNames = new List<string>();
        foreach (var buildSettingsScene in EditorBuildSettings.scenes)
        {
            if (buildSettingsScene.enabled)
                enabledScenePathNames.Add(buildSettingsScene.path);
        }
        return enabledScenePathNames;
    }

    public static void StartBuild(BuildPlayerOptions _buildPlayerOptions, string extension = "")
    {
        List<string> enabledScenePathNames = getEnabledScenesPathNames();

        string executableDirectoryPath = buildFolderPath + prefix + _buildPlayerOptions.target.ToString() + "_"+ date + "/";
        
        if(!Directory.Exists(executableDirectoryPath))
        {
            Directory.CreateDirectory(executableDirectoryPath);
        }
        
        string executableName = prefix + date;

        Debug.Log("Starting to make "+ _buildPlayerOptions.target.ToString() +" Build");

        _buildPlayerOptions.scenes = enabledScenePathNames.ToArray();
        _buildPlayerOptions.locationPathName = executableDirectoryPath + executableName + extension;

        BuildPipeline.BuildPlayer(_buildPlayerOptions);
    }

    [MenuItem("Innovamat/Make Android build")]
    public static void StartAndroidBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.None;

        StartBuild(buildPlayerOptions, ".apk");
    }

    [MenuItem("Innovamat/Make WebGL build")]
    public static void StartWebGLBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.target = BuildTarget.WebGL;
        buildPlayerOptions.options = BuildOptions.None;

        StartBuild(buildPlayerOptions);
    }
}
