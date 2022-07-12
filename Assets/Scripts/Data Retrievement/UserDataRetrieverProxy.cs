using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataRetrieverProxy : IUserDataRetriever
{
    IUserDataRetriever localRetriever;

    public UserDataRetrieverProxy(IUserDataRetriever _localRetriever)
    {
        localRetriever = _localRetriever;
    }

    public UserData retrieveData()
    {
        // SI ESTAMOS EN ANDROID
        return localRetriever.retrieveData();

        // SI ESTAMOS EN WEBGL

    }
}
