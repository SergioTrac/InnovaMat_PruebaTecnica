using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A class to retrieve Json data from local Json file.
/// </summary>
public class JsonLocalRetriever : IUserDataRetriever
{
    private TextAsset jsonFile;
    
    public JsonLocalRetriever(TextAsset _jsonFile)
    {
        jsonFile = _jsonFile;
    }

    public void retrieveData(UnityEvent<UserData> _OnDataLoaded)
    {
        UserData userData = JsonUtility.FromJson<UserData>(jsonFile.text);

        if (userData != null)
            _OnDataLoaded?.Invoke(userData);
        else
            Debug.LogError("JsonLocalRetriever: Incorrect data structure or not defined Json file.");
    }
}
