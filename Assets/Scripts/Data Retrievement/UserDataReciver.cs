using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataReciver : MonoBehaviour
{
    public SessionInfo sessionInfo;
    public TextAsset jsonFile;

    IUserDataRetriever userDataRetriever;

    private void Start()
    {
        userDataRetriever = new UserDataRetrieverProxy(new JsonLocalRetriever(jsonFile));
        UserData _user = userDataRetriever.retrieveData();
        sessionInfo.UserData = _user;

        Debug.Log(sessionInfo.UserData.first_name);
    }
}
