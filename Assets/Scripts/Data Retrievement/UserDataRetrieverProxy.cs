using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Proxy class that manage de rules for the use of retrievers
/// </summary>
public class UserDataRetrieverProxy : IUserDataRetriever
{
    IUserDataRetriever localRetriever;
    IUserDataRetriever remoteRetriever;

    public UserDataRetrieverProxy(IUserDataRetriever _localRetriever, IUserDataRetriever _remoteRetriever)
    {
        localRetriever = _localRetriever;
        remoteRetriever = _remoteRetriever;
    }

    /// <summary>
    /// Choose the retriever that process the data.
    /// Returns in the callback the requested data.
    /// </summary>
    /// <param name="_OnDataLoaded">callback event</param>
    public void retrieveData(UnityEvent<UserData> _OnDataLoaded)
    {
        
        if(Application.platform == RuntimePlatform.Android)
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
