using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataReciver : MonoBehaviour
{
    public SessionInfo sessionInfo;

    public TextAsset jsonFile;
    public string googleDriveFileID;

    private readonly string GOOGLE_DRIVE_DOWNLOAD_PREFIX = "https://drive.google.com/uc?export=download&id=";
    private string URLPathToFile;

    IUserDataRetriever userDataRetriever;

    private void Awake()
    {
        URLPathToFile = GOOGLE_DRIVE_DOWNLOAD_PREFIX + googleDriveFileID;

        userDataRetriever = new UserDataRetrieverProxy(
                                    new JsonLocalRetriever(jsonFile),
                                    new JsonURLRetriever(URLPathToFile)
                                    );

    }

    private void Start()
    {
        Getdata();
    }

    public void Getdata()
    {
        UserData _user = userDataRetriever.retrieveData();
        sessionInfo.UserData = _user;

        Debug.Log(sessionInfo.UserData.first_name);
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Generate Nodes"))
        {
            Getdata();
        }
    }
}
