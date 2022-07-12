using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class JsonURLRetriever : IUserDataRetriever
{
    private string URLPathToFile;

    public JsonURLRetriever(string _url)
    {
        URLPathToFile = _url;
    }

    public void retrieveData(UnityEvent<UserData> _OnDataLoaded)
    {
        getRemoteData(_OnDataLoaded);
    }

    private async void getRemoteData(UnityEvent<UserData> _OnDataLoaded)
    {
        var webRequest = UnityWebRequest.Get(URLPathToFile);
        webRequest.SetRequestHeader("Content-Type", "application/json");

        var operation = webRequest.SendWebRequest();
        while (!operation.isDone)
            await Task.Yield();

        string jsonResponse = webRequest.downloadHandler.text;

        if(webRequest.result == UnityWebRequest.Result.Success)
        {
            UserData userData = JsonConvert.DeserializeObject<UserData>(jsonResponse);
            _OnDataLoaded?.Invoke(userData);
        }
    }

}
