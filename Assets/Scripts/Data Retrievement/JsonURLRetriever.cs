using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

/// <summary>
/// A class to retrieve Json data from a remote Json file.
/// </summary>
public class JsonURLRetriever : IUserDataRetriever
{
    private string URLPathToFile;

    public JsonURLRetriever(string _url)
    {
        URLPathToFile = _url;
    }

    public void retrieveData(UnityEvent<UserData> _OnDataLoaded)
    {
        getRemoteUserData(_OnDataLoaded);
    }

    /// <summary>
    /// Asincronous method to get a remote Json User Data file.
    /// </summary>
    /// <param name="_OnDataLoaded">CallBack event</param>
    private async void getRemoteUserData(UnityEvent<UserData> _OnDataLoaded)
    {
        var webRequest = UnityWebRequest.Get(URLPathToFile);
        webRequest.SetRequestHeader("Content-Type", "application/json");

        var operation = webRequest.SendWebRequest();
        while (!operation.isDone)
            await Task.Yield();

        // Taking the final Json.
        string jsonResponse = webRequest.downloadHandler.text;

        if(webRequest.result == UnityWebRequest.Result.Success)
        {
            // Converting Json in User Data.
            UserData userData = JsonConvert.DeserializeObject<UserData>(jsonResponse);
            _OnDataLoaded?.Invoke(userData);
        }
    }

}
