using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SessionInfo", menuName = "Data/SessionInfo", order = 1)]
public class SessionInfo : ScriptableObject
{
    private UserData userData;

    public UserData GetUserData()
    {
        return userData;
    }

    public void SetUserData(UserData _userData)
    {
        userData = _userData;
        OnInfoChanged?.Invoke();
    }

    public UnityEvent OnInfoChanged;
}
