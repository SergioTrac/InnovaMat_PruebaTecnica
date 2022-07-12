using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UserDataReciver : MonoBehaviour
{
    public SessionInfo sessionInfo;

    public TextAsset jsonFile;
    public string googleDriveFileID;

    private readonly string GOOGLE_DRIVE_DOWNLOAD_PREFIX = "https://drive.google.com/uc?export=download&id=";
    private string URLPathToFile;

    UnityEvent<UserData> OnDataLoaded;

    UserDataRetrieverProxy userDataRetriever;

    private void Awake()
    {
        URLPathToFile = GOOGLE_DRIVE_DOWNLOAD_PREFIX + googleDriveFileID;

        userDataRetriever = new UserDataRetrieverProxy(
                                    new JsonLocalRetriever(jsonFile),
                                    new JsonURLRetriever(URLPathToFile)
                                    );

        if (OnDataLoaded == null)
            OnDataLoaded = new UnityEvent<UserData>();
    }

    private void OnEnable()
    {
        OnDataLoaded.AddListener(SetSessionData);
    }

    private void OnDisable()
    {
        OnDataLoaded.RemoveListener(SetSessionData);
    }

    private void Start()
    {
        userDataRetriever.retrieveData(OnDataLoaded);
    }

    private void SetSessionData(UserData _userData)
    {
        sessionInfo.SetUserData(_userData);
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Generate Nodes"))
        {
            Debug.Log(sessionInfo.GetUserData().first_name);
        }
    }
}
