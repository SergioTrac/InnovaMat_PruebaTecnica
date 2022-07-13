using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Interface used for retrieving User Data.
/// Part of the Proxy pattern implementation.
/// </summary>
public interface IUserDataRetriever
{
    void retrieveData(UnityEvent<UserData> _OnDataLoaded);
}
