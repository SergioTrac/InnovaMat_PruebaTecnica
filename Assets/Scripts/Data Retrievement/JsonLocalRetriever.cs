using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonLocalRetriever : IUserDataRetriever
{
    private TextAsset jsonFile;
    
    public JsonLocalRetriever(TextAsset _jsonFile)
    {
        jsonFile = _jsonFile;
    }


    public UserData retrieveData()
    {
        return JsonUtility.FromJson<UserData>(jsonFile.text);
    }
}
