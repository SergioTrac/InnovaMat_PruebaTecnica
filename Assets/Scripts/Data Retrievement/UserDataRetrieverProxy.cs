using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataRetrieverProxy : IUserDataRetriever
{
    IUserDataRetriever localRetriever;
    IUserDataRetriever remoteRetriever;

    public UserDataRetrieverProxy(IUserDataRetriever _localRetriever, IUserDataRetriever _remoteRetriever)
    {
        localRetriever = _localRetriever;
        remoteRetriever = _remoteRetriever;
    }

    public UserData retrieveData()
    {
        
        if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            return remoteRetriever.retrieveData();
        }else if(Application.platform == RuntimePlatform.WebGLPlayer)
            return localRetriever.retrieveData();

        Debug.LogWarning("UserDataRetriever: Undefined behaviour for the current platform");

        return null;
    }
}
