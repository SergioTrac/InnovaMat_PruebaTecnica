using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Receive and store user data.
/// </summary>
public class UserDataReciver : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private SessionInfo sessionInfo;

    [Header("Resources")]
    [SerializeField] private TextAsset jsonFile;
    [SerializeField] private string googleDriveFileID;

    // CONSTANTS
    private readonly string GOOGLE_DRIVE_DOWNLOAD_PREFIX = "https://drive.google.com/uc?export=download&id=";


    private string URLPathToFile;
    UnityEvent<UserData> OnDataLoaded;
    UserDataRetrieverProxy userDataRetriever;

    private void Awake()
    {
        //Creation of final download URL.
        URLPathToFile = GOOGLE_DRIVE_DOWNLOAD_PREFIX + googleDriveFileID;

        // Creation of data retriever user Proxy pattern.
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
        // Request the data.
        userDataRetriever.retrieveData(OnDataLoaded);
    }

    private void SetSessionData(UserData _userData)
    {
        sessionInfo.SetUserData(_userData);
    }
}
