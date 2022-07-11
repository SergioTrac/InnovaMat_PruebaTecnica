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

    /// <summary>
    /// Make a build for Android platform.
    /// </summary>
    [MenuItem("Innovamat/Make Android build")]
    public static void StartAndroidBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.target = BuildTarget.Android;

        StartBuild(buildPlayerOptions, ".apk");
    }

    /// <summary>
    /// Make a build for WebGL platform.
    /// </summary>
    [MenuItem("Innovamat/Make WebGL build")]
    public static void StartWebGLBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.target = BuildTarget.WebGL;

        StartBuild(buildPlayerOptions);
    }

    /// <summary>
    /// General behavior for building process. Target should be defined.
    /// </summary>
    /// <param name="_buildPlayerOptions">Base BuildPlayerOption with target defined</param>
    /// <param name="fileExtension">(Optional) Extension of the file to generate</param>
    private static void StartBuild(BuildPlayerOptions _buildPlayerOptions, string fileExtension = "")
    {
        // Get list of scenes that are enabled in build settings
        List<string> enabledScenePathNames = getEnabledScenesPathNames();

        if(_buildPlayerOptions.target == 0)
        {
            Debug.LogError("BUILD FAILED: target has not been defined");
            return;
        }

        // Location path where we want to send the build to
        string executableDirectoryPath = buildFolderPath + prefix + _buildPlayerOptions.target.ToString() + "_"+ date + "/";
        
        // Create a directory to put the build and the data file
        if(!Directory.Exists(executableDirectoryPath))
        {
            Directory.CreateDirectory(executableDirectoryPath);
        }
        

        Debug.Log("Starting to make "+ _buildPlayerOptions.target.ToString() +" Build");

        _buildPlayerOptions.scenes = enabledScenePathNames.ToArray();

        // Name for the executable file.
        string executableName = prefix + date;
        _buildPlayerOptions.locationPathName = executableDirectoryPath + executableName + fileExtension;

        BuildPipeline.BuildPlayer(_buildPlayerOptions);
    }
    

    #region Auxiliar


    /// <summary>
    /// Get all enabled scene path names in Build Settings.
    /// </summary>
    /// <returns>enabled scene path names</returns>
    private static List<string> getEnabledScenesPathNames()
    {
        List<string> enabledScenePathNames = new List<string>();
        foreach (var buildSettingsScene in EditorBuildSettings.scenes)
        {
            if (buildSettingsScene.enabled)
                enabledScenePathNames.Add(buildSettingsScene.path);
        }
        return enabledScenePathNames;
    }


    #endregion
}
