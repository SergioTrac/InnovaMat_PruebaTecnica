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

    private bool dataLoaded = false;
    private bool loadingData = false;
    private string jsonFile;

    public JsonURLRetriever(string _url)
    {
        URLPathToFile = _url;
        getRemoteData();
    }

    public UserData retrieveData()
    {
        if (dataLoaded)
        {
            return JsonConvert.DeserializeObject<UserData>(jsonFile);
        }
        else if (!loadingData)
        {
            getRemoteData();
        }

        return null;
    }

    public async void getRemoteData()
    {
        loadingData = true;

        var webRequest = UnityWebRequest.Get(URLPathToFile);
        webRequest.SetRequestHeader("Content-Type", "application/json");

        var operation = webRequest.SendWebRequest();
        while (!operation.isDone)
            await Task.Yield();

        string jsonResponse = webRequest.downloadHandler.text;

        if(webRequest.result == UnityWebRequest.Result.Success)
        {
            jsonFile = jsonResponse;
            dataLoaded = true;
        }

        loadingData = false;
    }

}
