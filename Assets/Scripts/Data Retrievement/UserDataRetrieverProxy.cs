using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UserDataRetrieverProxy : IUserDataRetriever
{
    IUserDataRetriever localRetriever;
    IUserDataRetriever remoteRetriever;

    public UserDataRetrieverProxy(IUserDataRetriever _localRetriever, IUserDataRetriever _remoteRetriever)
    {
        localRetriever = _localRetriever;
        remoteRetriever = _remoteRetriever;
    }

    public void retrieveData(UnityEvent<UserData> _OnDataLoaded)
    {
        
        if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            remoteRetriever.retrieveData(_OnDataLoaded);
        }else if(Application.platform == RuntimePlatform.WebGLPlayer)
        {
            localRetriever.retrieveData(_OnDataLoaded);
        }
        else
            Debug.LogWarning("UserDataRetriever: Undefined behaviour for the current platform");
    }
}
